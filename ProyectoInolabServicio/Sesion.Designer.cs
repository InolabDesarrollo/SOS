namespace ProyectoInolabServicio
{
    partial class Sesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sesion));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtUser = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPsd = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timerActualizacion = new System.Windows.Forms.Timer(this.components);
            this.btnInicio = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lblF = new MaterialSkin.Controls.MaterialLabel();
            this.lblVer = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Depth = 0;
            this.txtUser.Hint = "";
            this.txtUser.Location = new System.Drawing.Point(130, 95);
            this.txtUser.MaxLength = 32767;
            this.txtUser.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.SelectedText = "";
            this.txtUser.SelectionLength = 0;
            this.txtUser.SelectionStart = 0;
            this.txtUser.Size = new System.Drawing.Size(113, 23);
            this.txtUser.TabIndex = 10;
            this.txtUser.TabStop = false;
            this.toolTip1.SetToolTip(this.txtUser, "Usuario");
            this.txtUser.UseSystemPasswordChar = false;
            // 
            // txtPsd
            // 
            this.txtPsd.Depth = 0;
            this.txtPsd.Hint = "";
            this.txtPsd.Location = new System.Drawing.Point(130, 136);
            this.txtPsd.MaxLength = 32767;
            this.txtPsd.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPsd.Name = "txtPsd";
            this.txtPsd.PasswordChar = '\0';
            this.txtPsd.SelectedText = "";
            this.txtPsd.SelectionLength = 0;
            this.txtPsd.SelectionStart = 0;
            this.txtPsd.Size = new System.Drawing.Size(113, 23);
            this.txtPsd.TabIndex = 11;
            this.txtPsd.TabStop = false;
            this.toolTip1.SetToolTip(this.txtPsd, "Password");
            this.txtPsd.UseSystemPasswordChar = true;
            this.txtPsd.Click += new System.EventHandler(this.txtPsd_Click);
            this.txtPsd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPsd_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(82, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Usuario");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(79, 135);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "Password");
            // 
            // timerActualizacion
            // 
            this.timerActualizacion.Interval = 50000;
            this.timerActualizacion.Tick += new System.EventHandler(this.timerActualizacion_Tick);
            // 
            // btnInicio
            // 
            this.btnInicio.AutoSize = true;
            this.btnInicio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInicio.Depth = 0;
            this.btnInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.Icon = null;
            this.btnInicio.Location = new System.Drawing.Point(117, 186);
            this.btnInicio.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Primary = true;
            this.btnInicio.Size = new System.Drawing.Size(86, 36);
            this.btnInicio.TabIndex = 9;
            this.btnInicio.Text = "Ingresar";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // lblF
            // 
            this.lblF.AutoSize = true;
            this.lblF.Depth = 0;
            this.lblF.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblF.Location = new System.Drawing.Point(9, 256);
            this.lblF.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(65, 19);
            this.lblF.TabIndex = 12;
            this.lblF.Text = "Versión:";
            // 
            // lblVer
            // 
            this.lblVer.AutoSize = true;
            this.lblVer.Depth = 0;
            this.lblVer.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblVer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblVer.Location = new System.Drawing.Point(55, 256);
            this.lblVer.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(19, 19);
            this.lblVer.TabIndex = 13;
            this.lblVer.Text = "V";
            // 
            // Sesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(310, 278);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.lblF);
            this.Controls.Add(this.txtPsd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(310, 278);
            this.MinimumSize = new System.Drawing.Size(310, 278);
            this.Name = "Sesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INOLAB S.O.S";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Sesion_FormClosing);
            this.Load += new System.EventHandler(this.Sesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timerActualizacion;
        private MaterialSkin.Controls.MaterialRaisedButton btnInicio;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtUser;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPsd;
        private MaterialSkin.Controls.MaterialLabel lblF;
        private MaterialSkin.Controls.MaterialLabel lblVer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}