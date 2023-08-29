namespace ProyectoInolabServicio
{
    partial class CalendarioDias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarioDias));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblf1 = new System.Windows.Forms.Label();
            this.lblf2 = new System.Windows.Forms.Label();
            this.btnSemanaAntes = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSemanaDespues = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnEnviaCorreo = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnModificaCalendario = new MaterialSkin.Controls.MaterialRaisedButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1081, 24);
            this.menuStrip1.TabIndex = 0;
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1081, 464);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 62);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1081, 488);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowPrintButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(1081, 464);
            this.reportViewer1.TabIndex = 0;
            // 
            // lblf1
            // 
            this.lblf1.AutoSize = true;
            this.lblf1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblf1.Location = new System.Drawing.Point(323, 38);
            this.lblf1.Name = "lblf1";
            this.lblf1.Size = new System.Drawing.Size(16, 13);
            this.lblf1.TabIndex = 3;
            this.lblf1.Text = "f1";
            this.lblf1.Visible = false;
            // 
            // lblf2
            // 
            this.lblf2.AutoSize = true;
            this.lblf2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblf2.Location = new System.Drawing.Point(373, 38);
            this.lblf2.Name = "lblf2";
            this.lblf2.Size = new System.Drawing.Size(16, 13);
            this.lblf2.TabIndex = 5;
            this.lblf2.Text = "f2";
            this.lblf2.Visible = false;
            // 
            // btnSemanaAntes
            // 
            this.btnSemanaAntes.AutoSize = true;
            this.btnSemanaAntes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSemanaAntes.Depth = 0;
            this.btnSemanaAntes.Icon = ((System.Drawing.Image)(resources.GetObject("btnSemanaAntes.Icon")));
            this.btnSemanaAntes.Image = ((System.Drawing.Image)(resources.GetObject("btnSemanaAntes.Image")));
            this.btnSemanaAntes.Location = new System.Drawing.Point(207, 26);
            this.btnSemanaAntes.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSemanaAntes.Name = "btnSemanaAntes";
            this.btnSemanaAntes.Primary = true;
            this.btnSemanaAntes.Size = new System.Drawing.Size(44, 36);
            this.btnSemanaAntes.TabIndex = 14;
            this.btnSemanaAntes.UseVisualStyleBackColor = true;
            this.btnSemanaAntes.Click += new System.EventHandler(this.btnSemanaAntes_Click);
            // 
            // btnSemanaDespues
            // 
            this.btnSemanaDespues.AutoSize = true;
            this.btnSemanaDespues.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSemanaDespues.Depth = 0;
            this.btnSemanaDespues.Icon = ((System.Drawing.Image)(resources.GetObject("btnSemanaDespues.Icon")));
            this.btnSemanaDespues.Location = new System.Drawing.Point(273, 26);
            this.btnSemanaDespues.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSemanaDespues.Name = "btnSemanaDespues";
            this.btnSemanaDespues.Primary = true;
            this.btnSemanaDespues.Size = new System.Drawing.Size(44, 36);
            this.btnSemanaDespues.TabIndex = 15;
            this.btnSemanaDespues.UseVisualStyleBackColor = true;
            this.btnSemanaDespues.Click += new System.EventHandler(this.btnSemanaDespues_Click);
            // 
            // btnEnviaCorreo
            // 
            this.btnEnviaCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviaCorreo.AutoSize = true;
            this.btnEnviaCorreo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEnviaCorreo.Depth = 0;
            this.btnEnviaCorreo.Icon = null;
            this.btnEnviaCorreo.Location = new System.Drawing.Point(945, 26);
            this.btnEnviaCorreo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnEnviaCorreo.Name = "btnEnviaCorreo";
            this.btnEnviaCorreo.Primary = true;
            this.btnEnviaCorreo.Size = new System.Drawing.Size(125, 36);
            this.btnEnviaCorreo.TabIndex = 16;
            this.btnEnviaCorreo.Text = "Enviar Correo";
            this.btnEnviaCorreo.UseVisualStyleBackColor = true;
            this.btnEnviaCorreo.Click += new System.EventHandler(this.bntEncviaCorreo_Click);
            // 
            // btnModificaCalendario
            // 
            this.btnModificaCalendario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificaCalendario.AutoSize = true;
            this.btnModificaCalendario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnModificaCalendario.Depth = 0;
            this.btnModificaCalendario.Icon = null;
            this.btnModificaCalendario.Location = new System.Drawing.Point(747, 26);
            this.btnModificaCalendario.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnModificaCalendario.Name = "btnModificaCalendario";
            this.btnModificaCalendario.Primary = true;
            this.btnModificaCalendario.Size = new System.Drawing.Size(180, 36);
            this.btnModificaCalendario.TabIndex = 17;
            this.btnModificaCalendario.Text = "Modificar Calendario";
            this.btnModificaCalendario.UseVisualStyleBackColor = true;
            this.btnModificaCalendario.Click += new System.EventHandler(this.btnModificaCalendario_Click);
            // 
            // CalendarioDias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 552);
            this.Controls.Add(this.btnModificaCalendario);
            this.Controls.Add(this.btnEnviaCorreo);
            this.Controls.Add(this.btnSemanaDespues);
            this.Controls.Add(this.btnSemanaAntes);
            this.Controls.Add(this.lblf2);
            this.Controls.Add(this.lblf1);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CalendarioDias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendario Por Días";
            this.Load += new System.EventHandler(this.CalendarioDias_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label lblf1;
        private System.Windows.Forms.Label lblf2;
        private MaterialSkin.Controls.MaterialRaisedButton btnSemanaAntes;
        private MaterialSkin.Controls.MaterialRaisedButton btnSemanaDespues;
        private MaterialSkin.Controls.MaterialRaisedButton btnEnviaCorreo;
        private MaterialSkin.Controls.MaterialRaisedButton btnModificaCalendario;
    }
}