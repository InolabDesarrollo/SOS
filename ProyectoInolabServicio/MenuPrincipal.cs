using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class MenuPrincipal : MaterialForm
    {
        public MenuPrincipal(int BD)
        {
            InitializeComponent();
            tipoBD = BD;
        }

        //VARIABLES
        int tipoBD;

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            if(tipoBD == 1)
            {
                if (TestSpire.Usr.K == 91 || TestSpire.Usr.K == 1 || TestSpire.Usr.K == 71 || TestSpire.Usr.K == 88)
                {
                    cambiarAPruebasToolStripMenuItem.Visible = true;
                }
                else
                {
                    cambiarAPruebasToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                cambiarAPruebasToolStripMenuItem.Visible = false;
            }

            if(TestSpire.Usr.K == 41 || TestSpire.Usr.K == 45 || TestSpire.Usr.K == 105 || TestSpire.Usr.K == 72 || TestSpire.Usr.K == 112 || TestSpire.Usr.K == 133 || TestSpire.Usr.K == 132)
            {
                btnCoordinacion.Text = "Protocolos";
                btnCoordinacion.Location = new Point(100, 44);
            }
            else if(TestSpire.Usr.K == 33 || TestSpire.Usr.K == 35 || TestSpire.Usr.K == 36 || TestSpire.Usr.K == 37 || TestSpire.Usr.K == 40 || TestSpire.Usr.K == 62 || TestSpire.Usr.K == 75 ||
                    TestSpire.Usr.K == 76 || TestSpire.Usr.K == 85 || TestSpire.Usr.K == 101 || TestSpire.Usr.K == 104 || TestSpire.Usr.K == 107 || TestSpire.Usr.K == 128 || TestSpire.Usr.K == 129 || TestSpire.Usr.K == 130
                    || TestSpire.Usr.K == 135 || TestSpire.Usr.K == 136 || TestSpire.Usr.K == 137)
            {
                btnCoordinacion.Text = "Documentación";
                btnCoordinacion.Location = new Point(85, 44);
            }
        }

        private void btnCopiasControladas_Click(object sender, EventArgs e)
        {
            if (TestSpire.Usr.Rick == 3 || TestSpire.Usr.Rick == 5 || TestSpire.Usr.Rick == 4 || TestSpire.Usr.Rick == 7)
            {
                //this.Hide();

                if (TestSpire.Usr.Joi == 4 || TestSpire.Usr.Joi == 5)
                {
                    //this.Close();
                    TestSpire.Consultar c = new TestSpire.Consultar();
                    c.Show();
                }
                else
                {
                    //this.Close();
                    TestSpire.Form1 cc = new TestSpire.Form1();
                    cc.Show();
                }
            }
            else
            {
                MessageBox.Show("No cuenta con los permisos necesarios para realizar esta acción.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCoordinacion_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu frm = new Menu(tipoBD);
            frm.Show();
            //this.Hide();
        }


        //******************** CIERRA LA APLICACION 
        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result;
            //result = MessageBox.Show("Esta seguro que desea salir de la Aplicación", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //if (result == System.Windows.Forms.DialogResult.Yes)
            //{
            //    Application.Exit();
            //    //this.Close();
            //}
            //if (result == System.Windows.Forms.DialogResult.No)
            //{
            //    e.Cancel = true;
            //    return;
            //}
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Esta seguro que desea Cerrar Sesión", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(r == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();

                Sesion lg = new Sesion();
                lg.Show();
            }
        }

        private void cambiarAPruebasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EleccionBD el = new EleccionBD();
            el.Show();
            this.Close();
        }
    }
}
