using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SchedulingSystem.Data;

namespace SchedulingSystem.Forms
{
    public partial class ReportForm : Form
    {
        private readonly DatabaseAccess _db;

        public ReportForm(DatabaseAccess db)
        {
            InitializeComponent();
            _db = db ?? throw new ArgumentNullException(nameof(db));
            reportTypeComboBox.Items.AddRange([
                "Appointment Types by Month",
                "Schedule for Each User",
                "Appointments by Customer"
            ]);
            reportTypeComboBox.SelectedIndexChanged += (s, e) => OnReportSelected();
        }

        private void OnReportSelected()
        {
            if (reportTypeComboBox.SelectedIndex < 0) return;
            var sel = reportTypeComboBox.SelectedItem.ToString();
            switch (sel)
            {
                case "Appointment Types by Month":
                    LoadTypesByMonth();
                    break;
                case "Schedule for Each User":
                    LoadScheduleByUser();
                    break;
                case "Appointments by Customer":
                    LoadAppointmentsByCustomer();
                    break;
            }
        }

        private void LoadTypesByMonth()
        {
            try
            {
                const string sql = "SELECT appointmentId,type,start FROM appointment;";
                var dt = _db.ExecuteQuery(sql);
                if (dt.Rows.Count == 0)
                {
                    reportDataGridView.DataSource = null;
                    MessageBox.Show("No appointments found.", "No Data",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var appts = dt.AsEnumerable().Select(r => new
                {
                    Start = r.Field<DateTime>("start"),
                    Type = r.Field<string>("type")
                });
                var grouped = appts
                    .GroupBy(a => new { a.Start.Year, a.Start.Month, a.Type })
                    .Select(g => new
                    {
                        g.Key.Year,
                        g.Key.Month,
                        g.Key.Type,
                        Count = g.Count()
                    })
                    .OrderBy(x => x.Year)
                    .ThenBy(x => x.Month)
                    .ThenBy(x => x.Type)
                    .ToList();
                var tbl = new DataTable();
                tbl.Columns.Add("Year", typeof(int));
                tbl.Columns.Add("Month", typeof(int));
                tbl.Columns.Add("Type", typeof(string));
                tbl.Columns.Add("Count", typeof(int));
                foreach (var item in grouped)
                {
                    tbl.Rows.Add(item.Year, item.Month, item.Type, item.Count);
                }
                reportDataGridView.DataSource = tbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadScheduleByUser()
        {
            try
            {
                const string sql = @"
                    SELECT u.userName,a.title,a.start,a.end,a.type
                    FROM appointment a
                    JOIN user u ON a.userId=u.userId
                    ORDER BY u.userName,a.start;
                ";
                var dt = _db.ExecuteQuery(sql);
                if (dt.Rows.Count == 0)
                {
                    reportDataGridView.DataSource = null;
                    MessageBox.Show("No user appointments found.",
                                    "No Data", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                var sorted = dt.AsEnumerable()
                    .OrderBy(r => r.Field<string>("userName"))
                    .ThenBy(r => r.Field<DateTime>("start"))
                    .ToList();
                var tbl = new DataTable();
                tbl.Columns.Add("UserName", typeof(string));
                tbl.Columns.Add("Title", typeof(string));
                tbl.Columns.Add("Start", typeof(DateTime));
                tbl.Columns.Add("End", typeof(DateTime));
                tbl.Columns.Add("Type", typeof(string));
                foreach (var row in sorted)
                {
                    tbl.Rows.Add(
                        row.Field<string>("userName"),
                        row.Field<string>("title"),
                        row.Field<DateTime>("start"),
                        row.Field<DateTime>("end"),
                        row.Field<string>("type")
                    );
                }
                reportDataGridView.DataSource = tbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadAppointmentsByCustomer()
        {
            try
            {
                const string sql = @"
                    SELECT a.appointmentId,c.customerName
                    FROM appointment a
                    JOIN customer c ON a.customerId=c.customerId;
                ";
                var dt = _db.ExecuteQuery(sql);
                if (dt.Rows.Count == 0)
                {
                    reportDataGridView.DataSource = null;
                    MessageBox.Show("No customer appointments found.",
                                    "No Data", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                var appts = dt.AsEnumerable().Select(r => new
                {
                    CustomerName = r.Field<string>("customerName"),
                    AppointmentId = r.Field<int>("appointmentId")
                });
                var grouped = appts
                    .GroupBy(x => x.CustomerName)
                    .Select(g => new
                    {
                        Customer = g.Key,
                        TotalAppointments = g.Count()
                    })
                    .OrderBy(x => x.Customer)
                    .ToList();
                var tbl = new DataTable();
                tbl.Columns.Add("Customer Name", typeof(string));
                tbl.Columns.Add("Appointment Count", typeof(int));
                foreach (var item in grouped)
                {
                    tbl.Rows.Add(item.Customer, item.TotalAppointments);
                }
                reportDataGridView.DataSource = tbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message,
                                "Report Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
