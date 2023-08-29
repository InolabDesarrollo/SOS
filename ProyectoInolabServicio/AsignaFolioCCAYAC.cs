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

namespace ProyectoInolabServicio
{
    public partial class AsignaFolioCCAYAC : Form
    {
        public AsignaFolioCCAYAC(string IdE)
        {
            InitializeComponent();
            IdEequipo = IdE;
        }

        string IdEequipo;
        string MttoP, MttoC, Calibracion, IQ, OQ, PQ;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardaFolio();
            GuardaCCAYAC();
        }

        int num;
        string CCAY, ccf;
        string comando;
        string servicio, tipoF;

        private void timer1_Tick(object sender, EventArgs e)
        {
            GeneraFolio();
        }

        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        private void AsignaFolioCCAYAC_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.dSBrowser.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.CCAYAC22' Puede moverla o quitarla según sea necesario.
            //this.cCAYAC22TableAdapter.Fill(this.dSBrowser.CCAYAC22);
            DatosEquipo();
        }

        

        public void DatosEquipo()
        {
            GeneraFolio();

            SqlCommand cmd = new SqlCommand("select * from CCAYAC22 where IDEquipo = '" + IdEequipo + "'", con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())
            //si trae datos
            {
                txtIdEquipo.Text = Convert.ToString(leer["IDEquipo"]);
                txtEquipo.Text = Convert.ToString(leer["Equipo"]);
                txtMarca.Text = Convert.ToString(leer["Marca"]);
                txtModelo.Text = Convert.ToString(leer["Modelo"]);
                txtNoSerie.Text = Convert.ToString(leer["Serie"]);
                txtUbicacion.Text = Convert.ToString(leer["Ubicacion"]);
                txtGerencia.Text = Convert.ToString(leer["Gerencia"]);
                txtPartida.Text = Convert.ToString(leer["Partida"]);
                txtDescripcion.Text = Convert.ToString(leer["Descripcion"]);
                MttoP = Convert.ToString(leer["MttoP"]);
                MttoC = Convert.ToString(leer["MttoC"]);
                Calibracion = Convert.ToString(leer["Calibracion"]);
                IQ = Convert.ToString(leer["IQ"]);
                OQ = Convert.ToString(leer["OQ"]);
                PQ = Convert.ToString(leer["PQ"]);

                if (MttoP == "true")
                {
                    //num += 1;
                    CCAY = "CCAYAC - 0" + num;
                    advancedDataGridView1.Rows.Add("Mantenimiento Preventivo", CCAY ,"Asignado");
                }
                if(MttoC == "true")
                {
                    num += 1;
                    CCAY = "CCAYAC - 0" + num;
                    advancedDataGridView1.Rows.Add("Mantenimiento Correctivo", CCAY , "Asignado");
                }
                if(Calibracion == "true")
                {
                    num += 1;
                    CCAY = "CCAYAC - 0" + num;
                    advancedDataGridView1.Rows.Add("Calibracion", CCAY, "Asignado");
                }
                if (IQ == "true")
                {
                    num += 1;
                    CCAY = "CCAYAC - 0" + num;
                    advancedDataGridView1.Rows.Add("IQ", CCAY, "Asignado");
                }
                if (OQ == "true")
                {
                    num += 1;
                    CCAY = "CCAYAC - 0" + num;
                    advancedDataGridView1.Rows.Add("OQ", CCAY, "Asignado");
                }
                if (PQ == "true")
                {
                    num += 1;
                    CCAY = "CCAYAC - 0" + num;
                    advancedDataGridView1.Rows.Add("PQ", CCAY, "Asignado");
                }
            }
            con.Close();
        }

        int idInge;
        string nomInge;
        public void GuardaFolio()
        {
            GeneraFolio();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            //ccf = "CCAYAC - 0" + num;
            con.Open();

            SqlCommand sf = new SqlCommand("Save_FolioCCAYAC", con);
            sf.CommandType = CommandType.StoredProcedure;

            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                ccf = "CCAYAC - 0" + num;
                MessageBox.Show("Numero " + num);
                sf.Parameters.Clear();

                sf.Parameters.Add("@numero", SqlDbType.Int);
                sf.Parameters.Add("@idequipo", SqlDbType.VarChar);
                sf.Parameters.Add("@ccayac", SqlDbType.VarChar);
                sf.Parameters.Add("@estatus", SqlDbType.VarChar);
                sf.Parameters.Add("@idinge", SqlDbType.Int);
                sf.Parameters.Add("@inge", SqlDbType.VarChar);
                sf.Parameters.Add("@equipo", SqlDbType.VarChar);
                sf.Parameters.Add("@tipoServicio", SqlDbType.VarChar);
                sf.Parameters.Add("@marca", SqlDbType.VarChar);
                sf.Parameters.Add("@modelo", SqlDbType.VarChar);
                sf.Parameters.Add("@noserie", SqlDbType.VarChar);
                sf.Parameters.Add("@gerencia", SqlDbType.VarChar);
                sf.Parameters.Add("@descripcion", SqlDbType.VarChar);
                sf.Parameters.Add("@ubicacion", SqlDbType.VarChar);
                sf.Parameters.Add("@Partida", SqlDbType.Int);

                sf.Parameters["@numero"].Value = num;
                sf.Parameters["@idequipo"].Value = txtIdEquipo.Text;
                sf.Parameters["@CCAYAC"].Value = "CCAYAC - 0" + num;
                sf.Parameters["@estatus"].Value = row.Cells["cmbDgvEstatus"].Value;
                idInge = Convert.ToInt32(row.Cells["cmbDgvIngeniero"].Value);
                sf.Parameters["@idinge"].Value = idInge;

                if (idInge == 30) { nomInge = "Armando"; }
                if (idInge == 46) { nomInge = "Lebni"; }
                if (idInge == 47) { nomInge = "Antonio"; }
                if (idInge == 48) { nomInge = "Aristeo"; }
                if (idInge == 49) { nomInge = "Brandon"; }
                if (idInge == 50) { nomInge = "Daniel"; }
                if (idInge == 51) { nomInge = "Dulce"; }
                if (idInge == 52) { nomInge = "Eduardo"; }
                if (idInge == 53) { nomInge = "Ezequiel"; }
                if (idInge == 54) { nomInge = "Gustavo"; }
                if (idInge == 55) { nomInge = "Isai"; }
                if (idInge == 56) { nomInge = "Israel"; }
                if (idInge == 57) { nomInge = "Jose Carlos"; }
                if (idInge == 58) { nomInge = "Noe Josue"; }
                if (idInge == 59) { nomInge = "Miguel"; }
                if (idInge == 60) { nomInge = "Sergio"; }
                if (idInge == 61) { nomInge = "Vicente"; }
                if (idInge == 64) { nomInge = "Carlos Daniel"; }
                if (idInge == 65) { nomInge = "Edgar"; }
                if (idInge == 66) { nomInge = "Alejandra"; }
                if (idInge == 71) { nomInge = "Carlos"; }
                if (idInge == 89) { nomInge = "Raúl"; }
                if (idInge == 90) { nomInge = "Jorge"; }
                if (idInge == 93) { nomInge = "Pablo"; }
                if (idInge == 97) { nomInge = "Marian Ariadna"; }
                if (idInge == 100) { nomInge = "Marcela Ibarra"; }
                if (idInge == 102) { nomInge = "Marcos Israel"; }

                sf.Parameters["@inge"].Value = nomInge;
                sf.Parameters["@equipo"].Value = txtEquipo.Text;
                sf.Parameters["@tipoServicio"].Value = row.Cells["txtDgvTipoServicio"].Value;
                sf.Parameters["@marca"].Value = txtMarca.Text;
                sf.Parameters["@modelo"].Value = txtModelo.Text;
                sf.Parameters["@noserie"].Value = txtNoSerie.Text;
                sf.Parameters["@gerencia"].Value = txtGerencia.Text;
                sf.Parameters["@descripcion"].Value = txtDescripcion.Text;
                sf.Parameters["@ubicacion"].Value = txtUbicacion.Text;
                sf.Parameters["@Partida"].Value = Convert.ToInt32(txtPartida.Text);

                sf.ExecuteNonQuery();
                MessageBox.Show("Se han Guardado el Folio CCAYAC - 0" + num, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                num += 1;
            }
            con.Close();
            //MessageBox.Show("Se han guardado los folios correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        public void GeneraFolio()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            string consulta = "select max(Numero) +1 As er From FolioCCAYAC22";

            con.Open();

            SqlCommand cmd = new SqlCommand(consulta, con);
           num = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();
        }


        
        public void GuardaCCAYAC()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            {
                servicio = Convert.ToString(row.Cells["txtDgvTipoServicio"].Value);
                string folio = Convert.ToString(row.Cells["Folio"].Value);

                if (servicio == "Mantenimiento Preventivo")
                {
                    tipoF = "FolioMP";
                    comando = "update CCAYAC22 set " + tipoF + " = '" + folio + "' where IDEquipo = '" + txtIdEquipo.Text +"'";
                    //MessageBox.Show(comando);
                }
                if (servicio == "Mantenimiento Correctivo")
                {
                    tipoF = "FolioMC";
                    comando = "update CCAYAC22 set " + tipoF + " = '" + folio + "' where IDEquipo = '" + txtIdEquipo.Text + "'";
                    //MessageBox.Show(comando);
                }
                if (servicio == "Calibracion")
                {
                    tipoF = "FolioCalib";
                    comando = "update CCAYAC22 set " + tipoF + " = '" + folio + "' where IDEquipo = '" + txtIdEquipo.Text + "'";
                    //MessageBox.Show(comando);
                }
                if (servicio == "IQ")
                {
                    tipoF = "FolioIQ";
                    comando = "update CCAYAC22 set " + tipoF + " = '" + folio + "' where IDEquipo = '" + txtIdEquipo.Text + "'";
                    //MessageBox.Show(comando);
                }
                if (servicio == "OQ")
                {
                    tipoF = "FolioOQ";
                    comando = "update CCAYAC22 set " + tipoF + " = '" + folio + "' where IDEquipo = '" + txtIdEquipo.Text + "'";
                    //MessageBox.Show(comando);
                }
                if (servicio == "PQ")
                {
                    tipoF = "FolioPQ";
                    comando = "update CCAYAC22 set " + tipoF + " = '" + folio + "' where IDEquipo = '" + txtIdEquipo.Text + "'";
                    //MessageBox.Show(comando);
                }
                if(servicio == "Revision")
                {
                    tipoF = "FolioRev";
                    comando = "update CCAYAC22 set " + tipoF + " = '" + folio + "' where IDEquipo = '" + txtIdEquipo.Text + "'";
                    //MessageBox.Show(comando);
                }                

                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = comando;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Se Ha Guardado en SAP el Folio " + lblFolio.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
            }
        }

    }
}
