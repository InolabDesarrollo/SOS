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
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class FSR : MaterialForm
    {
        public FSR(string llamada, int BD)
        {
            InitializeComponent();
            llamada_p = llamada;
            tipoBD = BD;

        }

        //**********VARIABLES
        string llamada_p, fservicio, clasifica, contrato;
        string archivo, carpeta, fant, rutaFSR;
        int tipoBD;
        int flag, idClas;
        int idasesor, asesorid;
        int idtservicio, idtContrato;
        int conteo = 0;


        //**********INSTANCIA DE CONCULTAS
        DataConsultas objConsultasBD = new DataConsultas();


        BackgroundWorker bg = new BackgroundWorker();


        //**********CONECXION A LA BD
        //SqlConnection con = new SqlConnection("Data Source=INOLABSERVER01;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");
        //SqlConnection con2 = new SqlConnection("Data Source=INOLABSERVER01;Initial Catalog=BrowserPruebas;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");



        //**********OBTIENE EL NOMBRE DE EQUIPO DEL USUARIO
        string name = System.Net.Dns.GetHostName();


        private void FSR_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.FillByIng(this.browserDataSet.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'inolabDataSet.OCLT' Puede moverla o quitarla según sea necesario.
            this.oCLTTableAdapter.Fill(this.inolabDataSet.OCLT);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.F_Status' Puede moverla o quitarla según sea necesario.
            this.f_StatusTableAdapter1.Fill(this.browserDataSet.F_Status);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Contrato' Puede moverla o quitarla según sea necesario.
            this.tipo_ContratoTableAdapter1.Fill(this.browserDataSet.Tipo_Contrato);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Problema' Puede moverla o quitarla según sea necesario.
            this.tipo_ProblemaTableAdapter1.Fill(this.browserDataSet.Tipo_Problema);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Clasificacion' Puede moverla o quitarla según sea necesario.
            this.clasificacionTableAdapter1.Fill(this.browserDataSet.Clasificacion);
            // TODO: esta línea de código carga datos en la tabla 'inolabDataSet.OCLT' Puede moverla o quitarla según sea necesario.
            this.oCLTTableAdapter.Fill(this.inolabDataSet.OCLT);

            //**********LLAMA LA CONSULTA PARA MOSTRAR FOLIO
            try
            {                
                lblFolio.Text = objConsultasBD.getUltimoFolio(tipoBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CargarDatos();
            timer1.Start();

            cmbIngAcomp1.Text = null;
            cmbIngAcomp2.Text = null;

            //**********LLENA EL COMBO PARA EL NUMERO DE DIAS
            for (int i = 1; i <= 10; i++)
            {
                cmbDiasS.Items.Add(i);
            }

            //**********COMPRUEBA ACCESO A USUARIOS
            if (TestSpire.Usr.K == 69 || TestSpire.Usr.K == 70 || TestSpire.Usr.K == 94 || TestSpire.Usr.K == 104)
            {
                btnGuardarFSR.Visible = false;
                btnSubirFSR.Visible = false;
            }

        }


        //********** CONSULTA LOS DATOS DE LA LLAMADA
        public void CargarDatos()
        {
            string horaServicio;
            try
            {
                SqlDataReader leer;
                leer = objConsultasBD.SetDatosFSR(tipoBD, llamada_p);

                if (leer.Read())
                {
                    flag = 1;

                    txtCliente.Text = Convert.ToString(leer["ClienteFiscal"]);
                    txtNResponsable.Text = Convert.ToString(leer["Nombre"]);
                    txtLocalidad.Text = Convert.ToString(leer["Municipio"]) + ", " + Convert.ToString(leer["Ciudad"]);
                    txtDireccion.Text = Convert.ToString(leer["Calle"]) + ", Col. " + Convert.ToString(leer["Colonia"]) + ", C.P. " + Convert.ToString(leer["CP"]);
                    txtTel.Text = Convert.ToString(leer["Telefono"]);
                    txtMail.Text = Convert.ToString(leer["Correo"]);
                    //asigna formato a la hora para mostrar 
                    horaServicio = Convert.ToString(leer["HoraSolicitudservicio"]);
                    txtHoraSolServicio.Text = horaServicio; //h + ":" + m;
                                                            //txtHoraSolServicio.Text = Convert.ToString(leer["HoraSolicitudservicio"]);
                    txtfechaSolServicio.Text = Convert.ToString(leer["FechaSolicitudServicio"]);
                    txtNumeroServicio.Text = Convert.ToString(leer["IDActividad"]);
                    txtIdllamada.Text = Convert.ToString(leer["IDLlamada"]);
                    txtcodcliente.Text = Convert.ToString(leer["CodigoCliente"]);
                    txtequipo.Text = Convert.ToString(leer["Equipo"]);
                    txtMarca.Text = Convert.ToString(leer["Marca"]);
                    txtModelo.Text = Convert.ToString(leer["Modelo"]);
                    txtnoSerie.Text = Convert.ToString(leer["noSerie"]);
                    dtpfecha.Text = Convert.ToString(leer["FechaInicioactividad"]);
                    cmbTServicio.SelectedValue = Convert.ToInt32(leer["IdTiposervicio"]);
                    txtDepto.Text = Convert.ToString(leer["Depto"]);
                    txtAsesor.Text = Convert.ToString(leer["Asignado"]);
                    lblmailasesor.Text = Convert.ToString(leer["MailAsesor"]);
                    txtOrdenVenta.Text = Convert.ToString(leer["OrdenVenta"]);
                    txtIdEquipo.Text = Convert.ToString(leer["IdEquipo"]);
                    //cbClasifica.SelectedValue = Convert.ToInt32(leer["IdTipoLlamada"]);

                    //**********Determina si tiene tipo de contrato
                    if (leer.IsDBNull(46))
                    {
                        cmbTContrato.Text = null;
                        cmbContratoInfo.Text = null;
                        contrato = " ";
                    }
                    else
                    {
                        cmbTContrato.SelectedValue = Convert.ToInt32(leer["IdContrato"]);
                        contrato = Convert.ToString(leer["ContractID"]);
                    }
                    //determina si tiene clasificacion
                    if (leer.IsDBNull(54))
                    {
                        cbClasifica.Text = null;
                    }
                    else
                    {
                        cbClasifica.SelectedValue = Convert.ToInt32(leer["IdTipoLlamada"]);

                    }

                    cmbTProblema.Text = null;
                    //cmbTServicio.Text = null;
                    cmbing.Text = null;
                    txtcomentarios.Text = Convert.ToString(leer["ComentariosLlamada"]);
                    txtactividad.Text = Convert.ToString(leer["Comentarios"]);
                    idasesor = Convert.ToInt32(leer["IdAsesor"]);
                    //Asigna el Id del asesor
                    if (idasesor == 29)
                    { asesorid = 44; } //DINORATH
                    if (idasesor == 30)
                    { asesorid = 16; } //EVELYN
                    if (idasesor == 31)
                    { asesorid = 15; } //KARINA
                    if (idasesor == 32)
                    { asesorid = 3; } //LIDIA
                    if (idasesor == 34)
                    { asesorid = 2; } //PAOLA
                    if (idasesor == 37)
                    { asesorid = 8; } //ELIZABETH
                    if (idasesor == 38)
                    { asesorid = 13; } //KARLA IVETTE
                    if (idasesor == 39)
                    { asesorid = 28; } //LOURDES
                    if(idasesor == 50 || idasesor == 36) //ASESORES DE GUADALAJARA
                    { asesorid = 119; }

                    txtFechaCreacionActiv.Text = Convert.ToString(leer["FechaCreaActiv"]);
                    txtFechaActualizaActiv.Text = Convert.ToString(leer["FechaActualizaActiv"]);

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
            
            DatosContrato();
        }       


        //*****************CARGA LOS DATOS DEPENDIENDO DEL CONTRATO
        public void DatosContrato()
        {
            if(contrato == " ")
            {
                txtFechaInicioC.Text = "";
                txtFechaFinC.Text = "";
                txtDescripcionC.Text = "";
                txtDescContrato.Text = "";
                lblVigenciaC.Text = "Sin Contrato";
            }
            else
            {
                try
                {
                    SqlDataReader leer;
                    leer = objConsultasBD.getInfoContrato(tipoBD, contrato);
                    if (leer.Read())
                    {
                        txtFechaInicioC.Text = Convert.ToString(leer["FechaInicioC"]);
                        txtFechaFinC.Text = Convert.ToString(leer["FechaFinC"]);
                        txtDescripcionC.Text = Convert.ToString(leer["Descripcion"]);
                        txtDescContrato.Text = Convert.ToString(leer["DescContrato"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               

                //********************COMPARA FECHAS PARA SABER SI ESTA VIGENTE O NO
                DateTime Fecha1, fecha2;
                Fecha1 = Convert.ToDateTime(txtFechaFinC.Text);
                fecha2 = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
                int result = DateTime.Compare(Fecha1, fecha2);

                if (result > 0)
                {
                    lblVigenciaC.Text = "Vigente";
                }
                else
                {
                    lblVigenciaC.Text = "No Vigente";
                }
            }
        }

        private void txtIdllamada_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnGenerarFolio_Click(object sender, EventArgs e)
        {//Este bloque ya no se ocupa
            //lblFolio.Visible = true;
            //UlTimoF();
            btnGenerarFolio.Enabled = false;
            GeneraFolio();

        }

        

        private void btnGuardarFSR_Click(object sender, EventArgs e)
        {
            //******************DETERMINA SI LOS CAMPOS ESTAN VACIOS
            if (string.IsNullOrEmpty(dtpHora.Text))
            {
                MessageBox.Show("No se ha seleccionado Hora de Servicio ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtMail.Text))
            {
                MessageBox.Show("El campo E-Mail no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("El campo Cliente/Empresa no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("El campo Localidad no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("El campo Dirección no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbing.Text))
            {
                MessageBox.Show("El campo Ingeniero no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTServicio.Text))
            {
                MessageBox.Show("El campo Tipo de Servicio no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTProblema.Text))
            {
                MessageBox.Show("El campo Tipo de Problema no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cbClasifica.Text))
            {
                MessageBox.Show("El campo Clasificación esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTContrato.Text))
            {
                MessageBox.Show("El campo Tipo de Contrato esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtFallaReport.Text))
            {
                MessageBox.Show("El campo Falla reportada esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtNResponsable.Text))
            {
                MessageBox.Show("El campo Cliente esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtDepto.Text))
            {
                MessageBox.Show("El campo Departamento esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtTel.Text))
            {
                MessageBox.Show("El campo Telefono esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtequipo.Text))
            {
                MessageBox.Show("El campo Equipo esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtnoSerie.Text))
            {
                MessageBox.Show("El campo No de serie esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("El campo Marca esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("El campo Modelo esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtIdEquipo.Text))
            {
                MessageBox.Show("El campo IdEquipo esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtAsesor.Text))
            {
                MessageBox.Show("El campo Asesor esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTServicio.Text))
            {
                MessageBox.Show("El campo tipo de servicio esta vacío. Solicitar informacion al area de ventas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbDiasS.Text))
            {
                MessageBox.Show("El campo dias de servicio esta vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (idtservicio == 1 || idtservicio == 2 || idtservicio == 3 || idtservicio == 4 || idtservicio == 5 || idtservicio == 6 || idtservicio == 7 || idtservicio == 11 || idtservicio == 12 || idtservicio == 13 || idtservicio == 14 || idtservicio == 15 || idtservicio == 16 || idtservicio == 17 || idtservicio == 18)
            {
                if (txtOrdenVenta.Text == "12787")
                {
                    MessageBox.Show("Llamada vinculada a Orden de Venta Generica. Favor de Revisarlo en el area Comercial para colocar la correcta.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (string.IsNullOrEmpty(txtOrdenVenta.Text))
            {
                MessageBox.Show("Llamada no vinculada a Orden de Venta. Favor de revisarlo en el area Comercial.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            //*******************DETERMINA SI LA FECHA COLOCADA ES MENOR A LA ACTUAL
            DateTime Fecha1, fecha2;
            Fecha1 = Convert.ToDateTime(dtpfecha.Value.ToString("dd-MM-yyyy"));
            fecha2 = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy"));
            int result = DateTime.Compare(Fecha1, fecha2);

            if (result < 0)
            {
                MessageBox.Show("La Fecha Requerida de Servicio no Puede ser Menor a la Fecha Actual", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            fservicio = dtpfecha.Text + " " + dtpHora.Text + ":00.000";

            MessageBox.Show("Validando datos. Por favor Espere...", "Cargando", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //timerSave.Enabled = true;
            timerSave.Start();
            progressBar1.Value = 0;
            btnGuardarFSR.Enabled = false;
                       
        }

        //*************************GUARDA FSR FISICOS
        public void PDFSaveFSR()
        {
            int tservicio = Convert.ToInt32(cmbTServicio.SelectedValue);

            string valor, protocolo, idcliente, cliente, folio, equipo, marca, modelo, noSerie, idEquipoC;
            string nrespo, nreport, mail, depto, tel, direccion, localidad, fechaSolServicio, horaServ, FallaReport, OC;
            int idContrato, idTProblema, idEstatus, idIng, idLlamada, noLlamada, result;

            if (tservicio == 10 || tservicio == 12 || tservicio == 13 || tservicio == 14 || tservicio == 20 || tservicio == 22)
            {
                valor = "Y";
            }
            else
                valor = "N";

            if (tservicio == 12 || tservicio == 13 || tservicio == 14 || tservicio == 23)
            {
                protocolo = "Y";
            }
            else
                protocolo = "N";

            clasifica = cbClasifica.Text;
            if (clasifica == "Temperatura")
            { idClas = 1; }
            if (clasifica == "Fisicoquimicos")
            { idClas = 2; }
            if (clasifica == "Analitica")
            { idClas = 3; }

            idcliente = txtcodcliente.Text;
            cliente = txtCliente.Text;
            idContrato = Convert.ToInt32(cmbTContrato.SelectedValue);
            idTProblema = Convert.ToInt32(cmbTProblema.SelectedValue);
            idEstatus = Convert.ToInt32(cmbestatus.SelectedValue);
            idIng = Convert.ToInt32(cmbing.SelectedValue);
            folio = lblFolio.Text;
            idLlamada = Convert.ToInt32(txtNumeroServicio.Text);
            equipo = txtequipo.Text;
            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            noSerie = txtnoSerie.Text;
            idEquipoC = txtIdEquipo.Text;
            nrespo = txtNResponsable.Text;
            nreport = txtNReportado.Text;
            mail = txtMail.Text;
            depto = txtDepto.Text;
            tel = txtTel.Text;
            direccion = txtDireccion.Text;
            localidad = txtLocalidad.Text;
            fechaSolServicio = txtfechaSolServicio.Text;
            horaServ = dtpHora.Text;
            noLlamada = Convert.ToInt32(txtIdllamada.Text);
            FallaReport = txtFallaReport.Text;
            OC = txtOrdenVenta.Text;

            try
            {
                result = objConsultasBD.PDFSaveFSR(tipoBD, idcliente, cliente, idContrato, idTProblema, tservicio, TestSpire.Usr.User, idEstatus, idIng, fservicio, folio, idLlamada, equipo, marca, modelo, noSerie, idEquipoC,
                    nrespo, nreport, mail, depto, tel, direccion, localidad, fechaSolServicio, horaServ, noLlamada, carpeta, asesorid, idClas, rutaFSR, FallaReport, OC, protocolo, name);

                if (result == 1)
                {
                    if(tipoBD == 1)
                    {
                        GeneraFolio();
                        FolioActual();
                        Limpiar();
                    }
                    MessageBox.Show("Se Ha Guardado el Folio " + txtFolioAnt.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }


        //********************GUARDA FSR NUEVOS
        public void SaveFSR()
        {
            timer1.Start();

            string valor, protocolo, idcliente, cliente, folio, equipo, marca, modelo, noSerie, idEquipoC;
            string nrespo, nreport, mail, depto, tel, direccion, localidad, fechaSolServicio, horaServ, FallaReport, OC;
            int idContrato, idTProblema, idEstatus, idIng, idLlamada, noLlamada, diasServ, result;

            int tservicio = Convert.ToInt32(cmbTServicio.SelectedValue);

            if (tservicio == 10 || tservicio == 12 || tservicio == 13 || tservicio == 14 || tservicio == 20 || tservicio == 22)
            {
                valor = "Y";
            }
            else
            {
                valor = "N";
            }
                
            if (tservicio == 12 || tservicio == 13 || tservicio == 14 || tservicio == 23)
            {
                protocolo = "Y";
            }
            else
            {
                protocolo = "N";
            }

            clasifica = cbClasifica.Text;
            if (clasifica == "Temperatura")
            { idClas = 1; }
            if (clasifica == "Fisicoquimicos")
            { idClas = 2; }
            if (clasifica == "Analitica")
            { idClas = 3; }

            idcliente = txtcodcliente.Text;
            cliente = txtCliente.Text;
            idContrato = Convert.ToInt32(cmbTContrato.SelectedValue);
            idTProblema = Convert.ToInt32(cmbTProblema.SelectedValue);
            idEstatus = Convert.ToInt32(cmbestatus.SelectedValue);
            idIng = Convert.ToInt32(cmbing.SelectedValue);
            folio = lblFolio.Text;
            idLlamada = Convert.ToInt32(txtNumeroServicio.Text);
            equipo = txtequipo.Text;
            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            noSerie = txtnoSerie.Text;
            idEquipoC = txtIdEquipo.Text;
            nrespo = txtNResponsable.Text;
            nreport = txtNReportado.Text;
            mail = txtMail.Text;
            depto = txtDepto.Text;
            tel = txtTel.Text;
            direccion = txtDireccion.Text;
            localidad = txtLocalidad.Text;
            fechaSolServicio = txtfechaSolServicio.Text;
            horaServ = dtpHora.Text;
            noLlamada = Convert.ToInt32(txtIdllamada.Text);
            FallaReport = txtFallaReport.Text;
            OC = txtOrdenVenta.Text;
            diasServ = Convert.ToInt32(cmbDiasS.SelectedItem);

            try
            {
                lblFolio.Text = objConsultasBD.getUltimoFolio(tipoBD);

                result = objConsultasBD.SaveFSR(tipoBD, idcliente, cliente, idContrato, idTProblema, idtservicio, TestSpire.Usr.User, idEstatus, idIng, fservicio, folio, idLlamada, equipo, marca, modelo, noSerie, idEquipoC, nrespo,
                    nreport, mail, depto, tel, direccion, localidad, fechaSolServicio, horaServ, noLlamada, valor, asesorid, idClas, FallaReport, OC, protocolo, diasServ, name);

                if(result == 1)
                {
                    //GeneraFolio();
                    //FolioActual();
                    if (tipoBD == 1)
                    {
                        GeneraFolio();
                        FolioActual();
                        ActualizaFechaActividad();
                        SaveDetFSR();
                        SaveEquipo();
                        Limpiar();
                    }
                    MessageBox.Show("Se Ha Guardado el Folio " + lblFolio.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //envia correo asesor y a ingeniero
            if (tipoBD == 1)
            {
                try
                {
                    objConsultasBD.SendCorreoIngResponsable(tipoBD);

                    if (idtservicio == 4 || idtservicio == 9)
                    {
                        objConsultasBD.SendCorreoAsesor(tipoBD);                        
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                               
            }            
        }


        //********************GUARDA FRS CUANDO SE TIENEN INGENIEROS ACOMPAÑANTES
        public void saveFSRInges()
        {
            timer1.Start();

            int tservicio = Convert.ToInt32(cmbTServicio.SelectedValue);

            string valor, protocolo, idcliente, cliente, folio, equipo, marca, modelo, noSerie, idEquipoC;
            string nrespo, nreport, mail, depto, tel, direccion, localidad, fechaSolServicio, horaServ, FallaReport, OC;
            int idTContrato, idTProblema, idEstatus, idIng, idLlamada, noLlamada, diasServ, result, idIng2, idIng3;

            if (tservicio == 10 || tservicio == 12 || tservicio == 13 || tservicio == 14 || tservicio == 20 || tservicio == 22)
            {
                valor = "Y";
            }
            else
                valor = "N";

            if (tservicio == 12 || tservicio == 13 || tservicio == 14 || tservicio == 23)
            {
                protocolo = "Y";
            }
            else
                protocolo = "N";

            clasifica = cbClasifica.Text;
            if (clasifica == "Temperatura")
            { idClas = 1; }
            if (clasifica == "Fisicoquimicos")
            { idClas = 2; }
            if (clasifica == "Analitica")
            { idClas = 3; }

            idcliente = txtcodcliente.Text;
            cliente = txtCliente.Text;
            idTContrato = Convert.ToInt32(cmbTContrato.SelectedValue);
            idTProblema = Convert.ToInt32(cmbTProblema.SelectedValue);
            idEstatus = Convert.ToInt32(cmbestatus.SelectedValue);
            idIng = Convert.ToInt32(cmbing.SelectedValue);
            folio = lblFolio.Text;
            idLlamada = Convert.ToInt32(txtNumeroServicio.Text);
            equipo = txtequipo.Text;
            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            noSerie = txtnoSerie.Text;
            idEquipoC = txtIdEquipo.Text;
            nrespo = txtNResponsable.Text;
            nreport = txtNReportado.Text;
            mail = txtMail.Text;
            depto = txtDepto.Text;
            tel = txtTel.Text;
            direccion = txtDireccion.Text;
            localidad = txtLocalidad.Text;
            fechaSolServicio = txtfechaSolServicio.Text;
            horaServ = dtpHora.Text;
            noLlamada = Convert.ToInt32(txtIdllamada.Text);
            FallaReport = txtFallaReport.Text;
            idIng2 = Convert.ToInt32(cmbIngAcomp1.SelectedValue);
            idIng3 = Convert.ToInt32(cmbIngAcomp2.SelectedValue);
            OC = txtOrdenVenta.Text;
            diasServ = Convert.ToInt32(cmbDiasS.SelectedItem);

            try
            {
                lblFolio.Text = objConsultasBD.getUltimoFolio(tipoBD);

                result = objConsultasBD.saveFSRIngenieros(tipoBD, idcliente, cliente, idTContrato, idTProblema, idtservicio, TestSpire.Usr.User, idEstatus, idIng, fservicio, equipo, marca, modelo, noSerie, idEquipoC, nrespo, nreport,
                   mail, folio, idLlamada, depto, tel, direccion, localidad, fechaSolServicio, horaServ, noLlamada, valor, asesorid, idClas, FallaReport, idIng2, idIng3, OC, protocolo, diasServ, name);

                if(result == 1)
                {
                    if(tipoBD == 1)
                    {
                        GeneraFolio();
                        FolioActual();
                        ActualizaFechaActividad();
                        SaveDetFSR();
                        SaveEquipo();
                        Limpiar();
                    }
                    MessageBox.Show("Se Ha Guardado el Folio " + lblFolio.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //***********************ENVIA CORREO SOLO ENCASO DE QUE SEA PRODUCCION
            if(tipoBD == 1)
            {
                try
                {
                    objConsultasBD.SendCorreoIngResponsable(tipoBD);
                    objConsultasBD.SendCorreoIngAc1(tipoBD);
                    objConsultasBD.SendCorreoIngAc2(tipoBD);

                    if(idtservicio == 4 || idtservicio == 9)
                    {
                        objConsultasBD.SendCorreoAsesor(tipoBD);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }                     
        }


        //**********************LIMPIA LOS DATOS DE LOS CONTROLES
        public void Limpiar()
        {
            txtCliente.Text = null;
            txtIdEquipo.Text = null;
            txtnoSerie.Text = null;
            txtequipo.Text = null;
            txtMarca.Text = null;
            txtModelo.Text = null;
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
            txtHoraSolServicio.Text = null;
            txtfechaSolServicio.Text = null;
            txtNumeroServicio.Text = null;
            txtcodcliente.Text = null;
            dtpHora.Text = null;
            cbClasifica.Text = null;
            cmbIngAcomp1.Text = null;
            cmbIngAcomp2.Text = null;
        }


        //*******************GUARDA DETALLE DEL FOLIO 
        public void SaveDetFSR()
        {
            int result;
            string idCliente, nRespo, nReport, mail, depto, tel, direccion, localidad, folio;

            folio = lblFolio.Text;
            idCliente = txtcodcliente.Text;
            nRespo = txtNResponsable.Text;
            nReport = txtNReportado.Text;
            mail = txtMail.Text;
            depto = txtDepto.Text;
            tel = txtTel.Text;
            direccion = txtDireccion.Text;
            localidad = txtLocalidad.Text;
            try
            {
                result = objConsultasBD.SaveDetalleFSR(tipoBD, folio, idCliente, nRespo, nReport, mail, depto, tel, direccion, localidad);
                if(result == 1)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }


        //****************TOMA Y DA FORMATO A LA FECHA DE SERVICIO
        private void dtpHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fservicio = dtpfecha.Text + " " + dtpHora.Text + ":00.000";
        }


        //*****************VALIDA SI EXISTE EL NUMERO DE SERIE
        public void validanoserie()
        {
            try
            {
                SqlDataReader leer;
                leer = objConsultasBD.getValidaNoSerie(tipoBD, txtnoSerie.Text);
                if (leer.Read())
                {
                    flag = 1;                    
                }
                else
                {
                    flag = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        //******************SI EL EQUIPO NO EXISTE LO CREA
        public void SaveEquipo()
        {
            int Res;
            string descrip, noSerie, marca, modelo, idCliente;
            
            descrip = txtequipo.Text;
            noSerie = txtnoSerie.Text;
            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            idCliente = txtcodcliente.Text;

            validanoserie();

            if(flag == 0)
            {
                try
                {
                    Res = objConsultasBD.SaveEquipo(tipoBD, descrip, noSerie, marca, modelo, idCliente);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
       

        private void dtpfecha_ValueChanged(object sender, EventArgs e)
        {

        }


        //********************ABRE REPORTE DE CALENDARIO
        private void calendarioGeneralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarioDias frm = new CalendarioDias(tipoBD);
            //CalendarioGeneral frm = new CalendarioGeneral(tipoBD);
            frm.Show();
        }
                

        private void cmbTProblema_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chCarpeta_CheckedChanged(object sender, EventArgs e)
        {

        }


        //*****************BOTON SUBIR FOLIO, VISIBILIDAD A OBJETOS
        private void button1_Click(object sender, EventArgs e)
        {
            btnGenerarFolio.Visible = false;
            btnGuardarFSR.Visible = false;
            btnSubirFSR.Visible = false;
            btnSubirPDF.Visible = true;

            lblFolio.Visible = false;
            txtFolioAnt.Visible = true;
            txtFolioAnt.Enabled = true;
            cmbestatus.SelectedValue = 3;

            btnGuardarFSRAnterior.Visible = true;

            ckbIngAcomp.Enabled = false;
        }


        private void cmbestatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        
        //*******************GUARDA FSR FISICO
        private void btnGuardarFSRAnterior_Click(object sender, EventArgs e)
        {            
            string consul, file;
            int existe;

            fant = txtFolioAnt.Text;

            if (string.IsNullOrEmpty(txtFolioAnt.Text))
            {
                MessageBox.Show("El campo Folio esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //********************BUSCA SI EXISTE ALGUN FOLIO IGUAL
            existe = Convert.ToInt32(objConsultasBD.getBuscaExistFolio(tipoBD, fant));

            //**************SI NO EXISTE Y ESTA EN EL RANGO DEJA GUARDARLO 
            if(existe == 0 || Convert.ToInt32(fant) <= 26599)
            {
                saveFSRFisico();
            }
            else
            {
                MessageBox.Show("Ya existe un registro con el Folio: " + fant, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
        }


        //*********************REALIZA UPDATE A FECHAS DE SERVICIO
        public void ActualizaFechaActividad()
        {
            int r;

            try
            {
                r = objConsultasBD.UpdateFechaActividad(tipoBD, dtpfecha.Value, dtpfecha.Value, Convert.ToInt32(txtNumeroServicio.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        //*************************LLAMA PROCESOS DE GUARDADO PARA LOS FSR FISICOS
        public void saveFSRFisico()
        {
            if (string.IsNullOrEmpty(txtFolioAnt.Text))
            {
                MessageBox.Show("El campo Folio esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(dtpHora.Text))
            {
                MessageBox.Show("No se ha seleccionado Hora de Servicio ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtMail.Text))
            {
                MessageBox.Show("El campo E-Mail no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("El campo Cliente/Empresa no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtLocalidad.Text))
            {
                MessageBox.Show("El campo Localidad no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("El campo Dirección no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbing.Text))
            {
                MessageBox.Show("El campo Ingeniero no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTServicio.Text))
            {
                MessageBox.Show("El campo Tipo de Servicio no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTProblema.Text))
            {
                MessageBox.Show("El campo Tipo de Problema no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbing.Text))
            {
                MessageBox.Show("El campo Ingeniero Asignado no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cbClasifica.Text))
            {
                MessageBox.Show("El campo Clasificación esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTContrato.Text))
            {
                MessageBox.Show("El campo Tipo de Contrato esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtFallaReport.Text))
            {
                MessageBox.Show("El campo Falla reportada esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtNResponsable.Text))
            {
                MessageBox.Show("El campo Cliente esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtDepto.Text))
            {
                MessageBox.Show("El campo Departamento esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtTel.Text))
            {
                MessageBox.Show("El campo Telefono esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtequipo.Text))
            {
                MessageBox.Show("El campo Equipo esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtnoSerie.Text))
            {
                MessageBox.Show("El campo No de serie esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                MessageBox.Show("El campo Marca esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("El campo Modelo esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtIdEquipo.Text))
            {
                MessageBox.Show("El campo IdEquipo esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtAsesor.Text))
            {
                MessageBox.Show("El campo Asesor esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbTServicio.Text))
            {
                MessageBox.Show("El campo tipo de servicio esta vacío. Solicitar informacion al area de ventas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            
            if (string.IsNullOrEmpty(lblSelectArchivo.Text))
            {
                MessageBox.Show("No ha seleccionado el archivo PDF.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (checkBox1.Checked == true)
            {
                pdfg();
                PDFSaveFSR();
                Refaccion();
            }
            else
            {
                pdfg();
                PDFSaveFSR();
            }
            this.Close();
        }


        //********************GUARDA PDF EN LA CARPETA SEÑALADA DEL SERVIDOR
        public void pdfg()
        {
            try
            {   
                if (File.Exists(@"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + fant + ".pdf"))
                {
                    //MessageBox.Show("Existe. Dias " + cmbDiasS.SelectedItem);
                    carpeta = Path.Combine(Application.StartupPath, String.Format(@"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + fant + "-A" + txtNumeroServicio.Text + ".pdf", Path.GetFileName(openFileDialog1.FileName)));
                    File.Copy(openFileDialog1.FileName, carpeta);
                    rutaFSR = @"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + fant + "-A" + txtNumeroServicio.Text + ".pdf";
                    //MessageBox.Show(rutaFSR);
                }
                else
                {
                    carpeta = Path.Combine(Application.StartupPath, String.Format(@"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + fant + ".pdf", Path.GetFileName(openFileDialog1.FileName)));
                    File.Copy(openFileDialog1.FileName, carpeta);
                    rutaFSR = @"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + fant + ".pdf";
                }                   

                MessageBox.Show("Documento guardado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtFolioAnt.Visible = false;
                lblFolio.Text = fant;
                lblFolio.Visible = true;
                
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un problema al guardar el archivo " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void timerSave_Tick(object sender, EventArgs e)
        {
            lblProgreso.Visible = true;
            progressBar1.Visible = true;

            try
            {
                lblFolio.Text = objConsultasBD.getUltimoFolio(tipoBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //progressBar1.Increment(20);
            conteo++;
            lblProgreso.Text = "Cargando: " + conteo.ToString() + "%";

            if(progressBar1.Value < 100)
            {
                progressBar1.Value++;
                btnGuardarFSR.Enabled = false;
            }
            if(progressBar1.Value == 100)
            {
                timerSave.Enabled = false;
                lblProgreso.Visible = false;
                progressBar1.Visible = false;
                //btnGuardarFSR.Enabled = true;
                if (ckbIngAcomp.Checked == true)
                {
                    saveFSRInges();
                }
                if (checkBox1.Checked == true && ckbIngAcomp.Checked == true)
                {
                    saveFSRInges();
                    Refaccion();
                }
                if (checkBox1.Checked == true)
                {
                    SaveFSR();
                    Refaccion();
                }
                if (checkBox1.Checked == false && ckbIngAcomp.Checked == false)
                {
                    SaveFSR();
                }
                this.Close();
                btnGuardarFSR.Enabled = false;
            }
        }


        //***************ACTIVA CONTROLES SI ES NECESARIO AGEGAR MAS INGENIEROS
        private void ckbIngAcomp_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbIngAcomp.Checked == true)
            {
                lblAcom1.Visible = true;
                lblAcom2.Visible = true;

                cmbIngAcomp1.Visible = true;
                cmbIngAcomp2.Visible = true;
            }
            else
            {
                lblAcom1.Visible = false;
                lblAcom2.Visible = false;

                cmbIngAcomp1.Visible = false;
                cmbIngAcomp2.Visible = false;
            }
        }

        private void cbClasifica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fillByIngToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.usuariosTableAdapter.FillByIng(this.browserDataSet.Usuarios);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByIngToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.usuariosTableAdapter.FillByIng(this.browserDataSet.Usuarios);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void cmbDiasS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //********************ABRE EL DIRECTORIO PARA SELECCIONAR ARCHIVOS pdf
        private void btnSubirPDF_Click(object sender, EventArgs e)
        {
            try
            {
                    openFileDialog1.InitialDirectory = "c:\\";
                    openFileDialog1.Filter = "Archivos de texto (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";
                    openFileDialog1.RestoreDirectory = true;
                    if(openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        archivo = openFileDialog1.FileName;
                        lblRuta.Text = archivo;
                        lblSelectArchivo.Text = Path.GetFileName(openFileDialog1.FileName);
                        lblSelectArchivo.Visible = true;
                        fant = txtFolioAnt.Text;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar el archivo: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        
        private void cmbTContrato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //**************************ASIGNA LOS VALORES INTERNOS DE ID PARA EL SERVICIO
        private void cmbTServicio_SelectedIndexChanged(object sender, EventArgs e)
        {            
            int tservicio = Convert.ToInt32(cmbTServicio.SelectedValue);
           
            if(tservicio==8)
            {
                idtservicio = 1;
            }
            if (tservicio == 9)
            {
                idtservicio = 2;
            }
            if (tservicio == 10)
            {
                idtservicio = 3;
            }
            if (tservicio == 11)
            {
                idtservicio = 4;
            }
            if (tservicio == 12)
            {
                idtservicio = 5;
            }
            if (tservicio == 13)
            {
                idtservicio = 6;
            }
            if (tservicio == 14)
            {
                idtservicio = 7;
            }
            if (tservicio == 15)
            {
                idtservicio = 8;
            }
            if (tservicio == 16)
            {
                idtservicio = 9;
            }
            if (tservicio == 17)
            {
                idtservicio = 10;
            }
            if (tservicio == 18)
            {
                idtservicio = 11;
            }
            if (tservicio == 19)
            {
                idtservicio = 12;
            }
            if (tservicio == 20)
            {
                idtservicio = 13;
            }
            if (tservicio == 21)
            {
                idtservicio = 14;
            }
            if (tservicio == 22)
            {
                idtservicio = 16;
            }
            if (tservicio == 23)
            {
                idtservicio = 17;
            }

            if (tservicio == 10 || tservicio == 12 || tservicio == 13 || tservicio == 14 || tservicio == 20 || tservicio == 22)
            {
                chCarpeta.Checked = true;
            }
            else
                chCarpeta.Checked = false;
        }


        //***********************HACE REFRESH AL SIGUIENTE FOLIO PARA EVITAR SERVICIOS CON FOLIOS DUPLICADOS
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblFolio.Text = objConsultasBD.getUltimoFolio(tipoBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        //**************************REFLEJA EL FOLIO Y ESTATUS EN SAP
        public void FolioActual()
        {
            int rst;
            try
            {
                rst = objConsultasBD.UpdateFolioSAP(tipoBD, Convert.ToInt32(lblFolio.Text), cmbestatus.Text, Convert.ToInt32(txtNumeroServicio.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "EROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //*********************ACTUALIZA EL ESTATUS Y FOLIO EN SAP
        public void GeneraFolio()
        {
            int res;
            try
            {
                res = objConsultasBD.GeneraFolioSAP(tipoBD, Convert.ToInt32(lblFolio.Text), cmbestatus.Text, Convert.ToInt32(txtNumeroServicio.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                    
        }


        //**********************EN CASO DE TENER REFACCIONES LAS GUARDA
        public void Refaccion()
        {
            //for(int i = 0; i < dataGridView1.Rows.Count - 1; i ++)
            //{
            //    SqlCommand inse = new SqlCommand(@"insert into Refaccion (numRefaccion,cantidadRefaccion,descRefaccion,idFSR) values ('" + dataGridView1.Rows[i].Cells["NoParte"].Value+"',"+Convert.ToInt32(dataGridView1.Rows[i].Cells["Cantidad"].Value)+",'"+ dataGridView1.Rows[i].Cells["Descripcion"].Value +"',"+Convert.ToInt32(lblFolio.Text),con);

            //    con.Open();
            //    inse.ExecuteNonQuery();
            //    con.Close();
            //}
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    objConsultasBD.insetRefacciones(tipoBD, dataGridView1.Rows[i].Cells["NoParte"].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells["Cantidad"].Value), dataGridView1.Rows[i].Cells["Descripcion"].Value.ToString(), Convert.ToInt32(lblFolio.Text));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        //*************AL SELECCIONAR REFACCIONES SE ACTIVA EL GRID PSRS LLENADO
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dataGridView1.Visible = true;
                dataGridView1.Enabled = true;
            }
            else
            {
                dataGridView1.Visible = false;
                dataGridView1.Enabled = false;
            }                
        }
    }
}
