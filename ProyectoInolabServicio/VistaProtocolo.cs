using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class VistaProtocolo : MaterialForm
    {
        public VistaProtocolo(string llamada)
        {
            InitializeComponent();
            noLlamada = llamada;
        }
        string noLlamada;
        int estatus;

        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        private void VistaProtocolo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Llamadas_SAP2' Puede moverla o quitarla según sea necesario.
            //this.llamadas_SAP2TableAdapter.Fill(this.dSBrowser.Llamadas_SAP2);

            CargaDatosCliente();
            CargaDatosServicio();
            UFolioP();

            cmbEstatus.SelectedIndex = 0;
        }

        public void CargaDatosCliente()
        {
            SqlCommand cmd = new SqlCommand("select * FROM Llamadas_SAP2 where NoLlamada = " + noLlamada, con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())

            //si trae datos
            {
                txtLlamada.Text = Convert.ToString(leer["NoLlamada"]);
                txtCliente.Text = Convert.ToString(leer["Cliente"]);
                txtDireccion.Text = Convert.ToString(leer["Calle"]) + " Col. " + Convert.ToString(leer["Colonia"]) + " C.P. " + Convert.ToString(leer["CP"]) + ", " + Convert.ToString(leer["Ciudad"]);
                txtTelefono.Text = Convert.ToString(leer["Telefono"]);
                txtResponsable.Text = Convert.ToString(leer["Nombre"]);
                txtMailResp.Text = Convert.ToString(leer["Correo"]);
            }

            con.Close();
        }

        public void CargaDatosServicio()
        {
            string cons;
            con.Open();

            cons = "select Status_ as Estatus, TipoServicio, Equipo, Marca, " +
                   "Modelo, noSerie, FechaSolicitudServicio, Comentarios, FolioFSR, TipoContrato " +
                   "from Llamadas_SAP2 where NoLlamada = " + noLlamada +
                   " and IdTiposervicio in (12, 13, 14, 23, 34, 35, 36, 37)";

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cons;
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            advancedDataGridView1.DataSource = dt;

            con.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SaveProtocolo();
            btnGuardar.Visible = true;
            this.Dispose();
        }

        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int estatus_c = cmbEstatus.SelectedIndex;

            if(estatus_c == 0)
            {
                estatus = 14;
            }
            if(estatus_c == 1)
            {
                estatus = 6;
            }
            if(estatus_c == 2)
            {
                estatus = 8;
            }
            if(estatus_c == 3)
            {
                estatus = 13;
            }
            if(estatus_c == 4)
            {
                estatus = 15;
            }
            if(estatus_c == 5)
            {
                estatus = 16;
            }
        }

        public void SaveProtocolo()
        {
            string comando;
            comando = "insert into Protocolos (NoLlamada, IdEstatus, F_SinAsignar) values ('" + txtLlamada.Text + "'," + estatus + " , GETDATE())";

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = comando;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Se ha guardado la llamada " + txtLlamada.Text + " para Protocolos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UFolioP()
        {
            SqlCommand cmd = new SqlCommand("select max(FolioProtocolo) + 1 AS er from Protocolos", con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                lblProto.Text = Convert.ToString(leer["er"]);
            }

            con.Close();
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
