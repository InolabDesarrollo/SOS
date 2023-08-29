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
    public partial class NuevaMarca : MaterialForm
    {
        public NuevaMarca()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            SaveMarca();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        conexion con = new conexion();
        public void SaveMarca()
        {
            string addmarca = "insert into marca (descripcion) values ('" + txtMarca.Text + "')";
            if (con.insertar(addmarca))
            {
                MessageBox.Show("Marca Agregado Exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al Guardar.");
            }
        }

        private void NuevaMarca_Load(object sender, EventArgs e)
        {

        }
    }
}
