using System;
using System.Windows.Forms;
using SchedulingSystem.Data;

namespace SchedulingSystem.Forms
{
    public partial class MainForm : Form
    {
        private readonly DatabaseAccess _db;
        private readonly int _currentUserId;
        private readonly string _currentUser;

        public MainForm(DatabaseAccess db, int currentUserId, string currentUser)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _currentUserId = currentUserId;
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            var localZone = TimeZoneInfo.Local;
            var offset = localZone.GetUtcOffset(DateTime.UtcNow);
            var sign = offset >= TimeSpan.Zero ? "+" : "-";
            var offsetAbs = offset.Duration().ToString(@"hh\:mm");
            timezoneLabel.Text = "Current Timezone: (UTC" + sign + offsetAbs + ") " + localZone.DisplayName;
            userLabel.Text = "User: " + _currentUser;
            customersMenuItem.Click += (s, e) => ShowCustomerForm();
            appointmentsMenuItem.Click += (s, e) => ShowAppointmentForm();
            reportsMenuItem.Click += (s, e) => ShowReportsForm();
            monthCalendar.DateSelected += (s, e) => LoadAppointments(e.Start);
            radioDailyView.CheckedChanged += (s, e) => OnViewChanged();
            radioMonthlyView.CheckedChanged += (s, e) => OnViewChanged();
            LoadAppointments(DateTime.Today);
        }

        private void ShowCustomerForm()
        {
            try
            {
                var form = new CustomerForm(_db, _currentUser);
                form.FormClosed += (s, e) => LoadAppointments(monthCalendar.SelectionStart);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Customer form: " + ex.Message,
                                "Form Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ShowAppointmentForm()
        {
            try
            {
                var form = new AppointmentForm(_db, _currentUserId, _currentUser);
                form.FormClosed += (s, e) => LoadAppointments(monthCalendar.SelectionStart);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Appointment form: " + ex.Message,
                                "Form Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ShowReportsForm()
        {
            try
            {
                var form = new ReportForm(_db);
                form.FormClosed += (s, e) => LoadAppointments(monthCalendar.SelectionStart);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Reports form: " + ex.Message,
                                "Form Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void OnViewChanged()
        {
            if (radioDailyView.Checked || radioMonthlyView.Checked)
            {
                LoadAppointments(monthCalendar.SelectionStart);
            }
        }

        private void LoadAppointments(DateTime date)
        {
            try
            {
                var sql = radioDailyView.Checked
                    ? @"SELECT appointmentId, customerId, userId, title, type, start, end
                       FROM appointment
                       WHERE userId=@u AND DATE(start)=DATE(@d)
                       ORDER BY start"
                    : @"SELECT appointmentId, customerId, userId, title, type, start, end
                       FROM appointment
                       WHERE userId=@u
                         AND MONTH(start)=MONTH(@d)
                         AND YEAR(start)=YEAR(@d)
                       ORDER BY start";
                var param = new System.Collections.Generic.Dictionary<string, object>
                {
                    ["@u"] = _currentUserId,
                    ["@d"] = date
                };
                var dt = _db.ExecuteQuery(sql, param);
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
    }
}
