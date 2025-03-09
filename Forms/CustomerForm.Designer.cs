namespace SchedulingSystem.Forms
{
    partial class CustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.TextBox textBoxAddress2;
        private System.Windows.Forms.TextBox textBoxCity;
        private System.Windows.Forms.TextBox textBoxCountry;
        private System.Windows.Forms.TextBox textBoxPostalCode;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView customerDataGridView;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelAddress2;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelPostalCode;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.CheckBox checkBoxActive;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxAddress2 = new System.Windows.Forms.TextBox();
            this.textBoxCity = new System.Windows.Forms.TextBox();
            this.textBoxCountry = new System.Windows.Forms.TextBox();
            this.textBoxPostalCode = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.customerDataGridView = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelAddress2 = new System.Windows.Forms.Label();
            this.labelCity = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelPostalCode = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).BeginInit();
            this.SuspendLayout();
            
            // textBoxName
            this.textBoxName.Location = new System.Drawing.Point(20, 60);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 20);
            this.textBoxName.TabIndex = 1;

            // textBoxAddress
            this.textBoxAddress.Location = new System.Drawing.Point(20, 100);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(200, 20);
            this.textBoxAddress.TabIndex = 2;

            // textBoxAddress2
            this.textBoxAddress2.Location = new System.Drawing.Point(20, 140);
            this.textBoxAddress2.Name = "textBoxAddress2";
            this.textBoxAddress2.Size = new System.Drawing.Size(200, 20);
            this.textBoxAddress2.TabIndex = 3;

            // textBoxCity
            this.textBoxCity.Location = new System.Drawing.Point(20, 180);
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(200, 20);
            this.textBoxCity.TabIndex = 4;

            // textBoxCountry
            this.textBoxCountry.Location = new System.Drawing.Point(20, 220);
            this.textBoxCountry.Name = "textBoxCountry";
            this.textBoxCountry.Size = new System.Drawing.Size(200, 20);
            this.textBoxCountry.TabIndex = 5;

            // textBoxPostalCode
            this.textBoxPostalCode.Location = new System.Drawing.Point(20, 260);
            this.textBoxPostalCode.Name = "textBoxPostalCode";
            this.textBoxPostalCode.Size = new System.Drawing.Size(200, 20);
            this.textBoxPostalCode.TabIndex = 6;

            // textBoxPhone
            this.textBoxPhone.Location = new System.Drawing.Point(20, 300);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(200, 20);
            this.textBoxPhone.TabIndex = 7;

            // buttonNew
            this.buttonNew.Location = new System.Drawing.Point(20, 340);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(60, 25);
            this.buttonNew.TabIndex = 8;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);

            // buttonSave
            this.buttonSave.Location = new System.Drawing.Point(90, 340);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(60, 25);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);

            // buttonDelete
            this.buttonDelete.Location = new System.Drawing.Point(160, 340);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(60, 25);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            // customerDataGridView
            this.customerDataGridView.AllowUserToAddRows = false;
            this.customerDataGridView.AllowUserToDeleteRows = false;
            this.customerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGridView.Location = new System.Drawing.Point(250, 20);
            this.customerDataGridView.Name = "customerDataGridView";
            this.customerDataGridView.ReadOnly = true;
            this.customerDataGridView.Size = new System.Drawing.Size(500, 400);
            this.customerDataGridView.TabIndex = 11;

            // labelName
            this.labelName.Location = new System.Drawing.Point(20, 40);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(100, 20);
            this.labelName.TabIndex = 12;
            this.labelName.Text = "Name*";

            // labelAddress
            this.labelAddress.Location = new System.Drawing.Point(20, 80);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(100, 20);
            this.labelAddress.TabIndex = 13;
            this.labelAddress.Text = "Address*";

            // labelAddress2
            this.labelAddress2.Location = new System.Drawing.Point(20, 120);
            this.labelAddress2.Name = "labelAddress2";
            this.labelAddress2.Size = new System.Drawing.Size(100, 20);
            this.labelAddress2.TabIndex = 14;
            this.labelAddress2.Text = "Address 2";

            // labelCity
            this.labelCity.Location = new System.Drawing.Point(20, 160);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(100, 20);
            this.labelCity.TabIndex = 15;
            this.labelCity.Text = "City*";

            // labelCountry
            this.labelCountry.Location = new System.Drawing.Point(20, 200);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(100, 20);
            this.labelCountry.TabIndex = 16;
            this.labelCountry.Text = "Country*";

            // labelPostalCode
            this.labelPostalCode.Location = new System.Drawing.Point(20, 240);
            this.labelPostalCode.Name = "labelPostalCode";
            this.labelPostalCode.Size = new System.Drawing.Size(100, 20);
            this.labelPostalCode.TabIndex = 17;
            this.labelPostalCode.Text = "Postal Code*";

            // labelPhone
            this.labelPhone.Location = new System.Drawing.Point(20, 280);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(100, 20);
            this.labelPhone.TabIndex = 18;
            this.labelPhone.Text = "Phone*";

            // checkBoxActive
            this.checkBoxActive.Location = new System.Drawing.Point(20, 380);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(100, 20);
            this.checkBoxActive.TabIndex = 19;
            this.checkBoxActive.Text = "Active";

            // CustomerForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxAddress2);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxCountry);
            this.Controls.Add(this.textBoxPostalCode);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.customerDataGridView);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelAddress2);
            this.Controls.Add(this.labelCity);
            this.Controls.Add(this.labelCountry);
            this.Controls.Add(this.labelPostalCode);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.checkBoxActive);
            this.Name = "CustomerForm";
            this.Text = "Customer Management";
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
