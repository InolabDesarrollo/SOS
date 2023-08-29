namespace ProyectoInolabServicio
{
    partial class CalendarioPlaneacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarioPlaneacion));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.llamadas_SAPTableAdapter1 = new ProyectoInolabServicio.DSBrowserTableAdapters.Llamadas_SAPTableAdapter();
            this.LlamadasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSBrowser = new ProyectoInolabServicio.DSBrowser();
            this.lblf1 = new System.Windows.Forms.Label();
            this.lblf2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.LlamadasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSBrowser)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(799, 362);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // llamadas_SAPTableAdapter1
            // 
            this.llamadas_SAPTableAdapter1.ClearBeforeFill = true;
            // 
            // LlamadasBindingSource
            // 
            this.LlamadasBindingSource.DataSource = this.dSBrowser;
            this.LlamadasBindingSource.Position = 0;
            // 
            // dSBrowser
            // 
            this.dSBrowser.DataSetName = "DSBrowser";
            this.dSBrowser.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblf1
            // 
            this.lblf1.AutoSize = true;
            this.lblf1.Location = new System.Drawing.Point(123, 23);
            this.lblf1.Name = "lblf1";
            this.lblf1.Size = new System.Drawing.Size(16, 13);
            this.lblf1.TabIndex = 3;
            this.lblf1.Text = "f1";
            this.lblf1.Visible = false;
            // 
            // lblf2
            // 
            this.lblf2.AutoSize = true;
            this.lblf2.Location = new System.Drawing.Point(159, 23);
            this.lblf2.Name = "lblf2";
            this.lblf2.Size = new System.Drawing.Size(16, 13);
            this.lblf2.TabIndex = 5;
            this.lblf2.Text = "f2";
            this.lblf2.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(799, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.reportViewer1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblf2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblf1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(799, 362);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 63);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(799, 386);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // CalendarioPlaneacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CalendarioPlaneacion";
            this.Text = "CalendarioPlaneacion";
            this.Load += new System.EventHandler(this.CalendarioPlaneacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LlamadasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSBrowser)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DSBrowserTableAdapters.Llamadas_SAPTableAdapter llamadas_SAPTableAdapter1;
        private System.Windows.Forms.BindingSource LlamadasBindingSource;
        private DSBrowser dSBrowser;
        private System.Windows.Forms.Label lblf1;
        private System.Windows.Forms.Label lblf2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}