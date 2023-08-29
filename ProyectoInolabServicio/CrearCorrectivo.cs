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
    public partial class CrearCorrectivo : MaterialForm
    {
        public CrearCorrectivo(string user, string fsr, int BD)
        {
            InitializeComponent();
            usuario = user;
            folio = fsr;
            tipoBD = BD;
        }


        //*******************************VARIABLES
        string usuario, folio, IdEmp, IdEquipo;
        int flag, IdFolio, tipoBD;


        //****************************INSTANCIA DE CLASE DATA CONSULTAS
        DataConsultas objConsultasBD = new DataConsultas();


        
        
        //***********************OBTIENE EL NOMBRE DE EQUIPO DEL USUARIO
        string name = System.Net.Dns.GetHostName();


        //******************************CARGA LA INFORMACION DE CONTROLES
        private void CrearCorrectivo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.v_Asesor' Puede moverla o quitarla según sea necesario.
            this.v_AsesorTableAdapter.Fill(this.browserDataSet.v_Asesor);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.browserDataSet.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Problema' Puede moverla o quitarla según sea necesario.
            this.tipo_ProblemaTableAdapter.Fill(this.browserDataSet.Tipo_Problema);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Contrato' Puede moverla o quitarla según sea necesario.
            this.tipo_ContratoTableAdapter.Fill(this.browserDataSet.Tipo_Contrato);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_ServicioTableAdapter.Fill(this.browserDataSet.Tipo_Servicio);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.F_Status' Puede moverla o quitarla según sea necesario.
            this.f_StatusTableAdapter.Fill(this.browserDataSet.F_Status);

            timer1.Start();

            cmbTServicio.SelectedValue = 4;
            Limpiar();
            Consecutivo();
            ConsecutivoFSR();
            CargarDatos();
        }


        //*****************************MUESTRA DATOS DEL FOLIO
        public void CargarDatos()
        {
            try
            {
                SqlDataReader leer;
                leer = objConsultasBD.setDatosCorrectivo(tipoBD, folio);

                if (leer.Read())
                {
                    flag = 1;

                    txtCliente.Text = Convert.ToString(leer["Cliente"]);
                    txtDireccion.Text = Convert.ToString(leer["Direccion"]);
                    txtLocalidad.Text = Convert.ToString(leer["Localidad"]);
                    txtTel.Text = Convert.ToString(leer["Telefono"]);
                    txtDepto.Text = Convert.ToString(leer["Departamento"]);
                    txtNResponsable.Text = Convert.ToString(leer["N_Responsable"]);
                    txtNReportado.Text = Convert.ToString(leer["N_Reportado"]);
                    txtMail.Text = Convert.ToString(leer["Mail"]);
                    txtEquipo.Text = Convert.ToString(leer["Equipo"]);
                    txtModelo.Text = Convert.ToString(leer["Modelo"]);
                    txtMarca.Text = Convert.ToString(leer["Marca"]);
                    txtNoSerie.Text = Convert.ToString(leer["NoSerie"]);
                    cmbing.SelectedValue = Convert.ToInt32(leer["IdIngeniero"]);
                    txtIdequipo_C.Text = Convert.ToString(leer["IdEquipo_C"]);
                }
                else
                {
                    flag = 0;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        private void txtNoSerie_TextChanged(object sender, EventArgs e)
        {
            
        }


        //***********************LLAMA LA FUNCION PARA GUARDAR LOS DATOS 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ValidaCampos();
        }


        //************************SI LOS CAMPOS NO ESTAN VACIOS LLAMA LA FUNCION PARA GUARDAR LA LLAMADA
        public void ValidaCampos()
        {
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("El Campo Cliente/Empresa no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("El Campo Dirección no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("El Campo Localidad no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtTel.Text))
            {
                MessageBox.Show("El Campo Telefono no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtDepto.Text))
            {
                MessageBox.Show("El Campo Departamento no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtNResponsable.Text))
            {
                MessageBox.Show("El Campo Nombre Responsable no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtNReportado.Text))
            {
                MessageBox.Show("El Campo Reportado por no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtMail.Text))
            {
                MessageBox.Show("El Campo E-mail no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtOC.Text))
            {
                MessageBox.Show("El Campo OC no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtCotizacion.Text))
            {
                MessageBox.Show("El Campo Cotización no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtEquipo.Text))
            {
                MessageBox.Show("El Campo Equipo no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("El Campo Marca no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("El Campo Modelo no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtNoSerie.Text))
            {
                MessageBox.Show("El Campo NoSerie no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtIdequipo_C.Text))
            {
                MessageBox.Show("El Campo Identificacion del Equipo no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbing.Text))
            {
                MessageBox.Show("Selecciona al Ingeniero de Servicio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTContrato.Text))
            {
                MessageBox.Show("Selecciona el Tipo de Contrato", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTProblema.Text))
            {
                MessageBox.Show("Selecciona el Tipo de Problema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtObservaciones.Text))
            {
                MessageBox.Show("El Campo Observaciones no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(dtpfecha.Text))
            {
                MessageBox.Show("No ha seleccionado Fecha de Servicio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(dtpHora.Text))
            {
                MessageBox.Show("El Campo Hora de Servicio no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtfallaReportada.Text))
            {
                MessageBox.Show("El Campo Falla Reportada no puede estar Vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbasesor.Text))
            {
                MessageBox.Show("No ha seleccionado Asesor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbDiasServicio.Text))
            {
                MessageBox.Show("El campo dias de servicio no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DateTime Fecha1, fecha2;
            Fecha1 = Convert.ToDateTime(dtpfecha.Value.ToString("dd-MM-yyyy"));
            fecha2 = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            int result = DateTime.Compare(Fecha1, fecha2);

            if (result < 0)
            {
                MessageBox.Show("La Fecha Requerida de Servicio no puede ser menor a la Fecha Actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveCall();
        }
        

        //***********************LLAMA AL PROCESO ALMACENADO PARA GENERAR LA NUEVA LLAMADA INTERNA
        public void SaveCall()
        {
            Consecutivo();
            ConsecutivoFSR();
            buscaCliente();

            int result;

            try
            {
                result = objConsultasBD.saveLlamadaInterna(tipoBD, Convert.ToInt32(lblLlamada.Text), 0, txtCliente.Text, Convert.ToInt32(cmbing.SelectedValue), Convert.ToInt32(cmbTContrato.SelectedValue), Convert.ToInt32(cmbTProblema.SelectedValue), IdFolio,
                        usuario, Convert.ToInt32(cmbestatus.SelectedValue), txtObservaciones.Text, txtCotizacion.Text, txtOC.Text, name);

                if(result == 1)
                {
                    SaveDetFSR();
                    SaveFolios();                    
                    SaveDetCliente();
                    Limpiar();

                    MessageBox.Show("Se Ha Registrado la Lamada No. " + lblLlamada.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnGuardar.Visible = false;
                    Consecutivo();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //*******************************OBTIENE EL CONSECUTIVO DE LA LLAMADA 
        public void Consecutivo()
        {
            try
            {
                lblLlamada.Text = objConsultasBD.getConsecutivoLlamada(tipoBD);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //**************************GUARDA EL DETELLE DEL FOLIO
        public void SaveDetFSR()
        {
            buscaCliente();

            int res;

            try
            {
                res = objConsultasBD.SaveDetalleFSR(tipoBD, lblLlamada.Text, IdEmp, txtNResponsable.Text, txtNReportado.Text, txtMail.Text, txtDepto.Text, txtTel.Text, txtDireccion.Text, txtLocalidad.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        //*****************************BUSCA AL CLIENTE DENTRO DE LOS REGISTROS
        public void buscaCliente()
        {
            SqlDataReader leer;
            
            try
            {
                leer = objConsultasBD.getBuscaCliente(tipoBD, txtCliente.Text);
                if (leer.Read())
                {
                    IdEmp = Convert.ToString(leer["er"]);
                }
                else
                {
                    buscaClienteSAP();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //**********************************BUSCA CLIENTE DENTRO DE LOS REGISTROS DE SAP
        public void buscaClienteSAP()
        {
            try
            {
                IdEmp = objConsultasBD.getBuscaClienteSAP(tipoBD, txtCliente.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //************************GUARDA DETALLE DEL EQUIPO
        public void SaveDetEquipo()
        {
            int result;
            try
            {
                result = objConsultasBD.saveDetalleEquipo(tipoBD, lblLlamada.Text, Convert.ToInt32(txtEquipo.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                         
        }


        //*********************ACTUALIZA EL CONSECUTIVO CADA 5S
        private void timer1_Tick(object sender, EventArgs e)
        {
            ConsecutivoFSR();
            Consecutivo();
        }

        private void dtpfecha_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbTContrato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //*******************************GENERA Y GUARDA LA INFORMACION DEL FOLIO AL CREAR LA LLAMADA
        public void SaveFolios()
        {
            string cliente, fechaServ, equipo, marca, modelo, noSerie, idEquipo_C, nRespo, nReport, mail;
            string depto, tel, direccion, localidad, coti, oc, coment, hora; 
            int idTContrato, idTProblema, idTServicio, idEstatus, idIng, idLlamada, idAsesor, noLlamada, diasServ, res, correo;

            ConsecutivoFSR();
            buscaCliente();

            int tservicio = Convert.ToInt32(cmbTServicio.SelectedValue);
            string valor;

            if (tservicio == 3 || tservicio == 5 || tservicio == 6 || tservicio == 7 || tservicio == 13 || tservicio == 16)
            {
                valor = "Y";
            }
            else
                valor = "N";

            cliente = txtCliente.Text;
            idTContrato = Convert.ToInt32(cmbTContrato.SelectedValue);
            idTProblema = Convert.ToInt32(cmbTProblema.SelectedValue);
            idTServicio = Convert.ToInt32(cmbTServicio.SelectedValue);
            idEstatus = Convert.ToInt32(cmbestatus.SelectedValue);
            idIng = Convert.ToInt32(cmbing.SelectedValue);
            fechaServ = dtpfecha.Text;
            idLlamada = Convert.ToInt32(lblLlamada.Text);
            equipo = txtEquipo.Text;
            marca = txtMarca.Text;
            modelo = txtModelo.Text;
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
            diasServ = Convert.ToInt32(cmbDiasServicio.SelectedItem);
            noLlamada = Convert.ToInt32(lblLlamada.Text);

            try
            {
                res = objConsultasBD.saveFolioLlamadaInterna(tipoBD, IdEmp, cliente, idTContrato, idTProblema, idTServicio, usuario, idEstatus, idIng, fechaServ, IdFolio, idLlamada, equipo, marca, modelo, noSerie, idEquipo_C,
                                                            nRespo, nReport, mail, depto, tel, direccion, localidad, coti, oc, coment, hora, idAsesor, noLlamada, diasServ, name);

                if (res == 1)
                {
                    IdFolio += 1;
                    if (tipoBD == 1)
                    {
                        correo = objConsultasBD.SendCorreoIngResponsable(tipoBD);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //*******************************GUARDA DETALLE DEL CLIENTE
        public void SaveDetCliente()
        {
            buscaCliente();

            int result;

            try
            {
                if(flag == 0)
                {
                    result = objConsultasBD.saveDetalleCliente(tipoBD, lblLlamada.Text, 0, txtTel.Text, txtDireccion.Text, txtLocalidad.Text, txtNResponsable.Text, txtNReportado.Text, txtMail.Text, txtDepto.Text);
                }
                else
                {
                    result = objConsultasBD.UpdateDetalleCliente(tipoBD, 0, txtTel.Text, txtDireccion.Text, txtLocalidad.Text, txtNResponsable.Text, txtNReportado.Text, txtMail.Text, txtDepto.Text);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        //**********************LIMPIA LA INFORMACION DE LOS CONTROLES
        public void Limpiar()
        {
            txtCliente.Text = null;
            txtIdequipo_C.Text = null;
            txtNoSerie.Text = null;
            txtEquipo.Text = null;
            txtMarca.Text = null;
            txtModelo.Text = null;
            cmbTContrato.Text = null;
            cmbTProblema.Text = null;
            cmbing.Text = null;
            dtpHora.Text = "";
            txtLocalidad.Text = null;
            txtDepto.Text = null;
            txtNReportado.Text = null;
            txtNResponsable.Text = null;
            txtDireccion.Text = null;
            txtTel.Text = null;
            txtMail.Text = null;
            dtpHora.Text = null;
            IdEmp = "";
            txtCotizacion.Text = " ";
            txtOC.Text = " ";
            txtObservaciones.Text = null;
            cmbasesor.Text = null;
            txtfallaReportada.Text = null;
        }


        //************************OBTIENE EL CONSECUTIVO DE FSR A ASIGNAR
        public void ConsecutivoFSR()
        {         
            try
            {
                IdFolio = Convert.ToInt32(objConsultasBD.getUltimoFolio(tipoBD));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                        
        }
    }
}
