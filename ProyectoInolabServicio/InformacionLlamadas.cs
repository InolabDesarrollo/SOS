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
    public partial class Llamadas : Form
    {
        public Llamadas(string folio_p)
        {
            InitializeComponent();
            folio = folio_p;

        }
        string folio;

        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER01;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        private void ActualizacionFSR_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.dSBrowser.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.F_Status' Puede moverla o quitarla según sea necesario.
            this.f_StatusTableAdapter.Fill(this.dSBrowser.F_Status);
            SqlCommand cmd = new SqlCommand("select *from fsr where nollamada=" + Convert.ToInt32(folio), con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                txtEmpresa.Text = Convert.ToString(leer["Cliente"]);
                txtDepto.Text = Convert.ToString(leer["Depto"]);
                txtNRespon.Text = Convert.ToString(leer["N_Responsable"]);
                txtNReport.Text = Convert.ToString(leer["N_Reportado"]);
                txtTel.Text = Convert.ToString(leer["Telefono"]);
                txtDireccion.Text = Convert.ToString(leer["Direccion"]);
                txtLocalidad.Text = Convert.ToString(leer["localidad"]);
                txtEmail.Text = Convert.ToString(leer["Mail"]);
                txtEquipo.Text = Convert.ToString(leer["Equipo"]);
                txtMarca.Text = Convert.ToString(leer["Marca"]);
                txtModelo.Text = Convert.ToString(leer["Modelo"]);
                txtNoSerie.Text = Convert.ToString(leer["NoSerie"]);
                txtIdEquipoC.Text = Convert.ToString(leer["IdEquipo_C"]);
                txthorasolicitudserv.Text = Convert.ToString(leer["HoraServicio"]);
                txtfechasolicitudservicio.Text = Convert.ToString(leer["FechaFolio"]);
                txtNoSolicitud.Text = Convert.ToString(leer["NoLlamada"]);
                txtInicioServicio.Text = Convert.ToString(leer["Inicio_Servicio"]);
                txtFechaFinServicio.Text = Convert.ToString(leer["Fin_Servicio"]);
                lblNoSolicitud.Text = Convert.ToString(leer["NoLlamada"]);
                cmbIng.SelectedValue = Convert.ToInt32(leer["Id_Ingeniero"]);
                


                //txtNoSolicitud.Text = Convert.ToString(leer["IdFSR"]);
                //txtfechasolicitudservicio.Text = String.Format("{0:dd - MMM - yy}", leer["F_SolicitudServicio"]);
                //txthorasolicitudserv.Text = String.Format("{0:HH:mm}",leer["F_SolicitudServicio"]);
                //txtInicioServicio.Text= String.Format("{0:dd - MMM - yy}", leer["Inicio_Servicio"]);
                //txtinicioHoraServicio.Text= String.Format("{0:HH:mm}", leer["Inicio_Servicio"]);
                //txtFechaFinServicio.Text= String.Format("{0:dd - MMM - yy}", leer["Fin_Servicio"]);
                //txtHoraFinServicio.Text= String.Format("{0:HH:mm}", leer["Fin_Servicio"]);
                //txtObservaciones.Text = Convert.ToString(leer["Observaciones"]);
                //txtEmpresa.Text = Convert.ToString(leer["Cliente"]);
                //txtTel.Text = Convert.ToString(leer["Tel"]);
                //txtDepto.Text = Convert.ToString(leer["Departamento"]);
                //txtLocalidad.Text = Convert.ToString(leer["Localidad"]);
                //txtNReport.Text = Convert.ToString(leer["N_Report"]);
                //txtNRespon.Text = Convert.ToString(leer["N_respons"]);
                //txtEmail.Text = Convert.ToString(leer["Mail1"]);
                //txtTContrato.Text = Convert.ToString(leer["TipoContrato"]);
                //txtTProblema.Text = Convert.ToString(leer["TipoProblema"]);
                //txtTServicio.Text = Convert.ToString(leer["TipoServicio"]);
                //txtEquipo.Text = Convert.ToString(leer["Equipo"]);
                //txtMarca.Text = Convert.ToString(leer["Marca"]);
                //txtModelo.Text = Convert.ToString(leer["Modelo"]);
                //txtNoSerie.Text = Convert.ToString(leer["NoSerie"]);
                //txtIdEquipoC.Text = Convert.ToString(leer["IdEquipo_C"]);
                //txtDireccion.Text = Convert.ToString(leer["Direccion"]);


            }
            con.Close();
            servicios();
        }

        public void servicios()
        {
            SqlCommand cmd = new SqlCommand("select Descripcion, f.Folio from Tipo_Servicio S left join FSR F on F.IdT_Servicio=S.ID where F.NoLlamada=" + Convert.ToInt32(lblNoSolicitud.Text), con);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();



        }
    }
}
