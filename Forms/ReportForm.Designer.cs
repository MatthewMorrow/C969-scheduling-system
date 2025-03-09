namespace SchedulingSystem.Forms
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.reportTypeLabel = new System.Windows.Forms.Label();
            this.reportDataGridView = new System.Windows.Forms.DataGridView();
            this.controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(76, 24);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Reports";
            // 
            // controlsPanel
            // 
            this.controlsPanel.BackColor = System.Drawing.Color.White;
            this.controlsPanel.Controls.Add(this.reportTypeComboBox);
            this.controlsPanel.Controls.Add(this.reportTypeLabel);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlsPanel.Location = new System.Drawing.Point(0, 0);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Padding = new System.Windows.Forms.Padding(12);
            this.controlsPanel.Size = new System.Drawing.Size(784, 60);
            this.controlsPanel.TabIndex = 1;
            // 
            // reportTypeLabel
            // 
            this.reportTypeLabel.AutoSize = true;
            this.reportTypeLabel.Location = new System.Drawing.Point(12, 15);
            this.reportTypeLabel.Name = "reportTypeLabel";
            this.reportTypeLabel.Size = new System.Drawing.Size(71, 13);
            this.reportTypeLabel.TabIndex = 0;
            this.reportTypeLabel.Text = "Report Type:";
            // 
            // reportTypeComboBox
            // 
            this.reportTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportTypeComboBox.FormattingEnabled = true;
            this.reportTypeComboBox.Location = new System.Drawing.Point(89, 12);
            this.reportTypeComboBox.Name = "reportTypeComboBox";
            this.reportTypeComboBox.Size = new System.Drawing.Size(300, 21);
            this.reportTypeComboBox.TabIndex = 1;
            // 
            // reportDataGridView
            // 
            this.reportDataGridView.AllowUserToAddRows = false;
            this.reportDataGridView.AllowUserToDeleteRows = false;
            this.reportDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reportDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.reportDataGridView.Location = new System.Drawing.Point(12, 72);
            this.reportDataGridView.Name = "reportDataGridView";
            this.reportDataGridView.ReadOnly = true;
            this.reportDataGridView.Size = new System.Drawing.Size(760, 477);
            this.reportDataGridView.TabIndex = 2;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.reportDataGridView);
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.titleLabel);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ReportForm";
            this.Text = "Reports";
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Label reportTypeLabel;
        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private System.Windows.Forms.DataGridView reportDataGridView;
    }
}