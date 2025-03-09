using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchedulingSystem.Data;

namespace SchedulingSystem.Forms
{
    public partial class AppointmentForm : Form
    {
        private readonly DatabaseAccess _db;
        private readonly int _currentUserId;
        private readonly string _currentUser;
        private int? _currentAppointmentId;

        public AppointmentForm(DatabaseAccess db, int currentUserId, string currentUser)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _currentUserId = currentUserId;
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            appointmentDataGridView.SelectionChanged += (s, e) =>
            {
                if (appointmentDataGridView.SelectedRows.Count > 0)
                {
                    LoadSelectedAppointment(appointmentDataGridView.SelectedRows[0]);
                }
            };
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {
                const string cQuery = "SELECT customerId,customerName FROM customer ORDER BY customerName;";
                var dt = _db.ExecuteQuery(cQuery);
                customerComboBox.DataSource = dt;
                customerComboBox.ValueMember = "customerId";
                customerComboBox.DisplayMember = "customerName";
                customerComboBox.SelectedIndex = -1;
                typeComboBox.Items.Clear();
                typeComboBox.Items.AddRange(new[] { "Consultation", "Planning", "Review", "Follow-up" });
                typeComboBox.SelectedIndex = -1;
                durationComboBox.Items.Clear();
                durationComboBox.Items.AddRange(new[] { "15", "30", "45", "60" });
                durationComboBox.SelectedIndex = -1;
                RefreshAppointmentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading initial data: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void RefreshAppointmentGrid()
        {
            try
            {
                const string q = @"
                    SELECT a.appointmentId,a.customerId,c.customerName,
                           a.title,a.type,a.url,a.description,a.start,a.end
                    FROM appointment a
                    JOIN customer c ON a.customerId=c.customerId
                    WHERE a.userId=@uid
                    ORDER BY a.start;
                ";
                var p = new Dictionary<string, object> { ["@uid"] = _currentUserId };
                var dt = _db.ExecuteQuery(q, p);
                appointmentDataGridView.DataSource = dt;
                appointmentDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointments: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadSelectedAppointment(DataGridViewRow row)
        {
            try
            {
                _currentAppointmentId = Convert.ToInt32(row.Cells["appointmentId"].Value);
                var startUtc = (DateTime)row.Cells["start"].Value;
                var endUtc = (DateTime)row.Cells["end"].Value;
                var startLocal = startUtc.ToLocalTime();
                var endLocal = endUtc.ToLocalTime();
                customerComboBox.SelectedValue = (int)row.Cells["customerId"].Value;
                titleTextBox.Text = row.Cells["title"].Value?.ToString() ?? "";
                urlTextBox.Text = row.Cells["url"].Value?.ToString() ?? "";
                textDescription.Text = row.Cells["description"].Value?.ToString() ?? "";
                typeComboBox.Text = row.Cells["type"].Value?.ToString() ?? "";
                dateTimePicker.Value = startLocal.Date;
                startTimePicker.Value = startLocal;
                var totalMinutes = (endLocal - startLocal).TotalMinutes;
                durationComboBox.SelectedIndex = durationComboBox.Items.IndexOf(totalMinutes.ToString("0"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading appointment: " + ex.Message,
                                "Grid Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _currentAppointmentId = null;
            customerComboBox.SelectedIndex = -1;
            titleTextBox.Clear();
            urlTextBox.Clear();
            textDescription.Clear();
            typeComboBox.SelectedIndex = -1;
            dateTimePicker.Value = DateTime.Now.Date;
            startTimePicker.Value = DateTime.Now;
            durationComboBox.SelectedIndex = -1;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (customerComboBox.SelectedIndex < 0 ||
                    string.IsNullOrWhiteSpace(titleTextBox.Text) ||
                    string.IsNullOrWhiteSpace(typeComboBox.Text) ||
                    durationComboBox.SelectedIndex < 0)
                {
                    MessageBox.Show("Please fill all required fields (customer, title, type, duration).",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                var localStart = dateTimePicker.Value.Date + startTimePicker.Value.TimeOfDay;
                if (!int.TryParse(durationComboBox.Text, out var durationMins))
                {
                    MessageBox.Show("Invalid duration. Select 15, 30, 45, or 60.",
                                    "Validation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                var localEnd = localStart.AddMinutes(durationMins);
                var utcStart = localStart.ToUniversalTime();
                var utcEnd = localEnd.ToUniversalTime();
                var estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                var estStart = TimeZoneInfo.ConvertTimeFromUtc(utcStart, estZone);
                var isWeekend = estStart.DayOfWeek == DayOfWeek.Saturday || estStart.DayOfWeek == DayOfWeek.Sunday;
                var within9To5 = estStart.Hour is >= 9 and < 17;
                if (!within9To5 || isWeekend)
                {
                    MessageBox.Show(
                        "Appointments must be within 9:00 AM - 5:00 PM ET, Monday-Friday (accounting for DST).",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
                const string overlapQ = @"
                    SELECT COUNT(*) FROM appointment
                    WHERE userId=@u
                      AND ((start BETWEEN @s AND @e)
                        OR (end BETWEEN @s AND @e)
                        OR (start<@s AND end>@e))
                      AND appointmentId!=@id;
                ";
                var overlapP = new Dictionary<string, object>
                {
                    ["@u"] = _currentUserId,
                    ["@s"] = utcStart,
                    ["@e"] = utcEnd,
                    ["@id"] = _currentAppointmentId ?? 0
                };
                var conflicts = Convert.ToInt32(_db.ExecuteScalar(overlapQ, overlapP));
                if (conflicts > 0)
                {
                    MessageBox.Show("This appointment overlaps with an existing one.",
                                    "Scheduling Conflict",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }
                var userCity = "Phoenix, Arizona";
                var sql = (_currentAppointmentId == null)
                    ? @"INSERT INTO appointment
                         (customerId,userId,title,description,location,type,url,
                          start,end,createDate,createdBy,lastUpdateBy)
                       VALUES
                         (@cid,@uid,@ttl,@desc,@loc,@typ,@url,
                          @st,@en,UTC_TIMESTAMP(),@usr,@usr);"
                    : @"UPDATE appointment
                       SET customerId=@cid,title=@ttl,description=@desc,type=@typ,
                           url=@url,start=@st,end=@en,lastUpdateBy=@usr,location=@loc
                       WHERE appointmentId=@apptId;";
                var p = new Dictionary<string, object>
                {
                    ["@cid"] = customerComboBox.SelectedValue,
                    ["@uid"] = _currentUserId,
                    ["@ttl"] = titleTextBox.Text.Trim(),
                    ["@desc"] = textDescription.Text.Trim(),
                    ["@loc"] = userCity,
                    ["@typ"] = typeComboBox.Text.Trim(),
                    ["@url"] = urlTextBox.Text.Trim(),
                    ["@st"] = utcStart,
                    ["@en"] = utcEnd,
                    ["@usr"] = _currentUser
                };
                if (_currentAppointmentId != null) p["@apptId"] = _currentAppointmentId;
                _db.ExecuteNonQuery(sql, p);
                RefreshAppointmentGrid();
                MessageBox.Show("Appointment saved successfully.",
                                "Save Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving appointment: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_currentAppointmentId == null)
            {
                MessageBox.Show("No appointment selected to delete.",
                                "Delete Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show("Delete this appointment?",
                                          "Confirm Delete",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                const string q = "DELETE FROM appointment WHERE appointmentId=@id;";
                var p = new Dictionary<string, object> { ["@id"] = _currentAppointmentId };
                _db.ExecuteNonQuery(q, p);
                RefreshAppointmentGrid();
                buttonNew_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting appointment: " + ex.Message,
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
