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
    public partial class EleccionBD : MaterialForm
    {
        public EleccionBD()
        {
            InitializeComponent();
        }

        int tipoBD;

        private void EleccionBD_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            MenuPrincipal frm = new MenuPrincipal(tipoBD);
            this.Close();
            frm.Show();

        }
    

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                MenuPrincipal frm = new MenuPrincipal(tipoBD);
                this.Close();
                frm.Show();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                tipoBD = 1;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                tipoBD = 2;
            }
        }
    }
}
