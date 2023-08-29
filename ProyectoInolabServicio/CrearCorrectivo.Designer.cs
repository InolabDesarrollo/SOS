namespace ProyectoInolabServicio
{
    partial class CrearCorrectivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearCorrectivo));
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbestatus = new System.Windows.Forms.ComboBox();
            this.fStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet = new ProyectoInolabServicio.BrowserDataSet();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtfallaReportada = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.cmbTServicio = new System.Windows.Forms.ComboBox();
            this.tipoServicioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtEquipo = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbing = new System.Windows.Forms.ComboBox();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtNoSerie = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNReportado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNResponsable = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLlamada = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.cmbTContrato = new System.Windows.Forms.ComboBox();
            this.tipoContratoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbTProblema = new System.Windows.Forms.ComboBox();
            this.tipoProblemaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbasesor = new System.Windows.Forms.ComboBox();
            this.vAsesorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtOC = new System.Windows.Forms.TextBox();
            this.txtCotizacion = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmbDiasServicio = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtIdequipo_C = new System.Windows.Forms.TextBox();
            this.f_StatusTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.F_StatusTableAdapter();
            this.tipo_ServicioTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.Tipo_ServicioTableAdapter();
            this.tipo_ContratoTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.Tipo_ContratoTableAdapter();
            this.tipo_ProblemaTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.Tipo_ProblemaTableAdapter();
            this.usuariosTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.UsuariosTableAdapter();
            this.v_AsesorTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.v_AsesorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.fStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoServicioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoContratoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoProblemaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vAsesorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(819, 430);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 39);
            this.btnGuardar.TabIndex = 214;
            this.btnGuardar.Text = "Guardar servicio";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(705, 89);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 13);
            this.label19.TabIndex = 213;
            this.label19.Text = "Estatus";
            // 
            // cmbestatus
            // 
            this.cmbestatus.DataSource = this.fStatusBindingSource;
            this.cmbestatus.DisplayMember = "Descripcion";
            this.cmbestatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbestatus.FormattingEnabled = true;
            this.cmbestatus.Location = new System.Drawing.Point(753, 84);
            this.cmbestatus.Name = "cmbestatus";
            this.cmbestatus.Size = new System.Drawing.Size(82, 21);
            this.cmbestatus.TabIndex = 212;
            this.cmbestatus.ValueMember = "IdStatus";
            // 
            // fStatusBindingSource
            // 
            this.fStatusBindingSource.DataMember = "F_Status";
            this.fStatusBindingSource.DataSource = this.browserDataSet;
            // 
            // browserDataSet
            // 
            this.browserDataSet.DataSetName = "BrowserDataSet";
            this.browserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(497, 182);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(100, 20);
            this.txtModelo.TabIndex = 211;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Location = new System.Drawing.Point(653, 315);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(85, 13);
            this.label26.TabIndex = 210;
            this.label26.Text = "Falla Reportada:";
            // 
            // txtfallaReportada
            // 
            this.txtfallaReportada.Location = new System.Drawing.Point(651, 328);
            this.txtfallaReportada.Multiline = true;
            this.txtfallaReportada.Name = "txtfallaReportada";
            this.txtfallaReportada.Size = new System.Drawing.Size(243, 68);
            this.txtfallaReportada.TabIndex = 209;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(648, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 208;
            this.label10.Text = "Tipo de Servicio";
            // 
            // dtpHora
            // 
            this.dtpHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dtpHora.FormattingEnabled = true;
            this.dtpHora.Items.AddRange(new object[] {
            "07:00",
            "07:30",
            "08:00",
            "08:30",
            "09:00",
            "09:30",
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30"});
            this.dtpHora.Location = new System.Drawing.Point(750, 141);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(85, 21);
            this.dtpHora.TabIndex = 207;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(750, 124);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 13);
            this.label21.TabIndex = 206;
            this.label21.Text = "Hora de Servicio";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(648, 124);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 13);
            this.label20.TabIndex = 205;
            this.label20.Text = "Fecha de Servicio:";
            // 
            // dtpfecha
            // 
            this.dtpfecha.CustomFormat = "yyyy-MM-dd";
            this.dtpfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfecha.Location = new System.Drawing.Point(651, 142);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(94, 19);
            this.dtpfecha.TabIndex = 204;
            this.dtpfecha.ValueChanged += new System.EventHandler(this.dtpfecha_ValueChanged);
            // 
            // cmbTServicio
            // 
            this.cmbTServicio.DataSource = this.tipoServicioBindingSource;
            this.cmbTServicio.DisplayMember = "Descripcion";
            this.cmbTServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTServicio.Enabled = false;
            this.cmbTServicio.FormattingEnabled = true;
            this.cmbTServicio.Location = new System.Drawing.Point(651, 198);
            this.cmbTServicio.Name = "cmbTServicio";
            this.cmbTServicio.Size = new System.Drawing.Size(153, 21);
            this.cmbTServicio.TabIndex = 203;
            this.cmbTServicio.ValueMember = "ID";
            // 
            // tipoServicioBindingSource
            // 
            this.tipoServicioBindingSource.DataMember = "Tipo_Servicio";
            this.tipoServicioBindingSource.DataSource = this.browserDataSet;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(362, 183);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(100, 20);
            this.txtMarca.TabIndex = 202;
            // 
            // txtEquipo
            // 
            this.txtEquipo.Enabled = false;
            this.txtEquipo.Location = new System.Drawing.Point(362, 140);
            this.txtEquipo.Name = "txtEquipo";
            this.txtEquipo.Size = new System.Drawing.Size(243, 20);
            this.txtEquipo.TabIndex = 201;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Location = new System.Drawing.Point(360, 309);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(203, 13);
            this.label22.TabIndex = 200;
            this.label22.Text = "Observaciones de la Solicitud de Servicio";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(363, 325);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(242, 68);
            this.txtObservaciones.TabIndex = 199;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(359, 252);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 13);
            this.label18.TabIndex = 198;
            this.label18.Text = "Ingeniero de Servicio";
            // 
            // cmbing
            // 
            this.cmbing.DataSource = this.usuariosBindingSource;
            this.cmbing.DisplayMember = "Nombre";
            this.cmbing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbing.FormattingEnabled = true;
            this.cmbing.Location = new System.Drawing.Point(362, 266);
            this.cmbing.Name = "cmbing";
            this.cmbing.Size = new System.Drawing.Size(243, 21);
            this.cmbing.TabIndex = 197;
            this.cmbing.ValueMember = "IdUsuario";
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "Usuarios";
            this.usuariosBindingSource.DataSource = this.browserDataSet;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(494, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 13);
            this.label12.TabIndex = 195;
            this.label12.Text = "Identificación del Equipo";
            // 
            // txtNoSerie
            // 
            this.txtNoSerie.Location = new System.Drawing.Point(362, 227);
            this.txtNoSerie.Name = "txtNoSerie";
            this.txtNoSerie.Size = new System.Drawing.Size(126, 20);
            this.txtNoSerie.TabIndex = 194;
            this.txtNoSerie.TextChanged += new System.EventHandler(this.txtNoSerie_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(359, 207);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 193;
            this.label13.Text = "No. Serie:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(494, 167);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 192;
            this.label14.Text = "Modelo:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(359, 167);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 13);
            this.label15.TabIndex = 191;
            this.label15.Text = "Marca:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(359, 124);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 190;
            this.label16.Text = "Equipo:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(16, 384);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(305, 20);
            this.txtMail.TabIndex = 189;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(15, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 188;
            this.label8.Text = "E-mail:";
            // 
            // txtNReportado
            // 
            this.txtNReportado.Location = new System.Drawing.Point(16, 345);
            this.txtNReportado.Name = "txtNReportado";
            this.txtNReportado.Size = new System.Drawing.Size(305, 20);
            this.txtNReportado.TabIndex = 187;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(13, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 186;
            this.label7.Text = "Reportado por:";
            // 
            // txtNResponsable
            // 
            this.txtNResponsable.Location = new System.Drawing.Point(16, 305);
            this.txtNResponsable.Name = "txtNResponsable";
            this.txtNResponsable.Size = new System.Drawing.Size(305, 20);
            this.txtNResponsable.TabIndex = 185;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(13, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 184;
            this.label6.Text = "Nombre del Responsable:";
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(144, 266);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(177, 20);
            this.txtDepto.TabIndex = 183;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(144, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 182;
            this.label5.Text = "Departamento:";
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(16, 227);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(305, 20);
            this.txtLocalidad.TabIndex = 181;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(15, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 180;
            this.label4.Text = "Localidad:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(16, 183);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(305, 20);
            this.txtDireccion.TabIndex = 179;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(13, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 178;
            this.label3.Text = "Dirección:";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(16, 266);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(122, 20);
            this.txtTel.TabIndex = 177;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(15, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 176;
            this.label2.Text = "Tel. Ext.:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 175;
            this.label1.Text = "Cliente/Empresa:";
            // 
            // lblLlamada
            // 
            this.lblLlamada.AutoSize = true;
            this.lblLlamada.BackColor = System.Drawing.Color.Transparent;
            this.lblLlamada.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLlamada.ForeColor = System.Drawing.Color.Maroon;
            this.lblLlamada.Location = new System.Drawing.Point(192, 73);
            this.lblLlamada.Name = "lblLlamada";
            this.lblLlamada.Size = new System.Drawing.Size(18, 19);
            this.lblLlamada.TabIndex = 174;
            this.lblLlamada.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DarkBlue;
            this.label17.Location = new System.Drawing.Point(12, 73);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(174, 19);
            this.label17.TabIndex = 173;
            this.label17.Text = "Solicitud de Llamada:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(16, 140);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(305, 20);
            this.txtCliente.TabIndex = 215;
            // 
            // cmbTContrato
            // 
            this.cmbTContrato.DataSource = this.tipoContratoBindingSource;
            this.cmbTContrato.DisplayMember = "Descripcion";
            this.cmbTContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTContrato.FormattingEnabled = true;
            this.cmbTContrato.Location = new System.Drawing.Point(651, 242);
            this.cmbTContrato.Name = "cmbTContrato";
            this.cmbTContrato.Size = new System.Drawing.Size(243, 21);
            this.cmbTContrato.TabIndex = 219;
            this.cmbTContrato.ValueMember = "ID";
            this.cmbTContrato.SelectedIndexChanged += new System.EventHandler(this.cmbTContrato_SelectedIndexChanged);
            // 
            // tipoContratoBindingSource
            // 
            this.tipoContratoBindingSource.DataMember = "Tipo_Contrato";
            this.tipoContratoBindingSource.DataSource = this.browserDataSet;
            // 
            // cmbTProblema
            // 
            this.cmbTProblema.DataSource = this.tipoProblemaBindingSource;
            this.cmbTProblema.DisplayMember = "Descripcion";
            this.cmbTProblema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTProblema.FormattingEnabled = true;
            this.cmbTProblema.Location = new System.Drawing.Point(651, 282);
            this.cmbTProblema.Name = "cmbTProblema";
            this.cmbTProblema.Size = new System.Drawing.Size(243, 21);
            this.cmbTProblema.TabIndex = 218;
            this.cmbTProblema.ValueMember = "ID";
            // 
            // tipoProblemaBindingSource
            // 
            this.tipoProblemaBindingSource.DataMember = "Tipo_Problema";
            this.tipoProblemaBindingSource.DataSource = this.browserDataSet;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(648, 228);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 217;
            this.label11.Text = "Tipo de Contrato:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(648, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 216;
            this.label9.Text = "Tipo de Problema:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Location = new System.Drawing.Point(363, 407);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(42, 13);
            this.label27.TabIndex = 221;
            this.label27.Text = "Asesor:";
            // 
            // cmbasesor
            // 
            this.cmbasesor.DataSource = this.vAsesorBindingSource;
            this.cmbasesor.DisplayMember = "Nombre";
            this.cmbasesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbasesor.FormattingEnabled = true;
            this.cmbasesor.Location = new System.Drawing.Point(411, 399);
            this.cmbasesor.Name = "cmbasesor";
            this.cmbasesor.Size = new System.Drawing.Size(177, 21);
            this.cmbasesor.TabIndex = 220;
            this.cmbasesor.ValueMember = "IdUsuario";
            // 
            // vAsesorBindingSource
            // 
            this.vAsesorBindingSource.DataMember = "v_Asesor";
            this.vAsesorBindingSource.DataSource = this.browserDataSet;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Location = new System.Drawing.Point(171, 414);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(22, 13);
            this.label25.TabIndex = 225;
            this.label25.Text = "OC";
            this.label25.Visible = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Location = new System.Drawing.Point(15, 414);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 13);
            this.label24.TabIndex = 224;
            this.label24.Text = "Cotización:";
            this.label24.Visible = false;
            // 
            // txtOC
            // 
            this.txtOC.Location = new System.Drawing.Point(168, 430);
            this.txtOC.Name = "txtOC";
            this.txtOC.Size = new System.Drawing.Size(153, 20);
            this.txtOC.TabIndex = 223;
            this.txtOC.Text = "---";
            this.txtOC.Visible = false;
            // 
            // txtCotizacion
            // 
            this.txtCotizacion.Location = new System.Drawing.Point(16, 430);
            this.txtCotizacion.Name = "txtCotizacion";
            this.txtCotizacion.Size = new System.Drawing.Size(146, 20);
            this.txtCotizacion.TabIndex = 222;
            this.txtCotizacion.Text = "---";
            this.txtCotizacion.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmbDiasServicio
            // 
            this.cmbDiasServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiasServicio.FormattingEnabled = true;
            this.cmbDiasServicio.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbDiasServicio.Location = new System.Drawing.Point(815, 198);
            this.cmbDiasServicio.Name = "cmbDiasServicio";
            this.cmbDiasServicio.Size = new System.Drawing.Size(57, 21);
            this.cmbDiasServicio.TabIndex = 226;
            this.cmbDiasServicio.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Location = new System.Drawing.Point(812, 182);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 13);
            this.label23.TabIndex = 227;
            this.label23.Text = "Dias de servicio";
            // 
            // txtIdequipo_C
            // 
            this.txtIdequipo_C.Location = new System.Drawing.Point(494, 228);
            this.txtIdequipo_C.Name = "txtIdequipo_C";
            this.txtIdequipo_C.Size = new System.Drawing.Size(111, 20);
            this.txtIdequipo_C.TabIndex = 196;
            // 
            // f_StatusTableAdapter
            // 
            this.f_StatusTableAdapter.ClearBeforeFill = true;
            // 
            // tipo_ServicioTableAdapter
            // 
            this.tipo_ServicioTableAdapter.ClearBeforeFill = true;
            // 
            // tipo_ContratoTableAdapter
            // 
            this.tipo_ContratoTableAdapter.ClearBeforeFill = true;
            // 
            // tipo_ProblemaTableAdapter
            // 
            this.tipo_ProblemaTableAdapter.ClearBeforeFill = true;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // v_AsesorTableAdapter
            // 
            this.v_AsesorTableAdapter.ClearBeforeFill = true;
            // 
            // CrearCorrectivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 477);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.cmbDiasServicio);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtOC);
            this.Controls.Add(this.txtCotizacion);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.cmbasesor);
            this.Controls.Add(this.cmbTContrato);
            this.Controls.Add(this.cmbTProblema);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbestatus);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtfallaReportada);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.dtpfecha);
            this.Controls.Add(this.cmbTServicio);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.txtEquipo);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cmbing);
            this.Controls.Add(this.txtIdequipo_C);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNoSerie);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNReportado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNResponsable);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLlamada);
            this.Controls.Add(this.label17);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(906, 477);
            this.Name = "CrearCorrectivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Correctivo";
            this.Load += new System.EventHandler(this.CrearCorrectivo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoServicioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoContratoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoProblemaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vAsesorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbestatus;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtfallaReportada;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox dtpHora;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.ComboBox cmbTServicio;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtEquipo;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbing;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNoSerie;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNReportado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNResponsable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLlamada;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ComboBox cmbTContrato;
        private System.Windows.Forms.ComboBox cmbTProblema;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cmbasesor;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtOC;
        private System.Windows.Forms.TextBox txtCotizacion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cmbDiasServicio;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtIdequipo_C;
        private BrowserDataSet browserDataSet;
        private System.Windows.Forms.BindingSource fStatusBindingSource;
        private BrowserDataSetTableAdapters.F_StatusTableAdapter f_StatusTableAdapter;
        private System.Windows.Forms.BindingSource tipoServicioBindingSource;
        private BrowserDataSetTableAdapters.Tipo_ServicioTableAdapter tipo_ServicioTableAdapter;
        private System.Windows.Forms.BindingSource tipoContratoBindingSource;
        private BrowserDataSetTableAdapters.Tipo_ContratoTableAdapter tipo_ContratoTableAdapter;
        private System.Windows.Forms.BindingSource tipoProblemaBindingSource;
        private BrowserDataSetTableAdapters.Tipo_ProblemaTableAdapter tipo_ProblemaTableAdapter;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private BrowserDataSetTableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.BindingSource vAsesorBindingSource;
        private BrowserDataSetTableAdapters.v_AsesorTableAdapter v_AsesorTableAdapter;
    }
}