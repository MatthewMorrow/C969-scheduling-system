using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace SchedulingSystem.Data
{
    public class DatabaseAccess(string connectionString)
    {
        private MySqlConnection _transactionConnection;

        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            using var conn = CreateConnection();
            using var cmd = CreateCommand(query, conn, parameters);
            try
            {
                using var adapter = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
                throw new DatabaseException("Error executing query.", ex);
            }
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            if (_transactionConnection != null)
            {
                using var cmd = CreateCommand(query, _transactionConnection, parameters);
                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    throw new DatabaseException("Error executing non-query in transaction.", ex);
                }
            }
            using var conn = CreateConnection();
            using var c2 = CreateCommand(query, conn, parameters);
            conn.Open();
            try
            {
                return c2.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new DatabaseException("Error executing non-query.", ex);
            }
        }

        public object ExecuteScalar(string query, Dictionary<string, object> parameters = null)
        {
            using var conn = CreateConnection();
            using var cmd = CreateCommand(query, conn, parameters);
            conn.Open();
            try
            {
                return cmd.ExecuteScalar();
            }
            catch (MySqlException ex)
            {
                throw new DatabaseException("Error executing scalar.", ex);
            }
        }

        public void BeginTransaction()
        {
            if (_transactionConnection != null)
                throw new InvalidOperationException("Transaction already in progress.");
            _transactionConnection = CreateConnection();
            _transactionConnection.Open();
            using var cmd = _transactionConnection.CreateCommand();
            cmd.CommandText = "START TRANSACTION";
            cmd.ExecuteNonQuery();
        }

        public void CommitTransaction()
        {
            if (_transactionConnection == null)
                throw new InvalidOperationException("No transaction in progress.");
            try
            {
                using var cmd = _transactionConnection.CreateCommand();
                cmd.CommandText = "COMMIT";
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new DatabaseException("Error committing transaction.", ex);
            }
            finally
            {
                _transactionConnection.Dispose();
                _transactionConnection = null;
            }
        }

        public void RollbackTransaction()
        {
            if (_transactionConnection == null)
                throw new InvalidOperationException("No transaction in progress.");
            try
            {
                using var cmd = _transactionConnection.CreateCommand();
                cmd.CommandText = "ROLLBACK";
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new DatabaseException("Error rolling back transaction.", ex);
            }
            finally
            {
                _transactionConnection.Dispose();
                _transactionConnection = null;
            }
        }

        private MySqlConnection CreateConnection()
        {
            return new MySqlConnection(connectionString);
        }

        private static MySqlCommand CreateCommand(string query, MySqlConnection connection, Dictionary<string, object> parameters = null)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = query;
            if (parameters == null) return cmd;
            foreach (var kv in parameters)
            {
                var p = cmd.CreateParameter();
                p.ParameterName = kv.Key;
                p.Value = kv.Value ?? DBNull.Value;
                cmd.Parameters.Add(p);
            }
            return cmd;
        }
    }

    public class DatabaseException(string message, Exception innerException) : Exception(message, innerException);
}
