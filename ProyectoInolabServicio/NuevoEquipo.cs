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
    public partial class NuevoEquipo : MaterialForm
    {
        string idempresa;
        int idmarca;
        public NuevoEquipo( string empresid)
        {
            InitializeComponent();
           
            idempresa = empresid;
        }

        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        private void NuevoEquipo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Modelo' Puede moverla o quitarla según sea necesario.
            this.modeloTableAdapter.Fill(this.browserDataSet.Modelo);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Marca' Puede moverla o quitarla según sea necesario.
            this.marcaTableAdapter.Fill(this.browserDataSet.Marca);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlCommand ne = new SqlCommand("SaveEquipoFSR", con);
            ne.CommandType = CommandType.StoredProcedure;

            con.Open();

            ne.Parameters.Add("@equipo", SqlDbType.VarChar);
            ne.Parameters.Add("@serie",SqlDbType.VarChar);
            ne.Parameters.Add("@idcliente",SqlDbType.VarChar);
            ne.Parameters.Add("@idmarca",SqlDbType.Int);
            ne.Parameters.Add("@idmodelo",SqlDbType.Int);
            ne.Parameters.Add("@idequipoc",SqlDbType.VarChar);



            ne.Parameters["@equipo"].Value = txtEquipo.Text;
            ne.Parameters["@serie"].Value = txtNoSerie.Text;
            ne.Parameters["@idcliente"].Value = idempresa;
            ne.Parameters["@idmarca"].Value = Convert.ToInt32(cmbMarca.SelectedValue);
            ne.Parameters["@idmodelo"].Value = Convert.ToInt32(cmbModelo.SelectedValue);
            ne.Parameters["@idequipoc"].Value = txtIdClienteEquipo.Text;

            ne.ExecuteNonQuery();

            MessageBox.Show("Equipo agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnagregarmarca_Click(object sender, EventArgs e)
        {
            NuevaMarca frm = new NuevaMarca();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.marcaTableAdapter.Fill(this.browserDataSet.Marca);
            }

        }

        private void btnagregamodelo_Click(object sender, EventArgs e)
        {
            idmarca =Convert.ToInt32(cmbMarca.SelectedValue);


            NuevoModelo frm = new NuevoModelo(idmarca);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.modeloTableAdapter.Fill(this.browserDataSet.Modelo);
            }

        }
    }
}
