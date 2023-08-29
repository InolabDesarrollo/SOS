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
    public partial class ActualizaFolioCCAYAC : Form
    {
        public ActualizaFolioCCAYAC( string IdE, string folio, string tipoS, int IdA)
        {
            InitializeComponent();
            IdEquipo = IdE;
            FolioCC = folio;
            tipoServ = tipoS;
            IdArea = IdA;
        }

        string IdEquipo, FolioCC, tipoServ;
        string fecha, accionR, hora;
        int IdArea;

        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (IdArea == 4)
            {
                ActualizaFolio(2);
            }
            if (IdArea == 6)
            {
                if (string.IsNullOrEmpty(dtpFechaInicio.Text))
                {
                    MessageBox.Show("El campo de Fecha Inicio no puede estar vacio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(dtpFechaFin.Text))
                {
                    MessageBox.Show("El campo de Fecha Fin no puede estar vacio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(cmbHoraIni.Text))
                {
                    MessageBox.Show("El campo de Hora Inicio no puede estar vacio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(cmbMinIni.Text))
                {
                    MessageBox.Show("El campo de Minutos Inicio no puede estar vacio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(cmbHorafin.Text))
                {
                    MessageBox.Show("El campo de Hora Fin no puede estar vacio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(cmbMinFin.Text))
                {
                    MessageBox.Show("El campo de Minutos Fin no puede estar vacio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(advancedDataGridView2.Rows.Count-1 == 0)
                {
                    MessageBox.Show("No se han agregado Acciones", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ActualizaFolio(1);
            }

            GuardaAcciones();

            
            //btnGuardar.Visible = false;
            //ActualizaFolio(1);
        }

        private void ActualizaFolioCCAYAC_Load(object sender, EventArgs e)
        {            
            cmbIngeniero.SelectedItem = null;
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.browserDataSet.Usuarios);
            

            CargaDatos();
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.AccionCCAYAC22' Puede moverla o quitarla según sea necesario.
            this.accionCCAYAC22TableAdapter.FillBy(this.browserDataSet.AccionCCAYAC22, Convert.ToInt32(lblNum.Text));

            if (IdArea == 6)
            {
                cmbIngeniero.Enabled = false;
            }
            if(IdArea == 4)
            {
                dtpFechaInicio.Enabled = false;
                dtpFechaFin.Enabled = false;
                txtObservaciones.Enabled = false;
                txtNombreUser.Enabled = false;
                cmbHoraIni.Enabled = false;
                cmbHorafin.Enabled = false;
                cmbMinIni.Enabled = false;
                cmbMinFin.Enabled = false;
                txtOrdenServ.Enabled = false;
                txtNomResponsable.Enabled = false;
            }
            
            for (int i = 1; i <= 24; i++)
            {
                if(i <= 9)
                {
                    cmbHoraIni.Items.Add("0" + i);
                    cmbHorafin.Items.Add("0" + i);
                }
                else
                {
                    cmbHoraIni.Items.Add(i);
                    cmbHorafin.Items.Add(i);
                }
                
            }
        }           



        public void CargaDatos()
        {
            DateTime fechaI, fechaF;
            string horaI, horaF;
            int IdIng;
            SqlCommand cmd = new SqlCommand("select *,  DATEPART(HOUR, Fecha_Inicio) as HoraIni, DATEPART(MINUTE, Fecha_Inicio) as MinIni, " +
                "DATEPART(HOUR, Fecha_Fin) as HoraFin, DATEPART(MINUTE, Fecha_Fin) AS MinFin from FolioCCAYAC22 where  CCAYAC = '" + FolioCC + "' AND IdEquipo = '" + IdEquipo + "'", con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                lblFolio.Text = Convert.ToString(leer["CCAYAC"]);
                lblServicio.Text = Convert.ToString(leer["TipoServicio"]);
                lblNum.Text = Convert.ToString(leer["Numero"]);
                txtIdEquipo.Text = Convert.ToString(leer["IdEquipo"]);
                txtEquipo.Text = Convert.ToString(leer["Equipo"]);
                txtMarca.Text = Convert.ToString(leer["Marca"]);
                txtModelo.Text = Convert.ToString(leer["Modelo"]);
                txtNoserie.Text = Convert.ToString(leer["NoSerie"]);
                txtUbicacion.Text = Convert.ToString(leer["Ubicacion"]);
                txtGerencia.Text = Convert.ToString(leer["Gerencia"]);
                txtPartida.Text = Convert.ToString(leer["Partida"]);
                IdIng = Convert.ToInt32(leer["IdIngeniero"]);
                dtpFechaInicio.Text = Convert.ToString(leer["Fecha_Inicio"]);                            
                dtpFechaFin.Text = Convert.ToString(leer["Fecha_Fin"]);
                txtObservaciones.Text = Convert.ToString(leer["Observaciones"]);
                txtNombreUser.Text = Convert.ToString(leer["NombreUser"]);
                txtOrdenServ.Text = Convert.ToString(leer["OrdenServicio"]);
                txtNomResponsable.Text = Convert.ToString(leer["NResponsable"]);
                cmbHoraIni.SelectedItem = Convert.ToString(leer["HoraIni"]);
                cmbMinIni.SelectedItem= Convert.ToString(leer["MinIni"]);
                cmbHorafin.SelectedItem = Convert.ToString(leer["HoraFin"]);
                cmbMinFin.SelectedItem = Convert.ToString(leer["MinFin"]);

                if (IdIng == 0)
                {
                    cmbIngeniero.Text = "";
                }
                else
                {
                    cmbIngeniero.SelectedValue = IdIng;
                }
            }
            con.Close();

            for(int i = 0; i <= 59; i++)
            {
                if(i <= 9)
                {
                    cmbMinIni.Items.Add("0" + i);
                    cmbMinFin.Items.Add("0" + i);
                }
                else
                {
                    cmbMinIni.Items.Add(i);
                    cmbMinFin.Items.Add(i);
                }                
            }
        }

        int v_dvg;

        private void advancedDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        string consul;
        public void GuardaAcciones()
        {
            BuscaAcciones();
            string fecha, hora, accion, folio;
            int filas, IdAccion;
            DateTime fecha1;

            filas = advancedDataGridView2.Rows.Count -1;
            filas = filas - cont;
            if(advancedDataGridView2.Rows.Count-1 > cont)
            {
                for (int i = 0; i < filas; i++)
                {
                    fecha1 = Convert.ToDateTime(advancedDataGridView2.Rows[i + cont].Cells["txtDgvFechaAccion"].Value);
                    fecha = fecha1.ToString("yyyy-MM-dd");
                    hora = Convert.ToString(advancedDataGridView2.Rows[i + cont].Cells["txtDgvHorasAccion"].Value);
                    accion = Convert.ToString(advancedDataGridView2.Rows[i + cont].Cells["txtDgvAccion"].Value);
                    folio = lblNum.Text;

                    consul = "insert into AccionCCAYAC22 values('" + fecha + "', " + hora + ", '" + accion + "', " + folio + ", GETDATE())";

                    SqlCommand insert = new SqlCommand(consul, con);
                    con.Open();
                    insert.ExecuteNonQuery();
                    con.Close();
                }

                for(int i = 0; i <  advancedDataGridView2.Rows.Count-filas-1; i++)
                {
                    fecha1 = Convert.ToDateTime(advancedDataGridView2.Rows[i].Cells["txtDgvFechaAccion"].Value);
                    fecha = fecha1.ToString("yyyy-MM-dd");
                    hora = Convert.ToString(advancedDataGridView2.Rows[i].Cells["txtDgvHorasAccion"].Value);
                    accion = Convert.ToString(advancedDataGridView2.Rows[i].Cells["txtDgvAccion"].Value);
                    IdAccion = Convert.ToInt32(advancedDataGridView2.Rows[i].Cells["txtDgvIdAccion"].Value);

                    consul = "update AccionCCAYAC22 set FechaAccion = '" + fecha + "', HorasAccion = " + hora + ", Accion = '" + accion + "', FechaSist = GETDATE() WHERE IdAccion = " + IdAccion;

                    SqlCommand update = new SqlCommand(consul, con);
                    con.Open();
                    update.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Se guardaron los datos Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if(advancedDataGridView2.Rows.Count-1 == cont)
            {
                for(int i = 0; i < advancedDataGridView2.Rows.Count-1; i++)
                {
                    fecha1 = Convert.ToDateTime(advancedDataGridView2.Rows[i].Cells["txtDgvFechaAccion"].Value);
                    fecha = fecha1.ToString("yyyy-MM-dd");
                    hora = Convert.ToString(advancedDataGridView2.Rows[i].Cells["txtDgvHorasAccion"].Value);
                    accion = Convert.ToString(advancedDataGridView2.Rows[i].Cells["txtDgvAccion"].Value);
                    IdAccion = Convert.ToInt32(advancedDataGridView2.Rows[i].Cells["txtDgvIdAccion"].Value);

                    consul = "update AccionCCAYAC22 set FechaAccion = '" + fecha + "', HorasAccion = " + hora + ", Accion = '" + accion + "', FechaSist = GETDATE() WHERE IdAccion = " + IdAccion;
                    
                    SqlCommand update = new SqlCommand(consul, con);
                    con.Open();
                    update.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Se guardaron los datos Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        int cont;
        public void BuscaAcciones()
        {
            string query;
            query = "select COUNT(*) as n from AccionCCAYAC22 where FolioCC = " + lblNum.Text;
            
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cont = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
                       
        }

        string query;
        public void ActualizaFolio(int tipo)
        {
            BuscaNoming();
            string  fini, ffin, hini, hfin, minIni, minFin;
            string HoraInicio, HoraFin;

            fini = String.Format("{0:yyyy/MM/dd}", dtpFechaInicio.Value);
            ffin = String.Format("{0:yyyy/MM/dd}", dtpFechaFin.Value);
            hini = cmbHoraIni.Text;
            minIni = cmbMinIni.Text;
            minFin = cmbMinFin.Text;
            hfin = cmbHorafin.Text;
            HoraInicio = hini + ":" + minIni + ":00.000";
            HoraFin = hfin + ":" + minFin + ":00.000";

            if (tipo == 1)
            {
                query = "update FolioCCAYAC22 set Fecha_Inicio = '" + fini + " " + HoraInicio +"', Fecha_Fin = '" + ffin + " " + HoraFin + "', Observaciones = '" + txtObservaciones.Text + "', NombreUser = '" + txtNombreUser.Text + "', " +
                     "F_InicioWEB = GETDATE(), F_FinWEB = GETDATE(), NResponsable = '" + txtNomResponsable.Text + "', OrdenServicio = '" + txtOrdenServ.Text + "' where Numero = " + lblNum.Text;
            }
            if(tipo == 2)
            {
                query = "update FolioCCAYAC22 set IdIngeniero = " + cmbIngeniero.SelectedValue + ", Ingeniero = '" + NomIng + "' where Numero = " + lblNum.Text;
                
            }

            //MessageBox.Show(query);

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        string NomIng;
        public void BuscaNoming()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("select Nombre + ' ' + Apellidos as Nombre from usuarios where IdUsuario = " + cmbIngeniero.SelectedValue, con);
            //cmd.CommandText = query;
            //cmd.Connection = con;                                    
            NomIng = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
        }

    }
}
