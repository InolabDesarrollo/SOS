namespace ProyectoInolabServicio
{
    partial class VistaProtocolo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaProtocolo));
            this.lblProto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaSolicitudServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vFSRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSBrowser = new ProyectoInolabServicio.DSBrowser();
            this.v_FSRTableAdapter = new ProyectoInolabServicio.DSBrowserTableAdapters.V_FSRTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtResponsable = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMailResp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLlamada = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.llamadasSAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.llamadas_SAPTableAdapter = new ProyectoInolabServicio.DSBrowserTableAdapters.Llamadas_SAPTableAdapter();
            this.llamadasSAP2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.llamadas_SAP2TableAdapter = new ProyectoInolabServicio.DSBrowserTableAdapters.Llamadas_SAP2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vFSRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.llamadasSAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.llamadasSAP2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProto
            // 
            this.lblProto.AutoSize = true;
            this.lblProto.BackColor = System.Drawing.Color.Transparent;
            this.lblProto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProto.ForeColor = System.Drawing.Color.Maroon;
            this.lblProto.Location = new System.Drawing.Point(120, 79);
            this.lblProto.Name = "lblProto";
            this.lblProto.Size = new System.Drawing.Size(18, 19);
            this.lblProto.TabIndex = 4;
            this.lblProto.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(24, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Protocolo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 100;
            this.label4.Text = "Cliente/Empresa:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(26, 179);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(298, 20);
            this.txtCliente.TabIndex = 101;
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.TipoServicio,
            this.Equipo,
            this.Marca,
            this.Modelo,
            this.noSerie,
            this.FechaSolicitudServicio,
            this.Comentarios,
            this.Folio,
            this.TipoContrato});
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(12, 278);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(772, 202);
            this.advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.TabIndex = 102;
            this.advancedDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellContentClick);
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Estatus";
            this.Status.HeaderText = "Estatus";
            this.Status.MinimumWidth = 22;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Status.Width = 80;
            // 
            // TipoServicio
            // 
            this.TipoServicio.DataPropertyName = "TipoServicio";
            this.TipoServicio.HeaderText = "TipoServicio";
            this.TipoServicio.MinimumWidth = 22;
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.ReadOnly = true;
            this.TipoServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Equipo
            // 
            this.Equipo.DataPropertyName = "Equipo";
            this.Equipo.HeaderText = "Equipo";
            this.Equipo.MinimumWidth = 22;
            this.Equipo.Name = "Equipo";
            this.Equipo.ReadOnly = true;
            this.Equipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "Marca";
            this.Marca.HeaderText = "Marca";
            this.Marca.MinimumWidth = 22;
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            this.Marca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Marca.Width = 80;
            // 
            // Modelo
            // 
            this.Modelo.DataPropertyName = "Modelo";
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.MinimumWidth = 22;
            this.Modelo.Name = "Modelo";
            this.Modelo.ReadOnly = true;
            this.Modelo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Modelo.Width = 80;
            // 
            // noSerie
            // 
            this.noSerie.DataPropertyName = "noSerie";
            this.noSerie.HeaderText = "noSerie";
            this.noSerie.MinimumWidth = 22;
            this.noSerie.Name = "noSerie";
            this.noSerie.ReadOnly = true;
            this.noSerie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.noSerie.Width = 80;
            // 
            // FechaSolicitudServicio
            // 
            this.FechaSolicitudServicio.DataPropertyName = "FechaSolicitudServicio";
            this.FechaSolicitudServicio.HeaderText = "FechaSolicitudServicio";
            this.FechaSolicitudServicio.MinimumWidth = 22;
            this.FechaSolicitudServicio.Name = "FechaSolicitudServicio";
            this.FechaSolicitudServicio.ReadOnly = true;
            this.FechaSolicitudServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FechaSolicitudServicio.Width = 80;
            // 
            // Comentarios
            // 
            this.Comentarios.DataPropertyName = "Comentarios";
            this.Comentarios.HeaderText = "Comentarios";
            this.Comentarios.MinimumWidth = 22;
            this.Comentarios.Name = "Comentarios";
            this.Comentarios.ReadOnly = true;
            this.Comentarios.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Comentarios.Width = 150;
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "FolioFSR";
            this.Folio.HeaderText = "FolioFSR";
            this.Folio.MinimumWidth = 22;
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            this.Folio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Folio.Width = 70;
            // 
            // TipoContrato
            // 
            this.TipoContrato.DataPropertyName = "TipoContrato";
            this.TipoContrato.HeaderText = "TipoContrato";
            this.TipoContrato.MinimumWidth = 22;
            this.TipoContrato.Name = "TipoContrato";
            this.TipoContrato.ReadOnly = true;
            this.TipoContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TipoContrato.Width = 75;
            // 
            // vFSRBindingSource
            // 
            this.vFSRBindingSource.DataMember = "V_FSR";
            this.vFSRBindingSource.DataSource = this.dSBrowser;
            // 
            // dSBrowser
            // 
            this.dSBrowser.DataSetName = "DSBrowser";
            this.dSBrowser.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_FSRTableAdapter
            // 
            this.v_FSRTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(26, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 103;
            this.label2.Text = "Direccion:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(29, 223);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(295, 20);
            this.txtDireccion.TabIndex = 104;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(593, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 105;
            this.label3.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Location = new System.Drawing.Point(596, 223);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(120, 20);
            this.txtTelefono.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(418, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 107;
            this.label5.Text = "Responsable:";
            // 
            // txtResponsable
            // 
            this.txtResponsable.Enabled = false;
            this.txtResponsable.Location = new System.Drawing.Point(421, 179);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Size = new System.Drawing.Size(295, 20);
            this.txtResponsable.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(32, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "Servicios:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(418, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 110;
            this.label7.Text = "Correo:";
            // 
            // txtMailResp
            // 
            this.txtMailResp.Enabled = false;
            this.txtMailResp.Location = new System.Drawing.Point(421, 223);
            this.txtMailResp.Name = "txtMailResp";
            this.txtMailResp.Size = new System.Drawing.Size(150, 20);
            this.txtMailResp.TabIndex = 111;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(593, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 112;
            this.label8.Text = "Estatus:";
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatus.Enabled = false;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Items.AddRange(new object[] {
            "Sin Asignar",
            "Realizando",
            "Revision",
            "Correccion",
            "Aprobado",
            "Enviado electronico",
            "Enviado fisico"});
            this.cmbEstatus.Location = new System.Drawing.Point(645, 82);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(108, 21);
            this.cmbEstatus.TabIndex = 113;
            this.cmbEstatus.SelectedIndexChanged += new System.EventHandler(this.cmbEstatus_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(26, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 114;
            this.label9.Text = "No. Llamada:";
            // 
            // txtLlamada
            // 
            this.txtLlamada.Enabled = false;
            this.txtLlamada.Location = new System.Drawing.Point(102, 122);
            this.txtLlamada.Name = "txtLlamada";
            this.txtLlamada.Size = new System.Drawing.Size(100, 20);
            this.txtLlamada.TabIndex = 115;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(709, 512);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 32);
            this.btnGuardar.TabIndex = 116;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // llamadasSAPBindingSource
            // 
            this.llamadasSAPBindingSource.DataMember = "Llamadas_SAP";
            this.llamadasSAPBindingSource.DataSource = this.dSBrowser;
            // 
            // llamadas_SAPTableAdapter
            // 
            this.llamadas_SAPTableAdapter.ClearBeforeFill = true;
            // 
            // llamadasSAP2BindingSource
            // 
            this.llamadasSAP2BindingSource.DataMember = "Llamadas_SAP2";
            this.llamadasSAP2BindingSource.DataSource = this.dSBrowser;
            // 
            // llamadas_SAP2TableAdapter
            // 
            this.llamadas_SAP2TableAdapter.ClearBeforeFill = true;
            // 
            // VistaProtocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 553);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtLlamada);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbEstatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtMailResp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtResponsable);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.advancedDataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblProto);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 553);
            this.Name = "VistaProtocolo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VistaProtocolo";
            this.Load += new System.EventHandler(this.VistaProtocolo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vFSRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.llamadasSAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.llamadasSAP2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblProto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private DSBrowser dSBrowser;
        private System.Windows.Forms.BindingSource vFSRBindingSource;
        private DSBrowserTableAdapters.V_FSRTableAdapter v_FSRTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtResponsable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMailResp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLlamada;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.BindingSource llamadasSAPBindingSource;
        private DSBrowserTableAdapters.Llamadas_SAPTableAdapter llamadas_SAPTableAdapter;
        private System.Windows.Forms.BindingSource llamadasSAP2BindingSource;
        private DSBrowserTableAdapters.Llamadas_SAP2TableAdapter llamadas_SAP2TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn noSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaSolicitudServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoContrato;
    }
}