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
    public partial class NuevoFSR : Form
    {
        public NuevoFSR()
        {
            InitializeComponent();
        }
        conexion cone = new conexion();
        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER01;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");
        string cmbidempresa;
        string fservicio;

        int flag;
       
        private void btnBuscaEmpresa_Click(object sender, EventArgs e)
        {
            Limpiar();

            Cliente frm = new Cliente();
            frm.p_empresid += new Cliente.EmpresaID(EmpresaID);
            frm.ShowDialog();



            //Equipos fm = new Equipos(Convert.ToInt32(cmbidempresa));
            Equipos fm = new Equipos(cmbidempresa);
            fm.p_equipoid += new Equipos.EquipoID(EquipoID);
            fm.ShowDialog();

        }

        public void EmpresaID(string empresa)
        {
            cmbEmpresa.SelectedValue = empresa;
        }
        public void EquipoID(string equipo)
        {
            this.equiposTableAdapter.Fill(this.dSBrowser.Equipos);
            this.modeloTableAdapter.Fill(this.dSBrowser.Modelo);
            this.marcaTableAdapter.Fill(this.dSBrowser.Marca);
            cmbEquipo.SelectedValue = equipo;
        }
        
        //LOAD
        private void NuevoFSR_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.F_Status' Puede moverla o quitarla según sea necesario.
            this.f_StatusTableAdapter.Fill(this.dSBrowser.F_Status);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.ingenieros(this.dSBrowser.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Tipo_Servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_ServicioTableAdapter.Fill(this.dSBrowser.Tipo_Servicio);            
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Tipo_Contrato' Puede moverla o quitarla según sea necesario.
            this.tipo_ContratoTableAdapter.Fill(this.dSBrowser.Tipo_Contrato);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Tipo_Problema' Puede moverla o quitarla según sea necesario.
            this.tipo_ProblemaTableAdapter.Fill(this.dSBrowser.Tipo_Problema);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Equipos' Puede moverla o quitarla según sea necesario.
            this.equiposTableAdapter.Fill(this.dSBrowser.Equipos);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Modelo' Puede moverla o quitarla según sea necesario.
            this.modeloTableAdapter.Fill(this.dSBrowser.Modelo);
            //// TODO: esta línea de código carga datos en la tabla 'dSBrowser.Marca' Puede moverla o quitarla según sea necesario.
            this.marcaTableAdapter.Fill(this.dSBrowser.Marca);
            //// TODO: esta línea de código carga datos en la tabla 'dSBrowser.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.dSBrowser.Clientes);

            //Consecutivo();
            Limpiar();
            //timer1.Start();
            
            
        }
        // Limpia informacion guardada
        public void Limpiar()
        {
            cmbEmpresa.Text = null;
            txtIdequipo_C.Text = null;
            txtNoSerie.Text = null;
            cmbEquipo.Text = null;
            cmbMarca.Text = null;
            cmbModelo.Text = null;
            cmbTContrato.Text = null;
            cmbTProblema.Text = null;
            cmbTServicio.Text = null;
            cmbing.Text = null;
            dtpHora.Text = "";
            txtLocalidad.Text = null;
            txtDepto.Text = null;
            txtNReportado.Text = null;
            txtNResponsable.Text = null;
            txtDireccion.Text = null;
            txtTel.Text = null;
            txtMail.Text = null;
            txtfolio.Text = null;

        
        }
        // id de la empresa
        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbidempresa = Convert.ToString(cmbEmpresa.SelectedValue);

            SqlCommand cmd = new SqlCommand("select *from detalle_clientes where idclientes=" + Convert.ToInt32(cmbEmpresa.SelectedValue), con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())

                //si existe en la BD de detalle cliente
            {
                flag = 1;

                txtTel.Text = Convert.ToString(leer["Tel"]);
                txtDireccion.Text = Convert.ToString(leer["Direccion"]);
                txtLocalidad.Text = Convert.ToString(leer["Localidad"]);
                txtNResponsable.Text = Convert.ToString(leer["N_Responsable"]);
                txtNReportado.Text = Convert.ToString(leer["N_Reportado"]);
                txtMail.Text = Convert.ToString(leer["Mail"]);
                txtDepto.Text = Convert.ToString(leer["Departamento"]);

            }
            //Para Insertar nuevo detalle cliente
            else
            {
                flag = 0;
               
            }

            con.Close();

        }

        // Selecciona equipo y devuelve su informacion
        private void cmbEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select *from equipos where idequipo='" + Convert.ToInt32(cmbEquipo.SelectedValue)+"'", con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                cmbMarca.SelectedValue = Convert.ToInt32(leer["IdMarca"]);
                cmbModelo.SelectedValue = Convert.ToInt32(leer["IdModelo"]);
                txtNoSerie.Text = Convert.ToString(leer["NoSerie"]);
                txtIdequipo_C.Text = Convert.ToString(leer["IdEquipo_C"]);
                //con.Close();
            }
            else
            {
                txtIdequipo_C.Text = null;
                txtNoSerie.Text = null;
                cmbEquipo.Text = null;
                cmbMarca.Text = "";
                cmbModelo.Text = "";
            }
            con.Close();

        }
        // ventana equipos por cliente
        private void btnEquipos_Click(object sender, EventArgs e)
        {
            Equipos frm = new Equipos(cmbidempresa);
            frm.p_equipoid += new Equipos.EquipoID(EquipoID);
            frm.ShowDialog();
        }
        public void Consecutivo()
        {
            SqlCommand cmd = new SqlCommand("select max(folio) + 1 AS er from fsr", con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                txtfolio.Text = Convert.ToString(leer["er"]);
            }

            con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //Consecutivo();
        }

        //Guarda FSR
        public void SaveFSR()
        {
            //Consecutivo();
            con.Open();

            SqlCommand sf = new SqlCommand("Save_FSR_1", con);
            sf.CommandType = CommandType.StoredProcedure;

            sf.Parameters.Add("@idcliente",SqlDbType.VarChar);
            sf.Parameters.Add("@cliente",SqlDbType.VarChar);
            sf.Parameters.Add("@idtcontrato",SqlDbType.Int);
            sf.Parameters.Add("@idtproblema",SqlDbType.Int);
            sf.Parameters.Add("@idtservicio",SqlDbType.Int);
            sf.Parameters.Add("@usuario",SqlDbType.VarChar);
            sf.Parameters.Add("@idstatus",SqlDbType.Int);
            sf.Parameters.Add("@iding",SqlDbType.Int);
            sf.Parameters.Add("@fechaservicio",SqlDbType.DateTime);
            sf.Parameters.Add("@folio",SqlDbType.VarChar);
            sf.Parameters.Add("@idllamada",SqlDbType.Int);
            sf.Parameters.Add("@equipo", SqlDbType.VarChar);
            sf.Parameters.Add("@marca", SqlDbType.VarChar);
            sf.Parameters.Add("@modelo", SqlDbType.VarChar);
            sf.Parameters.Add("@noserie", SqlDbType.VarChar);
            sf.Parameters.Add("@idequipo_C", SqlDbType.VarChar);
            sf.Parameters.Add("@nrespo", SqlDbType.VarChar);
            sf.Parameters.Add("@nreport", SqlDbType.VarChar);
            sf.Parameters.Add("@mail", SqlDbType.VarChar);
            sf.Parameters.Add("@depto", SqlDbType.VarChar);
            sf.Parameters.Add("@tel", SqlDbType.VarChar);
            sf.Parameters.Add("@direccion", SqlDbType.VarChar);
            sf.Parameters.Add("@localidad", SqlDbType.VarChar);
            


            sf.Parameters["@idcliente"].Value = cmbidempresa;
            sf.Parameters["@cliente"].Value = cmbEmpresa.Text;
            sf.Parameters["@idtcontrato"].Value =Convert.ToInt32(cmbTContrato.SelectedValue);
            sf.Parameters["@idtproblema"].Value = Convert.ToInt32(cmbTProblema.SelectedValue);
            sf.Parameters["@idtservicio"].Value = Convert.ToInt32(cmbTServicio.SelectedValue);
            sf.Parameters["@usuario"].Value = "carlos";
            sf.Parameters["@idstatus"].Value = Convert.ToInt32(cmbestatus.SelectedValue);
            sf.Parameters["@iding"].Value =Convert.ToInt32(cmbing.SelectedValue);
            sf.Parameters["@fechaservicio"].Value =dtpfecha.Value;
            sf.Parameters["@folio"].Value = txtfolio.Text;

            sf.Parameters["@idllamada"].Value = 0;
            sf.Parameters["@equipo"].Value = cmbEquipo.Text;
            sf.Parameters["@marca"].Value = cmbMarca.Text;
            sf.Parameters["@modelo"].Value = cmbModelo.Text;
            sf.Parameters["@noserie"].Value = txtNoSerie.Text;
            sf.Parameters["@idequipo_C"].Value = txtIdequipo_C.Text;
            sf.Parameters["@nrespo"].Value = txtNResponsable.Text;
            sf.Parameters["@nreport"].Value = txtNReportado.Text;
            sf.Parameters["@mail"].Value = txtMail.Text;
            sf.Parameters["@depto"].Value = txtDepto.Text;
            sf.Parameters["@tel"].Value = txtTel.Text;
            sf.Parameters["@direccion"].Value = txtDireccion.Text;
            sf.Parameters["@localidad"].Value = txtLocalidad.Text;
                

            sf.ExecuteNonQuery();

            MessageBox.Show("Se Ha Guardado el Folio " +txtfolio.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            con.Close();
            SaveDetEquipo();
            SaveDetFSR();
            SaveDetCliente();

            //Consecutivo();
            
            Limpiar();
            //timer1.Start();
        }
        
        // Boton guardar FSR
        private void btnGuardarFSR_Click(object sender, EventArgs e)
        {
            SaveFSR();
            Limpiar();
        }

        //Guarda detalle Equipo FSR
        public void SaveDetEquipo()
        {
            con.Open();

            SqlCommand de = new SqlCommand("SaveDetEquipo", con);
            de.CommandType = CommandType.StoredProcedure;

            de.Parameters.Add("@folio", SqlDbType.Int);
            de.Parameters.Add("@idequipo", SqlDbType.Int);

            de.Parameters["@folio"].Value =Convert.ToInt32(txtfolio.Text);
            de.Parameters["@idequipo"].Value = Convert.ToInt32(cmbEquipo.SelectedValue);

            de.ExecuteNonQuery();

            con.Close();
        }

        //Guarda en tabla detalle equipo
        public void SaveDetFSR()
        {
            con.Open();

            SqlCommand df = new SqlCommand("SaveDetalleFSR", con);
            df.CommandType = CommandType.StoredProcedure;

            df.Parameters.Add("@folio", SqlDbType.Int);
            df.Parameters.Add("@idcliente", SqlDbType.Int);
            df.Parameters.Add("@nrespo", SqlDbType.VarChar);
            df.Parameters.Add("@nreport", SqlDbType.VarChar);
            df.Parameters.Add("@mail", SqlDbType.VarChar);
            df.Parameters.Add("@depto", SqlDbType.VarChar);
            df.Parameters.Add("@tel", SqlDbType.VarChar);
            df.Parameters.Add("@direccion", SqlDbType.VarChar);
            df.Parameters.Add("@localidad", SqlDbType.VarChar);

            df.Parameters["@folio"].Value = Convert.ToInt32(txtfolio.Text);
            df.Parameters["@idcliente"].Value = Convert.ToInt32(cmbEmpresa.SelectedValue);
            df.Parameters["@nrespo"].Value = txtNResponsable.Text;
            df.Parameters["@nreport"].Value = txtNReportado.Text;
            df.Parameters["@mail"].Value = txtMail.Text;
            df.Parameters["@depto"].Value = txtDepto.Text;
            df.Parameters["@tel"].Value = txtTel.Text;
            df.Parameters["@direccion"].Value = txtDireccion.Text;
            df.Parameters["@localidad"].Value = txtLocalidad.Text;

            df.ExecuteNonQuery();

            con.Close();

        }
        public void SaveDetCliente()
        {
            con.Open();

            if (flag == 0)
            {
                SqlCommand dc = new SqlCommand("SaveDetCliente", con);
                dc.CommandType = CommandType.StoredProcedure;

                dc.Parameters.Add("@folio", SqlDbType.Int);
                dc.Parameters.Add("@idcliente", SqlDbType.Int);
                dc.Parameters.Add("@tel", SqlDbType.VarChar);
                dc.Parameters.Add("@direccion", SqlDbType.VarChar);
                dc.Parameters.Add("@localidad", SqlDbType.VarChar);
                dc.Parameters.Add("@nrespon", SqlDbType.VarChar);
                dc.Parameters.Add("@nreport", SqlDbType.VarChar);
                dc.Parameters.Add("@mail", SqlDbType.VarChar);
                dc.Parameters.Add("@depto", SqlDbType.VarChar);

                dc.Parameters["@folio"].Value = Convert.ToInt32(txtfolio.Text);
                dc.Parameters["@idcliente"].Value = Convert.ToInt32(cmbEmpresa.SelectedValue);
                dc.Parameters["@tel"].Value = txtTel.Text;
                dc.Parameters["@direccion"].Value = txtDireccion.Text;
                dc.Parameters["@localidad"].Value = txtLocalidad.Text;
                dc.Parameters["@nrespon"].Value = txtNResponsable.Text;
                dc.Parameters["@nreport"].Value = txtNReportado.Text;
                dc.Parameters["@mail"].Value = txtMail.Text;
                dc.Parameters["@depto"].Value = txtDepto.Text;

                dc.ExecuteNonQuery();
            }

            else
            {

                SqlCommand dc = new SqlCommand("UpdateDetCliente", con);
                dc.CommandType = CommandType.StoredProcedure;

                dc.Parameters.Add("@idcliente", SqlDbType.VarChar);             
                dc.Parameters.Add("@tel", SqlDbType.VarChar);
                dc.Parameters.Add("@direccion", SqlDbType.VarChar);
                dc.Parameters.Add("@localidad", SqlDbType.VarChar);
                dc.Parameters.Add("@nrespon", SqlDbType.VarChar);
                dc.Parameters.Add("@nreport", SqlDbType.VarChar);
                dc.Parameters.Add("@mail", SqlDbType.VarChar);
                dc.Parameters.Add("@depto", SqlDbType.VarChar);

                dc.Parameters["@idcliente"].Value = Convert.ToInt32(cmbEmpresa.SelectedValue);
                dc.Parameters["@tel"].Value = txtTel.Text;
                dc.Parameters["@direccion"].Value = txtDireccion.Text;
                dc.Parameters["@localidad"].Value = txtLocalidad.Text;
                dc.Parameters["@nrespon"].Value = txtNResponsable.Text;
                dc.Parameters["@nreport"].Value = txtNReportado.Text;
                dc.Parameters["@mail"].Value = txtMail.Text;
                dc.Parameters["@depto"].Value = txtDepto.Text;

                dc.ExecuteNonQuery();
            }                      

            con.Close();
        }

        // Concatena fecha servicio
        private void dtpHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            fservicio= dtpfecha.Text +" "+ dtpHora.Text+":00.000";
            

        }

        public void DetalleEmpresa()
        {
            if(flag==1)
            {

            }
        }

        private void verFolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
      
        }

        private void registroDeFoliosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Registrodefolios frm = new Registrodefolios();
            //frm.Show();
        }

        private void dtpfecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
