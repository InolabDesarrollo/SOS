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


namespace ProyectoInolabServicio
{
    public partial class CCAYAC : Form
    {
        public CCAYAC()
        {
            InitializeComponent();
        }

        string Equipo;
        int Index;

        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");
        private void CCAYAC_Load(object sender, EventArgs e)
        {
            timer1.Start();
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser1.CCAYAC22' Puede moverla o quitarla según sea necesario.
            //this.cCAYAC22TableAdapter.Fill(this.dSBrowser1.CCAYAC22);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.CCAYAC22' Puede moverla o quitarla según sea necesario.
            //this.cCAYAC22TableAdapter.Fill(this.dSBrowser.CCAYAC22);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.CCAYAC21' Puede moverla o quitarla según sea necesario.
            //this.cCAYAC21TableAdapter.Fill(this.dSBrowser.CCAYAC21);

            if(TestSpire.Usr.Rick == 4 || TestSpire.Usr.K == 91 || TestSpire.Usr.K == 71 || TestSpire.Usr.K == 1 || TestSpire.Usr.K == 88 || TestSpire.Usr.K == 8)
            {
                CargaRegistos(1);
            }
            if (TestSpire.Usr.Rick == 6)
            {
                CargaRegistos(2);
                crearFolioMttoPrevToolStripMenuItem.Visible = false;
                verAcuseToolStripMenuItem.Visible = false;
                mttoCDataGridViewTextBoxColumn.Visible = false;
                mttoPDataGridViewTextBoxColumn.Visible = false;
                calibracionDataGridViewTextBoxColumn.Visible = false;
                iQDataGridViewTextBoxColumn.Visible = false;
                oQDataGridViewTextBoxColumn.Visible = false;
                pQDataGridViewTextBoxColumn.Visible = false;
                imprimirFoliosToolStripMenuItem.Visible = false;
                label1.Visible = false;
                textBox1.Visible = false;
            }
          

            Cargardgv_P();
            Cargardgv_S();
            Cargardgv_I();

            timer2.Start();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            recorregrid();
            Cargardgv_P();
            Cargardgv_S();
            Cargardgv_I();

        }

        public void recorregrid()
        {
            con.Open();

            SqlCommand sf = new SqlCommand("SaveCcayac", con);
            sf.CommandType = CommandType.StoredProcedure;

            //foreach (DataGridViewRow row in advancedDataGridView1.Rows)
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                sf.Parameters.Clear();

                sf.Parameters.Add("@ide", SqlDbType.VarChar);
                sf.Parameters.Add("@f_mp", SqlDbType.Date);
                sf.Parameters.Add("@f_mc", SqlDbType.Date);
                sf.Parameters.Add("@f_cal", SqlDbType.Date);
                sf.Parameters.Add("@f_iq", SqlDbType.Date);
                sf.Parameters.Add("@f_oq", SqlDbType.Date);
                sf.Parameters.Add("@f_pq", SqlDbType.Date);
                sf.Parameters.Add("@f_rev", SqlDbType.Date);
                sf.Parameters.Add("@prot", SqlDbType.VarChar);
                sf.Parameters.Add("@serv", SqlDbType.VarChar);
                sf.Parameters.Add("@inf", SqlDbType.VarChar);
                sf.Parameters.Add("@osmc", SqlDbType.VarChar);
                sf.Parameters.Add("@osmp", SqlDbType.VarChar);
                sf.Parameters.Add("@oscalib", SqlDbType.VarChar);
                sf.Parameters.Add("@oscalif", SqlDbType.VarChar);
                sf.Parameters.Add("@f_prot", SqlDbType.Date);
                sf.Parameters.Add("@f_rec", SqlDbType.Date);
                sf.Parameters.Add("@f_eeq", SqlDbType.Date);
                sf.Parameters.Add("@f_rep", SqlDbType.Date);

                sf.Parameters.Add("@f_eprot", SqlDbType.Date);
                sf.Parameters.Add("@f_eserv", SqlDbType.Date);
                sf.Parameters.Add("@f_einf", SqlDbType.Date);
                sf.Parameters.Add("@sensor", SqlDbType.VarChar);
                sf.Parameters.Add("@puntos", SqlDbType.VarChar);
                

                sf.Parameters["@ide"].Value = row.Cells[0].Value;
                sf.Parameters["@f_mp"].Value = row.Cells[27].Value;
                sf.Parameters["@f_mc"].Value = row.Cells[26].Value;
                sf.Parameters["@f_cal"].Value = row.Cells[28].Value;
                sf.Parameters["@f_iq"].Value = row.Cells[29].Value;
                sf.Parameters["@f_oq"].Value = row.Cells[30].Value;
                sf.Parameters["@f_pq"].Value = row.Cells[31].Value;
                sf.Parameters["@f_rev"].Value = row.Cells[32].Value;
                sf.Parameters["@prot"].Value = row.Cells[1].Value;
                sf.Parameters["@serv"].Value = row.Cells[3].Value;
                sf.Parameters["@inf"].Value = row.Cells[5].Value;
                sf.Parameters["@osmc"].Value = row.Cells[12].Value;
                sf.Parameters["@osmp"].Value = row.Cells[13].Value;
                sf.Parameters["@oscalib"].Value = row.Cells[15].Value;
                sf.Parameters["@oscalif"].Value = row.Cells[14].Value;
                sf.Parameters["@f_prot"].Value = row.Cells[33].Value;
                sf.Parameters["@f_rec"].Value = row.Cells[34].Value;
                sf.Parameters["@f_eeq"].Value = row.Cells[35].Value;
                sf.Parameters["@f_rep"].Value = row.Cells[36].Value;

                sf.Parameters["@f_eprot"].Value = row.Cells[2].Value;
                sf.Parameters["@f_eserv"].Value = row.Cells[4].Value;
                sf.Parameters["@f_einf"].Value = row.Cells[6].Value;
                sf.Parameters["@sensor"].Value = row.Cells[25].Value;
                sf.Parameters["@puntos"].Value = row.Cells[19].Value;

                sf.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Se han actualizado los datos correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
            con.Open();

            SqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText= "select *from ccayac22 where idequipo like '%" + textBox1.Text+"%'";
            search.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(search);
            da.Fill(dt);
            //advancedDataGridView1.DataSource = dt;
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void advancedDataGridView1_Enter(object sender, EventArgs e)
        {
            //recorregrid();
        }
        public void Cargardgv_P()
        {
            SqlCommand cmd = new SqlCommand("select distinct(protocolo) as proto_e, count(idequipo) as num from CCAYAC22 where protocolo is not null group by protocolo", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        public void Cargardgv_S()
        {
            SqlCommand cmd = new SqlCommand("select distinct(servicio) as serv_e, count(idequipo) as num from CCAYAC22 where servicio is not null group by servicio", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }
        public void Cargardgv_I()
        {
            SqlCommand cmd = new SqlCommand("select distinct(informes) as inf_e, count(informes) as num from CCAYAC22 where informes is not null group by informes", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex == -1)// EVALUA EL INDICE EN DADO CASO DE SELECCIONAR EL ENCABEZADO
            //{
            //    return;
            //}
            DataGridViewRow dvg = dataGridView2.Rows[e.RowIndex];

            con.Open();

            SqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "select *from ccayac22 where protocolo like '%" + dvg.Cells[0].Value.ToString() + "%'";
            search.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(search);
            da.Fill(dt);
            //advancedDataGridView1.DataSource = dt;
            dataGridView1.DataSource = dt;

            con.Close();
        }
        string idequipo;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dvg = dataGridView1.Rows[e.RowIndex];
           

            idequipo = dvg.Cells[0].Value.ToString();

            //MessageBox.Show(idequipo);

        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dgv = dataGridView1.Rows[e.RowIndex];
            Equipo = dgv.Cells["iDEquipodgvTxt"].Value.ToString();

            int cont;
            string query = "select COUNT(IdEquipo) as f from FolioCCAYAC22 where IdEquipo = '" + Equipo + "'";

            con.Open();

            SqlCommand cm = new SqlCommand(query, con);
            cont = Convert.ToInt32(cm.ExecuteScalar());
            con.Close();

            if (cont >= 1)
            {
                MessageBox.Show("El equipo ya cuenta con folios Asignados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                AsignaFolioCCAYAC frm = new AsignaFolioCCAYAC(Equipo);
                frm.Show();
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dvg = dataGridView3.Rows[e.RowIndex];

            con.Open();

            SqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "select *from ccayac22 where servicio like '%" + dvg.Cells[0].Value.ToString() + "%'";
            search.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(search);
            da.Fill(dt);
            //advancedDataGridView1.DataSource = dt;
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dvg = dataGridView4.Rows[e.RowIndex];

            con.Open();

            SqlCommand search = con.CreateCommand();
            search.CommandType = CommandType.Text;
            search.CommandText = "select *from ccayac22 where informes like '%" + dvg.Cells[0].Value.ToString() + "%'";
            search.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(search);
            da.Fill(dt);
            //advancedDataGridView1.DataSource = dt;
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void crearFolioMttoPrevToolStripMenuItem_Click(object sender, EventArgs e)
        {

           

        }
       //MP
        private void crearFolioIQToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            folio();
            idE = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();
            string equipo = dataGridView1.Rows[Index].Cells["equipoDgvTxt"].Value.ToString();
            string marca = dataGridView1.Rows[Index].Cells["txtDgvMarca"].Value.ToString();
            string modelo = dataGridView1.Rows[Index].Cells["txtDgvModelo"].Value.ToString();
            string noserie = dataGridView1.Rows[Index].Cells["txtDgvSerie"].Value.ToString();
            string gerencia = dataGridView1.Rows[Index].Cells["txtDgvGerencia"].Value.ToString();
            string partida = dataGridView1.Rows[Index].Cells["partida"].Value.ToString();
            string ubicacion = dataGridView1.Rows[Index].Cells["txtDgvUbicacion"].Value.ToString();
            string descipcion = dataGridView1.Rows[Index].Cells["txtDgvDescripcion"].Value.ToString();

            con.Open();

            SqlCommand sf = new SqlCommand("Save_FolioCCAYAC", con);
            sf.CommandType = CommandType.StoredProcedure;

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

            sf.Parameters["@numero"].Value = c_folio;
            sf.Parameters["@idequipo"].Value = idE;
            sf.Parameters["@CCAYAC"].Value = "CCAYAC - 0" + c_folio;
            sf.Parameters["@estatus"].Value = "Asignado";
            sf.Parameters["@idinge"].Value = 0;
            sf.Parameters["@inge"].Value = "";
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@tipoServicio"].Value = "Mantenimiento Preventivo";
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noserie;
            sf.Parameters["@gerencia"].Value = gerencia;
            sf.Parameters["@descripcion"].Value = descipcion;
            sf.Parameters["@ubicacion"].Value = ubicacion;
            sf.Parameters["@Partida"].Value = partida;//Convert.ToInt32(txtPartida.Text);

            sf.ExecuteNonQuery();

            con.Close();

            saveCCayac("FolioMP");

            //folio();
            MessageBox.Show("Se asigno el folio CCAYAC - 0" + c_folio);
        }

        string idE;
        //IQ
        private void crearFolioOQToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            folio();
            idE = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();
            string equipo = dataGridView1.Rows[Index].Cells["equipoDgvTxt"].Value.ToString();
            string marca = dataGridView1.Rows[Index].Cells["txtDgvMarca"].Value.ToString();
            string modelo = dataGridView1.Rows[Index].Cells["txtDgvModelo"].Value.ToString();
            string noserie = dataGridView1.Rows[Index].Cells["txtDgvSerie"].Value.ToString();
            string gerencia = dataGridView1.Rows[Index].Cells["txtDgvGerencia"].Value.ToString();
            string partida = dataGridView1.Rows[Index].Cells["partida"].Value.ToString();
            string ubicacion = dataGridView1.Rows[Index].Cells["txtDgvUbicacion"].Value.ToString();
            string descripcion = dataGridView1.Rows[Index].Cells["txtDgvDescripcion"].Value.ToString();

            con.Open();

            SqlCommand sf = new SqlCommand("Save_FolioCCAYAC", con);
            sf.CommandType = CommandType.StoredProcedure;

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

            sf.Parameters["@numero"].Value = c_folio;
            sf.Parameters["@idequipo"].Value = idE;
            sf.Parameters["@CCAYAC"].Value = "CCAYAC - 0" + c_folio;
            sf.Parameters["@estatus"].Value = "Asignado";            
            sf.Parameters["@idinge"].Value = 0;            
            sf.Parameters["@inge"].Value = "";
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@tipoServicio"].Value = "IQ";
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noserie;
            sf.Parameters["@gerencia"].Value = gerencia;
            sf.Parameters["@descripcion"].Value = descripcion;
            sf.Parameters["@ubicacion"].Value = ubicacion;
            sf.Parameters["@Partida"].Value = partida;//Convert.ToInt32(txtPartida.Text);

            sf.ExecuteNonQuery();

            con.Close();

            saveCCayac("FolioIQ");

            //folio();
            MessageBox.Show("Se asigno el folio CCAYAC - 0" + c_folio);
        }


        int c_folio;
        public void folio()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            SqlCommand cmd = new SqlCommand("select max(Numero) +1 AS er from FolioCCAYAC22", con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                c_folio= Convert.ToInt32(leer["er"]);
            }

            con.Close();
        }


        public void saveCCayac(string tipoFolio)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            string comando = "update CCAYAC22 set " + tipoFolio + " = 'CCAYAC - 0" + c_folio + "' where IDEquipo = '" + idE + "'";

            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = comando;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Se Ha Guardado en SAP el Folio " + lblFolio.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }


        //OQ
        private void crearFolioCalibToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            folio();
            idE = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();
            string equipo = dataGridView1.Rows[Index].Cells["equipoDgvTxt"].Value.ToString();
            string marca = dataGridView1.Rows[Index].Cells["txtDgvMarca"].Value.ToString();
            string modelo = dataGridView1.Rows[Index].Cells["txtDgvModelo"].Value.ToString();
            string noserie = dataGridView1.Rows[Index].Cells["txtDgvSerie"].Value.ToString();
            string gerencia = dataGridView1.Rows[Index].Cells["txtDgvGerencia"].Value.ToString();
            string partida = dataGridView1.Rows[Index].Cells["partida"].Value.ToString();
            string ubicacion = dataGridView1.Rows[Index].Cells["txtDgvUbicacion"].Value.ToString();
            string descripcion = dataGridView1.Rows[Index].Cells["txtDgvDescripcion"].Value.ToString();

            con.Open();

            SqlCommand sf = new SqlCommand("Save_FolioCCAYAC", con);
            sf.CommandType = CommandType.StoredProcedure;

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

            sf.Parameters["@numero"].Value = c_folio;
            sf.Parameters["@idequipo"].Value = idE;
            sf.Parameters["@CCAYAC"].Value = "CCAYAC - 0" + c_folio;
            sf.Parameters["@estatus"].Value = "Asignado";
            sf.Parameters["@idinge"].Value = 0;
            sf.Parameters["@inge"].Value = "";
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@tipoServicio"].Value = "OQ";
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noserie;
            sf.Parameters["@gerencia"].Value = gerencia;
            sf.Parameters["@descripcion"].Value = descripcion;
            sf.Parameters["@ubicacion"].Value = ubicacion;
            sf.Parameters["@Partida"].Value = partida;//Convert.ToInt32(txtPartida.Text);

            sf.ExecuteNonQuery();

            con.Close();

            saveCCayac("FolioOQ");

            //folio();
            MessageBox.Show("Se asigno el folio CCAYAC - 0" + c_folio);
        }
        //PQ
        private void crearFolioRevToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            folio();
            idE = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();
            string equipo = dataGridView1.Rows[Index].Cells["equipoDgvTxt"].Value.ToString();
            string marca = dataGridView1.Rows[Index].Cells["txtDgvMarca"].Value.ToString();
            string modelo = dataGridView1.Rows[Index].Cells["txtDgvModelo"].Value.ToString();
            string noserie = dataGridView1.Rows[Index].Cells["txtDgvSerie"].Value.ToString();
            string gerencia = dataGridView1.Rows[Index].Cells["txtDgvGerencia"].Value.ToString();
            string partida = dataGridView1.Rows[Index].Cells["partida"].Value.ToString();
            string ubicacion = dataGridView1.Rows[Index].Cells["txtDgvUbicacion"].Value.ToString();
            string descripcion = dataGridView1.Rows[Index].Cells["txtDgvDescripcion"].Value.ToString();

            con.Open();

            SqlCommand sf = new SqlCommand("Save_FolioCCAYAC", con);
            sf.CommandType = CommandType.StoredProcedure;

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

            sf.Parameters["@numero"].Value = c_folio;
            sf.Parameters["@idequipo"].Value = idE;
            sf.Parameters["@CCAYAC"].Value = "CCAYAC - 0" + c_folio;
            sf.Parameters["@estatus"].Value = "Asignado";
            sf.Parameters["@idinge"].Value = 0;
            sf.Parameters["@inge"].Value = "";
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@tipoServicio"].Value = "PQ";
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noserie;
            sf.Parameters["@gerencia"].Value = gerencia;
            sf.Parameters["@descripcion"].Value = descripcion;
            sf.Parameters["@ubicacion"].Value = ubicacion;
            sf.Parameters["@Partida"].Value = partida;//Convert.ToInt32(txtPartida.Text);

            sf.ExecuteNonQuery();

            con.Close();

            saveCCayac("FolioPQ");

            //folio();
            MessageBox.Show("Se asigno el folio CCAYAC - 0" + c_folio);
        }
        //Calib
        private void calibracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folio();
            idE = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();
            string equipo = dataGridView1.Rows[Index].Cells["equipoDgvTxt"].Value.ToString();
            string marca = dataGridView1.Rows[Index].Cells["txtDgvMarca"].Value.ToString();
            string modelo = dataGridView1.Rows[Index].Cells["txtDgvModelo"].Value.ToString();
            string noserie = dataGridView1.Rows[Index].Cells["txtDgvSerie"].Value.ToString();
            string gerencia = dataGridView1.Rows[Index].Cells["txtDgvGerencia"].Value.ToString();
            string partida = dataGridView1.Rows[Index].Cells["partida"].Value.ToString();
            string ubicacion = dataGridView1.Rows[Index].Cells["txtDgvUbicacion"].Value.ToString();
            string descripcion = dataGridView1.Rows[Index].Cells["txtDgvDescripcion"].Value.ToString();

            con.Open();

            SqlCommand sf = new SqlCommand("Save_FolioCCAYAC", con);
            sf.CommandType = CommandType.StoredProcedure;

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

            sf.Parameters["@numero"].Value = c_folio;
            sf.Parameters["@idequipo"].Value = idE;
            sf.Parameters["@CCAYAC"].Value = "CCAYAC - 0" + c_folio;
            sf.Parameters["@estatus"].Value = "Asignado";
            sf.Parameters["@idinge"].Value = 0;
            sf.Parameters["@inge"].Value = "";
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@tipoServicio"].Value = "Calibracion";
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noserie;
            sf.Parameters["@gerencia"].Value = gerencia;
            sf.Parameters["@descripcion"].Value = descripcion;
            sf.Parameters["@ubicacion"].Value = ubicacion;
            sf.Parameters["@Partida"].Value = partida;//Convert.ToInt32(txtPartida.Text);

            sf.ExecuteNonQuery();

            con.Close();

            saveCCayac("FolioCalib");

            //folio();
            MessageBox.Show("Se asigno el folio CCAYAC - 0" + c_folio);
        }
        //Rev
        private void revisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folio();
            idE = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();
            string equipo = dataGridView1.Rows[Index].Cells["equipoDgvTxt"].Value.ToString();
            string marca = dataGridView1.Rows[Index].Cells["txtDgvMarca"].Value.ToString();
            string modelo = dataGridView1.Rows[Index].Cells["txtDgvModelo"].Value.ToString();
            string noserie = dataGridView1.Rows[Index].Cells["txtDgvSerie"].Value.ToString();
            string gerencia = dataGridView1.Rows[Index].Cells["txtDgvGerencia"].Value.ToString();
            string partida = dataGridView1.Rows[Index].Cells["partida"].Value.ToString();
            string ubicacion = dataGridView1.Rows[Index].Cells["txtDgvUbicacion"].Value.ToString();
            string descripcion = dataGridView1.Rows[Index].Cells["txtDgvDescripcion"].Value.ToString();

            con.Open();

            SqlCommand sf = new SqlCommand("Save_FolioCCAYAC", con);
            sf.CommandType = CommandType.StoredProcedure;

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

            sf.Parameters["@numero"].Value = c_folio;
            sf.Parameters["@idequipo"].Value = idE;
            sf.Parameters["@CCAYAC"].Value = "CCAYAC - 0" + c_folio;
            sf.Parameters["@estatus"].Value = "Asignado";
            sf.Parameters["@idinge"].Value = 0;
            sf.Parameters["@inge"].Value = "";
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@tipoServicio"].Value = "Revision";
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noserie;
            sf.Parameters["@gerencia"].Value = gerencia;
            sf.Parameters["@descripcion"].Value = descripcion;
            sf.Parameters["@ubicacion"].Value = ubicacion;
            sf.Parameters["@Partida"].Value = partida;//Convert.ToInt32(txtPartida.Text);

            sf.ExecuteNonQuery();

            con.Close();

            saveCCayac("FolioRev");

            //folio();
            MessageBox.Show("Se asigno el folio CCAYAC - 0" + c_folio);
        }

        //MC
        private void crearFolioPQToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            folio();
            idE = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();
            string equipo = dataGridView1.Rows[Index].Cells["equipoDgvTxt"].Value.ToString();
            string marca = dataGridView1.Rows[Index].Cells["txtDgvMarca"].Value.ToString();
            string modelo = dataGridView1.Rows[Index].Cells["txtDgvModelo"].Value.ToString();
            string noserie = dataGridView1.Rows[Index].Cells["txtDgvSerie"].Value.ToString();
            string gerencia = dataGridView1.Rows[Index].Cells["txtDgvGerencia"].Value.ToString();
            string partida = dataGridView1.Rows[Index].Cells["partida"].Value.ToString();
            string ubicacion = dataGridView1.Rows[Index].Cells["txtDgvUbicacion"].Value.ToString();
            string descripcion = dataGridView1.Rows[Index].Cells["txtDgvDescripcion"].Value.ToString();

            con.Open();

            SqlCommand sf = new SqlCommand("Save_FolioCCAYAC", con);
            sf.CommandType = CommandType.StoredProcedure;

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

            sf.Parameters["@numero"].Value = c_folio;
            sf.Parameters["@idequipo"].Value = idE;
            sf.Parameters["@CCAYAC"].Value = "CCAYAC - 0" + c_folio;
            sf.Parameters["@estatus"].Value = "Asignado";
            sf.Parameters["@idinge"].Value = 0;
            sf.Parameters["@inge"].Value = "";
            sf.Parameters["@equipo"].Value = equipo;
            sf.Parameters["@tipoServicio"].Value = "Mantenimiento Correctivo";
            sf.Parameters["@marca"].Value = marca;
            sf.Parameters["@modelo"].Value = modelo;
            sf.Parameters["@noserie"].Value = noserie;
            sf.Parameters["@gerencia"].Value = gerencia;
            sf.Parameters["@descripcion"].Value = descripcion;
            sf.Parameters["@ubicacion"].Value = ubicacion;
            sf.Parameters["@Partida"].Value = partida;//Convert.ToInt32(txtPartida.Text);

            sf.ExecuteNonQuery();

            con.Close();

            saveCCayac("FolioMC");

            //folio();
            //MessageBox.Show("Info " + equipo + modelo + descripcion);
            MessageBox.Show("Se asigno el folio CCAYAC - 0" + c_folio);
        }

        private void imprimirFoliosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idE = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();

            FoliosCCAYAC frm = new FoliosCCAYAC(idE);
            frm.Show();
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            CalendarioCCAYAC frm = new CalendarioCCAYAC();
            frm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void calendarioCCAYACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarioCCAYAC frm = new CalendarioCCAYAC();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        string folioCC;
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //this.dataGridView1.Rows[e.RowIndex].Selected = true;
                this.Index = e.RowIndex;
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.contextMenuStrip1.Show(this.dataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);

                if (dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioIQ"] || dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioOQ"] || dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioPQ"]
                    || dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioMC"] || dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioMP"] || dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioCalib"]
                    || dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioRev"])
                {
                    folioCC = dataGridView1.Rows[Index].Cells[e.ColumnIndex].Value.ToString();
                    actualizarFolioToolStripMenuItem.Visible = true;
                    verFolioToolStripMenuItem.Visible = true;
                }
                else
                {
                    actualizarFolioToolStripMenuItem.Visible = false;
                    verFolioToolStripMenuItem.Visible = false;
                }
            }
        }


        private void verAcuseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string equipo;
            equipo = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();

            //MessageBox.Show(equipo);

            AcuseServicio frm = new AcuseServicio(equipo);
            frm.Show();
        }

        private void actualizarFolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string eq = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();
            BuscaFolio(eq, folioCC);

            if(conteo <= 0)
            {
                MessageBox.Show("El folio para este servicio aun no ha sido creado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioIQ"])
                {
                    ActualizaFolioCCAYAC frm = new ActualizaFolioCCAYAC(eq, dataGridView1.Rows[Index].Cells["FolioIQ"].Value.ToString(), "IQ", TestSpire.Usr.Rick);
                    frm.Show();
                }
                if (dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioOQ"])
                {
                    ActualizaFolioCCAYAC frm = new ActualizaFolioCCAYAC(eq, dataGridView1.Rows[Index].Cells["FolioOQ"].Value.ToString(), "OQ", TestSpire.Usr.Rick);
                    frm.Show();
                }
                if (dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioPQ"])
                {
                    ActualizaFolioCCAYAC frm = new ActualizaFolioCCAYAC(eq, dataGridView1.Rows[Index].Cells["FolioPQ"].Value.ToString(), "PQ", TestSpire.Usr.Rick);
                    frm.Show();
                }
                if (dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioMC"])
                {
                    ActualizaFolioCCAYAC frm = new ActualizaFolioCCAYAC(eq, dataGridView1.Rows[Index].Cells["FolioMC"].Value.ToString(), "Mantenimiento Correctivo", TestSpire.Usr.Rick);
                    frm.Show();
                }
                if (dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioMP"])
                {
                    ActualizaFolioCCAYAC frm = new ActualizaFolioCCAYAC(eq, dataGridView1.Rows[Index].Cells["FolioMP"].Value.ToString(), "Mantenimiento Preventivo", TestSpire.Usr.Rick);
                    frm.Show();
                }
                if (dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioCalib"])
                {
                    ActualizaFolioCCAYAC frm = new ActualizaFolioCCAYAC(eq, dataGridView1.Rows[Index].Cells["FolioCalib"].Value.ToString(), "Calibracion", TestSpire.Usr.Rick);
                    frm.Show();
                }
                if (dataGridView1.CurrentCell == dataGridView1.Rows[Index].Cells["FolioRev"])
                {
                    ActualizaFolioCCAYAC frm = new ActualizaFolioCCAYAC(eq, dataGridView1.Rows[Index].Cells["FolioRev"].Value.ToString(), "Revision", TestSpire.Usr.Rick);
                    frm.Show();
                }
            }
        }


        int conteo;
        public void BuscaFolio(string eq, string numcc)
        {
            string q = "select count(*) as N from FolioCCAYAC22 where IDEquipo = '" + eq + "' and CCAYAC = '" + numcc + "'";

            con.Open();
            SqlCommand cmd = new SqlCommand(q, con);
            conteo = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
        }


        string numeroF = null;
        public void BuscaNum(string eq, string numcc)
        {
            string qu = "select Numero from FolioCCAYAC22 where IDEquipo = '" + eq + "' and CCAYAC = '" + numcc + "'";

            con.Open();
            SqlCommand cmd = new SqlCommand(qu, con);
            numeroF = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

        string query;
        public void CargaRegistos(int tipo)
        {            
            if (tipo == 1)
            {
                query = "select * from CCAYAC22";
            }
            if(tipo == 2)
            {
                query = "select distinct a.* from CCAYAC22 a inner join FolioCCAYAC22 b on b.Partida = a.Partida where b.IdIngeniero = " + TestSpire.Usr.K;
            }

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            con.Close();
        }

        private void verFolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string eq = dataGridView1.Rows[Index].Cells["iDEquipodgvTxt"].Value.ToString();
            BuscaNum(eq, folioCC);
            
            if(string.IsNullOrEmpty(numeroF))
            {
                MessageBox.Show("No Existe Folio para este Servicio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                VerFolioCCAYAC frm = new VerFolioCCAYAC(numeroF);
                frm.Show();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.cCAYAC22TableAdapter.Fill(this.dSBrowser1.CCAYAC22);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            folio();
        }
  
    }
}
