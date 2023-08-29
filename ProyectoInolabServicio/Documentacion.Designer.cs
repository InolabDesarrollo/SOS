namespace ProyectoInolabServicio
{
    partial class Documentacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Documentacion));
            this.label1 = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.dtpfechaServicio = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEquipo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTServicio = new System.Windows.Forms.ComboBox();
            this.tipoServicioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet = new ProyectoInolabServicio.BrowserDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAsesor = new System.Windows.Forms.TextBox();
            this.txtNoSerie = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbIngeniero = new System.Windows.Forms.ComboBox();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cmbResponsable = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDocumenta = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lblEstatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbIncidencia = new System.Windows.Forms.ComboBox();
            this.incidenciasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtOtro = new System.Windows.Forms.TextBox();
            this.lblOtro = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtDgvIdIncidencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDgvTipoIncidencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.txtComentarios = new System.Windows.Forms.TextBox();
            this.usuariosTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.UsuariosTableAdapter();
            this.tipo_ServicioTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.Tipo_ServicioTableAdapter();
            this.incidenciasTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.IncidenciasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tipoServicioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidenciasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(27, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folio:";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.BackColor = System.Drawing.Color.Transparent;
            this.lblFolio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolio.ForeColor = System.Drawing.Color.Maroon;
            this.lblFolio.Location = new System.Drawing.Point(86, 78);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(18, 19);
            this.lblFolio.TabIndex = 2;
            this.lblFolio.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(477, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 96;
            this.label3.Text = "Ingeniero de servicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(28, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 98;
            this.label4.Text = "Cliente/Empresa:";
            // 
            // txtCliente
            // 
            this.txtCliente.Enabled = false;
            this.txtCliente.Location = new System.Drawing.Point(31, 145);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(298, 20);
            this.txtCliente.TabIndex = 99;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(350, 27);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(96, 13);
            this.label24.TabIndex = 101;
            this.label24.Text = "Fecha de Servicio:";
            // 
            // dtpfechaServicio
            // 
            this.dtpfechaServicio.CustomFormat = "yyyy-MM-dd";
            this.dtpfechaServicio.Enabled = false;
            this.dtpfechaServicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfechaServicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfechaServicio.Location = new System.Drawing.Point(352, 47);
            this.dtpfechaServicio.Name = "dtpfechaServicio";
            this.dtpfechaServicio.Size = new System.Drawing.Size(94, 19);
            this.dtpfechaServicio.TabIndex = 100;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 13);
            this.label12.TabIndex = 102;
            this.label12.Text = "Equipo";
            // 
            // txtEquipo
            // 
            this.txtEquipo.Enabled = false;
            this.txtEquipo.Location = new System.Drawing.Point(12, 46);
            this.txtEquipo.Name = "txtEquipo";
            this.txtEquipo.Size = new System.Drawing.Size(286, 20);
            this.txtEquipo.TabIndex = 103;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(641, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 106;
            this.label6.Text = "Tipo de servicio:";
            // 
            // cmbTServicio
            // 
            this.cmbTServicio.DataSource = this.tipoServicioBindingSource;
            this.cmbTServicio.DisplayMember = "Descripcion";
            this.cmbTServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTServicio.Enabled = false;
            this.cmbTServicio.FormattingEnabled = true;
            this.cmbTServicio.Location = new System.Drawing.Point(644, 45);
            this.cmbTServicio.Name = "cmbTServicio";
            this.cmbTServicio.Size = new System.Drawing.Size(121, 21);
            this.cmbTServicio.TabIndex = 107;
            this.cmbTServicio.ValueMember = "ID";
            // 
            // tipoServicioBindingSource
            // 
            this.tipoServicioBindingSource.DataMember = "Tipo_Servicio";
            this.tipoServicioBindingSource.DataSource = this.browserDataSet;
            // 
            // browserDataSet
            // 
            this.browserDataSet.DataSetName = "BrowserDataSet";
            this.browserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtAsesor);
            this.groupBox1.Controls.Add(this.txtNoSerie);
            this.groupBox1.Controls.Add(this.txtModelo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtMarca);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.dtpfechaServicio);
            this.groupBox1.Controls.Add(this.cmbTServicio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbIngeniero);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtEquipo);
            this.groupBox1.Location = new System.Drawing.Point(31, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(788, 153);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servicio";
            // 
            // txtAsesor
            // 
            this.txtAsesor.Enabled = false;
            this.txtAsesor.Location = new System.Drawing.Point(586, 107);
            this.txtAsesor.Name = "txtAsesor";
            this.txtAsesor.Size = new System.Drawing.Size(179, 20);
            this.txtAsesor.TabIndex = 115;
            // 
            // txtNoSerie
            // 
            this.txtNoSerie.Enabled = false;
            this.txtNoSerie.Location = new System.Drawing.Point(293, 107);
            this.txtNoSerie.Name = "txtNoSerie";
            this.txtNoSerie.Size = new System.Drawing.Size(128, 20);
            this.txtNoSerie.TabIndex = 114;
            // 
            // txtModelo
            // 
            this.txtModelo.Enabled = false;
            this.txtModelo.Location = new System.Drawing.Point(154, 107);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(119, 20);
            this.txtModelo.TabIndex = 113;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(583, 91);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 112;
            this.label11.Text = "Asesor";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(290, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 111;
            this.label10.Text = "No. de Serie";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(151, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 110;
            this.label9.Text = "Modelo";
            // 
            // txtMarca
            // 
            this.txtMarca.Enabled = false;
            this.txtMarca.Location = new System.Drawing.Point(12, 107);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(123, 20);
            this.txtMarca.TabIndex = 109;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 108;
            this.label5.Text = "Marca";
            // 
            // cmbIngeniero
            // 
            this.cmbIngeniero.DataSource = this.usuariosBindingSource;
            this.cmbIngeniero.DisplayMember = "Nombre";
            this.cmbIngeniero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIngeniero.Enabled = false;
            this.cmbIngeniero.FormattingEnabled = true;
            this.cmbIngeniero.Location = new System.Drawing.Point(480, 45);
            this.cmbIngeniero.Name = "cmbIngeniero";
            this.cmbIngeniero.Size = new System.Drawing.Size(121, 21);
            this.cmbIngeniero.TabIndex = 97;
            this.cmbIngeniero.ValueMember = "IdUsuario";
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "Usuarios";
            this.usuariosBindingSource.DataSource = this.browserDataSet;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(353, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 109;
            this.label7.Text = "Responsable:";
            // 
            // cmbResponsable
            // 
            this.cmbResponsable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResponsable.FormattingEnabled = true;
            this.cmbResponsable.Location = new System.Drawing.Point(356, 346);
            this.cmbResponsable.Name = "cmbResponsable";
            this.cmbResponsable.Size = new System.Drawing.Size(121, 21);
            this.cmbResponsable.TabIndex = 110;
            this.cmbResponsable.SelectedIndexChanged += new System.EventHandler(this.cmbResponsable_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(353, 382);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 111;
            this.label8.Text = "Documentador:";
            // 
            // cmbDocumenta
            // 
            this.cmbDocumenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumenta.FormattingEnabled = true;
            this.cmbDocumenta.Location = new System.Drawing.Point(356, 397);
            this.cmbDocumenta.Name = "cmbDocumenta";
            this.cmbDocumenta.Size = new System.Drawing.Size(121, 21);
            this.cmbDocumenta.TabIndex = 112;
            this.cmbDocumenta.SelectedIndexChanged += new System.EventHandler(this.cmDocumenta_SelectedIndexChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(738, 527);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 39);
            this.btnGuardar.TabIndex = 123;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DarkBlue;
            this.label15.Location = new System.Drawing.Point(613, 78);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 19);
            this.label15.TabIndex = 125;
            this.label15.Text = "Estatus Folio:";
            // 
            // lblEstatus
            // 
            this.lblEstatus.AutoSize = true;
            this.lblEstatus.BackColor = System.Drawing.Color.Transparent;
            this.lblEstatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstatus.ForeColor = System.Drawing.Color.Maroon;
            this.lblEstatus.Location = new System.Drawing.Point(734, 78);
            this.lblEstatus.Name = "lblEstatus";
            this.lblEstatus.Size = new System.Drawing.Size(85, 19);
            this.lblEstatus.TabIndex = 126;
            this.lblEstatus.Text = "lblEstatus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(695, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 127;
            this.label2.Text = "Estatus:";
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstatus.Enabled = false;
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Location = new System.Drawing.Point(698, 144);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(121, 21);
            this.cmbEstatus.TabIndex = 128;
            this.cmbEstatus.SelectedIndexChanged += new System.EventHandler(this.cmbEstatus_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(28, 330);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 146;
            this.label13.Text = "Incidencias:";
            // 
            // cmbIncidencia
            // 
            this.cmbIncidencia.DataSource = this.incidenciasBindingSource;
            this.cmbIncidencia.DisplayMember = "Descripcion";
            this.cmbIncidencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIncidencia.FormattingEnabled = true;
            this.cmbIncidencia.Location = new System.Drawing.Point(31, 346);
            this.cmbIncidencia.Name = "cmbIncidencia";
            this.cmbIncidencia.Size = new System.Drawing.Size(242, 21);
            this.cmbIncidencia.TabIndex = 147;
            this.cmbIncidencia.ValueMember = "IdIncidencia";
            this.cmbIncidencia.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // incidenciasBindingSource
            // 
            this.incidenciasBindingSource.DataMember = "Incidencias";
            this.incidenciasBindingSource.DataSource = this.browserDataSet;
            // 
            // txtOtro
            // 
            this.txtOtro.Location = new System.Drawing.Point(31, 546);
            this.txtOtro.Name = "txtOtro";
            this.txtOtro.Size = new System.Drawing.Size(295, 20);
            this.txtOtro.TabIndex = 149;
            this.txtOtro.Visible = false;
            // 
            // lblOtro
            // 
            this.lblOtro.AutoSize = true;
            this.lblOtro.BackColor = System.Drawing.Color.Transparent;
            this.lblOtro.Location = new System.Drawing.Point(28, 530);
            this.lblOtro.Name = "lblOtro";
            this.lblOtro.Size = new System.Drawing.Size(30, 13);
            this.lblOtro.TabIndex = 150;
            this.lblOtro.Text = "Otro:";
            this.lblOtro.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtDgvIdIncidencia,
            this.txtDgvTipoIncidencia});
            this.dataGridView1.Location = new System.Drawing.Point(31, 373);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 151;
            // 
            // txtDgvIdIncidencia
            // 
            this.txtDgvIdIncidencia.HeaderText = "IdIncidencia";
            this.txtDgvIdIncidencia.Name = "txtDgvIdIncidencia";
            this.txtDgvIdIncidencia.ReadOnly = true;
            this.txtDgvIdIncidencia.Visible = false;
            this.txtDgvIdIncidencia.Width = 20;
            // 
            // txtDgvTipoIncidencia
            // 
            this.txtDgvTipoIncidencia.HeaderText = "TipoIncidencia";
            this.txtDgvTipoIncidencia.Name = "txtDgvTipoIncidencia";
            this.txtDgvTipoIncidencia.ReadOnly = true;
            this.txtDgvTipoIncidencia.Width = 200;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(555, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 152;
            this.label14.Text = "Comentarios:";
            // 
            // txtComentarios
            // 
            this.txtComentarios.Location = new System.Drawing.Point(558, 346);
            this.txtComentarios.Multiline = true;
            this.txtComentarios.Name = "txtComentarios";
            this.txtComentarios.Size = new System.Drawing.Size(261, 59);
            this.txtComentarios.TabIndex = 153;
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // tipo_ServicioTableAdapter
            // 
            this.tipo_ServicioTableAdapter.ClearBeforeFill = true;
            // 
            // incidenciasTableAdapter
            // 
            this.incidenciasTableAdapter.ClearBeforeFill = true;
            // 
            // Documentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 578);
            this.Controls.Add(this.txtComentarios);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblOtro);
            this.Controls.Add(this.txtOtro);
            this.Controls.Add(this.cmbIncidencia);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbEstatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEstatus);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbDocumenta);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbResponsable);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblFolio);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(856, 578);
            this.Name = "Documentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar Folio Documentación";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tipoServicioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidenciasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker dtpfechaServicio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEquipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTServicio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbResponsable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDocumenta;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cmbIngeniero;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblEstatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.TextBox txtAsesor;
        private System.Windows.Forms.TextBox txtNoSerie;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbIncidencia;
        private System.Windows.Forms.TextBox txtOtro;
        private System.Windows.Forms.Label lblOtro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtComentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDgvIdIncidencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtDgvTipoIncidencia;
        private BrowserDataSet browserDataSet;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private BrowserDataSetTableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.BindingSource tipoServicioBindingSource;
        private BrowserDataSetTableAdapters.Tipo_ServicioTableAdapter tipo_ServicioTableAdapter;
        private System.Windows.Forms.BindingSource incidenciasBindingSource;
        private BrowserDataSetTableAdapters.IncidenciasTableAdapter incidenciasTableAdapter;
    }
}