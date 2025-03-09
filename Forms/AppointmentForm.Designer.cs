namespace SchedulingSystem.Forms
{
    partial class AppointmentForm
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
            this.appointmentDataGridView = new System.Windows.Forms.DataGridView();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.labelAppointments = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.labelURL = new System.Windows.Forms.Label();
            this.urlTextBox = new System.Windows.Forms.TextBox();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelTime = new System.Windows.Forms.Label();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelDuration = new System.Windows.Forms.Label();
            this.durationComboBox = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.labelBusinessHours = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonNew = new System.Windows.Forms.Button();
            this.labelRequired = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // appointmentDataGridView
            // 
            this.appointmentDataGridView.AllowUserToAddRows = false;
            this.appointmentDataGridView.AllowUserToDeleteRows = false;
            this.appointmentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGridView.Location = new System.Drawing.Point(10, 40);
            this.appointmentDataGridView.Name = "appointmentDataGridView";
            this.appointmentDataGridView.ReadOnly = true;
            this.appointmentDataGridView.Size = new System.Drawing.Size(521, 462);
            this.appointmentDataGridView.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.labelAppointments);
            this.panelLeft.Controls.Add(this.appointmentDataGridView);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(545, 530);
            this.panelLeft.TabIndex = 0;
            // 
            // labelAppointments
            // 
            this.labelAppointments.AutoSize = true;
            this.labelAppointments.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelAppointments.Location = new System.Drawing.Point(10, 15);
            this.labelAppointments.Name = "labelAppointments";
            this.labelAppointments.Size = new System.Drawing.Size(102, 16);
            this.labelAppointments.TabIndex = 0;
            this.labelAppointments.Text = "Appointments";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.labelURL);
            this.panelRight.Controls.Add(this.urlTextBox);
            this.panelRight.Controls.Add(this.labelCustomer);
            this.panelRight.Controls.Add(this.customerComboBox);
            this.panelRight.Controls.Add(this.labelDate);
            this.panelRight.Controls.Add(this.dateTimePicker);
            this.panelRight.Controls.Add(this.labelTime);
            this.panelRight.Controls.Add(this.startTimePicker);
            this.panelRight.Controls.Add(this.labelDuration);
            this.panelRight.Controls.Add(this.durationComboBox);
            this.panelRight.Controls.Add(this.labelType);
            this.panelRight.Controls.Add(this.typeComboBox);
            this.panelRight.Controls.Add(this.labelTitle);
            this.panelRight.Controls.Add(this.titleTextBox);
            this.panelRight.Controls.Add(this.labelDescription);
            this.panelRight.Controls.Add(this.textDescription);
            this.panelRight.Controls.Add(this.labelBusinessHours);
            this.panelRight.Controls.Add(this.buttonSave);
            this.panelRight.Controls.Add(this.buttonDelete);
            this.panelRight.Controls.Add(this.buttonNew);
            this.panelRight.Controls.Add(this.labelRequired);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(545, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(469, 530);
            this.panelRight.TabIndex = 1;
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(10, 247);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(36, 13);
            this.labelURL.TabIndex = 14;
            this.labelURL.Text = "URL *";
            // 
            // urlTextBox
            // 
            this.urlTextBox.Location = new System.Drawing.Point(10, 267);
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(200, 20);
            this.urlTextBox.TabIndex = 15;
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(10, 40);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(58, 13);
            this.labelCustomer.TabIndex = 1;
            this.labelCustomer.Text = "Customer *";
            // 
            // customerComboBox
            // 
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(10, 60);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(200, 21);
            this.customerComboBox.TabIndex = 1;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(10, 90);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(37, 13);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "Date *";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(10, 110);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 2;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(230, 90);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(37, 13);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "Time *";
            // 
            // startTimePicker
            // 
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimePicker.Location = new System.Drawing.Point(230, 110);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.ShowUpDown = true;
            this.startTimePicker.Size = new System.Drawing.Size(90, 20);
            this.startTimePicker.TabIndex = 3;
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(330, 90);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(92, 13);
            this.labelDuration.TabIndex = 4;
            this.labelDuration.Text = "Duration (minutes)";
            // 
            // durationComboBox
            // 
            this.durationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.durationComboBox.FormattingEnabled = true;
            this.durationComboBox.Location = new System.Drawing.Point(330, 110);
            this.durationComboBox.Name = "durationComboBox";
            this.durationComboBox.Size = new System.Drawing.Size(100, 21);
            this.durationComboBox.TabIndex = 4;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(10, 140);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(38, 13);
            this.labelType.TabIndex = 5;
            this.labelType.Text = "Type *";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(10, 160);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(200, 21);
            this.typeComboBox.TabIndex = 5;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(10, 192);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(34, 13);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Title *";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(10, 212);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(200, 20);
            this.titleTextBox.TabIndex = 6;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(10, 298);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 7;
            this.labelDescription.Text = "Description";
            // 
            // textDescription
            // 
            this.textDescription.Location = new System.Drawing.Point(10, 318);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.Size = new System.Drawing.Size(420, 60);
            this.textDescription.TabIndex = 7;
            // 
            // labelBusinessHours
            // 
            this.labelBusinessHours.AutoSize = true;
            this.labelBusinessHours.Location = new System.Drawing.Point(10, 410);
            this.labelBusinessHours.Name = "labelBusinessHours";
            this.labelBusinessHours.Size = new System.Drawing.Size(240, 13);
            this.labelBusinessHours.TabIndex = 9;
            this.labelBusinessHours.Text = "Business Hours: 9:00 AM - 5:00 PM EST, Mon-Fri";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(10, 450);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(100, 450);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 11;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(190, 450);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 23);
            this.buttonNew.TabIndex = 12;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // labelRequired
            // 
            this.labelRequired.AutoSize = true;
            this.labelRequired.Location = new System.Drawing.Point(10, 490);
            this.labelRequired.Name = "labelRequired";
            this.labelRequired.Size = new System.Drawing.Size(87, 13);
            this.labelRequired.TabIndex = 13;
            this.labelRequired.Text = "* Required Fields";
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 530);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.MinimumSize = new System.Drawing.Size(786, 569);
            this.Name = "AppointmentForm";
            this.Text = "Manage Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGridView)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView appointmentDataGridView;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label labelAppointments;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.ComboBox durationComboBox;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.Label labelBusinessHours;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Label labelRequired;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.TextBox urlTextBox;
    }
}
