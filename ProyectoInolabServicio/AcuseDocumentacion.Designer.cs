namespace ProyectoInolabServicio
{
    partial class AcuseDocumentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AcuseDocumentacion));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listaDeAcusesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.lblGuia = new System.Windows.Forms.Label();
            this.txtNoGuia = new System.Windows.Forms.TextBox();
            this.chkbEnvio = new System.Windows.Forms.CheckBox();
            this.cmbTelefono = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDireccion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVistaP = new System.Windows.Forms.Button();
            this.lblFolio = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.adgvDatosFolios = new Zuby.ADGV.AdvancedDataGridView();
            this.cmbFolios = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaAcuse = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.vDocumentacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet = new ProyectoInolabServicio.BrowserDataSet();
            this.v_DocumentacionTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.V_DocumentacionTableAdapter();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noserie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvDatosFolios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDocumentacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeAcusesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listaDeAcusesToolStripMenuItem
            // 
            this.listaDeAcusesToolStripMenuItem.Name = "listaDeAcusesToolStripMenuItem";
            this.listaDeAcusesToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.listaDeAcusesToolStripMenuItem.Text = "Lista de Acuses";
            this.listaDeAcusesToolStripMenuItem.Click += new System.EventHandler(this.listaDeAcusesToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblGuia);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtNoGuia);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.chkbEnvio);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbTelefono);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label9);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbDireccion);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label8);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbClientes);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnGuardar);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnVistaP);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lblFolio);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label7);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.txtObservaciones);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label6);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.adgvDatosFolios);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbFolios);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label5);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dtpFechaAcuse);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label4);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbDepartamento);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cmbResponsable);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label2);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(600, 497);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 62);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(600, 521);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // lblGuia
            // 
            this.lblGuia.AutoSize = true;
            this.lblGuia.Location = new System.Drawing.Point(178, 198);
            this.lblGuia.Name = "lblGuia";
            this.lblGuia.Size = new System.Drawing.Size(54, 13);
            this.lblGuia.TabIndex = 27;
            this.lblGuia.Text = "No. Guía:";
            this.lblGuia.Visible = false;
            // 
            // txtNoGuia
            // 
            this.txtNoGuia.Location = new System.Drawing.Point(181, 214);
            this.txtNoGuia.Name = "txtNoGuia";
            this.txtNoGuia.Size = new System.Drawing.Size(159, 20);
            this.txtNoGuia.TabIndex = 26;
            this.txtNoGuia.Visible = false;
            // 
            // chkbEnvio
            // 
            this.chkbEnvio.AutoSize = true;
            this.chkbEnvio.Location = new System.Drawing.Point(35, 207);
            this.chkbEnvio.Name = "chkbEnvio";
            this.chkbEnvio.Size = new System.Drawing.Size(125, 17);
            this.chkbEnvio.TabIndex = 25;
            this.chkbEnvio.Text = "Envio por Paqueteria";
            this.chkbEnvio.UseVisualStyleBackColor = true;
            this.chkbEnvio.CheckedChanged += new System.EventHandler(this.chkbEnvio_CheckedChanged);
            // 
            // cmbTelefono
            // 
            this.cmbTelefono.Enabled = false;
            this.cmbTelefono.FormattingEnabled = true;
            this.cmbTelefono.Location = new System.Drawing.Point(442, 115);
            this.cmbTelefono.Name = "cmbTelefono";
            this.cmbTelefono.Size = new System.Drawing.Size(138, 21);
            this.cmbTelefono.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(439, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Telefono;";
            // 
            // cmbDireccion
            // 
            this.cmbDireccion.Enabled = false;
            this.cmbDireccion.FormattingEnabled = true;
            this.cmbDireccion.Location = new System.Drawing.Point(30, 115);
            this.cmbDireccion.Name = "cmbDireccion";
            this.cmbDireccion.Size = new System.Drawing.Size(374, 21);
            this.cmbDireccion.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Dirección:";
            // 
            // cmbClientes
            // 
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(30, 71);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(374, 21);
            this.cmbClientes.TabIndex = 20;
            this.cmbClientes.SelectedIndexChanged += new System.EventHandler(this.cmbClientes_SelectedIndexChanged);
            this.cmbClientes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbClientes_KeyPress);
            this.cmbClientes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbClientes_KeyUp);
            this.cmbClientes.Validating += new System.ComponentModel.CancelEventHandler(this.cmbClientes_Validating);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Location = new System.Drawing.Point(505, 464);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVistaP
            // 
            this.btnVistaP.Enabled = false;
            this.btnVistaP.Location = new System.Drawing.Point(26, 464);
            this.btnVistaP.Name = "btnVistaP";
            this.btnVistaP.Size = new System.Drawing.Size(75, 23);
            this.btnVistaP.TabIndex = 18;
            this.btnVistaP.Text = "Vista Previa";
            this.btnVistaP.UseVisualStyleBackColor = true;
            this.btnVistaP.Click += new System.EventHandler(this.btnVistaP_Click);
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolio.ForeColor = System.Drawing.Color.Maroon;
            this.lblFolio.Location = new System.Drawing.Point(67, 14);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(47, 16);
            this.lblFolio.TabIndex = 16;
            this.lblFolio.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(26, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Folio:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(107, 423);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(473, 20);
            this.txtObservaciones.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Observaciones:";
            // 
            // adgvDatosFolios
            // 
            this.adgvDatosFolios.AllowUserToAddRows = false;
            this.adgvDatosFolios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvDatosFolios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folio,
            this.TipoServicio,
            this.Equipo,
            this.Noserie});
            this.adgvDatosFolios.FilterAndSortEnabled = true;
            this.adgvDatosFolios.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.adgvDatosFolios.Location = new System.Drawing.Point(19, 281);
            this.adgvDatosFolios.Name = "adgvDatosFolios";
            this.adgvDatosFolios.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.adgvDatosFolios.Size = new System.Drawing.Size(561, 134);
            this.adgvDatosFolios.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.adgvDatosFolios.TabIndex = 12;
            // 
            // cmbFolios
            // 
            this.cmbFolios.Enabled = false;
            this.cmbFolios.FormattingEnabled = true;
            this.cmbFolios.Location = new System.Drawing.Point(63, 254);
            this.cmbFolios.Name = "cmbFolios";
            this.cmbFolios.Size = new System.Drawing.Size(97, 21);
            this.cmbFolios.TabIndex = 11;
            this.cmbFolios.SelectedIndexChanged += new System.EventHandler(this.cmbFolios_SelectedIndexChanged);
            this.cmbFolios.Click += new System.EventHandler(this.cmbFolios_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Folios:";
            // 
            // dtpFechaAcuse
            // 
            this.dtpFechaAcuse.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAcuse.Location = new System.Drawing.Point(442, 71);
            this.dtpFechaAcuse.Name = "dtpFechaAcuse";
            this.dtpFechaAcuse.Size = new System.Drawing.Size(89, 20);
            this.dtpFechaAcuse.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha:";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.Enabled = false;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(345, 163);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(235, 21);
            this.cmbDepartamento.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Departamento:";
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.Enabled = false;
            this.cmbResponsable.FormattingEnabled = true;
            this.cmbResponsable.Location = new System.Drawing.Point(30, 163);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(250, 21);
            this.cmbResponsable.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Atención:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cliente:";
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // vDocumentacionBindingSource
            // 
            this.vDocumentacionBindingSource.DataMember = "V_Documentacion";
            this.vDocumentacionBindingSource.DataSource = this.browserDataSet;
            // 
            // browserDataSet
            // 
            this.browserDataSet.DataSetName = "BrowserDataSet";
            this.browserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_DocumentacionTableAdapter
            // 
            this.v_DocumentacionTableAdapter.ClearBeforeFill = true;
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "Folio";
            this.Folio.HeaderText = "Folio";
            this.Folio.MinimumWidth = 22;
            this.Folio.Name = "Folio";
            this.Folio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TipoServicio
            // 
            this.TipoServicio.DataPropertyName = "TipoServicio";
            this.TipoServicio.HeaderText = "Tipo de Servicio";
            this.TipoServicio.MinimumWidth = 22;
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TipoServicio.Width = 150;
            // 
            // Equipo
            // 
            this.Equipo.DataPropertyName = "Equipo";
            this.Equipo.HeaderText = "Equipo";
            this.Equipo.MinimumWidth = 22;
            this.Equipo.Name = "Equipo";
            this.Equipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Equipo.Width = 150;
            // 
            // Noserie
            // 
            this.Noserie.DataPropertyName = "NoSerie";
            this.Noserie.HeaderText = "N.S.";
            this.Noserie.MinimumWidth = 22;
            this.Noserie.Name = "Noserie";
            this.Noserie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // AcuseDocumentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 586);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(601, 586);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(601, 586);
            this.Name = "AcuseDocumentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acuse Documentación";
            this.Load += new System.EventHandler(this.AcuseDocumentacion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvDatosFolios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDocumentacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFolios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaAcuse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private Zuby.ADGV.AdvancedDataGridView adgvDatosFolios;
        private BrowserDataSet browserDataSet;
        private System.Windows.Forms.BindingSource vDocumentacionBindingSource;
        private BrowserDataSetTableAdapters.V_DocumentacionTableAdapter v_DocumentacionTableAdapter;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVistaP;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDireccion;
        private System.Windows.Forms.ComboBox cmbTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblGuia;
        private System.Windows.Forms.TextBox txtNoGuia;
        private System.Windows.Forms.CheckBox chkbEnvio;
        private System.Windows.Forms.ToolStripMenuItem listaDeAcusesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noserie;
    }
}