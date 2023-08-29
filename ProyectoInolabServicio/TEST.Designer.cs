namespace ProyectoInolabServicio
{
    partial class TEST
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TEST));
            this.txtdireccionemail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnenviarcorreo = new System.Windows.Forms.Button();
            this.txtfolio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfechaservicio = new System.Windows.Forms.TextBox();
            this.btnenviar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtdireccionemail
            // 
            this.txtdireccionemail.Location = new System.Drawing.Point(83, 193);
            this.txtdireccionemail.Name = "txtdireccionemail";
            this.txtdireccionemail.Size = new System.Drawing.Size(185, 20);
            this.txtdireccionemail.TabIndex = 0;
            this.txtdireccionemail.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "correo";
            this.label1.Visible = false;
            // 
            // btnenviarcorreo
            // 
            this.btnenviarcorreo.Location = new System.Drawing.Point(271, 229);
            this.btnenviarcorreo.Name = "btnenviarcorreo";
            this.btnenviarcorreo.Size = new System.Drawing.Size(80, 37);
            this.btnenviarcorreo.TabIndex = 2;
            this.btnenviarcorreo.Text = "button1";
            this.btnenviarcorreo.UseVisualStyleBackColor = true;
            this.btnenviarcorreo.Visible = false;
            this.btnenviarcorreo.Click += new System.EventHandler(this.btnenviarcorreo_Click);
            // 
            // txtfolio
            // 
            this.txtfolio.Location = new System.Drawing.Point(100, 90);
            this.txtfolio.Name = "txtfolio";
            this.txtfolio.Size = new System.Drawing.Size(100, 20);
            this.txtfolio.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(62, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Folio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "FechaServicio";
            this.label3.Visible = false;
            // 
            // txtfechaservicio
            // 
            this.txtfechaservicio.Location = new System.Drawing.Point(83, 219);
            this.txtfechaservicio.Name = "txtfechaservicio";
            this.txtfechaservicio.Size = new System.Drawing.Size(100, 20);
            this.txtfechaservicio.TabIndex = 5;
            this.txtfechaservicio.Visible = false;
            this.txtfechaservicio.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnenviar
            // 
            this.btnenviar.Location = new System.Drawing.Point(210, 88);
            this.btnenviar.Name = "btnenviar";
            this.btnenviar.Size = new System.Drawing.Size(75, 23);
            this.btnenviar.TabIndex = 7;
            this.btnenviar.Text = "Enviar";
            this.btnenviar.UseVisualStyleBackColor = true;
            this.btnenviar.Click += new System.EventHandler(this.btnenviar_Click);
            // 
            // TEST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 132);
            this.Controls.Add(this.btnenviar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtfechaservicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtfolio);
            this.Controls.Add(this.btnenviarcorreo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdireccionemail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TEST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envio de correo";
            this.Load += new System.EventHandler(this.TEST_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtdireccionemail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnenviarcorreo;
        private System.Windows.Forms.TextBox txtfolio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtfechaservicio;
        private System.Windows.Forms.Button btnenviar;
    }
}