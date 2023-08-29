namespace ProyectoInolabServicio
{
    partial class AcuseCorreccionDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcuseCorreccionDoc));
            this.label1 = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.cmbFolios = new System.Windows.Forms.ComboBox();
            this.txtNoGuia = new System.Windows.Forms.TextBox();
            this.lblGuia = new System.Windows.Forms.Label();
            this.chkbEnvio = new System.Windows.Forms.CheckBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtAtencion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVistaPrevia = new System.Windows.Forms.Button();
            this.txtAcuseAnterior = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.adgvFoliosAcuse = new Zuby.ADGV.AdvancedDataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.FolioFSR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvFoliosAcuse)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(32, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folio:";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFolio.ForeColor = System.Drawing.Color.Maroon;
            this.lblFolio.Location = new System.Drawing.Point(80, 4);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(47, 16);
            this.lblFolio.TabIndex = 1;
            this.lblFolio.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cliente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(404, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(407, 102);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(81, 20);
            this.dtpFecha.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(599, 24);
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbFolios);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtNoGuia);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblGuia);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.chkbEnvio);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtObservaciones);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label10);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtDepto);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtAtencion);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtTelefono);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtDireccion);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtCliente);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnGuardar);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnVistaPrevia);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtAcuseAnterior);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label9);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label8);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.adgvFoliosAcuse);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label7);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label6);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label5);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label4);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dtpFecha);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblFolio);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(599, 568);
            this.toolStripContainer1.Location = new System.Drawing.Point(2, 65);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(599, 592);
            this.toolStripContainer1.TabIndex = 7;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // cmbFolios
            // 
            this.cmbFolios.FormattingEnabled = true;
            this.cmbFolios.Location = new System.Drawing.Point(56, 280);
            this.cmbFolios.Name = "cmbFolios";
            this.cmbFolios.Size = new System.Drawing.Size(87, 21);
            this.cmbFolios.TabIndex = 30;
            this.cmbFolios.SelectedIndexChanged += new System.EventHandler(this.cmbFolios_SelectedIndexChanged);
            this.cmbFolios.Click += new System.EventHandler(this.cmbFolios_Click);
            // 
            // txtNoGuia
            // 
            this.txtNoGuia.Location = new System.Drawing.Point(173, 239);
            this.txtNoGuia.Name = "txtNoGuia";
            this.txtNoGuia.Size = new System.Drawing.Size(130, 20);
            this.txtNoGuia.TabIndex = 29;
            this.txtNoGuia.Visible = false;
            this.txtNoGuia.WordWrap = false;
            // 
            // lblGuia
            // 
            this.lblGuia.AutoSize = true;
            this.lblGuia.Location = new System.Drawing.Point(170, 225);
            this.lblGuia.Name = "lblGuia";
            this.lblGuia.Size = new System.Drawing.Size(51, 13);
            this.lblGuia.TabIndex = 28;
            this.lblGuia.Text = "No. Guía";
            this.lblGuia.Visible = false;
            // 
            // chkbEnvio
            // 
            this.chkbEnvio.AutoSize = true;
            this.chkbEnvio.Location = new System.Drawing.Point(16, 239);
            this.chkbEnvio.Name = "chkbEnvio";
            this.chkbEnvio.Size = new System.Drawing.Size(127, 17);
            this.chkbEnvio.TabIndex = 27;
            this.chkbEnvio.Text = "Envio por paqueteria:";
            this.chkbEnvio.UseVisualStyleBackColor = true;
            this.chkbEnvio.CheckedChanged += new System.EventHandler(this.chkbEnvio_CheckedChanged);
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(98, 470);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(474, 45);
            this.txtObservaciones.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 470);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Observaciones:";
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(302, 193);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(242, 20);
            this.txtDepto.TabIndex = 24;
            // 
            // txtAtencion
            // 
            this.txtAtencion.Location = new System.Drawing.Point(16, 193);
            this.txtAtencion.Name = "txtAtencion";
            this.txtAtencion.Size = new System.Drawing.Size(246, 20);
            this.txtAtencion.TabIndex = 23;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(407, 149);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(137, 20);
            this.txtTelefono.TabIndex = 22;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(16, 149);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(360, 20);
            this.txtDireccion.TabIndex = 21;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(16, 105);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(360, 20);
            this.txtCliente.TabIndex = 20;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(497, 531);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.Enabled = false;
            this.btnVistaPrevia.Location = new System.Drawing.Point(16, 531);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(75, 23);
            this.btnVistaPrevia.TabIndex = 18;
            this.btnVistaPrevia.Text = "Vista Previa";
            this.btnVistaPrevia.UseVisualStyleBackColor = true;
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // txtAcuseAnterior
            // 
            this.txtAcuseAnterior.Location = new System.Drawing.Point(16, 54);
            this.txtAcuseAnterior.Name = "txtAcuseAnterior";
            this.txtAcuseAnterior.Size = new System.Drawing.Size(186, 20);
            this.txtAcuseAnterior.TabIndex = 17;
            this.txtAcuseAnterior.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAcuseAnterior_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Buscar Acuse Anterior:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(404, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Telefono:";
            // 
            // adgvFoliosAcuse
            // 
            this.adgvFoliosAcuse.AllowUserToAddRows = false;
            this.adgvFoliosAcuse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvFoliosAcuse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FolioFSR,
            this.TipoServicio,
            this.Equipo,
            this.NoSerie});
            this.adgvFoliosAcuse.FilterAndSortEnabled = true;
            this.adgvFoliosAcuse.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.adgvFoliosAcuse.Location = new System.Drawing.Point(16, 313);
            this.adgvFoliosAcuse.Name = "adgvFoliosAcuse";
            this.adgvFoliosAcuse.ReadOnly = true;
            this.adgvFoliosAcuse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.adgvFoliosAcuse.Size = new System.Drawing.Size(556, 150);
            this.adgvFoliosAcuse.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.adgvFoliosAcuse.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Folios:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Departamento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Atención:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Dirección:";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FolioFSR
            // 
            this.FolioFSR.DataPropertyName = "FolioFSR";
            this.FolioFSR.HeaderText = "FSR";
            this.FolioFSR.MinimumWidth = 22;
            this.FolioFSR.Name = "FolioFSR";
            this.FolioFSR.ReadOnly = true;
            this.FolioFSR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FolioFSR.Width = 80;
            // 
            // TipoServicio
            // 
            this.TipoServicio.DataPropertyName = "TipoServicio";
            this.TipoServicio.HeaderText = "Tipo de Servicio";
            this.TipoServicio.MinimumWidth = 22;
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            this.TipoServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TipoServicio.Width = 150;
            // 
            // Equipo
            // 
            this.Equipo.DataPropertyName = "Equipo";
            this.Equipo.HeaderText = "Equipo";
            this.Equipo.MinimumWidth = 22;
            this.Equipo.Name = "Equipo";
            this.Equipo.ReadOnly = true;
            this.Equipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Equipo.Width = 130;
            // 
            // NoSerie
            // 
            this.NoSerie.DataPropertyName = "NoSerie";
            this.NoSerie.HeaderText = "N.S.";
            this.NoSerie.MinimumWidth = 22;
            this.NoSerie.Name = "NoSerie";
            this.NoSerie.ReadOnly = true;
            this.NoSerie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.NoSerie.Width = 130;
            // 
            // AcuseCorreccionDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 659);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(601, 659);
            this.MinimumSize = new System.Drawing.Size(601, 659);
            this.Name = "AcuseCorreccionDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acuse de Correcciones";
            this.Load += new System.EventHandler(this.AcuseCorreccionDoc_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvFoliosAcuse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private Zuby.ADGV.AdvancedDataGridView adgvFoliosAcuse;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAcuseAnterior;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtAtencion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVistaPrevia;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkbEnvio;
        private System.Windows.Forms.Label lblGuia;
        private System.Windows.Forms.TextBox txtNoGuia;
        private System.Windows.Forms.ComboBox cmbFolios;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolioFSR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoSerie;
    }
}