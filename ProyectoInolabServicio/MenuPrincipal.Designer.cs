namespace ProyectoInolabServicio
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.btnCoordinacion = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCopiasControladas = new MaterialSkin.Controls.MaterialRaisedButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.cambiarAPruebasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCoordinacion
            // 
            this.btnCoordinacion.AutoSize = true;
            this.btnCoordinacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCoordinacion.Depth = 0;
            this.btnCoordinacion.Icon = null;
            this.btnCoordinacion.Location = new System.Drawing.Point(60, 44);
            this.btnCoordinacion.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCoordinacion.Name = "btnCoordinacion";
            this.btnCoordinacion.Primary = true;
            this.btnCoordinacion.Size = new System.Drawing.Size(185, 36);
            this.btnCoordinacion.TabIndex = 0;
            this.btnCoordinacion.Text = "Coordinacion-Servicio";
            this.btnCoordinacion.UseVisualStyleBackColor = true;
            this.btnCoordinacion.Click += new System.EventHandler(this.btnCoordinacion_Click);
            // 
            // btnCopiasControladas
            // 
            this.btnCopiasControladas.AutoSize = true;
            this.btnCopiasControladas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCopiasControladas.Depth = 0;
            this.btnCopiasControladas.Icon = null;
            this.btnCopiasControladas.Location = new System.Drawing.Point(68, 106);
            this.btnCopiasControladas.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCopiasControladas.Name = "btnCopiasControladas";
            this.btnCopiasControladas.Primary = true;
            this.btnCopiasControladas.Size = new System.Drawing.Size(170, 36);
            this.btnCopiasControladas.TabIndex = 1;
            this.btnCopiasControladas.Text = "Copias Controladas";
            this.btnCopiasControladas.UseVisualStyleBackColor = true;
            this.btnCopiasControladas.Click += new System.EventHandler(this.btnCopiasControladas_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(307, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnCoordinacion);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.btnCopiasControladas);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(307, 170);
            this.toolStripContainer1.Location = new System.Drawing.Point(-1, 64);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(307, 218);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip2);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarAPruebasToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(307, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // cambiarAPruebasToolStripMenuItem
            // 
            this.cambiarAPruebasToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.cambiarAPruebasToolStripMenuItem.Name = "cambiarAPruebasToolStripMenuItem";
            this.cambiarAPruebasToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.cambiarAPruebasToolStripMenuItem.Text = "Cambiar de Base";
            this.cambiarAPruebasToolStripMenuItem.Visible = false;
            this.cambiarAPruebasToolStripMenuItem.Click += new System.EventHandler(this.cambiarAPruebasToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 282);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(306, 282);
            this.MinimumSize = new System.Drawing.Size(306, 282);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menú Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton btnCoordinacion;
        private MaterialSkin.Controls.MaterialRaisedButton btnCopiasControladas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem cambiarAPruebasToolStripMenuItem;
    }
}