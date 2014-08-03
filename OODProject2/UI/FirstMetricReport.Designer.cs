namespace OODProject_2_.UI
{
    partial class FirstMetricReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.goalPanel = new System.Windows.Forms.Panel();
            this.goalLabel = new System.Windows.Forms.Label();
            this.viewReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // goalPanel
            // 
            this.goalPanel.Location = new System.Drawing.Point(89, 53);
            this.goalPanel.Name = "goalPanel";
            this.goalPanel.Size = new System.Drawing.Size(165, 135);
            this.goalPanel.TabIndex = 1;
            // 
            // goalLabel
            // 
            this.goalLabel.AutoSize = true;
            this.goalLabel.Font = new System.Drawing.Font("Nazanin", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.goalLabel.Location = new System.Drawing.Point(260, 53);
            this.goalLabel.Name = "goalLabel";
            this.goalLabel.Size = new System.Drawing.Size(71, 23);
            this.goalLabel.TabIndex = 2;
            this.goalLabel.Text = "اهداف اجرایی";
            // 
            // viewReport
            // 
            this.viewReport.BackColor = System.Drawing.Color.LightSkyBlue;
            this.viewReport.Font = new System.Drawing.Font("Nazanin", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.viewReport.Location = new System.Drawing.Point(154, 194);
            this.viewReport.Name = "viewReport";
            this.viewReport.Size = new System.Drawing.Size(100, 20);
            this.viewReport.TabIndex = 3;
            this.viewReport.Text = "گزارش اندازه ها و متریک ها";
            this.viewReport.UseVisualStyleBackColor = false;
            this.viewReport.Click += new System.EventHandler(this.button1_Click);
            // 
            // FirstMetricReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewReport);
            this.Controls.Add(this.goalLabel);
            this.Controls.Add(this.goalPanel);
            this.Name = "FirstMetricReport";
            this.Load += new System.EventHandler(this.FirstMetricReport_Load);
            this.Controls.SetChildIndex(this.headerLabel, 0);
            this.Controls.SetChildIndex(this.goalPanel, 0);
            this.Controls.SetChildIndex(this.goalLabel, 0);
            this.Controls.SetChildIndex(this.viewReport, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel goalPanel;
        private System.Windows.Forms.Label goalLabel;
        private System.Windows.Forms.Button viewReport;
    }
}
