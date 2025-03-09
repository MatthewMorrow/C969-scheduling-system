namespace SchedulingSystem.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Cleans up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Initialize and configure the controls in the designer for this LoginForm.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.panelMain = new System.Windows.Forms.Panel(); // Renamed from panel2
            this.labelTimezone = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.labelUsername.Location = new System.Drawing.Point(28, 133);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(126, 32);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username:"; 
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(11, 43);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(370, 60);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Scheduling System Login"; 
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.labelPassword.Location = new System.Drawing.Point(28, 218);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(116, 32);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password:";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textUsername
            // 
            this.textUsername.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.textUsername.Location = new System.Drawing.Point(33, 169);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(325, 36);
            this.textUsername.TabIndex = 3;
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.textPassword.Location = new System.Drawing.Point(33, 254);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(325, 36);
            this.textPassword.TabIndex = 4;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // panelMain
            // 
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.labelTimezone);
            this.panelMain.Controls.Add(this.buttonLogin);
            this.panelMain.Controls.Add(this.labelTitle);
            this.panelMain.Controls.Add(this.textUsername);
            this.panelMain.Controls.Add(this.textPassword);
            this.panelMain.Controls.Add(this.labelPassword);
            this.panelMain.Controls.Add(this.labelUsername);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(390, 418);
            this.panelMain.TabIndex = 5;
            // 
            // labelTimezone
            // 
            this.labelTimezone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelTimezone.Location = new System.Drawing.Point(52, 98);
            this.labelTimezone.Name = "labelTimezone";
            this.labelTimezone.Size = new System.Drawing.Size(291, 33);
            this.labelTimezone.TabIndex = 7;
            this.labelTimezone.Text = "Current Timezone:";
            this.labelTimezone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(89, 327);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(202, 60);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 418);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(395, 427);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduling System Login";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelTimezone;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}
