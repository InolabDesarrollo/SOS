namespace ProyectoInolabServicio
{
    partial class FoliosDocumentacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoliosDocumentacion));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filtrarPorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sinDocuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rangoDeFechasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TcmbFiltroMes = new System.Windows.Forms.ToolStripComboBox();
            this.registrosDocumentacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.gridTxtFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noLlamadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEquipo_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modeloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingeniero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaServicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documentador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Responsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.responsableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbResponsable = new System.Windows.Forms.ToolStripComboBox();
            this.documentadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbDocument = new System.Windows.Forms.ToolStripComboBox();
            this.verFSRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargarEvidenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vFSRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet = new ProyectoInolabServicio.BrowserDataSet();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.v_FSRTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.V_FSRTableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vFSRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtrarPorToolStripMenuItem,
            this.registrosDocumentacionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(858, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // filtrarPorToolStripMenuItem
            // 
            this.filtrarPorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todosToolStripMenuItem1,
            this.sinDocuToolStripMenuItem1,
            this.rangoDeFechasToolStripMenuItem});
            this.filtrarPorToolStripMenuItem.Name = "filtrarPorToolStripMenuItem";
            this.filtrarPorToolStripMenuItem.Size = new System.Drawing.Size(85, 21);
            this.filtrarPorToolStripMenuItem.Text = "Filtrar por...";
            // 
            // todosToolStripMenuItem1
            // 
            this.todosToolStripMenuItem1.Name = "todosToolStripMenuItem1";
            this.todosToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.todosToolStripMenuItem1.Text = "Todos los folios";
            this.todosToolStripMenuItem1.Click += new System.EventHandler(this.todosToolStripMenuItem1_Click);
            // 
            // sinDocuToolStripMenuItem1
            // 
            this.sinDocuToolStripMenuItem1.Name = "sinDocuToolStripMenuItem1";
            this.sinDocuToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.sinDocuToolStripMenuItem1.Text = "Sin documentador";
            this.sinDocuToolStripMenuItem1.Click += new System.EventHandler(this.sinDocuToolStripMenuItem1_Click);
            // 
            // rangoDeFechasToolStripMenuItem
            // 
            this.rangoDeFechasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TcmbFiltroMes});
            this.rangoDeFechasToolStripMenuItem.Name = "rangoDeFechasToolStripMenuItem";
            this.rangoDeFechasToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.rangoDeFechasToolStripMenuItem.Text = "Mes";
            this.rangoDeFechasToolStripMenuItem.ToolTipText = "Mes de Fecha Fin Servicio";
            // 
            // TcmbFiltroMes
            // 
            this.TcmbFiltroMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.TcmbFiltroMes.Name = "TcmbFiltroMes";
            this.TcmbFiltroMes.Size = new System.Drawing.Size(121, 23);
            this.TcmbFiltroMes.SelectedIndexChanged += new System.EventHandler(this.TcmbFiltroMes_SelectedIndexChanged);
            this.TcmbFiltroMes.Click += new System.EventHandler(this.TcmbFiltroMes_Click);
            // 
            // registrosDocumentacionToolStripMenuItem
            // 
            this.registrosDocumentacionToolStripMenuItem.Name = "registrosDocumentacionToolStripMenuItem";
            this.registrosDocumentacionToolStripMenuItem.Size = new System.Drawing.Size(173, 21);
            this.registrosDocumentacionToolStripMenuItem.Text = "Registros Documentacion";
            this.registrosDocumentacionToolStripMenuItem.Click += new System.EventHandler(this.registrosDocumentacionToolStripMenuItem_Click);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.AutoGenerateColumns = false;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridTxtFolio,
            this.noLlamadaDataGridViewTextBoxColumn,
            this.estatusDataGridViewTextBoxColumn,
            this.clienteDataGridViewTextBoxColumn,
            this.TipoServicio,
            this.IdEquipo_C,
            this.equipoDataGridViewTextBoxColumn,
            this.marcaDataGridViewTextBoxColumn,
            this.modeloDataGridViewTextBoxColumn,
            this.noSerieDataGridViewTextBoxColumn,
            this.Ingeniero,
            this.fechaServicioDataGridViewTextBoxColumn,
            this.observacionesDataGridViewTextBoxColumn,
            this.mailDataGridViewTextBoxColumn,
            this.telefonoDataGridViewTextBoxColumn,
            this.direccionDataGridViewTextBoxColumn,
            this.Documentador,
            this.Responsable});
            this.advancedDataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.advancedDataGridView1.DataSource = this.vFSRBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advancedDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.advancedDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.advancedDataGridView1.Size = new System.Drawing.Size(858, 424);
            this.advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.TabIndex = 1;
            this.advancedDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellContentClick);
            this.advancedDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellDoubleClick);
            this.advancedDataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.advancedDataGridView1_CellFormatting);
            this.advancedDataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridView1_CellMouseUp);
            this.advancedDataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridView1_DataBindingComplete);
            this.advancedDataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.advancedDataGridView1_RowPostPaint);
            // 
            // gridTxtFolio
            // 
            this.gridTxtFolio.DataPropertyName = "Folio";
            this.gridTxtFolio.Frozen = true;
            this.gridTxtFolio.HeaderText = "Folio";
            this.gridTxtFolio.MinimumWidth = 22;
            this.gridTxtFolio.Name = "gridTxtFolio";
            this.gridTxtFolio.ReadOnly = true;
            this.gridTxtFolio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridTxtFolio.Width = 60;
            // 
            // noLlamadaDataGridViewTextBoxColumn
            // 
            this.noLlamadaDataGridViewTextBoxColumn.DataPropertyName = "NoLlamada";
            this.noLlamadaDataGridViewTextBoxColumn.Frozen = true;
            this.noLlamadaDataGridViewTextBoxColumn.HeaderText = "No. Llamada";
            this.noLlamadaDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.noLlamadaDataGridViewTextBoxColumn.Name = "noLlamadaDataGridViewTextBoxColumn";
            this.noLlamadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.noLlamadaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.noLlamadaDataGridViewTextBoxColumn.Width = 60;
            // 
            // estatusDataGridViewTextBoxColumn
            // 
            this.estatusDataGridViewTextBoxColumn.DataPropertyName = "Estatus";
            this.estatusDataGridViewTextBoxColumn.Frozen = true;
            this.estatusDataGridViewTextBoxColumn.HeaderText = "Estatus";
            this.estatusDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.estatusDataGridViewTextBoxColumn.Name = "estatusDataGridViewTextBoxColumn";
            this.estatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.estatusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.estatusDataGridViewTextBoxColumn.Width = 75;
            // 
            // clienteDataGridViewTextBoxColumn
            // 
            this.clienteDataGridViewTextBoxColumn.DataPropertyName = "Cliente";
            this.clienteDataGridViewTextBoxColumn.Frozen = true;
            this.clienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.clienteDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.clienteDataGridViewTextBoxColumn.Name = "clienteDataGridViewTextBoxColumn";
            this.clienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clienteDataGridViewTextBoxColumn.Width = 160;
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
            // IdEquipo_C
            // 
            this.IdEquipo_C.DataPropertyName = "IdEquipo_C";
            this.IdEquipo_C.HeaderText = "IdEquipo";
            this.IdEquipo_C.MinimumWidth = 22;
            this.IdEquipo_C.Name = "IdEquipo_C";
            this.IdEquipo_C.ReadOnly = true;
            this.IdEquipo_C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // equipoDataGridViewTextBoxColumn
            // 
            this.equipoDataGridViewTextBoxColumn.DataPropertyName = "Equipo";
            this.equipoDataGridViewTextBoxColumn.HeaderText = "Equipo";
            this.equipoDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.equipoDataGridViewTextBoxColumn.Name = "equipoDataGridViewTextBoxColumn";
            this.equipoDataGridViewTextBoxColumn.ReadOnly = true;
            this.equipoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.equipoDataGridViewTextBoxColumn.Width = 120;
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            this.marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            this.marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.marcaDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            this.marcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.marcaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.marcaDataGridViewTextBoxColumn.Width = 120;
            // 
            // modeloDataGridViewTextBoxColumn
            // 
            this.modeloDataGridViewTextBoxColumn.DataPropertyName = "Modelo";
            this.modeloDataGridViewTextBoxColumn.HeaderText = "Modelo";
            this.modeloDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.modeloDataGridViewTextBoxColumn.Name = "modeloDataGridViewTextBoxColumn";
            this.modeloDataGridViewTextBoxColumn.ReadOnly = true;
            this.modeloDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.modeloDataGridViewTextBoxColumn.Width = 120;
            // 
            // noSerieDataGridViewTextBoxColumn
            // 
            this.noSerieDataGridViewTextBoxColumn.DataPropertyName = "NoSerie";
            this.noSerieDataGridViewTextBoxColumn.HeaderText = "NoSerie";
            this.noSerieDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.noSerieDataGridViewTextBoxColumn.Name = "noSerieDataGridViewTextBoxColumn";
            this.noSerieDataGridViewTextBoxColumn.ReadOnly = true;
            this.noSerieDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Ingeniero
            // 
            this.Ingeniero.DataPropertyName = "Ingeniero";
            this.Ingeniero.HeaderText = "Ingeniero";
            this.Ingeniero.MinimumWidth = 22;
            this.Ingeniero.Name = "Ingeniero";
            this.Ingeniero.ReadOnly = true;
            this.Ingeniero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Ingeniero.Width = 150;
            // 
            // fechaServicioDataGridViewTextBoxColumn
            // 
            this.fechaServicioDataGridViewTextBoxColumn.DataPropertyName = "FechaServicio";
            this.fechaServicioDataGridViewTextBoxColumn.HeaderText = "Fecha de Servicio";
            this.fechaServicioDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.fechaServicioDataGridViewTextBoxColumn.Name = "fechaServicioDataGridViewTextBoxColumn";
            this.fechaServicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaServicioDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // observacionesDataGridViewTextBoxColumn
            // 
            this.observacionesDataGridViewTextBoxColumn.DataPropertyName = "Observaciones";
            this.observacionesDataGridViewTextBoxColumn.HeaderText = "Observaciones";
            this.observacionesDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.observacionesDataGridViewTextBoxColumn.Name = "observacionesDataGridViewTextBoxColumn";
            this.observacionesDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacionesDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.observacionesDataGridViewTextBoxColumn.Width = 170;
            // 
            // mailDataGridViewTextBoxColumn
            // 
            this.mailDataGridViewTextBoxColumn.DataPropertyName = "Mail";
            this.mailDataGridViewTextBoxColumn.HeaderText = "Mail";
            this.mailDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.mailDataGridViewTextBoxColumn.Name = "mailDataGridViewTextBoxColumn";
            this.mailDataGridViewTextBoxColumn.ReadOnly = true;
            this.mailDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            this.telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            this.telefonoDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            this.telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.telefonoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // direccionDataGridViewTextBoxColumn
            // 
            this.direccionDataGridViewTextBoxColumn.DataPropertyName = "Direccion";
            this.direccionDataGridViewTextBoxColumn.HeaderText = "Direccion";
            this.direccionDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.direccionDataGridViewTextBoxColumn.Name = "direccionDataGridViewTextBoxColumn";
            this.direccionDataGridViewTextBoxColumn.ReadOnly = true;
            this.direccionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.direccionDataGridViewTextBoxColumn.Width = 180;
            // 
            // Documentador
            // 
            this.Documentador.DataPropertyName = "Documentador";
            this.Documentador.HeaderText = "Documentador";
            this.Documentador.MinimumWidth = 22;
            this.Documentador.Name = "Documentador";
            this.Documentador.ReadOnly = true;
            this.Documentador.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // Responsable
            // 
            this.Responsable.DataPropertyName = "Responsable";
            this.Responsable.HeaderText = "Responsable";
            this.Responsable.MinimumWidth = 22;
            this.Responsable.Name = "Responsable";
            this.Responsable.ReadOnly = true;
            this.Responsable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.responsableToolStripMenuItem,
            this.documentadorToolStripMenuItem,
            this.verFSRToolStripMenuItem,
            this.descargarEvidenciaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // responsableToolStripMenuItem
            // 
            this.responsableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbResponsable});
            this.responsableToolStripMenuItem.Name = "responsableToolStripMenuItem";
            this.responsableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.responsableToolStripMenuItem.Text = "Responsable";
            this.responsableToolStripMenuItem.Click += new System.EventHandler(this.responsableToolStripMenuItem_Click);
            // 
            // cbResponsable
            // 
            this.cbResponsable.Items.AddRange(new object[] {
            "Aliz",
            "Iskra",
            "Lorena"});
            this.cbResponsable.Name = "cbResponsable";
            this.cbResponsable.Size = new System.Drawing.Size(121, 23);
            // 
            // documentadorToolStripMenuItem
            // 
            this.documentadorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbDocument});
            this.documentadorToolStripMenuItem.Name = "documentadorToolStripMenuItem";
            this.documentadorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.documentadorToolStripMenuItem.Text = "Documentador";
            this.documentadorToolStripMenuItem.Click += new System.EventHandler(this.documentadorToolStripMenuItem_Click);
            // 
            // cbDocument
            // 
            this.cbDocument.Items.AddRange(new object[] {
            "Adela Torres",
            "Alejandra Gutierrez",
            "Alicia Ruiz",
            "Alizbeth Segura",
            "Carmen Patiño",
            "Cinthia Martinez",
            "Edgar Aguilar",
            "Fernanda Rodriguez",
            "Iskra Cruz",
            "Itzel Figueroa",
            "Jennifer Velasco",
            "Jessica Nieto",
            "Judith Tamayo",
            "Lorena Reyes",
            "Luis Alcantara",
            "Monica Pichardo",
            "Rosario Martinez",
            "Sonia Mendoza",
            "Patricia Rodriguez",
            "Cinthia Torres",
            "Brenda Pacheco",
            "Josue Gomez",
            "Marco Galicia",
            "Andrea Miranda",
            "Regina Siordia"});
            this.cbDocument.Name = "cbDocument";
            this.cbDocument.Size = new System.Drawing.Size(121, 23);
            this.cbDocument.Click += new System.EventHandler(this.cbDocument_Click);
            // 
            // verFSRToolStripMenuItem
            // 
            this.verFSRToolStripMenuItem.Name = "verFSRToolStripMenuItem";
            this.verFSRToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verFSRToolStripMenuItem.Text = "Ver FSR";
            this.verFSRToolStripMenuItem.Click += new System.EventHandler(this.verFSRToolStripMenuItem_Click);
            // 
            // descargarEvidenciaToolStripMenuItem
            // 
            this.descargarEvidenciaToolStripMenuItem.Name = "descargarEvidenciaToolStripMenuItem";
            this.descargarEvidenciaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.descargarEvidenciaToolStripMenuItem.Text = "Descargar evidencia";
            this.descargarEvidenciaToolStripMenuItem.Visible = false;
            this.descargarEvidenciaToolStripMenuItem.Click += new System.EventHandler(this.descargarEvidenciaToolStripMenuItem_Click);
            // 
            // vFSRBindingSource
            // 
            this.vFSRBindingSource.DataMember = "V_FSR";
            this.vFSRBindingSource.DataSource = this.browserDataSet;
            // 
            // browserDataSet
            // 
            this.browserDataSet.DataSetName = "BrowserDataSet";
            this.browserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.advancedDataGridView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(858, 424);
            this.toolStripContainer1.Location = new System.Drawing.Point(2, 63);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(858, 449);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRegistros.Location = new System.Drawing.Point(746, 32);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(54, 15);
            this.lblRegistros.TabIndex = 3;
            this.lblRegistros.Text = "registros";
            // 
            // v_FSRTableAdapter
            // 
            this.v_FSRTableAdapter.ClearBeforeFill = true;
            // 
            // FoliosDocumentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 512);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(861, 512);
            this.Name = "FoliosDocumentacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FSR para documentacion";
            this.Load += new System.EventHandler(this.FoliosDocumentacion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vFSRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).EndInit();
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
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem responsableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cbResponsable;
        private System.Windows.Forms.ToolStripComboBox cbDocument;
        private System.Windows.Forms.ToolStripMenuItem registrosDocumentacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtrarPorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sinDocuToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rangoDeFechasToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox TcmbFiltroMes;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem verFSRToolStripMenuItem;
        private BrowserDataSet browserDataSet;
        private System.Windows.Forms.BindingSource vFSRBindingSource;
        private BrowserDataSetTableAdapters.V_FSRTableAdapter v_FSRTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem descargarEvidenciaToolStripMenuItem;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTxtFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn noLlamadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEquipo_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modeloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingeniero;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaServicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documentador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Responsable;
    }
}