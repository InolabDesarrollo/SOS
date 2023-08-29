using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInolabServicio
{
    public partial class _1 : Form
    {
        public _1()
        {
            InitializeComponent();
        }

        private void _1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.V_FSR' Puede moverla o quitarla según sea necesario.
            this.v_FSRTableAdapter.Fill(this.dSBrowser.V_FSR);

        }
    }
}
