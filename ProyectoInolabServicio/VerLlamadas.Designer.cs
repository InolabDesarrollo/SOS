namespace ProyectoInolabServicio
{
    partial class VerLlamadas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerLlamadas));
            this.llamadaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSBrowser = new ProyectoInolabServicio.DSBrowser();
            this.llamadaTableAdapter = new ProyectoInolabServicio.DSBrowserTableAdapters.LlamadaTableAdapter();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.todasLasLlamadasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaLlamadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.Estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdLlamada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoLlamada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingeniero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inicio_Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fin_Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proximo_Servicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            ((System.ComponentModel.ISupportInitialize)(this.llamadaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSBrowser)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // llamadaBindingSource
            // 
            this.llamadaBindingSource.DataMember = "Llamada";
            this.llamadaBindingSource.DataSource = this.dSBrowser;
            // 
            // dSBrowser
            // 
            this.dSBrowser.DataSetName = "DSBrowser";
            this.dSBrowser.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // llamadaTableAdapter
            // 
            this.llamadaTableAdapter.ClearBeforeFill = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.todasLasLlamadasToolStripMenuItem,
            this.nuevaLlamadaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // todasLasLlamadasToolStripMenuItem
            // 
            this.todasLasLlamadasToolStripMenuItem.Name = "todasLasLlamadasToolStripMenuItem";
            this.todasLasLlamadasToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.todasLasLlamadasToolStripMenuItem.Text = "Todas las Llamadas";
            this.todasLasLlamadasToolStripMenuItem.Visible = false;
            this.todasLasLlamadasToolStripMenuItem.Click += new System.EventHandler(this.todasLasLlamadasToolStripMenuItem_Click);
            // 
            // nuevaLlamadaToolStripMenuItem
            // 
            this.nuevaLlamadaToolStripMenuItem.Name = "nuevaLlamadaToolStripMenuItem";
            this.nuevaLlamadaToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.nuevaLlamadaToolStripMenuItem.Text = "Nueva Llamada";
            this.nuevaLlamadaToolStripMenuItem.Visible = false;
            this.nuevaLlamadaToolStripMenuItem.Click += new System.EventHandler(this.nuevaLlamadaToolStripMenuItem_Click);
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AllowUserToAddRows = false;
            this.advancedDataGridView1.AllowUserToDeleteRows = false;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Estatus,
            this.IdLlamada,
            this.NoLlamada,
            this.Cliente,
            this.TipoContrato,
            this.TipoServicio,
            this.Ingeniero,
            this.Inicio_Servicio,
            this.Fin_Servicio,
            this.Proximo_Servicio,
            this.Observaciones,
            this.Cotizacion,
            this.OC});
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.ReadOnly = true;
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.Size = new System.Drawing.Size(816, 341);
            this.advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView1.TabIndex = 2;
            this.advancedDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellContentClick);
            this.advancedDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellDoubleClick);
            this.advancedDataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.advancedDataGridView1_CellFormatting);
            // 
            // Estatus
            // 
            this.Estatus.DataPropertyName = "Estatus";
            this.Estatus.HeaderText = "Estatus";
            this.Estatus.MinimumWidth = 22;
            this.Estatus.Name = "Estatus";
            this.Estatus.ReadOnly = true;
            this.Estatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Estatus.Width = 80;
            // 
            // IdLlamada
            // 
            this.IdLlamada.DataPropertyName = "IdLlamada";
            this.IdLlamada.HeaderText = "IdLlamada";
            this.IdLlamada.MinimumWidth = 22;
            this.IdLlamada.Name = "IdLlamada";
            this.IdLlamada.ReadOnly = true;
            this.IdLlamada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.IdLlamada.Width = 65;
            // 
            // NoLlamada
            // 
            this.NoLlamada.DataPropertyName = "NoLlamada";
            this.NoLlamada.HeaderText = "NoLlamad";
            this.NoLlamada.MinimumWidth = 22;
            this.NoLlamada.Name = "NoLlamada";
            this.NoLlamada.ReadOnly = true;
            this.NoLlamada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.NoLlamada.Width = 65;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MinimumWidth = 22;
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Cliente.Width = 170;
            // 
            // TipoContrato
            // 
            this.TipoContrato.DataPropertyName = "TipoContrato";
            this.TipoContrato.HeaderText = "TipoContrato";
            this.TipoContrato.MinimumWidth = 22;
            this.TipoContrato.Name = "TipoContrato";
            this.TipoContrato.ReadOnly = true;
            this.TipoContrato.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            // Inicio_Servicio
            // 
            this.Inicio_Servicio.DataPropertyName = "Inicio_Servicio";
            this.Inicio_Servicio.HeaderText = "Inicio_Servicio";
            this.Inicio_Servicio.MinimumWidth = 22;
            this.Inicio_Servicio.Name = "Inicio_Servicio";
            this.Inicio_Servicio.ReadOnly = true;
            this.Inicio_Servicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Inicio_Servicio.Width = 80;
            // 
            // Fin_Servicio
            // 
            this.Fin_Servicio.DataPropertyName = "Fin_Servicio";
            this.Fin_Servicio.HeaderText = "Fin_Servicio";
            this.Fin_Servicio.MinimumWidth = 22;
            this.Fin_Servicio.Name = "Fin_Servicio";
            this.Fin_Servicio.ReadOnly = true;
            this.Fin_Servicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Fin_Servicio.Width = 80;
            // 
            // Proximo_Servicio
            // 
            this.Proximo_Servicio.DataPropertyName = "Proximo_Servicio";
            this.Proximo_Servicio.HeaderText = "Proximo_Servicio";
            this.Proximo_Servicio.MinimumWidth = 22;
            this.Proximo_Servicio.Name = "Proximo_Servicio";
            this.Proximo_Servicio.ReadOnly = true;
            this.Proximo_Servicio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Proximo_Servicio.Width = 80;
            // 
            // Observaciones
            // 
            this.Observaciones.DataPropertyName = "Observaciones";
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.MinimumWidth = 22;
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            this.Observaciones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Observaciones.Width = 150;
            // 
            // Cotizacion
            // 
            this.Cotizacion.DataPropertyName = "Cotizacion";
            this.Cotizacion.HeaderText = "Cotizacion";
            this.Cotizacion.MinimumWidth = 22;
            this.Cotizacion.Name = "Cotizacion";
            this.Cotizacion.ReadOnly = true;
            this.Cotizacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // OC
            // 
            this.OC.DataPropertyName = "OC";
            this.OC.HeaderText = "OC";
            this.OC.MinimumWidth = 22;
            this.OC.Name = "OC";
            this.OC.ReadOnly = true;
            this.OC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(816, 341);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 63);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(816, 365);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // VerLlamadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 429);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VerLlamadas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resgistro de Llamadas";
            this.Load += new System.EventHandler(this.VerLlamadas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.llamadaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSBrowser)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DSBrowser dSBrowser;
        private System.Windows.Forms.BindingSource llamadaBindingSource;
        private DSBrowserTableAdapters.LlamadaTableAdapter llamadaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCliente;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem todasLasLlamadasToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevaLlamadaToolStripMenuItem;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdLlamada;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoLlamada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingeniero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inicio_Servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fin_Servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proximo_Servicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn OC;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    }
}