namespace ProyectoInolabServicio
{
    partial class ActualizaProtocolo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizaProtocolo));
            this.txtLlamada = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMailResp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtResponsable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.vLlamadasSAPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet = new ProyectoInolabServicio.BrowserDataSet();
            this.llamadasSAP2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblProto = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.llamadas_SAP2TableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.Llamadas_SAP2TableAdapter();
            this.v_LlamadasSAPTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.V_LlamadasSAPTableAdapter();
            this.IDActividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicioActividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folioFSR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentariosLlamada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarios = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbEstatusP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbRealiza = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vLlamadasSAPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.llamadasSAP2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLlamada
            // 
            this.txtLlamada.Enabled = false;
            this.txtLlamada.Location = new System.Drawing.Point(102, 126);
            this.txtLlamada.Name = "txtLlamada";
            this.txtLlamada.Size = new System.Drawing.Size(59, 20);
            this.txtLlamada.TabIndex = 133;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(26, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 132;
            this.label9.Text = "No. Llamada:";
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Items.AddRange(new object[] {
            "Sin Asignar",
            "Realizando",
            "Revision",
            "Correccion",
            "Aprobado",
            "Enviado electronico",
            "Enviado fisico"});
            this.cmbEstatus.Location = new System.Drawing.Point(645, 86);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(108, 21);
            this.cmbEstatus.TabIndex = 131;
            this.cmbEstatus.Visible = false;
            this.cmbEstatus.SelectedIndexChanged += new System.EventHandler(this.cmbEstatus_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(593, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 130;
            this.label8.Text = "Estatus:";
            this.label8.Visible = false;
            // 
            // txtMailResp
            // 
            this.txtMailResp.Location = new System.Drawing.Point(421, 227);
            this.txtMailResp.Name = "txtMailResp";
            this.txtMailResp.Size = new System.Drawing.Size(150, 20);
            this.txtMailResp.TabIndex = 129;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(418, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 128;
            this.label7.Text = "Correo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(25, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "Servicios:";
            // 
            // txtResponsable
            // 
            this.txtResponsable.Location = new System.Drawing.Point(421, 183);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Size = new System.Drawing.Size(295, 20);
            this.txtResponsable.TabIndex = 126;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(418, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Responsable:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(596, 227);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(120, 20);
            this.txtTelefono.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(593, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 123;
            this.label3.Text = "Telefono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(29, 227);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(295, 20);
            this.txtDireccion.TabIndex = 122;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(26, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Direccion:";
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AutoGenerateColumns = false;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDActividad,
            this.TipoServicio,
            this.Equipo,
            this.Marca,
            this.Modelo,
            this.NoSerie,
            this.FechaInicioActividad,
            this.folioFSR,
            this.comentariosLlamada,
            this.comentarios,
            this.cmbEstatusP,
            this.cmbRealiza});
            this.advancedDataGridView1.DataSource = this.vLlamadasSAPBindingSource;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(12, 285);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(772, 202);
            this.advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.TabIndex = 120;
            this.advancedDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellContentClick);
            // 
            // vLlamadasSAPBindingSource
            // 
            this.vLlamadasSAPBindingSource.DataMember = "V_LlamadasSAP";
            this.vLlamadasSAPBindingSource.DataSource = this.browserDataSet;
            // 
            // browserDataSet
            // 
            this.browserDataSet.DataSetName = "BrowserDataSet";
            this.browserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // llamadasSAP2BindingSource
            // 
            this.llamadasSAP2BindingSource.DataMember = "Llamadas_SAP2";
            this.llamadasSAP2BindingSource.DataSource = this.browserDataSet;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(23, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 118;
            this.label4.Text = "Cliente/Empresa:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(26, 183);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(298, 20);
            this.txtCliente.TabIndex = 119;
            // 
            // lblProto
            // 
            this.lblProto.AutoSize = true;
            this.lblProto.BackColor = System.Drawing.Color.Transparent;
            this.lblProto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProto.ForeColor = System.Drawing.Color.Maroon;
            this.lblProto.Location = new System.Drawing.Point(120, 83);
            this.lblProto.Name = "lblProto";
            this.lblProto.Size = new System.Drawing.Size(18, 19);
            this.lblProto.TabIndex = 117;
            this.lblProto.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(24, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 116;
            this.label1.Text = "Protocolo:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(713, 517);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 34);
            this.btnActualizar.TabIndex = 136;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(418, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 137;
            this.label10.Text = "Realiza:";
            this.label10.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Fernanda",
            "Bianca",
            "Monica",
            "Maria Fernanda",
            "Ricardo"});
            this.comboBox1.Location = new System.Drawing.Point(469, 126);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(169, 21);
            this.comboBox1.TabIndex = 138;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // llamadas_SAP2TableAdapter
            // 
            this.llamadas_SAP2TableAdapter.ClearBeforeFill = true;
            // 
            // v_LlamadasSAPTableAdapter
            // 
            this.v_LlamadasSAPTableAdapter.ClearBeforeFill = true;
            // 
            // IDActividad
            // 
            this.IDActividad.DataPropertyName = "IDActividad";
            this.IDActividad.HeaderText = "Actividad SAP";
            this.IDActividad.MinimumWidth = 22;
            this.IDActividad.Name = "IDActividad";
            this.IDActividad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.IDActividad.Width = 80;
            // 
            // TipoServicio
            // 
            this.TipoServicio.DataPropertyName = "TipoServicio";
            this.TipoServicio.HeaderText = "TipoServicio";
            this.TipoServicio.MinimumWidth = 22;
            this.TipoServicio.Name = "TipoServicio";
            this.TipoServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Equipo
            // 
            this.Equipo.DataPropertyName = "Equipo";
            this.Equipo.HeaderText = "Equipo";
            this.Equipo.MinimumWidth = 22;
            this.Equipo.Name = "Equipo";
            this.Equipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Equipo.Width = 80;
            // 
            // Marca
            // 
            this.Marca.DataPropertyName = "Marca";
            this.Marca.HeaderText = "Marca";
            this.Marca.MinimumWidth = 22;
            this.Marca.Name = "Marca";
            this.Marca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Marca.Width = 80;
            // 
            // Modelo
            // 
            this.Modelo.DataPropertyName = "Modelo";
            this.Modelo.HeaderText = "Modelo";
            this.Modelo.MinimumWidth = 22;
            this.Modelo.Name = "Modelo";
            this.Modelo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Modelo.Width = 80;
            // 
            // NoSerie
            // 
            this.NoSerie.DataPropertyName = "NoSerie";
            this.NoSerie.HeaderText = "NoSerie";
            this.NoSerie.MinimumWidth = 22;
            this.NoSerie.Name = "NoSerie";
            this.NoSerie.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.NoSerie.Width = 80;
            // 
            // FechaInicioActividad
            // 
            this.FechaInicioActividad.DataPropertyName = "FechaSolicitudServicio";
            this.FechaInicioActividad.HeaderText = "Fecha Comercial";
            this.FechaInicioActividad.MinimumWidth = 22;
            this.FechaInicioActividad.Name = "FechaInicioActividad";
            this.FechaInicioActividad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FechaInicioActividad.Width = 80;
            // 
            // folioFSR
            // 
            this.folioFSR.DataPropertyName = "FolioFSR";
            this.folioFSR.HeaderText = "FolioFSR";
            this.folioFSR.MinimumWidth = 22;
            this.folioFSR.Name = "folioFSR";
            this.folioFSR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.folioFSR.Width = 80;
            // 
            // comentariosLlamada
            // 
            this.comentariosLlamada.DataPropertyName = "ComentariosLlamada";
            this.comentariosLlamada.HeaderText = "ComentariosLlamada";
            this.comentariosLlamada.MinimumWidth = 22;
            this.comentariosLlamada.Name = "comentariosLlamada";
            this.comentariosLlamada.ReadOnly = true;
            this.comentariosLlamada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.comentariosLlamada.Width = 150;
            // 
            // comentarios
            // 
            this.comentarios.DataPropertyName = "Comentarios";
            this.comentarios.HeaderText = "Observaciones de Llamada";
            this.comentarios.MinimumWidth = 22;
            this.comentarios.Name = "comentarios";
            this.comentarios.ReadOnly = true;
            this.comentarios.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.comentarios.Width = 150;
            // 
            // cmbEstatusP
            // 
            this.cmbEstatusP.AutoComplete = false;
            this.cmbEstatusP.DataPropertyName = "EstatusP";
            this.cmbEstatusP.HeaderText = "EstatusProtocolo";
            this.cmbEstatusP.Items.AddRange(new object[] {
            "Sin Asignar",
            "Realizando",
            "Revision",
            "Correccion",
            "Aprobado",
            "Enviado electronico",
            "Enviado Fisico"});
            this.cmbEstatusP.MinimumWidth = 22;
            this.cmbEstatusP.Name = "cmbEstatusP";
            this.cmbEstatusP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // cmbRealiza
            // 
            this.cmbRealiza.HeaderText = "Realiza";
            this.cmbRealiza.Items.AddRange(new object[] {
            "Bianca",
            "Fernanda",
            "Monica",
            "Maria Fernanda",
            "Ricardo",
            "Clara Lizbeth"});
            this.cmbRealiza.MinimumWidth = 22;
            this.cmbRealiza.Name = "cmbRealiza";
            this.cmbRealiza.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ActualizaProtocolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 563);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnActualizar);
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
            this.MaximumSize = new System.Drawing.Size(800, 563);
            this.Name = "ActualizaProtocolo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Protocolo";
            this.Load += new System.EventHandler(this.ActualizaProtocolo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vLlamadasSAPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.llamadasSAP2BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtLlamada;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMailResp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtResponsable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label2;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblProto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Timer timer1;
        private BrowserDataSet browserDataSet;
        private System.Windows.Forms.BindingSource llamadasSAP2BindingSource;
        private BrowserDataSetTableAdapters.Llamadas_SAP2TableAdapter llamadas_SAP2TableAdapter;
        private System.Windows.Forms.BindingSource vLlamadasSAPBindingSource;
        private BrowserDataSetTableAdapters.V_LlamadasSAPTableAdapter v_LlamadasSAPTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicioActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn folioFSR;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentariosLlamada;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarios;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbEstatusP;
        private System.Windows.Forms.DataGridViewComboBoxColumn cmbRealiza;
    }
}