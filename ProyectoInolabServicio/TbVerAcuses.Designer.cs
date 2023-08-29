namespace ProyectoInolabServicio
{
    partial class TbVerAcuses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TbVerAcuses));
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FoliosAcuses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.adgvListaAcuseFirma = new Zuby.ADGV.AdvancedDataGridView();
            this.FSR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ruta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipodAcuse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adgvListaAcuses = new Zuby.ADGV.AdvancedDataGridView();
            this.FolioAcuses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FolioSFR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoAcuses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvListaAcuseFirma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adgvListaAcuses)).BeginInit();
            this.SuspendLayout();
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "FolioFSR";
            this.Folio.HeaderText = "Folio FSR";
            this.Folio.Name = "Folio";
            // 
            // FoliosAcuses
            // 
            this.FoliosAcuses.DataPropertyName = "FoliosAcuses";
            this.FoliosAcuses.HeaderText = "Folio de Acuse";
            this.FoliosAcuses.MinimumWidth = 22;
            this.FoliosAcuses.Name = "FoliosAcuses";
            this.FoliosAcuses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(270, 24);
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
            this.toolStripContainer1.ContentPanel.Controls.Add(this.adgvListaAcuseFirma);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.adgvListaAcuses);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(270, 289);
            this.toolStripContainer1.Location = new System.Drawing.Point(-1, 64);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(270, 313);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // adgvListaAcuseFirma
            // 
            this.adgvListaAcuseFirma.AllowUserToAddRows = false;
            this.adgvListaAcuseFirma.AllowUserToDeleteRows = false;
            this.adgvListaAcuseFirma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvListaAcuseFirma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FSR,
            this.Ruta,
            this.TipodAcuse});
            this.adgvListaAcuseFirma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvListaAcuseFirma.FilterAndSortEnabled = true;
            this.adgvListaAcuseFirma.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.adgvListaAcuseFirma.Location = new System.Drawing.Point(0, 0);
            this.adgvListaAcuseFirma.Name = "adgvListaAcuseFirma";
            this.adgvListaAcuseFirma.ReadOnly = true;
            this.adgvListaAcuseFirma.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.adgvListaAcuseFirma.Size = new System.Drawing.Size(270, 289);
            this.adgvListaAcuseFirma.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.adgvListaAcuseFirma.TabIndex = 1;
            this.adgvListaAcuseFirma.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvListaAcuseFirma_CellDoubleClick);
            // 
            // FSR
            // 
            this.FSR.DataPropertyName = "FolioFSR";
            this.FSR.HeaderText = "FSR";
            this.FSR.MinimumWidth = 22;
            this.FSR.Name = "FSR";
            this.FSR.ReadOnly = true;
            this.FSR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FSR.Visible = false;
            // 
            // Ruta
            // 
            this.Ruta.DataPropertyName = "RutaAcuses";
            this.Ruta.HeaderText = "RutaAcuse";
            this.Ruta.MinimumWidth = 22;
            this.Ruta.Name = "Ruta";
            this.Ruta.ReadOnly = true;
            this.Ruta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Ruta.Visible = false;
            // 
            // TipodAcuse
            // 
            this.TipodAcuse.DataPropertyName = "TipoAcuse";
            this.TipodAcuse.HeaderText = "Tipo Acuse";
            this.TipodAcuse.MinimumWidth = 22;
            this.TipodAcuse.Name = "TipodAcuse";
            this.TipodAcuse.ReadOnly = true;
            this.TipodAcuse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // adgvListaAcuses
            // 
            this.adgvListaAcuses.AllowUserToAddRows = false;
            this.adgvListaAcuses.AllowUserToDeleteRows = false;
            this.adgvListaAcuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adgvListaAcuses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FolioAcuses,
            this.FolioSFR,
            this.TipoAcuses});
            this.adgvListaAcuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adgvListaAcuses.FilterAndSortEnabled = true;
            this.adgvListaAcuses.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.adgvListaAcuses.Location = new System.Drawing.Point(0, 0);
            this.adgvListaAcuses.Name = "adgvListaAcuses";
            this.adgvListaAcuses.ReadOnly = true;
            this.adgvListaAcuses.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.adgvListaAcuses.Size = new System.Drawing.Size(270, 289);
            this.adgvListaAcuses.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.adgvListaAcuses.TabIndex = 0;
            this.adgvListaAcuses.Visible = false;
            this.adgvListaAcuses.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adgvListaAcuses_CellDoubleClick);
            // 
            // FolioAcuses
            // 
            this.FolioAcuses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FolioAcuses.DataPropertyName = "FoliosAcuses";
            this.FolioAcuses.HeaderText = "Folios Acuses";
            this.FolioAcuses.MinimumWidth = 22;
            this.FolioAcuses.Name = "FolioAcuses";
            this.FolioAcuses.ReadOnly = true;
            this.FolioAcuses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // FolioSFR
            // 
            this.FolioSFR.DataPropertyName = "FolioFSR";
            this.FolioSFR.HeaderText = "FolioFSR";
            this.FolioSFR.MinimumWidth = 22;
            this.FolioSFR.Name = "FolioSFR";
            this.FolioSFR.ReadOnly = true;
            this.FolioSFR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FolioSFR.Visible = false;
            // 
            // TipoAcuses
            // 
            this.TipoAcuses.DataPropertyName = "TipoAcuse";
            this.TipoAcuses.HeaderText = "TipoAcuses";
            this.TipoAcuses.MinimumWidth = 22;
            this.TipoAcuses.Name = "TipoAcuses";
            this.TipoAcuses.ReadOnly = true;
            this.TipoAcuses.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TipoAcuses.Visible = false;
            // 
            // TbVerAcuses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 378);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 378);
            this.MinimumSize = new System.Drawing.Size(270, 378);
            this.Name = "TbVerAcuses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de Acuses";
            this.Load += new System.EventHandler(this.TbVerAcuses_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adgvListaAcuseFirma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adgvListaAcuses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FoliosAcuses;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private Zuby.ADGV.AdvancedDataGridView adgvListaAcuses;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolioAcuses;
        private System.Windows.Forms.DataGridViewTextBoxColumn FolioSFR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoAcuses;
        private Zuby.ADGV.AdvancedDataGridView adgvListaAcuseFirma;
        private System.Windows.Forms.DataGridViewTextBoxColumn FSR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ruta;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipodAcuse;
    }
}