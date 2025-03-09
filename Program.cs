using System;
using System.Configuration;
using System.Windows.Forms;
using SchedulingSystem.Data;
using SchedulingSystem.Forms;

namespace SchedulingSystem
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                var connectionString = ConfigurationManager
                    .ConnectionStrings["client_schedule"]
                    .ConnectionString;
                var db = new DatabaseAccess(connectionString);
                Application.Run(new LoginForm(db));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Critical Application Error: " + ex.Message,
                    "Application Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}