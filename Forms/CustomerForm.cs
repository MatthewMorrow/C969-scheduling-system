using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SchedulingSystem.Data;

namespace SchedulingSystem.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly DatabaseAccess _db;
        private readonly string _currentUser;
        private int? _currentCustomerId;
        private int? _currentAddressId;

        public CustomerForm(DatabaseAccess db, string currentUser)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            Load += (s, e) => RefreshCustomerGrid();
            customerDataGridView.SelectionChanged += (s, e) =>
            {
                if (customerDataGridView.SelectedRows.Count == 0) return;
                LoadSelectedCustomer(customerDataGridView.SelectedRows[0]);
            };
        }

        private void RefreshCustomerGrid()
        {
            try
            {
                const string query = @"
                    SELECT c.customerId,c.customerName,c.active,c.addressId,
                           a.address,a.address2,a.postalCode,a.phone,
                           ci.city,co.country
                    FROM customer c
                    JOIN address a ON c.addressId=a.addressId
                    JOIN city ci ON a.cityId=ci.cityId
                    JOIN country co ON ci.countryId=co.countryId
                    ORDER BY c.customerId;
                ";
                var dt = _db.ExecuteQuery(query);
                customerDataGridView.DataSource = dt;
                customerDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadSelectedCustomer(DataGridViewRow row)
        {
            try
            {
                _currentCustomerId = Convert.ToInt32(row.Cells["customerId"].Value);
                _currentAddressId = Convert.ToInt32(row.Cells["addressId"].Value);
                textBoxName.Text = row.Cells["customerName"].Value.ToString();
                textBoxAddress.Text = row.Cells["address"].Value.ToString();
                textBoxAddress2.Text = row.Cells["address2"].Value.ToString();
                textBoxCity.Text = row.Cells["city"].Value.ToString();
                textBoxCountry.Text = row.Cells["country"].Value.ToString();
                textBoxPostalCode.Text = row.Cells["postalCode"].Value.ToString();
                textBoxPhone.Text = row.Cells["phone"].Value.ToString();
                checkBoxActive.Checked = Convert.ToBoolean(row.Cells["active"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading selected customer: " + ex.Message,
                                "Grid Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxAddress.Clear();
            textBoxAddress2.Clear();
            textBoxCity.Clear();
            textBoxCountry.Clear();
            textBoxPostalCode.Clear();
            textBoxPhone.Clear();
            checkBoxActive.Checked = true;
            _currentCustomerId = null;
            _currentAddressId = null;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
                    string.IsNullOrWhiteSpace(textBoxCity.Text) ||
                    string.IsNullOrWhiteSpace(textBoxCountry.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPostalCode.Text) ||
                    string.IsNullOrWhiteSpace(textBoxPhone.Text))
                {
                    MessageBox.Show(
                        "Please fill in all required fields (Name, Address, City, Country, PostalCode, Phone).",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                if (!textBoxPhone.Text.All(c => char.IsDigit(c) || c == '-'))
                {
                    MessageBox.Show("Phone number can only contain digits and dashes.",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                _db.BeginTransaction();
                try
                {
                    var countryId = InsertOrUpdateCountry(textBoxCountry.Text.Trim());
                    var cityId = InsertOrUpdateCity(textBoxCity.Text.Trim(), countryId);
                    var addressId = InsertOrUpdateAddress(cityId);
                    var sql = (_currentCustomerId == null)
                        ? @"INSERT INTO customer
                             (customerName,addressId,active,createDate,createdBy,lastUpdateBy)
                           VALUES
                             (@name,@addrId,@act,UTC_TIMESTAMP(),@usr,@usr);"
                        : @"UPDATE customer
                           SET customerName=@name,active=@act,lastUpdateBy=@usr
                           WHERE customerId=@custId;";
                    var custParams = new Dictionary<string, object>
                    {
                        ["@name"] = textBoxName.Text.Trim(),
                        ["@addrId"] = addressId,
                        ["@act"] = checkBoxActive.Checked,
                        ["@usr"] = _currentUser
                    };
                    if (_currentCustomerId != null) custParams["@custId"] = _currentCustomerId;
                    _db.ExecuteNonQuery(sql, custParams);
                    _db.CommitTransaction();
                    RefreshCustomerGrid();
                    MessageBox.Show("Customer saved successfully.",
                                    "Save Successful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                catch
                {
                    _db.RollbackTransaction();
                    throw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving customer: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private int InsertOrUpdateCountry(string countryName)
        {
            const string sql = @"
                INSERT INTO country (country,createDate,createdBy,lastUpdateBy)
                VALUES (@cnt,UTC_TIMESTAMP(),@usr,@usr)
                ON DUPLICATE KEY UPDATE countryId=LAST_INSERT_ID(countryId);
                SELECT LAST_INSERT_ID();
            ";
            var p = new Dictionary<string, object>
            {
                ["@cnt"] = countryName,
                ["@usr"] = _currentUser
            };
            return Convert.ToInt32(_db.ExecuteScalar(sql, p));
        }

        private int InsertOrUpdateCity(string cityName, int countryId)
        {
            const string sql = @"
                INSERT INTO city (city,countryId,createDate,createdBy,lastUpdateBy)
                VALUES (@cty,@cid,UTC_TIMESTAMP(),@usr,@usr)
                ON DUPLICATE KEY UPDATE cityId=LAST_INSERT_ID(cityId);
                SELECT LAST_INSERT_ID();
            ";
            var p = new Dictionary<string, object>
            {
                ["@cty"] = cityName,
                ["@cid"] = countryId,
                ["@usr"] = _currentUser
            };
            return Convert.ToInt32(_db.ExecuteScalar(sql, p));
        }

        private int InsertOrUpdateAddress(int cityId)
        {
            var sql = (_currentCustomerId == null)
                ? @"INSERT INTO address
                     (address,address2,cityId,postalCode,phone,createDate,createdBy,lastUpdateBy)
                   VALUES
                     (@ad,@ad2,@cid,@pc,@ph,UTC_TIMESTAMP(),@usr,@usr);
                   SELECT LAST_INSERT_ID();"
                : @"UPDATE address
                   SET address=@ad,address2=@ad2,cityId=@cid,
                       postalCode=@pc,phone=@ph,lastUpdateBy=@usr
                   WHERE addressId=@addrId;
                   SELECT @addrId;";
            var p = new Dictionary<string, object>
            {
                ["@ad"] = textBoxAddress.Text.Trim(),
                ["@ad2"] = textBoxAddress2.Text.Trim(),
                ["@cid"] = cityId,
                ["@pc"] = textBoxPostalCode.Text.Trim(),
                ["@ph"] = textBoxPhone.Text.Trim(),
                ["@usr"] = _currentUser
            };
            if (_currentCustomerId != null) p["@addrId"] = _currentAddressId;
            return Convert.ToInt32(_db.ExecuteScalar(sql, p));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_currentCustomerId == null)
            {
                MessageBox.Show("No customer selected to delete.",
                                "Delete Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show("Delete this customer?",
                                          "Confirm Delete",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                const string sql = "DELETE FROM customer WHERE customerId=@cid;";
                var p = new Dictionary<string, object> { ["@cid"] = _currentCustomerId };
                _db.ExecuteNonQuery(sql, p);
                RefreshCustomerGrid();
                buttonNew_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
