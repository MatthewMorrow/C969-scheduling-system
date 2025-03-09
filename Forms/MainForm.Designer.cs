namespace SchedulingSystem.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.customersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.timezoneLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.userLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.calendarPanel = new System.Windows.Forms.Panel();
            this.labelCalendar = new System.Windows.Forms.Label();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.viewOptionsPanel = new System.Windows.Forms.Panel();
            this.radioDailyView = new System.Windows.Forms.RadioButton();
            this.radioMonthlyView = new System.Windows.Forms.RadioButton();
            this.appointmentsPanel = new System.Windows.Forms.Panel();
            this.labelDailyAppointments = new System.Windows.Forms.Label();
            this.appointmentDataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.calendarPanel.SuspendLayout();
            this.viewOptionsPanel.SuspendLayout();
            this.appointmentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.customersMenuItem, this.appointmentsMenuItem, this.reportsMenuItem });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // customersMenuItem
            // 
            this.customersMenuItem.Name = "customersMenuItem";
            this.customersMenuItem.Size = new System.Drawing.Size(76, 20);
            this.customersMenuItem.Text = "&Customers";
            // 
            // appointmentsMenuItem
            // 
            this.appointmentsMenuItem.Name = "appointmentsMenuItem";
            this.appointmentsMenuItem.Size = new System.Drawing.Size(95, 20);
            this.appointmentsMenuItem.Text = "&Appointments";
            // 
            // reportsMenuItem
            // 
            this.reportsMenuItem.Name = "reportsMenuItem";
            this.reportsMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsMenuItem.Text = "&Reports";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.timezoneLabel, this.userLabel });
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // timezoneLabel
            // 
            this.timezoneLabel.Name = "timezoneLabel";
            this.timezoneLabel.Size = new System.Drawing.Size(309, 17);
            this.timezoneLabel.Text = "Current Timezone: (UTC-05:00) Eastern Time (US & Canada)";
            // 
            // userLabel
            // 
            this.userLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(55, 17);
            this.userLabel.Text = "User: test";
            // 
            // calendarPanel
            // 
            this.calendarPanel.Controls.Add(this.labelCalendar);
            this.calendarPanel.Controls.Add(this.monthCalendar);
            this.calendarPanel.Controls.Add(this.viewOptionsPanel);
            this.calendarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.calendarPanel.Location = new System.Drawing.Point(0, 24);
            this.calendarPanel.Name = "calendarPanel";
            this.calendarPanel.Size = new System.Drawing.Size(300, 515);
            this.calendarPanel.TabIndex = 3;
            // 
            // labelCalendar
            // 
            this.labelCalendar.AutoSize = true;
            this.labelCalendar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCalendar.Location = new System.Drawing.Point(12, 12);
            this.labelCalendar.Name = "labelCalendar";
            this.labelCalendar.Size = new System.Drawing.Size(73, 20);
            this.labelCalendar.TabIndex = 0;
            this.labelCalendar.Text = "Calendar";
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(12, 40);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 1;
            // 
            // viewOptionsPanel
            // 
            this.viewOptionsPanel.Controls.Add(this.radioDailyView);
            this.viewOptionsPanel.Controls.Add(this.radioMonthlyView);
            this.viewOptionsPanel.Location = new System.Drawing.Point(12, 210);
            this.viewOptionsPanel.Name = "viewOptionsPanel";
            this.viewOptionsPanel.Size = new System.Drawing.Size(227, 30);
            this.viewOptionsPanel.TabIndex = 2;
            // 
            // radioDailyView
            // 
            this.radioDailyView.AutoSize = true;
            this.radioDailyView.Checked = true;
            this.radioDailyView.Location = new System.Drawing.Point(3, 3);
            this.radioDailyView.Name = "radioDailyView";
            this.radioDailyView.Size = new System.Drawing.Size(74, 17);
            this.radioDailyView.TabIndex = 0;
            this.radioDailyView.TabStop = true;
            this.radioDailyView.Text = "Daily View";
            // 
            // radioMonthlyView
            // 
            this.radioMonthlyView.AutoSize = true;
            this.radioMonthlyView.Location = new System.Drawing.Point(87, 3);
            this.radioMonthlyView.Name = "radioMonthlyView";
            this.radioMonthlyView.Size = new System.Drawing.Size(88, 17);
            this.radioMonthlyView.TabIndex = 1;
            this.radioMonthlyView.Text = "Monthly View";
            // 
            // appointmentsPanel
            // 
            this.appointmentsPanel.Controls.Add(this.labelDailyAppointments);
            this.appointmentsPanel.Controls.Add(this.appointmentDataGridView);
            this.appointmentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appointmentsPanel.Location = new System.Drawing.Point(300, 24);
            this.appointmentsPanel.Name = "appointmentsPanel";
            this.appointmentsPanel.Size = new System.Drawing.Size(500, 515);
            this.appointmentsPanel.TabIndex = 4;
            // 
            // labelDailyAppointments
            // 
            this.labelDailyAppointments.AutoSize = true;
            this.labelDailyAppointments.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelDailyAppointments.Location = new System.Drawing.Point(12, 12);
            this.labelDailyAppointments.Name = "labelDailyAppointments";
            this.labelDailyAppointments.Size = new System.Drawing.Size(146, 20);
            this.labelDailyAppointments.TabIndex = 0;
            this.labelDailyAppointments.Text = "Daily Appointments";
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.AllowUserToAddRows = false;
            this.appointmentDataGridView.AllowUserToDeleteRows = false;
            this.appointmentDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.appointmentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentDataGridView.Location = new System.Drawing.Point(12, 40);
            this.appointmentDataGridView.MultiSelect = false;
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.ReadOnly = true;
            this.appointmentDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDataGridView.Size = new System.Drawing.Size(456, 458);
            this.appointmentDataGridView.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.appointmentsPanel);
            this.Controls.Add(this.calendarPanel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduling System";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.calendarPanel.ResumeLayout(false);
            this.calendarPanel.PerformLayout();
            this.viewOptionsPanel.ResumeLayout(false);
            this.viewOptionsPanel.PerformLayout();
            this.appointmentsPanel.ResumeLayout(false);
            this.appointmentsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem customersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel timezoneLabel;
        private System.Windows.Forms.ToolStripStatusLabel userLabel;
        private System.Windows.Forms.Panel calendarPanel;
        private System.Windows.Forms.Panel appointmentsPanel;
        private System.Windows.Forms.Label labelCalendar;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Panel viewOptionsPanel;
        private System.Windows.Forms.RadioButton radioDailyView;
        private System.Windows.Forms.RadioButton radioMonthlyView;
        private System.Windows.Forms.Label labelDailyAppointments;
        private System.Windows.Forms.DataGridView appointmentDataGridView;
    }
}
