using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class NuevoCliente : MaterialForm
    {
        public NuevoCliente()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string comando;
            comando = "insert into Clientes (FechaCreacion,Empresa) values(GETDATE(),'" + txtCliente.Text + "')";

            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = comando;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Se ha Guardado un Nuevo Cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
