namespace ProyectoInolabServicio
{
    partial class CalendarioGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarioGeneral));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblf1 = new System.Windows.Forms.Label();
            this.lblf2 = new System.Windows.Forms.Label();
            this.btnsemanterior = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnsemsiguiente = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSBrowser = new ProyectoInolabServicio.DSBrowser();
            this.usuariosTableAdapter = new ProyectoInolabServicio.DSBrowserTableAdapters.UsuariosTableAdapter();
            this.btnEnviarCorreo = new System.Windows.Forms.Button();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSBrowser)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
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
            this.reportViewer1.Size = new System.Drawing.Size(1082, 461);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // lblf1
            // 
            this.lblf1.AutoSize = true;
            this.lblf1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblf1.Location = new System.Drawing.Point(347, 36);
            this.lblf1.Name = "lblf1";
            this.lblf1.Size = new System.Drawing.Size(16, 13);
            this.lblf1.TabIndex = 2;
            this.lblf1.Text = "f1";
            this.lblf1.Visible = false;
            // 
            // lblf2
            // 
            this.lblf2.AutoSize = true;
            this.lblf2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblf2.Location = new System.Drawing.Point(384, 36);
            this.lblf2.Name = "lblf2";
            this.lblf2.Size = new System.Drawing.Size(16, 13);
            this.lblf2.TabIndex = 4;
            this.lblf2.Text = "f2";
            this.lblf2.Visible = false;
            // 
            // btnsemanterior
            // 
            this.btnsemanterior.ContextMenuStrip = this.contextMenuStrip1;
            this.btnsemanterior.Location = new System.Drawing.Point(528, 30);
            this.btnsemanterior.Name = "btnsemanterior";
            this.btnsemanterior.Size = new System.Drawing.Size(106, 24);
            this.btnsemanterior.TabIndex = 6;
            this.btnsemanterior.Text = "Semana Anterior";
            this.btnsemanterior.UseVisualStyleBackColor = true;
            this.btnsemanterior.Visible = false;
            this.btnsemanterior.Click += new System.EventHandler(this.btnsemanterior_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnsemsiguiente
            // 
            this.btnsemsiguiente.ContextMenuStrip = this.contextMenuStrip1;
            this.btnsemsiguiente.Location = new System.Drawing.Point(640, 32);
            this.btnsemsiguiente.Name = "btnsemsiguiente";
            this.btnsemsiguiente.Size = new System.Drawing.Size(106, 24);
            this.btnsemsiguiente.TabIndex = 7;
            this.btnsemsiguiente.Text = "Semana Siguiente";
            this.btnsemsiguiente.UseVisualStyleBackColor = true;
            this.btnsemsiguiente.Visible = false;
            this.btnsemsiguiente.Click += new System.EventHandler(this.btnsemsiguiente_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ContextMenuStrip = this.contextMenuStrip1;
            this.button1.Location = new System.Drawing.Point(866, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "Modificar Calendario";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "Usuarios";
            this.usuariosBindingSource.DataSource = this.dSBrowser;
            this.usuariosBindingSource.CurrentChanged += new System.EventHandler(this.usuariosBindingSource_CurrentChanged);
            // 
            // dSBrowser
            // 
            this.dSBrowser.DataSetName = "DSBrowser";
            this.dSBrowser.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // btnEnviarCorreo
            // 
            this.btnEnviarCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviarCorreo.ContextMenuStrip = this.contextMenuStrip1;
            this.btnEnviarCorreo.Location = new System.Drawing.Point(984, 28);
            this.btnEnviarCorreo.Name = "btnEnviarCorreo";
            this.btnEnviarCorreo.Size = new System.Drawing.Size(79, 28);
            this.btnEnviarCorreo.TabIndex = 11;
            this.btnEnviarCorreo.Text = "Enviar Correo";
            this.btnEnviarCorreo.UseVisualStyleBackColor = true;
            this.btnEnviarCorreo.Click += new System.EventHandler(this.btnEnviarCorreo_Click);
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1082, 461);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 62);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1082, 486);
            this.toolStripContainer1.TabIndex = 12;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.AutoSize = true;
            this.materialRaisedButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Icon = ((System.Drawing.Image)(resources.GetObject("materialRaisedButton1.Icon")));
            this.materialRaisedButton1.Image = ((System.Drawing.Image)(resources.GetObject("materialRaisedButton1.Image")));
            this.materialRaisedButton1.Location = new System.Drawing.Point(226, 26);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(44, 36);
            this.materialRaisedButton1.TabIndex = 13;
            this.toolTip1.SetToolTip(this.materialRaisedButton1, "Semana anterior");
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.AutoSize = true;
            this.materialRaisedButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Icon = ((System.Drawing.Image)(resources.GetObject("materialRaisedButton2.Icon")));
            this.materialRaisedButton2.Location = new System.Drawing.Point(289, 26);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(44, 36);
            this.materialRaisedButton2.TabIndex = 14;
            this.toolTip1.SetToolTip(this.materialRaisedButton2, "Semana Siguiente");
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // CalendarioGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 552);
            this.Controls.Add(this.materialRaisedButton2);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.btnsemanterior);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.btnEnviarCorreo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnsemsiguiente);
            this.Controls.Add(this.lblf2);
            this.Controls.Add(this.lblf1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalendarioGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendario General";
            this.Load += new System.EventHandler(this.CalendarioGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSBrowser)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label lblf1;
        private System.Windows.Forms.Label lblf2;
        private System.Windows.Forms.Button btnsemanterior;
        private System.Windows.Forms.Button btnsemsiguiente;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DSBrowser dSBrowser;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private DSBrowserTableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.Button btnEnviarCorreo;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}