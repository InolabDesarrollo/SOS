namespace ProyectoInolabServicio
{
    partial class SeguimientoFolios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeguimientoFolios));
            this.advancedDataGridView2 = new Zuby.ADGV.AdvancedDataGridView();
            this.gridFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noSerieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marcaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacionesFSRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridIngeniero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finServicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noLlamadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClasificacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grisCoordinaFSR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridAreaC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCoordinadoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridIdIngeniero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTServicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTxtF_Notificar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridTxtSeguimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notAsesorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.funcionandoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet1 = new ProyectoInolabServicio.BrowserDataSet();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.v_SeguimientoFolioTableAdapter1 = new ProyectoInolabServicio.BrowserDataSetTableAdapters.V_SeguimientoFolioTableAdapter();
            this.lblRegistro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet1)).BeginInit();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // advancedDataGridView2
            // 
            this.advancedDataGridView2.AllowUserToAddRows = false;
            this.advancedDataGridView2.AllowUserToDeleteRows = false;
            this.advancedDataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridView2.AutoGenerateColumns = false;
            this.advancedDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridFolio,
            this.clienteDataGridViewTextBoxColumn,
            this.noSerieDataGridViewTextBoxColumn,
            this.marcaDataGridViewTextBoxColumn,
            this.observacionesFSRDataGridViewTextBoxColumn,
            this.gridIngeniero,
            this.gridServicio,
            this.finServicioDataGridViewTextBoxColumn,
            this.noLlamadaDataGridViewTextBoxColumn,
            this.idClasificacionDataGridViewTextBoxColumn,
            this.grisCoordinaFSR,
            this.gridAreaC,
            this.idCoordinadoraDataGridViewTextBoxColumn,
            this.gridIdIngeniero,
            this.idTServicioDataGridViewTextBoxColumn,
            this.gridTxtF_Notificar,
            this.gridTxtSeguimiento,
            this.notAsesorDataGridViewTextBoxColumn,
            this.funcionandoDataGridViewTextBoxColumn});
            this.advancedDataGridView2.ContextMenuStrip = this.contextMenuStrip2;
            this.advancedDataGridView2.DataSource = this.bindingSource1;
            this.advancedDataGridView2.FilterAndSortEnabled = true;
            this.advancedDataGridView2.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView2.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView2.Name = "advancedDataGridView2";
            this.advancedDataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView2.Size = new System.Drawing.Size(995, 421);
            this.advancedDataGridView2.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView2.TabIndex = 0;
            this.advancedDataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellContentClick);
            this.advancedDataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellDoubleClick);
            this.advancedDataGridView2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.AdvancedDataGridView1_CellEnter);
            this.advancedDataGridView2.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridView1_CellMouseUp);
            this.advancedDataGridView2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.advancedDataGridView2_DataBindingComplete);
            this.advancedDataGridView2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.AdvancedDataGridView1_EditingControlShowing);
            this.advancedDataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.advancedDataGridView1_RowPostPaint);
            // 
            // gridFolio
            // 
            this.gridFolio.DataPropertyName = "Folio";
            this.gridFolio.HeaderText = "Folio";
            this.gridFolio.MinimumWidth = 22;
            this.gridFolio.Name = "gridFolio";
            this.gridFolio.ReadOnly = true;
            this.gridFolio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridFolio.Width = 80;
            // 
            // clienteDataGridViewTextBoxColumn
            // 
            this.clienteDataGridViewTextBoxColumn.DataPropertyName = "Cliente";
            this.clienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.clienteDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.clienteDataGridViewTextBoxColumn.Name = "clienteDataGridViewTextBoxColumn";
            this.clienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.clienteDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.clienteDataGridViewTextBoxColumn.Width = 150;
            // 
            // noSerieDataGridViewTextBoxColumn
            // 
            this.noSerieDataGridViewTextBoxColumn.DataPropertyName = "NoSerie";
            this.noSerieDataGridViewTextBoxColumn.HeaderText = "NoSerie";
            this.noSerieDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.noSerieDataGridViewTextBoxColumn.Name = "noSerieDataGridViewTextBoxColumn";
            this.noSerieDataGridViewTextBoxColumn.ReadOnly = true;
            this.noSerieDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.noSerieDataGridViewTextBoxColumn.Width = 80;
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            this.marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            this.marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            this.marcaDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            this.marcaDataGridViewTextBoxColumn.ReadOnly = true;
            this.marcaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.marcaDataGridViewTextBoxColumn.Width = 80;
            // 
            // observacionesFSRDataGridViewTextBoxColumn
            // 
            this.observacionesFSRDataGridViewTextBoxColumn.DataPropertyName = "ObservacionesFSR";
            this.observacionesFSRDataGridViewTextBoxColumn.HeaderText = "ObservacionesFSR";
            this.observacionesFSRDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.observacionesFSRDataGridViewTextBoxColumn.Name = "observacionesFSRDataGridViewTextBoxColumn";
            this.observacionesFSRDataGridViewTextBoxColumn.ReadOnly = true;
            this.observacionesFSRDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.observacionesFSRDataGridViewTextBoxColumn.Width = 150;
            // 
            // gridIngeniero
            // 
            this.gridIngeniero.DataPropertyName = "Ingeniero";
            this.gridIngeniero.HeaderText = "Ingeniero";
            this.gridIngeniero.MinimumWidth = 22;
            this.gridIngeniero.Name = "gridIngeniero";
            this.gridIngeniero.ReadOnly = true;
            this.gridIngeniero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridIngeniero.Width = 150;
            // 
            // gridServicio
            // 
            this.gridServicio.DataPropertyName = "Descripcion";
            this.gridServicio.HeaderText = "Servicio";
            this.gridServicio.MinimumWidth = 22;
            this.gridServicio.Name = "gridServicio";
            this.gridServicio.ReadOnly = true;
            this.gridServicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // finServicioDataGridViewTextBoxColumn
            // 
            this.finServicioDataGridViewTextBoxColumn.DataPropertyName = "Fin_Servicio";
            this.finServicioDataGridViewTextBoxColumn.HeaderText = "Fin_Servicio";
            this.finServicioDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.finServicioDataGridViewTextBoxColumn.Name = "finServicioDataGridViewTextBoxColumn";
            this.finServicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.finServicioDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.finServicioDataGridViewTextBoxColumn.Width = 80;
            // 
            // noLlamadaDataGridViewTextBoxColumn
            // 
            this.noLlamadaDataGridViewTextBoxColumn.DataPropertyName = "NoLlamada";
            this.noLlamadaDataGridViewTextBoxColumn.HeaderText = "NoLlamada";
            this.noLlamadaDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.noLlamadaDataGridViewTextBoxColumn.Name = "noLlamadaDataGridViewTextBoxColumn";
            this.noLlamadaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.noLlamadaDataGridViewTextBoxColumn.Visible = false;
            // 
            // idClasificacionDataGridViewTextBoxColumn
            // 
            this.idClasificacionDataGridViewTextBoxColumn.DataPropertyName = "idClasificacion";
            this.idClasificacionDataGridViewTextBoxColumn.HeaderText = "idClasificacion";
            this.idClasificacionDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.idClasificacionDataGridViewTextBoxColumn.Name = "idClasificacionDataGridViewTextBoxColumn";
            this.idClasificacionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idClasificacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // grisCoordinaFSR
            // 
            this.grisCoordinaFSR.DataPropertyName = "Coordinadora";
            this.grisCoordinaFSR.HeaderText = "Coordinadora";
            this.grisCoordinaFSR.MinimumWidth = 22;
            this.grisCoordinaFSR.Name = "grisCoordinaFSR";
            this.grisCoordinaFSR.ReadOnly = true;
            this.grisCoordinaFSR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.grisCoordinaFSR.Width = 80;
            // 
            // gridAreaC
            // 
            this.gridAreaC.DataPropertyName = "Area";
            this.gridAreaC.HeaderText = "Area";
            this.gridAreaC.MinimumWidth = 22;
            this.gridAreaC.Name = "gridAreaC";
            this.gridAreaC.ReadOnly = true;
            this.gridAreaC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridAreaC.Width = 80;
            // 
            // idCoordinadoraDataGridViewTextBoxColumn
            // 
            this.idCoordinadoraDataGridViewTextBoxColumn.DataPropertyName = "IdCoordinadora";
            this.idCoordinadoraDataGridViewTextBoxColumn.HeaderText = "IdCoordinadora";
            this.idCoordinadoraDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.idCoordinadoraDataGridViewTextBoxColumn.Name = "idCoordinadoraDataGridViewTextBoxColumn";
            this.idCoordinadoraDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idCoordinadoraDataGridViewTextBoxColumn.Visible = false;
            // 
            // gridIdIngeniero
            // 
            this.gridIdIngeniero.DataPropertyName = "Id_Ingeniero";
            this.gridIdIngeniero.HeaderText = "Id_Ingeniero";
            this.gridIdIngeniero.MinimumWidth = 22;
            this.gridIdIngeniero.Name = "gridIdIngeniero";
            this.gridIdIngeniero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridIdIngeniero.Visible = false;
            // 
            // idTServicioDataGridViewTextBoxColumn
            // 
            this.idTServicioDataGridViewTextBoxColumn.DataPropertyName = "IdT_Servicio";
            this.idTServicioDataGridViewTextBoxColumn.HeaderText = "IdT_Servicio";
            this.idTServicioDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.idTServicioDataGridViewTextBoxColumn.Name = "idTServicioDataGridViewTextBoxColumn";
            this.idTServicioDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idTServicioDataGridViewTextBoxColumn.Visible = false;
            // 
            // gridTxtF_Notificar
            // 
            this.gridTxtF_Notificar.DataPropertyName = "F_Notificar";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.gridTxtF_Notificar.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridTxtF_Notificar.HeaderText = "F_Notificar";
            this.gridTxtF_Notificar.MinimumWidth = 22;
            this.gridTxtF_Notificar.Name = "gridTxtF_Notificar";
            this.gridTxtF_Notificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // gridTxtSeguimiento
            // 
            this.gridTxtSeguimiento.DataPropertyName = "Seguimiento";
            this.gridTxtSeguimiento.HeaderText = "Seguimiento";
            this.gridTxtSeguimiento.MinimumWidth = 22;
            this.gridTxtSeguimiento.Name = "gridTxtSeguimiento";
            this.gridTxtSeguimiento.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridTxtSeguimiento.Width = 200;
            // 
            // notAsesorDataGridViewTextBoxColumn
            // 
            this.notAsesorDataGridViewTextBoxColumn.DataPropertyName = "NotAsesor";
            this.notAsesorDataGridViewTextBoxColumn.HeaderText = "NotAsesor";
            this.notAsesorDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.notAsesorDataGridViewTextBoxColumn.Name = "notAsesorDataGridViewTextBoxColumn";
            this.notAsesorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.notAsesorDataGridViewTextBoxColumn.Visible = false;
            // 
            // funcionandoDataGridViewTextBoxColumn
            // 
            this.funcionandoDataGridViewTextBoxColumn.DataPropertyName = "Funcionando";
            this.funcionandoDataGridViewTextBoxColumn.HeaderText = "Funcionando";
            this.funcionandoDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.funcionandoDataGridViewTextBoxColumn.Name = "funcionandoDataGridViewTextBoxColumn";
            this.funcionandoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.funcionandoDataGridViewTextBoxColumn.Visible = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detallesToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(116, 26);
            // 
            // detallesToolStripMenuItem
            // 
            this.detallesToolStripMenuItem.Name = "detallesToolStripMenuItem";
            this.detallesToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.detallesToolStripMenuItem.Text = "Detalles";
            this.detallesToolStripMenuItem.Click += new System.EventHandler(this.detallesToolStripMenuItem_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "V_SeguimientoFolio";
            this.bindingSource1.DataSource = this.browserDataSet1;
            // 
            // browserDataSet1
            // 
            this.browserDataSet1.DataSetName = "BrowserDataSet";
            this.browserDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(995, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripContainer2
            // 
            this.toolStripContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.advancedDataGridView2);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(995, 421);
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 64);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(995, 445);
            this.toolStripContainer2.TabIndex = 2;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.menuStrip2);
            // 
            // v_SeguimientoFolioTableAdapter1
            // 
            this.v_SeguimientoFolioTableAdapter1.ClearBeforeFill = true;
            // 
            // lblRegistro
            // 
            this.lblRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRegistro.Location = new System.Drawing.Point(886, 37);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(54, 15);
            this.lblRegistro.TabIndex = 4;
            this.lblRegistro.Text = "registros";
            // 
            // SeguimientoFolios
            // 
            this.ClientSize = new System.Drawing.Size(998, 511);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.toolStripContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "SeguimientoFolios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguimiento de FSR";
            this.Load += new System.EventHandler(this.SeguimientoFolios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet1)).EndInit();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private BrowserDataSet browserDataSet;
        private System.Windows.Forms.BindingSource vSeguimientoFolioBindingSource;
        private BrowserDataSetTableAdapters.V_SeguimientoFolioTableAdapter v_SeguimientoFolioTableAdapter;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private BrowserDataSetTableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem observacionesFSRToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFolioFSR;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNoLlamada;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridNoSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFinServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridObservacionesFSR;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIdClasificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridCoordinadora;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridCmbIdIngeniero;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIdT_Servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIdCoordinadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridF_Notificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridComentseguimiento;
        private System.Windows.Forms.Label lblRegistros;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView2;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private BrowserDataSet browserDataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private BrowserDataSetTableAdapters.V_SeguimientoFolioTableAdapter v_SeguimientoFolioTableAdapter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noSerieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacionesFSRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIngeniero;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn finServicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noLlamadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClasificacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn grisCoordinaFSR;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridAreaC;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCoordinadoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIdIngeniero;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTServicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTxtF_Notificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridTxtSeguimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn notAsesorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn funcionandoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblRegistro;
    }
}