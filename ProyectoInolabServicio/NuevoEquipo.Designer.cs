namespace ProyectoInolabServicio
{
    partial class NuevoEquipo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NuevoEquipo));
            this.label1 = new System.Windows.Forms.Label();
            this.txtEquipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNoSerie = new System.Windows.Forms.TextBox();
            this.txtIdClienteEquipo = new System.Windows.Forms.TextBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnagregarmarca = new System.Windows.Forms.Button();
            this.btnagregamodelo = new System.Windows.Forms.Button();
            this.browserDataSet = new ProyectoInolabServicio.BrowserDataSet();
            this.marcaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marcaTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.MarcaTableAdapter();
            this.modeloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.modeloTableAdapter = new ProyectoInolabServicio.BrowserDataSetTableAdapters.ModeloTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripción:";
            // 
            // txtEquipo
            // 
            this.txtEquipo.Location = new System.Drawing.Point(118, 74);
            this.txtEquipo.Name = "txtEquipo";
            this.txtEquipo.Size = new System.Drawing.Size(158, 20);
            this.txtEquipo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(20, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. Serie:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(20, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Modelo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(20, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Marca:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(20, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "ID Equipo Cliente:";
            // 
            // txtNoSerie
            // 
            this.txtNoSerie.Location = new System.Drawing.Point(118, 221);
            this.txtNoSerie.Name = "txtNoSerie";
            this.txtNoSerie.Size = new System.Drawing.Size(158, 20);
            this.txtNoSerie.TabIndex = 7;
            // 
            // txtIdClienteEquipo
            // 
            this.txtIdClienteEquipo.Location = new System.Drawing.Point(118, 262);
            this.txtIdClienteEquipo.Name = "txtIdClienteEquipo";
            this.txtIdClienteEquipo.Size = new System.Drawing.Size(158, 20);
            this.txtIdClienteEquipo.TabIndex = 8;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DataSource = this.marcaBindingSource;
            this.cmbMarca.DisplayMember = "Descripcion";
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(118, 124);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(158, 21);
            this.cmbMarca.TabIndex = 9;
            this.cmbMarca.ValueMember = "ID";
            // 
            // cmbModelo
            // 
            this.cmbModelo.DataSource = this.modeloBindingSource;
            this.cmbModelo.DisplayMember = "Descripcion";
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(118, 178);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(158, 21);
            this.cmbModelo.TabIndex = 10;
            this.cmbModelo.ValueMember = "ID";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(23, 304);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnagregarmarca
            // 
            this.btnagregarmarca.Location = new System.Drawing.Point(282, 124);
            this.btnagregarmarca.Name = "btnagregarmarca";
            this.btnagregarmarca.Size = new System.Drawing.Size(26, 23);
            this.btnagregarmarca.TabIndex = 35;
            this.btnagregarmarca.Text = "...";
            this.btnagregarmarca.UseVisualStyleBackColor = true;
            this.btnagregarmarca.Click += new System.EventHandler(this.btnagregarmarca_Click);
            // 
            // btnagregamodelo
            // 
            this.btnagregamodelo.Location = new System.Drawing.Point(282, 178);
            this.btnagregamodelo.Name = "btnagregamodelo";
            this.btnagregamodelo.Size = new System.Drawing.Size(26, 23);
            this.btnagregamodelo.TabIndex = 36;
            this.btnagregamodelo.Text = "...";
            this.btnagregamodelo.UseVisualStyleBackColor = true;
            this.btnagregamodelo.Click += new System.EventHandler(this.btnagregamodelo_Click);
            // 
            // browserDataSet
            // 
            this.browserDataSet.DataSetName = "BrowserDataSet";
            this.browserDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // marcaBindingSource
            // 
            this.marcaBindingSource.DataMember = "Marca";
            this.marcaBindingSource.DataSource = this.browserDataSet;
            // 
            // marcaTableAdapter
            // 
            this.marcaTableAdapter.ClearBeforeFill = true;
            // 
            // modeloBindingSource
            // 
            this.modeloBindingSource.DataMember = "Modelo";
            this.modeloBindingSource.DataSource = this.browserDataSet;
            // 
            // modeloTableAdapter
            // 
            this.modeloTableAdapter.ClearBeforeFill = true;
            // 
            // NuevoEquipo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 343);
            this.Controls.Add(this.btnagregamodelo);
            this.Controls.Add(this.btnagregarmarca);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbModelo);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.txtIdClienteEquipo);
            this.Controls.Add(this.txtNoSerie);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEquipo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NuevoEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuevoEquipo";
            this.Load += new System.EventHandler(this.NuevoEquipo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.browserDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marcaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modeloBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEquipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNoSerie;
        private System.Windows.Forms.TextBox txtIdClienteEquipo;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnagregarmarca;
        private System.Windows.Forms.Button btnagregamodelo;
        private BrowserDataSet browserDataSet;
        private System.Windows.Forms.BindingSource marcaBindingSource;
        private BrowserDataSetTableAdapters.MarcaTableAdapter marcaTableAdapter;
        private System.Windows.Forms.BindingSource modeloBindingSource;
        private BrowserDataSetTableAdapters.ModeloTableAdapter modeloTableAdapter;
    }
}