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
    public partial class LlamadaServicio : MaterialForm
    {
        public LlamadaServicio(int BD)
        {
            InitializeComponent();
            lblUsuario.Text = TestSpire.Usr.User;
            tipoBD = BD;
        }
        
        //Variables
        string cmbidempresa;
        int IdFolio, flag;
        int v_dvg = 0, v_dvg2 = 0;
        int tipoServ, tipoBD;
        string correo_a, nombre_a, asesor_id;


        //**************************INSTANCIA PARA CONSULTAS 
        DataConsultas objConsultasBD = new DataConsultas();

        //Conexiones
        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER01;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");
        SqlConnection con2 = new SqlConnection("Data Source=INOLABSERVER01;Initial Catalog=BrowserPruebas;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        //OBTIENE EL NOMBRE DE EQUIPO DEL USUARIO
        string name = System.Net.Dns.GetHostName();

        private void LlamadaServicio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.v_Asesor' Puede moverla o quitarla según sea necesario.
            this.v_AsesorTableAdapter1.Fill(this.browserDataSet.v_Asesor);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Problema' Puede moverla o quitarla según sea necesario.
            this.tipo_ProblemaTableAdapter1.Fill(this.browserDataSet.Tipo_Problema);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Contrato' Puede moverla o quitarla según sea necesario.
            this.tipo_ContratoTableAdapter1.Fill(this.browserDataSet.Tipo_Contrato);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter1.Fill(this.browserDataSet.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.F_Status' Puede moverla o quitarla según sea necesario.
            this.f_StatusTableAdapter1.Fill(this.browserDataSet.F_Status);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.v_Asesor' Puede moverla o quitarla según sea necesario.
            this.v_AsesorTableAdapter.Fill(this.dSBrowser.v_Asesor);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Modelo' Puede moverla o quitarla según sea necesario.
            this.modeloTableAdapter.Fill(this.dSBrowser.Modelo);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.F_Status' Puede moverla o quitarla según sea necesario.
            this.f_StatusTableAdapter.Fill(this.dSBrowser.F_Status);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Tipo_Servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_ServicioTableAdapter.Fill(this.dSBrowser.Tipo_Servicio);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Tipo_Contrato' Puede moverla o quitarla según sea necesario.
            this.tipo_ContratoTableAdapter.Fill(this.dSBrowser.Tipo_Contrato);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Tipo_Problema' Puede moverla o quitarla según sea necesario.
            this.tipo_ProblemaTableAdapter.Fill(this.dSBrowser.Tipo_Problema);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.ingenieros(this.dSBrowser.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Marca' Puede moverla o quitarla según sea necesario.
            this.marcaTableAdapter.Fill(this.dSBrowser.Marca);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Equipos' Puede moverla o quitarla según sea necesario.
            this.equiposTableAdapter.Fill(this.dSBrowser.Equipos);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.dSBrowser.Clientes);

            this.usuariosTableAdapter.Fill(this.dSBrowser.Usuarios);

            timer1.Start();
                        
            Limpiar();
            cmbidempresa = "0";
            Consecutivo();
            ConsecutivoFSR();
            timer1.Start();

        }


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
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dtpHora.Text = null;
            v_dvg = 0;
            v_dvg2 = 0;
            txtCotizacion.Text = null;
            txtOC.Text = null;
            txtObservaciones.Text = null;
            cmbasesor.Text = null;
            txtfallaReportada.Text = null;
        }

        private void btnBuscaEmpresa_Click(object sender, EventArgs e)
        {
            Limpiar();

            Cliente frm = new Cliente();
            frm.p_empresid += new Cliente.EmpresaID(EmpresaID);
            frm.ShowDialog();
            
            Equipos fm = new Equipos(cmbidempresa);
            fm.p_equipoid += new Equipos.EquipoID(EquipoID);
            fm.ShowDialog();
        }
        public void EmpresaID(string empresa)
        {
            cmbEmpresa.SelectedValue = empresa;
        }

        private void cmbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbidempresa = Convert.ToString(cmbEmpresa.SelectedValue);
            
            SqlDataReader leer;
            leer = objConsultasBD.setDetalleClienteInter(tipoBD, Convert.ToInt32(cmbEmpresa.SelectedValue));
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
        }


        private void btnEquipos_Click(object sender, EventArgs e)
        {
            Equipos frm = new Equipos(cmbidempresa);
            frm.p_equipoid += new Equipos.EquipoID(EquipoID);
            frm.ShowDialog();
        }


        public void EquipoID(string equipo)
        {
            this.equiposTableAdapter.Fill(this.dSBrowser.Equipos);
            this.modeloTableAdapter.Fill(this.dSBrowser.Modelo);
            this.marcaTableAdapter.Fill(this.dSBrowser.Marca);
            cmbEquipo.SelectedValue = equipo;
        }


        //Informacion del Equipo
        private void cmbEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader leer;
            leer = objConsultasBD.setEquipoLlamada(tipoBD, Convert.ToInt32(cmbEquipo.SelectedValue));
            if (leer.Read())
            {
                cmbMarca.SelectedValue = Convert.ToInt32(leer["IdMarca"]);
                cmbModelo.SelectedValue = Convert.ToInt32(leer["IdModelo"]);
                txtNoSerie.Text = Convert.ToString(leer["NoSerie"]);
                txtIdequipo_C.Text = Convert.ToString(leer["IdEquipo_C"]);
            }
            else
            {
                txtIdequipo_C.Text = null;
                txtNoSerie.Text = null;
                cmbEquipo.Text = null;
                cmbMarca.Text = "";
                cmbModelo.Text = "";
            }
        }


        //Agrega tipos de Servicio
        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            v_dvg = 1;
            dataGridView1.Rows.Add(cmbTServicio.Text, cmbTServicio.SelectedValue);
        }


        //Boton Guarda Llamada
        private void btnGuardarFSR_Click(object sender, EventArgs e)
        {
            ValidaCampos();
        }


        //Guarda en tabla llamada
        public void SaveCall()
        {
            Consecutivo();

            int result;

            try
            {
                result = objConsultasBD.saveLlamadaInterna(tipoBD, Convert.ToInt32(lblLlamada.Text), Convert.ToInt32(cmbidempresa), cmbEmpresa.Text, Convert.ToInt32(cmbing.SelectedValue), Convert.ToInt32(cmbTContrato.SelectedValue),
                    Convert.ToInt32(cmbTProblema.SelectedValue), IdFolio, lblUsuario.Text, Convert.ToInt32(cmbestatus.SelectedValue), txtObservaciones.Text, txtCotizacion.Text, txtOC.Text, name);

                if(result == 1)
                {
                    SaveDetFSR();
                    SaveDetEquipo();
                    SaveFolios();
                    SaveDetCliente();

                    MessageBox.Show("Se Ha Registrado la Llamada No. " + lblLlamada.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                    Consecutivo();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Consecutivo de llamada + 1
        public void Consecutivo()
        {
            try
            {
                lblLlamada.Text = objConsultasBD.getConsecutivoLlamada(tipoBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //Consecutivo  folios
        public void ConsecutivoFSR()
        {
            try
            {
                IdFolio = Convert.ToInt32(objConsultasBD.getUltimoFolio(tipoBD));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        //genera FSR por tipo de servicio en DVG
        public void SaveFolios()
        {
            string idCliente, Cliente, usuario, fechaServicio, equipo, marca, modelo, noSerie, idEquipo_C, nRespo, nReport, mail, depto, tel, direccion, localidad, coti, oc, coment, hora;
            int idTContrato, idTProblema, idTServicio, idEstatus, idIng, idLlamada, idAsesor, noLlamada, diasServ, result, correo; 
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int tservicio = Convert.ToInt32(row.Cells["IdTServicio"].Value);                
                string valor;

                if(tservicio == 0)
                {
                    tipoServ = 4;
                }
                if(tservicio == 1)
                {
                    tipoServ = 8;
                }
                if(tservicio == 2)
                {
                    tipoServ = 9;
                }

                if (tservicio == 3 || tservicio == 5 || tservicio == 6 || tservicio == 7 || tservicio == 13 || tservicio == 16)
                {
                    valor = "Y";
                }
                else
                    valor = "N";

                idCliente = cmbidempresa;
                Cliente = cmbEmpresa.Text;
                idTContrato = Convert.ToInt32(cmbTContrato.SelectedValue);
                idTProblema = Convert.ToInt32(cmbTProblema.SelectedValue);
                idTServicio = tipoServ; //Convert.ToInt32(row.Cells["IdTServicio"].Value);
                usuario = lblUsuario.Text;
                idEstatus = Convert.ToInt32(cmbestatus.SelectedValue);
                idIng = Convert.ToInt32(cmbing.SelectedValue);
                fechaServicio = Convert.ToString(dtpfecha.Value);
                idLlamada = Convert.ToInt32(lblLlamada.Text);
                equipo = cmbEquipo.Text;
                marca = cmbMarca.Text;
                modelo = cmbModelo.Text;
                noSerie = txtNoSerie.Text;
                idEquipo_C = txtIdequipo_C.Text;
                nRespo = txtNResponsable.Text;
                nReport = txtNReportado.Text;
                mail = txtMail.Text;
                depto = txtDepto.Text;
                tel = txtTel.Text;
                direccion = txtDireccion.Text;
                localidad = txtLocalidad.Text;
                coti = txtCotizacion.Text;
                oc = txtOC.Text;
                coment = txtObservaciones.Text;
                hora = dtpHora.Text;
                idAsesor = Convert.ToInt32(cmbasesor.SelectedValue);
                noLlamada = Convert.ToInt32(lblLlamada.Text);
                diasServ = Convert.ToInt32(row.Cells["DiasServicio"].Value);

                try
                {
                    result = objConsultasBD.saveFolioLlamadaInterna(tipoBD, idCliente, Cliente, idTContrato, idTProblema, idTServicio, usuario, idEstatus, idIng, fechaServicio, IdFolio, idLlamada, equipo, marca, modelo,
                        noSerie, idEquipo_C, nRespo, nReport, mail, depto, tel, direccion, localidad, coti, oc, coment, hora, idAsesor, noLlamada, diasServ, name);
                    if(result == 1)
                    {
                        IdFolio += 1;
                        if(tipoBD == 1)
                        {
                            objConsultasBD.SendCorreoIngResponsable(tipoBD);

                            if (tipoServ == 4 || tipoServ == 9)
                            {
                                correo = objConsultasBD.SendMailAsesor(tipoBD);
                            }
                        }                        
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
        }


        private void registroDeFoliosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerLlamadas frm = new VerLlamadas(tipoBD);
            frm.Show();
        }


        public void SaveDetCliente()
        {
            int result;

            try
            {
                if(flag == 0)
                {
                    result = objConsultasBD.saveDetalleCliente(tipoBD, lblLlamada.Text, Convert.ToInt32(cmbEmpresa.SelectedValue), txtTel.Text, txtDireccion.Text, txtLocalidad.Text, txtNResponsable.Text, txtNReportado.Text, txtMail.Text, txtDepto.Text);
                }
                else
                {
                    result = objConsultasBD.UpdateDetalleCliente(tipoBD, Convert.ToInt32(cmbEmpresa.SelectedValue), txtTel.Text, txtDireccion.Text, txtLocalidad.Text, txtNResponsable.Text, txtNReportado.Text, txtMail.Text, txtDepto.Text);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROE SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void SaveDetFSR()
        {
            int res;

            try
            {
                res = objConsultasBD.SaveDetalleFSR(tipoBD, lblLlamada.Text, Convert.ToString(cmbEmpresa.SelectedValue), txtNResponsable.Text, txtNReportado.Text, txtMail.Text, txtDepto.Text, txtTel.Text, txtDireccion.Text, txtLocalidad.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }


        //Guarda detalle Equipo FSR
        public void SaveDetEquipo()
        {
            int r;
            try
            {
                r = objConsultasBD.saveDetalleEquipo(tipoBD, lblLlamada.Text, Convert.ToInt32(cmbEquipo.SelectedValue));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dtpHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fservicio = dtpfecha.Text + " " + dtpHora.Text + ":00.000";
        }


        private void dtpfecha_ValueChanged(object sender, EventArgs e)
        {

        }


        private void fSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Folios frm = new Folios(tipoBD);
            frm.Show();
        }


        public void ValidaCampos()
        {
            if (string.IsNullOrEmpty(cmbEmpresa.Text))
            {
                MessageBox.Show("El Campo Cliente/Empresa no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("El Campo Dirección no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("El Campo Localidad no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtTel.Text))
            {
                MessageBox.Show("El Campo Telefono no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtDepto.Text))
            {
                MessageBox.Show("El Campo Departamento no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtNResponsable.Text))
            {
                MessageBox.Show("El Campo Nombre Responsable no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtNReportado.Text))
            {
                MessageBox.Show("El Campo Reportado por no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtMail.Text))
            {
                MessageBox.Show("El Campo E-mail no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtOC.Text))
            {
                MessageBox.Show("El Campo OC no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtCotizacion.Text))
            {
                MessageBox.Show("El Campo Cotización no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }            
            if (string.IsNullOrEmpty(cmbEquipo.Text))
            {
                MessageBox.Show("El Campo Equipo no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(cmbMarca.Text))
            {
                MessageBox.Show("El Campo Marca no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(cmbModelo.Text))
            {
                MessageBox.Show("El Campo Modelo no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtNoSerie.Text))
            {
                MessageBox.Show("El Campo NoSerie no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtIdequipo_C.Text))
            {
                MessageBox.Show("El Campo Identificacion del Equipo no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(cmbing.Text))
            {
                MessageBox.Show("Selecciona al Ingeniero de Servicio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (v_dvg == 0)
            {
                MessageBox.Show("No se ha agregado los Tipos de Servicios", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if(v_dvg2 == 0)
            {
                MessageBox.Show("No se ha agregado dias para Servicio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(cmbTContrato.Text))
            {
                MessageBox.Show("Selecciona el Tipo de Contrato", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(cmbTProblema.Text))
            {
                MessageBox.Show("Selecciona el Tipo de Problema", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtObservaciones.Text))
            {
                MessageBox.Show("El Campo Observaciones no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(dtpfecha.Text))
            {
                MessageBox.Show("No ha seleccionado Fecha de Servicio", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(dtpHora.Text))
            {
                MessageBox.Show("El Campo Hora de Servicio no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(txtfallaReportada.Text))
            {
                MessageBox.Show("El Campo Falla Reportada no puede estar Vacío", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            if (string.IsNullOrEmpty(cmbasesor.Text))
            {
                MessageBox.Show("No ha seleccionado Asesor", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            SaveCall();
        }


        private void btnLimpia_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        public void RecorreGrid()
        {
            con.Open();

            SqlCommand sf = new SqlCommand("Save_FSR", con);
            sf.CommandType = CommandType.StoredProcedure;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if((bool)row.Cells[1].Value==true)
                {
                    sf.Parameters.Clear();
                    int tservicio = Convert.ToInt32(row.Cells[0].Value);
                    string valor;

                    if (tservicio == 3 || tservicio == 5 || tservicio == 6 || tservicio == 7 || tservicio == 13 || tservicio == 16)
                    {
                        valor = "Y";
                    }
                    else
                        valor = "N";

                    sf.Parameters.Add("@idcliente", SqlDbType.VarChar);
                    sf.Parameters.Add("@cliente", SqlDbType.VarChar);
                    sf.Parameters.Add("@idtcontrato", SqlDbType.Int);
                    sf.Parameters.Add("@idtproblema", SqlDbType.Int);
                    sf.Parameters.Add("@idtservicio", SqlDbType.Int);
                    sf.Parameters.Add("@usuario", SqlDbType.VarChar);
                    sf.Parameters.Add("@idstatus", SqlDbType.Int);
                    sf.Parameters.Add("@iding", SqlDbType.Int);
                    sf.Parameters.Add("@fechaservicio", SqlDbType.Date);
                    sf.Parameters.Add("@folio", SqlDbType.Int);
                    sf.Parameters.Add("@idllamada", SqlDbType.Int);
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
                    sf.Parameters.Add("@fechasolservicio", SqlDbType.Date);
                    sf.Parameters.Add("@horaservicio", SqlDbType.VarChar);
                    sf.Parameters.Add("@nollamada", SqlDbType.Int);
                    sf.Parameters.Add("@carpeta", SqlDbType.VarChar);

                    sf.Parameters["@idcliente"].Value = cmbidempresa;
                    sf.Parameters["@cliente"].Value = cmbEmpresa.Text;
                    sf.Parameters["@idtcontrato"].Value = Convert.ToInt32(cmbTContrato.SelectedValue);
                    sf.Parameters["@idtproblema"].Value = Convert.ToInt32(cmbTProblema.SelectedValue);
                    sf.Parameters["@idtservicio"].Value = Convert.ToInt32(row.Cells[0].Value);
                    sf.Parameters["@usuario"].Value = "carlos";
                    sf.Parameters["@idstatus"].Value = Convert.ToInt32(cmbestatus.SelectedValue);
                    sf.Parameters["@iding"].Value = Convert.ToInt32(cmbing.SelectedValue);
                    sf.Parameters["@fechaservicio"].Value = dtpfecha.Value;
                    sf.Parameters["@folio"].Value = IdFolio;
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
                    sf.Parameters["@fechasolservicio"].Value = dtpfecha.Value;
                    sf.Parameters["@horaservicio"].Value = dtpHora.Text;
                    sf.Parameters["@nollamada"].Value = Convert.ToInt32(lblLlamada.Text);
                    sf.Parameters["@carpeta"].Value = valor;

                    IdFolio += 1;
                    sf.ExecuteNonQuery();
                    SqlCommand de = new SqlCommand("SendMail", con);
                    de.CommandType = CommandType.StoredProcedure;
                    de.ExecuteNonQuery();
                }                
            }
            con.Close();
        }


        private void cmbTServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            v_dvg = 1;
        }

        private void cmbDiasServ_SelectedIndexChanged(object sender, EventArgs e)
        {
            v_dvg2 = 1;
            dataGridView1.Rows.Add(cmbTServicio.Text, cmbTServicio.SelectedIndex, cmbDiasServ.SelectedItem);
        }
                

        private void cmbestatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            Consecutivo();
            ConsecutivoFSR();
        }

        
        private void cmbasesor_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader leer;
            leer = objConsultasBD.setInfoAsesor(tipoBD, Convert.ToInt32(cmbasesor.SelectedValue));
            if (leer.Read())
            {
                asesor_id = Convert.ToString(leer["IdUsuario"]);
                nombre_a= Convert.ToString(leer["Nombre"]);
                correo_a = Convert.ToString(leer["Mail"]);
                txtmailasesor.Text = correo_a;
            }
        }
    }
}
