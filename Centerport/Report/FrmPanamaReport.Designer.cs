namespace MedicalManagementSoftware.Report
{
    partial class FrmPanamaReport
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
            this.Viewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btn_page8 = new System.Windows.Forms.Button();
            this.btn_page7 = new System.Windows.Forms.Button();
            this.btn_page6 = new System.Windows.Forms.Button();
            this.btn_page2 = new System.Windows.Forms.Button();
            this.btn_page3 = new System.Windows.Forms.Button();
            this.btn_page4 = new System.Windows.Forms.Button();
            this.btn_page5 = new System.Windows.Forms.Button();
            this.btn_page1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // Viewer1
            // 
            this.Viewer1.ActiveViewIndex = -1;
            this.Viewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Viewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Viewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Viewer1.DisplayStatusBar = false;
            this.Viewer1.Location = new System.Drawing.Point(7, -2);
            this.Viewer1.Name = "Viewer1";
            this.Viewer1.ShowCloseButton = false;
            this.Viewer1.ShowLogo = false;
            this.Viewer1.Size = new System.Drawing.Size(857, 644);
            this.Viewer1.TabIndex = 1;
            this.Viewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // btn_page8
            // 
            this.btn_page8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_page8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_page8.Location = new System.Drawing.Point(253, 663);
            this.btn_page8.Name = "btn_page8";
            this.btn_page8.Size = new System.Drawing.Size(29, 23);
            this.btn_page8.TabIndex = 37;
            this.btn_page8.Text = "8";
            this.btn_page8.UseVisualStyleBackColor = true;
            this.btn_page8.Click += new System.EventHandler(this.btn8_Click);
            // 
            // btn_page7
            // 
            this.btn_page7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_page7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_page7.Location = new System.Drawing.Point(224, 663);
            this.btn_page7.Name = "btn_page7";
            this.btn_page7.Size = new System.Drawing.Size(29, 23);
            this.btn_page7.TabIndex = 36;
            this.btn_page7.Text = "7";
            this.btn_page7.UseVisualStyleBackColor = true;
            this.btn_page7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn_page6
            // 
            this.btn_page6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_page6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_page6.Location = new System.Drawing.Point(196, 663);
            this.btn_page6.Name = "btn_page6";
            this.btn_page6.Size = new System.Drawing.Size(29, 23);
            this.btn_page6.TabIndex = 35;
            this.btn_page6.Text = "6";
            this.btn_page6.UseVisualStyleBackColor = true;
            this.btn_page6.Click += new System.EventHandler(this.btn_page6_Click);
            // 
            // btn_page2
            // 
            this.btn_page2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_page2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_page2.Location = new System.Drawing.Point(80, 663);
            this.btn_page2.Name = "btn_page2";
            this.btn_page2.Size = new System.Drawing.Size(29, 23);
            this.btn_page2.TabIndex = 34;
            this.btn_page2.Text = "2";
            this.btn_page2.UseVisualStyleBackColor = true;
            this.btn_page2.Click += new System.EventHandler(this.btn_page2_Click);
            // 
            // btn_page3
            // 
            this.btn_page3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_page3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_page3.Location = new System.Drawing.Point(109, 663);
            this.btn_page3.Name = "btn_page3";
            this.btn_page3.Size = new System.Drawing.Size(29, 23);
            this.btn_page3.TabIndex = 33;
            this.btn_page3.Text = "3";
            this.btn_page3.UseVisualStyleBackColor = true;
            this.btn_page3.Click += new System.EventHandler(this.btn_page3_Click);
            // 
            // btn_page4
            // 
            this.btn_page4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_page4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_page4.Location = new System.Drawing.Point(138, 663);
            this.btn_page4.Name = "btn_page4";
            this.btn_page4.Size = new System.Drawing.Size(29, 23);
            this.btn_page4.TabIndex = 32;
            this.btn_page4.Text = "4";
            this.btn_page4.UseVisualStyleBackColor = true;
            this.btn_page4.Click += new System.EventHandler(this.btn_page4_Click);
            // 
            // btn_page5
            // 
            this.btn_page5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_page5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_page5.Location = new System.Drawing.Point(167, 663);
            this.btn_page5.Name = "btn_page5";
            this.btn_page5.Size = new System.Drawing.Size(29, 23);
            this.btn_page5.TabIndex = 31;
            this.btn_page5.Text = "5";
            this.btn_page5.UseVisualStyleBackColor = true;
            this.btn_page5.Click += new System.EventHandler(this.btn_page5_Click);
            // 
            // btn_page1
            // 
            this.btn_page1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_page1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_page1.Location = new System.Drawing.Point(51, 663);
            this.btn_page1.Name = "btn_page1";
            this.btn_page1.Size = new System.Drawing.Size(29, 23);
            this.btn_page1.TabIndex = 30;
            this.btn_page1.Text = "1";
            this.btn_page1.UseVisualStyleBackColor = true;
            this.btn_page1.Click += new System.EventHandler(this.btn_page1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 667);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Pages:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(769, 660);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 30);
            this.button1.TabIndex = 28;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // FrmPanamaReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 702);
            this.Controls.Add(this.btn_page8);
            this.Controls.Add(this.btn_page7);
            this.Controls.Add(this.btn_page6);
            this.Controls.Add(this.btn_page2);
            this.Controls.Add(this.btn_page3);
            this.Controls.Add(this.btn_page4);
            this.Controls.Add(this.btn_page5);
            this.Controls.Add(this.btn_page1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Viewer1);
            this.Name = "FrmPanamaReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPanamaReport";
            this.Load += new System.EventHandler(this.FrmPanamaReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer Viewer1;
        private System.Windows.Forms.Button btn_page8;
        private System.Windows.Forms.Button btn_page7;
        private System.Windows.Forms.Button btn_page6;
        private System.Windows.Forms.Button btn_page2;
        private System.Windows.Forms.Button btn_page3;
        private System.Windows.Forms.Button btn_page4;
        private System.Windows.Forms.Button btn_page5;
        private System.Windows.Forms.Button btn_page1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}