using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using SchedulingSystem.Data;

namespace SchedulingSystem.Forms
{
    public partial class LoginForm : Form
    {
        private readonly DatabaseAccess _db;
        private readonly Dictionary<string, string> _localText;

        public LoginForm(DatabaseAccess db)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            try { EnsureTestUserExists(); }
            catch (Exception ex)
            {
                MessageBox.Show("Error ensuring test user: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            _localText = LoginLocalization.LoadLocalizedText();
            LocalizeUi();
            labelTimezone.Text = _localText["TimezoneLabel"] + TimeZoneInfo.Local.DisplayName;
        }

        private void EnsureTestUserExists()
        {
            const string sql = @"
                INSERT INTO user (userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy)
                SELECT @u, @p, 1, UTC_TIMESTAMP(), @u, UTC_TIMESTAMP(), @u
                FROM DUAL
                WHERE NOT EXISTS (SELECT 1 FROM user WHERE userName=@u);
            ";
            var param = new Dictionary<string, object> { ["@u"] = "test", ["@p"] = "test" };
            _db.ExecuteNonQuery(sql, param);
        }

        private void LocalizeUi()
        {
            Text = _localText["LoginFormTitle"];
            labelTitle.Text = _localText["LoginFormTitle"];
            labelUsername.Text = _localText["UsernameLabel"];
            labelPassword.Text = _localText["PasswordLabel"];
            buttonLogin.Text = _localText["LoginButton"];
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var username = textUsername.Text.Trim();
            var password = textPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show(_localText["UsernameRequired"],
                                _localText["LoginFailed"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(_localText["PasswordRequired"],
                                _localText["LoginFailed"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            bool valid;
            try
            {
                valid = CheckCredentials(username, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking credentials: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            if (!valid)
            {
                MessageBox.Show(_localText["InvalidCredentials"],
                                _localText["LoginFailed"],
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            try { LogLogin(username); }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to log: " + ex.Message,
                                "File I/O Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            MessageBox.Show(_localText["LoginSuccessful"],
                            _localText["LoginSuccessful"],
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            try { CheckUpcomingAppointments(username); }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking appointments: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            int userId;
            try
            {
                userId = GetUserId(username);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user ID: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            Hide();
            using (var mainForm = new MainForm(_db, userId, username))
            {
                mainForm.ShowDialog();
            }
            Close();
        }

        private bool CheckCredentials(string user, string pass)
        {
            const string q = @"
                SELECT COUNT(*) FROM user
                WHERE userName=@u AND password=@p AND active=1;
            ";
            var p = new Dictionary<string, object> { ["@u"] = user, ["@p"] = pass };
            var count = Convert.ToInt32(_db.ExecuteScalar(q, p));
            return count > 0;
        }

        private int GetUserId(string user)
        {
            const string q = "SELECT userId FROM user WHERE userName=@name;";
            var p = new Dictionary<string, object> { ["@name"] = user };
            var obj = _db.ExecuteScalar(q, p);
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        private void LogLogin(string user)
        {
            var logLine = DateTime.UtcNow.ToString("o") + " - User '" + user + "' logged in";
            File.AppendAllText("Login_History.txt", logLine + Environment.NewLine);
        }

        private void CheckUpcomingAppointments(string user)
        {
            var userId = GetUserId(user);
            if (userId <= 0) return;
            var nowUtc = DateTime.UtcNow;
            var soon = nowUtc.AddMinutes(15);
            const string q = @"
                SELECT a.start, c.customerName
                FROM appointment a
                JOIN customer c ON a.customerId=c.customerId
                WHERE a.userId=@u AND a.start>=@start AND a.start<=@end
                ORDER BY a.start
                LIMIT 1;
            ";
            var p = new Dictionary<string, object>
            {
                ["@u"] = userId,
                ["@start"] = nowUtc,
                ["@end"] = soon
            };
            var dt = _db.ExecuteQuery(q, p);
            if (dt.Rows.Count <= 0) return;
            var startUtc = (DateTime)dt.Rows[0]["start"];
            var localTime = startUtc.ToLocalTime();
            var cust = dt.Rows[0]["customerName"].ToString();
            MessageBox.Show(
                "You have an upcoming appointment with '" + cust + "' at " + localTime.ToString("t") + " local time.",
                "Upcoming Appointment",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }

    public static class LoginLocalization
    {
        public static Dictionary<string, string> LoadLocalizedText()
        {
            var culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            if (culture.Equals("de", StringComparison.OrdinalIgnoreCase))
            {
                return new Dictionary<string, string>
                {
                    ["LoginSuccessful"] = "Anmeldung erfolgreich!",
                    ["LoginFailed"] = "Anmeldung fehlgeschlagen.",
                    ["InvalidCredentials"] = "Ungültiger Benutzername oder Passwort.",
                    ["UsernameRequired"] = "Der Benutzername ist erforderlich.",
                    ["PasswordRequired"] = "Das Passwort ist erforderlich.",
                    ["LoginButton"] = "Anmelden",
                    ["UsernameLabel"] = "Benutzername",
                    ["PasswordLabel"] = "Passwort",
                    ["TimezoneLabel"] = "Aktuelle Zeitzone: ",
                    ["LoginFormTitle"] = "Zeitplanungssystem"
                };
            }
            return new Dictionary<string, string>
            {
                ["LoginSuccessful"] = "Login successful!",
                ["LoginFailed"] = "Login failed.",
                ["InvalidCredentials"] = "Invalid username or password.",
                ["UsernameRequired"] = "Username is required.",
                ["PasswordRequired"] = "Password is required.",
                ["LoginButton"] = "Login",
                ["UsernameLabel"] = "Username",
                ["PasswordLabel"] = "Password",
                ["TimezoneLabel"] = "Current Timezone: ",
                ["LoginFormTitle"] = "Scheduling System"
            };
        }
    }
}
