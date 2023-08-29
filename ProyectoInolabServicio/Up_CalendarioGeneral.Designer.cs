namespace ProyectoInolabServicio
{
    partial class Up_CalendarioGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Up_CalendarioGeneral));
            this.label3 = new System.Windows.Forms.Label();
            this.cmbing = new System.Windows.Forms.ComboBox();
            this.usuariosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.browserDataSet = new ProyectoInolabServicio.BrowserDataSet();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.dtpfecha = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ing = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iding = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoReasig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnActualizaCalendario = new System.Windows.Forms.Button();
            this.usuariosTableAdapter = new ProyectoInolabServicio.DSBrowserTableAdapters.UsuariosTableAdapter();
            this.btnagregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMotivoR = new System.Windows.Forms.TextBox();
            this.usuariosTableAdapter1 = new ProyectoInolabServicio.BrowserDataSetTableAdapters.UsuariosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(279, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ing.";
            // 
            // cmbing
            // 
            this.cmbing.DataSource = this.usuariosBindingSource1;
            this.cmbing.DisplayMember = "Nombre";
            this.cmbing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbing.FormattingEnabled = true;
            this.cmbing.Location = new System.Drawing.Point(305, 86);
            this.cmbing.Name = "cmbing";
            this.cmbing.Size = new System.Drawing.Size(189, 21);
            this.cmbing.TabIndex = 21;
            this.cmbing.ValueMember = "IdUsuario";
            this.cmbing.SelectedIndexChanged += new System.EventHandler(this.cmbing_SelectedIndexChanged);
            // 
            // usuariosBindingSource1
            // 
            this.usuariosBindingSource1.DataMember = "Usuarios";
            this.usuariosBindingSource1.DataSource = this.browserDataSet;
            // 
            // browserDataSet
            // 
            this.browserDataSet.DataSetName = "BrowserDataSet";
            this.browserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(125, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fecha:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(8, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Folio:";
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(43, 89);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(64, 20);
            this.txtFolio.TabIndex = 18;
            // 
            // dtpfecha
            // 
            this.dtpfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfecha.Location = new System.Drawing.Point(168, 89);
            this.dtpfecha.Name = "dtpfecha";
            this.dtpfecha.Size = new System.Drawing.Size(86, 20);
            this.dtpfecha.TabIndex = 17;
            this.dtpfecha.ValueChanged += new System.EventHandler(this.dtpfecha_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Folio,
            this.FechaServicio,
            this.Ing,
            this.Iding,
            this.MotivoReasig});
            this.dataGridView1.Location = new System.Drawing.Point(12, 208);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(482, 256);
            this.dataGridView1.TabIndex = 23;
            // 
            // Folio
            // 
            this.Folio.FillWeight = 76.14214F;
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            this.Folio.Width = 50;
            // 
            // FechaServicio
            // 
            this.FechaServicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.NullValue = null;
            this.FechaServicio.DefaultCellStyle = dataGridViewCellStyle1;
            this.FechaServicio.FillWeight = 111.9289F;
            this.FechaServicio.HeaderText = "Fecha de Servicio";
            this.FechaServicio.Name = "FechaServicio";
            this.FechaServicio.ReadOnly = true;
            // 
            // Ing
            // 
            this.Ing.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ing.FillWeight = 111.9289F;
            this.Ing.HeaderText = "Ingeniero";
            this.Ing.Name = "Ing";
            this.Ing.ReadOnly = true;
            // 
            // Iding
            // 
            this.Iding.HeaderText = "IdING";
            this.Iding.Name = "Iding";
            this.Iding.ReadOnly = true;
            this.Iding.Visible = false;
            this.Iding.Width = 20;
            // 
            // MotivoReasig
            // 
            this.MotivoReasig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MotivoReasig.HeaderText = "Motivo";
            this.MotivoReasig.Name = "MotivoReasig";
            this.MotivoReasig.ReadOnly = true;
            // 
            // btnActualizaCalendario
            // 
            this.btnActualizaCalendario.Enabled = false;
            this.btnActualizaCalendario.Location = new System.Drawing.Point(357, 484);
            this.btnActualizaCalendario.Name = "btnActualizaCalendario";
            this.btnActualizaCalendario.Size = new System.Drawing.Size(75, 23);
            this.btnActualizaCalendario.TabIndex = 24;
            this.btnActualizaCalendario.Text = "Actualizar";
            this.btnActualizaCalendario.UseVisualStyleBackColor = true;
            this.btnActualizaCalendario.Click += new System.EventHandler(this.btnActualizaCalendario_Click);
            // 
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
            // 
            // btnagregar
            // 
            this.btnagregar.Enabled = false;
            this.btnagregar.Location = new System.Drawing.Point(469, 153);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(25, 23);
            this.btnagregar.TabIndex = 25;
            this.btnagregar.Text = "+";
            this.btnagregar.UseVisualStyleBackColor = true;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Motivo de Reasignacion:";
            // 
            // txtMotivoR
            // 
            this.txtMotivoR.Location = new System.Drawing.Point(143, 124);
            this.txtMotivoR.Multiline = true;
            this.txtMotivoR.Name = "txtMotivoR";
            this.txtMotivoR.Size = new System.Drawing.Size(266, 52);
            this.txtMotivoR.TabIndex = 27;
            // 
            // usuariosTableAdapter1
            // 
            this.usuariosTableAdapter1.ClearBeforeFill = true;
            // 
            // Up_CalendarioGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 536);
            this.Controls.Add(this.txtMotivoR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.btnActualizaCalendario);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.dtpfecha);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(522, 536);
            this.MinimumSize = new System.Drawing.Size(522, 536);
            this.Name = "Up_CalendarioGeneral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualiza Calendario ";
            this.Load += new System.EventHandler(this.Up_CalendarioGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.DateTimePicker dtpfecha;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnActualizaCalendario;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private DSBrowserTableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ing;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iding;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoReasig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMotivoR;
        private BrowserDataSet browserDataSet;
        private System.Windows.Forms.BindingSource usuariosBindingSource1;
        private BrowserDataSetTableAdapters.UsuariosTableAdapter usuariosTableAdapter1;
    }
}