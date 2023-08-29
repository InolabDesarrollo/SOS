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
    public partial class NuevoModelo : MaterialForm
    {
        int idmarca;
        public NuevoModelo(int marca)
        {
            InitializeComponent();
            idmarca = marca;

        }
        conexion con = new conexion();


        private void btnguardar_Click(object sender, EventArgs e)
        {
            SaveModelo();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public void SaveModelo()
        {
            string addmarca = "insert into modelo (descripcion,idmarca) values ('" + txtModelo.Text + "',"+idmarca+")";
            if (con.insertar(addmarca))
            {
                MessageBox.Show("Modelo Agregado Exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al Guardar.");
            }
        }

        private void NuevoModelo_Load(object sender, EventArgs e)
        {
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
