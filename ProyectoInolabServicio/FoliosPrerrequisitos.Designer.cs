namespace ProyectoInolabServicio
{
    partial class FoliosPrerrequisitos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoliosPrerrequisitos));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjuntarPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vPrerrequisitosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet = new ProyectoInolabServicio.BrowserDataSet();
            this.v_PrerrequisitosTableAdapter1 = new ProyectoInolabServicio.BrowserDataSetTableAdapters.V_PrerrequisitosTableAdapter();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gridIdActividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTiposervicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoServicioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFechaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contacto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorreoCont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAsesorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asesorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentariosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridFechaEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerArchivo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vPrerrequisitosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(797, 24);
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.advancedDataGridView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(797, 360);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 65);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(797, 384);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.AutoGenerateColumns = false;
            this.advancedDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.advancedDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.advancedDataGridView1.ColumnHeadersHeight = 30;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridIdActividad,
            this.ordenVentaDataGridViewTextBoxColumn,
            this.idClienteDataGridViewTextBoxColumn,
            this.clienteDataGridViewTextBoxColumn,
            this.idTiposervicioDataGridViewTextBoxColumn,
            this.tipoServicioDataGridViewTextBoxColumn,
            this.gridFechaCreacion,
            this.gridFechaEntrega,
            this.Contacto,
            this.CorreoCont,
            this.Telefono,
            this.idAsesorDataGridViewTextBoxColumn,
            this.asesorDataGridViewTextBoxColumn,
            this.comentariosDataGridViewTextBoxColumn,
            this.gridFechaEnvio,
            this.VerArchivo});
            this.advancedDataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.advancedDataGridView1.DataSource = this.vPrerrequisitosBindingSource1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advancedDataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.EnableHeadersVisualStyles = false;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.advancedDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.advancedDataGridView1.Size = new System.Drawing.Size(797, 360);
            this.advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.TabIndex = 0;
            this.advancedDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellClick);
            this.advancedDataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellEnter);
            this.advancedDataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.advancedDataGridView1_CellFormatting);
            this.advancedDataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.advancedDataGridView1_CellMouseUp);
            this.advancedDataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.advancedDataGridView1_EditingControlShowing);
            this.advancedDataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.advancedDataGridView1_RowPostPaint);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detallesToolStripMenuItem,
            this.adjuntarPDFToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // detallesToolStripMenuItem
            // 
            this.detallesToolStripMenuItem.Name = "detallesToolStripMenuItem";
            this.detallesToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.detallesToolStripMenuItem.Text = "Detalles";
            this.detallesToolStripMenuItem.Click += new System.EventHandler(this.detallesToolStripMenuItem_Click);
            // 
            // adjuntarPDFToolStripMenuItem
            // 
            this.adjuntarPDFToolStripMenuItem.Name = "adjuntarPDFToolStripMenuItem";
            this.adjuntarPDFToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.adjuntarPDFToolStripMenuItem.Text = "Adjuntar PDF";
            this.adjuntarPDFToolStripMenuItem.Click += new System.EventHandler(this.adjuntarPDFToolStripMenuItem_Click);
            // 
            // vPrerrequisitosBindingSource1
            // 
            this.vPrerrequisitosBindingSource1.DataMember = "V_Prerrequisitos";
            this.vPrerrequisitosBindingSource1.DataSource = this.browserDataSet;
            // 
            // browserDataSet
            // 
            this.browserDataSet.DataSetName = "BrowserDataSet";
            this.browserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // v_PrerrequisitosTableAdapter1
            // 
            this.v_PrerrequisitosTableAdapter1.ClearBeforeFill = true;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.BackColor = System.Drawing.Color.Transparent;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRegistros.Location = new System.Drawing.Point(679, 35);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(41, 15);
            this.lblRegistros.TabIndex = 2;
            this.lblRegistros.Text = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // gridIdActividad
            // 
            this.gridIdActividad.DataPropertyName = "NumActividad";
            this.gridIdActividad.Frozen = true;
            this.gridIdActividad.HeaderText = "Actividad";
            this.gridIdActividad.MinimumWidth = 22;
            this.gridIdActividad.Name = "gridIdActividad";
            this.gridIdActividad.ReadOnly = true;
            this.gridIdActividad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridIdActividad.Width = 75;
            // 
            // ordenVentaDataGridViewTextBoxColumn
            // 
            this.ordenVentaDataGridViewTextBoxColumn.DataPropertyName = "OrdenVenta";
            this.ordenVentaDataGridViewTextBoxColumn.Frozen = true;
            this.ordenVentaDataGridViewTextBoxColumn.HeaderText = "Orden de Venta";
            this.ordenVentaDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.ordenVentaDataGridViewTextBoxColumn.Name = "ordenVentaDataGridViewTextBoxColumn";
            this.ordenVentaDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordenVentaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ordenVentaDataGridViewTextBoxColumn.Width = 75;
            // 
            // idClienteDataGridViewTextBoxColumn
            // 
            this.idClienteDataGridViewTextBoxColumn.DataPropertyName = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.HeaderText = "IdCliente";
            this.idClienteDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.idClienteDataGridViewTextBoxColumn.Name = "idClienteDataGridViewTextBoxColumn";
            this.idClienteDataGridViewTextBoxColumn.ReadOnly = true;
            this.idClienteDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idClienteDataGridViewTextBoxColumn.Visible = false;
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
            this.clienteDataGridViewTextBoxColumn.Width = 200;
            // 
            // idTiposervicioDataGridViewTextBoxColumn
            // 
            this.idTiposervicioDataGridViewTextBoxColumn.DataPropertyName = "IdTiposervicio";
            this.idTiposervicioDataGridViewTextBoxColumn.HeaderText = "IdTiposervicio";
            this.idTiposervicioDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.idTiposervicioDataGridViewTextBoxColumn.Name = "idTiposervicioDataGridViewTextBoxColumn";
            this.idTiposervicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.idTiposervicioDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idTiposervicioDataGridViewTextBoxColumn.Visible = false;
            // 
            // tipoServicioDataGridViewTextBoxColumn
            // 
            this.tipoServicioDataGridViewTextBoxColumn.DataPropertyName = "TipoServicio";
            this.tipoServicioDataGridViewTextBoxColumn.HeaderText = "Tipo de Servicio";
            this.tipoServicioDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.tipoServicioDataGridViewTextBoxColumn.Name = "tipoServicioDataGridViewTextBoxColumn";
            this.tipoServicioDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoServicioDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.tipoServicioDataGridViewTextBoxColumn.Width = 150;
            // 
            // gridFechaCreacion
            // 
            this.gridFechaCreacion.DataPropertyName = "FechaCreacion";
            this.gridFechaCreacion.HeaderText = "Fecha de Creación";
            this.gridFechaCreacion.MinimumWidth = 22;
            this.gridFechaCreacion.Name = "gridFechaCreacion";
            this.gridFechaCreacion.ReadOnly = true;
            this.gridFechaCreacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridFechaCreacion.Width = 80;
            // 
            // gridFechaEntrega
            // 
            this.gridFechaEntrega.DataPropertyName = "FechaEntrega";
            this.gridFechaEntrega.HeaderText = "Fecha de Entrega";
            this.gridFechaEntrega.MinimumWidth = 22;
            this.gridFechaEntrega.Name = "gridFechaEntrega";
            this.gridFechaEntrega.ReadOnly = true;
            this.gridFechaEntrega.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.gridFechaEntrega.Width = 80;
            // 
            // Contacto
            // 
            this.Contacto.DataPropertyName = "Contacto";
            this.Contacto.HeaderText = "Persona de Contacto";
            this.Contacto.MinimumWidth = 22;
            this.Contacto.Name = "Contacto";
            this.Contacto.ReadOnly = true;
            this.Contacto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Contacto.Width = 130;
            // 
            // CorreoCont
            // 
            this.CorreoCont.DataPropertyName = "CorreoCont";
            this.CorreoCont.HeaderText = "Correo";
            this.CorreoCont.MinimumWidth = 22;
            this.CorreoCont.Name = "CorreoCont";
            this.CorreoCont.ReadOnly = true;
            this.CorreoCont.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.CorreoCont.Width = 150;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "Telefono";
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.MinimumWidth = 22;
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // idAsesorDataGridViewTextBoxColumn
            // 
            this.idAsesorDataGridViewTextBoxColumn.DataPropertyName = "IdAsesor";
            this.idAsesorDataGridViewTextBoxColumn.HeaderText = "IdAsesor";
            this.idAsesorDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.idAsesorDataGridViewTextBoxColumn.Name = "idAsesorDataGridViewTextBoxColumn";
            this.idAsesorDataGridViewTextBoxColumn.ReadOnly = true;
            this.idAsesorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.idAsesorDataGridViewTextBoxColumn.Visible = false;
            // 
            // asesorDataGridViewTextBoxColumn
            // 
            this.asesorDataGridViewTextBoxColumn.DataPropertyName = "Asesor";
            this.asesorDataGridViewTextBoxColumn.HeaderText = "Asesor";
            this.asesorDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.asesorDataGridViewTextBoxColumn.Name = "asesorDataGridViewTextBoxColumn";
            this.asesorDataGridViewTextBoxColumn.ReadOnly = true;
            this.asesorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // comentariosDataGridViewTextBoxColumn
            // 
            this.comentariosDataGridViewTextBoxColumn.DataPropertyName = "Comentarios";
            this.comentariosDataGridViewTextBoxColumn.HeaderText = "Comentarios";
            this.comentariosDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.comentariosDataGridViewTextBoxColumn.Name = "comentariosDataGridViewTextBoxColumn";
            this.comentariosDataGridViewTextBoxColumn.ReadOnly = true;
            this.comentariosDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.comentariosDataGridViewTextBoxColumn.Width = 200;
            // 
            // gridFechaEnvio
            // 
            this.gridFechaEnvio.DataPropertyName = "Fecha_Envio";
            this.gridFechaEnvio.HeaderText = "Fecha de Envío";
            this.gridFechaEnvio.MinimumWidth = 22;
            this.gridFechaEnvio.Name = "gridFechaEnvio";
            this.gridFechaEnvio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // VerArchivo
            // 
            this.VerArchivo.HeaderText = "Ver Archivo";
            this.VerArchivo.MinimumWidth = 22;
            this.VerArchivo.Name = "VerArchivo";
            this.VerArchivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.VerArchivo.Text = "Abrir";
            this.VerArchivo.UseColumnTextForButtonValue = true;
            // 
            // FoliosPrerrequisitos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FoliosPrerrequisitos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actividades para Prerrequisitos";
            this.Load += new System.EventHandler(this.FoliosPrerrequisitos_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vPrerrequisitosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem;
        private BrowserDataSet browserDataSet;
        private System.Windows.Forms.BindingSource vPrerrequisitosBindingSource1;
        private BrowserDataSetTableAdapters.V_PrerrequisitosTableAdapter v_PrerrequisitosTableAdapter1;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.ToolStripMenuItem adjuntarPDFToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridIdActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTiposervicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoServicioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFechaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contacto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorreoCont;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAsesorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn asesorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentariosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridFechaEnvio;
        private System.Windows.Forms.DataGridViewButtonColumn VerArchivo;
    }
}