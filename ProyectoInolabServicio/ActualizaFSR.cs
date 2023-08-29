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
using System.Reflection;
using ProyectoInolabServicio.BrowserDataSetTableAdapters;

namespace ProyectoInolabServicio
{
    public partial class ActualizaFSR : MaterialForm
    {
        public ActualizaFSR( string llamada, int BD)
        {
            InitializeComponent();
            llamada_p = llamada;
            tipoBD = BD;
            DoubleBuffered(dgvAcciones, true);
        }


        //****************************VARIABLES
        string llamada_p, archivo, rutaFSR, folioFSR, carpeta;
        int tipoBD;
        int v_dvg = 0;
        int v_dvg1 = 0;
        string fecha, accionR, hora;
        string numR, cantR, refaccion;

        string FSR, cliente, direccion, localidad, responsable, reportado, depto, telefono, mail, equipo, marca, modelo, noserie, idequipo, webinicio, webfin, fallaEncontrada, observaciones;
        int idT_servicio, idT_Problema, idT_Contrato;


        //***********************INSTANCIA PARA DATA CONSULTAS
        DataConsultas objConsultasBD = new DataConsultas();

        //**********OBTIENE EL NOMBRE DE EQUIPO DEL USUARIO
        string HostName = System.Net.Dns.GetHostName();


        //***********************CARGA TODOS LOS DATOS DEL FOLIO
        private void ActualizaFSR_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Contrato' Puede moverla o quitarla según sea necesario.
            this.tipo_ContratoTableAdapter.Fill(this.browserDataSet.Tipo_Contrato);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Problema' Puede moverla o quitarla según sea necesario.
            this.tipo_ProblemaTableAdapter.Fill(this.browserDataSet.Tipo_Problema);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_ServicioTableAdapter.Fill(this.browserDataSet.Tipo_Servicio);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Clasificacion' Puede moverla o quitarla según sea necesario.
            this.clasificacionTableAdapter.Fill(this.browserDataSet.Clasificacion);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.browserDataSet.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.F_Status' Puede moverla o quitarla según sea necesario.
            this.f_StatusTableAdapter.Fill(this.browserDataSet.F_Status);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Refaccion' Puede moverla o quitarla según sea necesario.
            this.refaccionTableAdapter.Fill(this.browserDataSet.Refaccion, Convert.ToInt32(lblFolio.Text));
            //this.refaccionTableAdapter.refaccion(this.browserDataSet.Refaccion, Convert.ToInt32(lblFolio.Text));
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.FSRAccion' Puede moverla o quitarla según sea necesario.
            this.fSRAccionTableAdapter.Fill(this.browserDataSet.FSRAccion);
            CargarDatos();
            Cargardgv();

            if(TestSpire.Usr.K == 136 || TestSpire.Usr.K == 88)
            {
                btnAgregarPDF.Visible = true;
            }

        }


        //*******************CARGA LOS DATOS DEL FSR
        public void CargarDatos()
        {
            SqlDataReader leer;
            try
            {
                leer = objConsultasBD.setCargaDatosFSR(tipoBD, llamada_p);
                if (leer.Read())
                {
                    txtCliente.Text = Convert.ToString(leer["Cliente"]);
                    txtNReportado.Text = Convert.ToString(leer["N_Reportado"]);
                    txtNResponsable.Text = Convert.ToString(leer["N_Responsable"]);
                    txtMail.Text = Convert.ToString(leer["Mail"]);
                    txtDepto.Text = Convert.ToString(leer["Depto"]);
                    txtTel.Text = Convert.ToString(leer["Telefono"]);
                    txtDireccion.Text = Convert.ToString(leer["Direccion"]);
                    txtLocalidad.Text = Convert.ToString(leer["Localidad"]);
                    txtNumeroServicio.Text = Convert.ToString(leer["IdLlamada"]);
                    lblFolio.Text = Convert.ToString(leer["Folio"]);
                    dtpfecha.Text = Convert.ToString(leer["FechaServicio"]);
                    txtequipo.Text = Convert.ToString(leer["Equipo"]);
                    txtMarca.Text = Convert.ToString(leer["Marca"]);
                    txtModelo.Text = Convert.ToString(leer["Modelo"]);
                    txtnoSerie.Text = Convert.ToString(leer["NoSerie"]);
                    txtIdEquipo.Text = Convert.ToString(leer["IdEquipo_C"]);
                    cmbestatus.SelectedValue = Convert.ToInt32(leer["IdStatus"]);
                    cmbing.SelectedValue = Convert.ToInt32(leer["Id_Ingeniero"]);
                    cmbTContrato.SelectedValue = Convert.ToInt32(leer["IdT_Contrato"]);
                    cmbTProblema.SelectedValue = Convert.ToInt32(leer["IdT_Problema"]);
                    cmbTServicio.SelectedValue = Convert.ToInt32(leer["IdT_servicio"]);
                    txtobservaciones.Text = Convert.ToString(leer["Observaciones"]);
                    txtIdllamada.Text = Convert.ToString(leer["NoLlamada"]);
                    txtfechaSolServicio.Text = Convert.ToString(leer["FechaFolio"]);
                    txtHoraSolServicio.Text = Convert.ToString(leer["Horaservicio"]);
                    txtNumeroServicio.Text = Convert.ToString(leer["NoLlamada"]);
                    txtinicioservicio.Text = Convert.ToString(leer["WebFechaIni"]);
                    txtfinservicio.Text = Convert.ToString(leer["WebFechaFin"]);
                    txtOC.Text = Convert.ToString(leer["OC"]);
                    txtfallareportada.Text = Convert.ToString(leer["FallaReportada"]);
                    txtfallaencontrada.Text = Convert.ToString(leer["FallaEncontrada"]);
                    txtOC.Text = Convert.ToString(leer["OC"]);
                    lblTipoLlamada.Text = Convert.ToString(leer["TipoLlamada"]);
                    cmbFunciona.Text = Convert.ToString(leer["Funcionando"]);
                    //cbClasificacion.SelectedValue = Convert.ToInt32(leer["IdClasificacion"]);
                    if (leer.IsDBNull(52))
                    {
                        cbClasificacion.Text = null;
                    }
                    else
                    {
                        cbClasificacion.SelectedValue = Convert.ToInt32(leer["IdClasificacion"]);
                    }

                    this.refaccionTableAdapter.Fill(this.browserDataSet.Refaccion, Convert.ToInt32(lblFolio.Text));

                    if (Convert.ToInt32(cmbestatus.SelectedValue) == 3)
                    {
                        lblDato.Visible = false;
                        lblArchivoS.Visible = false;
                        btnUpDate.Visible = false;
                        btnAdjuntarFSR.Visible = false;
                        btnAgregarPDF.Visible = false;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //********************CARGA LAS ACCIONES DEL FSR EN CASO DE TENER 
        public void Cargardgv()
        {
            try
            {
                dgvAcciones.DataSource = objConsultasBD.getAccionesFSR(tipoBD, Convert.ToInt32(lblFolio.Text));
                dgvRefacciones.DataSource = objConsultasBD.getRefaccionesFSR(tipoBD, lblFolio.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //************ BUFFERED REDUCE PARPADEO AL CARGAR EL GRID
        public new static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }


        //*********************ABRE EL FORM QUE CONTIENE EL CALENDARIO GENERAL
        private void calendarioGeneraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarioDias frm = new CalendarioDias(tipoBD);
            //CalendarioGeneral frm = new CalendarioGeneral(tipoBD);
            frm.Show();
        }


        //********************ABRE EL FORM QUE CONTIENE EL REPORTE DEL FSR
        private void btnVerFSR_Click(object sender, EventArgs e)
        {
            ReporteFolio frm = new ReporteFolio(lblFolio.Text);
            frm.Show();
        }


        //*******************GUARDABA LA ORDEN DE VENTA, YA NO SE USA***********************
        private void btnGuardaOC_Click(object sender, EventArgs e)
        {
            //string comando;
            //comando = "update fsr set OC='" + txtOC.Text+ "' where folio=" + Convert.ToInt32(lblFolio.Text);

            //con.Open();

            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = comando;
            //cmd.Connection = con;
            //cmd.ExecuteNonQuery();

            //MessageBox.Show("No. de Orden de Compra Agregada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //con.Close();
        }
        //*****************************************************************************************


        //********************ACTIVA CHEK REQUIERE REPORTE DEPENDIENDO DE LA SELECCION DE TIPO DE SERVICIO
        private void cmbTServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tservicio =Convert.ToInt32(cmbTServicio.SelectedValue);

            if (tservicio == 3 || tservicio == 5 || tservicio == 6 || tservicio == 7 || tservicio == 13 || tservicio == 16)
            {
                chCarpeta.Checked = true;
            }
            else
                chCarpeta.Checked = false;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        //********************LLAMA LA FUNCION PARA GUARDAR LA INFORMACION DE FOLIOS FISICOS
        private void btnUpDate_Click(object sender, EventArgs e)
        {
            validaCampos();
            //btnUpDate.Enabled = false;
        }

        private void dtpfecha_ValueChanged(object sender, EventArgs e)
        {

        }


       //********************ACTIVA LOS OBJETOS PARA COLOCAR INFORMACION DE FSR FISICO
        private void btnAgregarPDF_Click(object sender, EventArgs e)
        {
            //lblDato.Visible = true;
            //btnAdjuntarFSR.Visible = true;
            btnAgregarA.Visible = true;
            //dataGridVAccionesAdd.Visible = true;
            btnAgregarRefac.Visible = true;
            //dataGridVRefacAdd.Visible = true;
            lblFormato1.Visible = true;
            lblFormato2.Visible = true;
            btnUpDate.Visible = true;
        }

        private void cbClasificacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //***********************MUETRA EL DIALOG PARA AGREGAR LAS ACCIONES DEL FOLIO
        private void btnAgregarA_Click(object sender, EventArgs e)
        {
            //DialogAddAccion();
            UpdateAcciones();
        }

        private void fSRAccionBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }


        //*************************ABRE EL DIALOG PARA SELECCIONAR EL ARCHIVO PDF
        private void btnAdjuntarFSR_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Archivos de texto (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    archivo = openFileDialog1.FileName;
                    lblArchivoS.Text = Path.GetFileName(openFileDialog1.FileName);
                    folioFSR = lblFolio.Text;
                    btnUpDate.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar el archivo: " + ex.ToString());
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                //this.refaccionTableAdapter.Fill(this.browserDataSet.Refaccion, ((int)(System.Convert.ChangeType(folioToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }


        //******************VALIDA QUE LOS CAMPOS OBLIGATORIOS NO ESTEN VACIOS Y GUARDA LA INFORMACION
        public void validaCampos()
        {
            if(dgvAcciones.Rows.Count-1 <= 0)
            {
                MessageBox.Show("No se han agregado acciones.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtfinservicio.Text))
            {
                MessageBox.Show("El campo Fin del Servicio esta vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtinicioservicio.Text))
            {
                MessageBox.Show("El campo Inicio del Servicio esta vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbing.Text))
            {
                MessageBox.Show("No ha seleccionado Ingeniero de Servicio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cbClasificacion.Text))
            {
                MessageBox.Show("El campo Clasificación esta vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtfallaencontrada.Text))
            {
                MessageBox.Show("El campo Falla encontrada esta vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtfallareportada.Text))
            {
                MessageBox.Show("El campo Falla Reportada esta vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtIdEquipo.Text))
            {
                MessageBox.Show("El campo Id del Equipo esta vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                MessageBox.Show("El campo Modelo esta vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UpdateFSR();
        }
                       

        //********************ABRE EL DIALOG PARA AGREGAR LAS REFACCIONES
        private void btnAgregarRefac_Click(object sender, EventArgs e)
        {
            //DialogAddRefaccion();
            UpdateRefaccion();
        }


        //**********************REALIZA EL UPDATE AL FOLIO INCLYENDO LA RUTA DEL ARCHIVO FISICO
        public void UpdateBDFisico()
        {
            int result;
            try
            {
                result = objConsultasBD.UpdateFSRFisico(tipoBD, Convert.ToInt32(lblFolio.Text), rutaFSR, 3, txtinicioservicio.Text, txtfinservicio.Text, dtpfecha.Text, txtfallareportada.Text,
                            txtfallaencontrada.Text, txtnoSerie.Text, txtIdEquipo.Text, txtobservaciones.Text);

                if(result == 1)
                {
                    MessageBox.Show("Se Ha Actualizado el Folio " + lblFolio.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateRefaccion();
                    UpdateAcciones();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        public void UpdateFSR()
        {
            int result;
            FSR = lblFolio.Text;
            cliente = txtCliente.Text;
            direccion = txtDireccion.Text;
            localidad = txtLocalidad.Text;
            responsable = txtNResponsable.Text;
            reportado = txtNReportado.Text;
            depto = txtDepto.Text;
            telefono = txtTel.Text;
            mail = txtMail.Text;
            equipo = txtequipo.Text;
            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            noserie = txtnoSerie.Text;
            idequipo = txtIdEquipo.Text;
            webinicio = txtinicioservicio.Text;
            webfin = txtfinservicio.Text;
            fallaEncontrada = txtfallaencontrada.Text;
            idT_servicio = Convert.ToInt32(cmbTServicio.SelectedValue);
            idT_Problema = Convert.ToInt32(cmbTProblema.SelectedValue);
            idT_Contrato = Convert.ToInt32(cmbTContrato.SelectedValue);
            observaciones = txtobservaciones.Text;

            try
            {
                result = objConsultasBD.UpdateInfoFSR(tipoBD, FSR, cliente, direccion, localidad, responsable, reportado, depto, telefono, mail, equipo, marca, modelo, noserie,
                                        idequipo, String.Format("{0:yyyy-MM-dd HH:mm:ss}", webinicio), String.Format("{0:yyyy-MM-dd HH:mm:ss}", webfin), fallaEncontrada, idT_servicio, 
                                        idT_Problema, idT_Contrato, observaciones, HostName, cmbFunciona.Text);
                if(result == 1)
                {
                    MessageBox.Show("Cambios Realizados con Exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //*************************GUARDA EL ARCHIVO ADJUNTO PDF EN EL SERVIDOR *** SE UTILIZA EN FOLIOS FISICOS
        //public void Guardar()
        //{
        //    if (tipoBD == 1)
        //    {
        //        try
        //        {
        //            if (File.Exists(@"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + folioFSR + ".pdf"))
        //            {
        //                carpeta = Path.Combine(Application.StartupPath, String.Format(@"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + folioFSR + "-A" + txtNumeroServicio.Text + ".pdf", Path.GetFileName(openFileDialog1.FileName)));
        //                File.Copy(openFileDialog1.FileName, carpeta);
        //                rutaFSR = @"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + folioFSR + "-A" + txtNumeroServicio.Text + ".pdf";
        //                UpdateBD();
        //            }
        //            else
        //            {
        //                carpeta = Path.Combine(Application.StartupPath, String.Format(@"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + folioFSR + ".pdf", Path.GetFileName(openFileDialog1.FileName)));
        //                File.Copy(openFileDialog1.FileName, carpeta);
        //                rutaFSR = @"\\INOLABSERVER01\Desarrollo\FSR Escaneados\Folio" + folioFSR + ".pdf";
        //                UpdateBD();
        //            }

        //            MessageBox.Show("Documento guardado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Ocurrio un problema al guardar el archivo " + ex.ToString());
        //            return;
        //        }
        //    }            
        //}


        //**********************RECORRE EL GRID DE REFACCIONES SI NO ESTA VACIO Y LAS GUARDA EN BD
        int result, r;
        public void UpdateRefaccion()
        {
            string numRefaccion, descripcion, idRefac;
            int filas, cantidad;

            int cantR = objConsultasBD.getBuscaRefacciones(tipoBD, lblFolio.Text);
            filas = dgvRefacciones.Rows.Count-1;
            filas = filas - cantR;

            try
            {
                if(dgvRefacciones.Rows.Count-1 > cantR)
                {
                    for(int i = 0; i < filas; i++)
                    {
                        numRefaccion = dgvRefacciones.Rows[i + cantR].Cells["NumRefaccion"].Value.ToString();
                        cantidad = Convert.ToInt32(dgvRefacciones.Rows[i + cantR].Cells["CantidadRefac"].Value);
                        descripcion = dgvRefacciones.Rows[i + cantR].Cells["Descripcion"].Value.ToString();

                        r = objConsultasBD.UpdateInsertRefacciones(tipoBD, 1, numRefaccion, cantidad, descripcion, lblFolio.Text, "");
                    }

                    for(int i = 0; i < dgvRefacciones.Rows.Count-filas-1; i++)
                    {
                        numRefaccion = dgvRefacciones.Rows[i].Cells["NumRefaccion"].Value.ToString();
                        cantidad = Convert.ToInt32(dgvRefacciones.Rows[i].Cells["Cantidadrefac"].Value);
                        descripcion = dgvRefacciones.Rows[i].Cells["Descripcion"].Value.ToString();
                        idRefac = dgvRefacciones.Rows[i].Cells["idRefaccion"].Value.ToString();

                        r = objConsultasBD.UpdateInsertRefacciones(tipoBD, 2, numRefaccion, cantidad, descripcion, lblFolio.Text, idRefac);
                    }

                    if (r == 1)
                    {
                        MessageBox.Show("Refacciones Guardadas Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if(dgvRefacciones.Rows.Count == cantR)
                {
                    for(int i = 0; i < dgvRefacciones.Rows.Count-1; i++)
                    {
                        numRefaccion = dgvRefacciones.Rows[i].Cells["NumRefaccion"].Value.ToString();
                        cantidad = Convert.ToInt32(dgvRefacciones.Rows[i].Cells["Cantidadrefac"].Value);
                        descripcion = dgvRefacciones.Rows[i].Cells["Descripcion"].Value.ToString();
                        idRefac = dgvRefacciones.Rows[i].Cells["idRefaccion"].Value.ToString();

                        r = objConsultasBD.UpdateInsertRefacciones(tipoBD, 2, numRefaccion, cantidad, descripcion, lblFolio.Text, idRefac);
                    }
                    if (r == 1)
                    {
                        MessageBox.Show("Refacciones Guardadas Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        
        //**************************RECORRE EL GRID DE LAS ACCIONES SI NO ESTAN VACIO LAS GUARDA EN BD
        public void UpdateAcciones()
        {
            int filas, horas;
            string fecha, accion, idAccion;
            DateTime fecha1;

            int cantA = objConsultasBD.getBuscaAcciones(tipoBD, lblFolio.Text);
            filas = dgvAcciones.Rows.Count-1;
            filas = filas - cantA;

            try
            {
                if (dgvAcciones.Rows.Count - 1 > cantA)
                {
                    for (int i = 0; i < filas; i++)
                    {
                        fecha1 = Convert.ToDateTime(dgvAcciones.Rows[i + cantA].Cells["FechaAccion"].Value);
                        fecha = fecha1.ToString("yyyy-MM-dd");
                        horas = Convert.ToInt32(dgvAcciones.Rows[i + cantA].Cells["HorasAccion"].Value);
                        accion = dgvAcciones.Rows[i + cantA].Cells["AccionRealizada"].Value.ToString();

                        result = objConsultasBD.UpdateInsertAcciones(tipoBD, 1, fecha, horas, accion, lblFolio.Text, TestSpire.Usr.K, "");
                    }

                    for (int i = 0; i < dgvAcciones.Rows.Count - filas - 1; i++)
                    {
                        fecha1 = Convert.ToDateTime(dgvAcciones.Rows[i].Cells["FechaAccion"].Value);
                        fecha = fecha1.ToString("yyyy-MM-dd");
                        horas = Convert.ToInt32(dgvAcciones.Rows[i].Cells["HorasAccion"].Value);
                        accion = dgvAcciones.Rows[i].Cells["AccionRealizada"].Value.ToString();
                        idAccion = dgvAcciones.Rows[i].Cells["idFSRAccion"].Value.ToString();

                        result = objConsultasBD.UpdateInsertAcciones(tipoBD, 2, fecha, horas, accion, lblFolio.Text, TestSpire.Usr.K, idAccion);
                    }

                    if (result == 1)
                    {
                        MessageBox.Show("Acciones Guardadas Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if(dgvAcciones.Rows.Count-1 == cantA)
                {
                    for(int i = 0; i < dgvAcciones.Rows.Count-1; i++)
                    {
                        fecha1 = Convert.ToDateTime(dgvAcciones.Rows[i].Cells["FechaAccion"].Value);
                        fecha = fecha1.ToString("yyyy-MM-dd");
                        horas = Convert.ToInt32(dgvAcciones.Rows[i].Cells["HorasAccion"].Value);
                        accion = dgvAcciones.Rows[i].Cells["AccionRealizada"].Value.ToString();
                        idAccion = dgvAcciones.Rows[i].Cells["AccionRealizada"].Value.ToString();

                        result = objConsultasBD.UpdateInsertAcciones(tipoBD, 2, fecha, horas, accion, lblFolio.Text, TestSpire.Usr.K, idAccion);
                    }

                    if (result == 1)
                    {
                        MessageBox.Show("Acciones Guardadas Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            

        }
                       

        //**********************CREA EL DIALOG PARA AGREGAR LAS ACCIONES
        public void DialogAddAccion()
        {
            Form form1 = new Form();
            Button btnOk = new Button();
            Button btnCancel = new Button();
            DateTimePicker dtpFechaAccion = new DateTimePicker();
            Label lblFecha = new Label();
            Label lblAccion = new Label();
            Label lblHoras = new Label();
            TextBox txtAccionR = new TextBox();
            TextBox txtHoras = new TextBox();
            // Agremos texto y localizacion de ambos botones.
            btnOk.Text = "OK";
            btnOk.Location = new Point(280, 35);
            btnCancel.Text = "Cerrar";
            btnCancel.Location = new Point(btnOk.Left, btnCancel.Height + btnOk.Top + 10);
            //damos valor del dialog a los botones
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            //Agregamos propiedades al picket            
            dtpFechaAccion.Format = DateTimePickerFormat.Custom;
            dtpFechaAccion.CustomFormat = "yyyy-MM-dd";
            dtpFechaAccion.Size = new System.Drawing.Size(94, 19);
            dtpFechaAccion.Location = new Point(70, 20);            

            //Agregamos propiedades al label
            lblFecha.Text = "Fecha:";
            lblFecha.Location = new Point(20, 20);
            lblFecha.Size = new Size(40, 13);
            lblHoras.Text = "Horas:";
            lblHoras.Location = new Point(20, 50);
            lblHoras.Size = new Size(40, 13);
            lblAccion.Text = "Accion:";
            lblAccion.Location = new Point(20, 80);
            lblAccion.Size = new Size(43, 13);

            //Agregamos propiedades a los txt
            txtAccionR.Location = new Point(70, 80);
            txtAccionR.Size = new Size(100, 100);
            txtHoras.Location = new Point(70, 50);

            //Nombre del form y estilos
            form1.Text = "Acciones";
            form1.FormBorderStyle = FormBorderStyle.FixedDialog;
            form1.AcceptButton = btnOk;
            form1.CancelButton = btnCancel;
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Size = new System.Drawing.Size(380, 200);

            // Agregamos los controles al form
            form1.Controls.Add(btnOk);
            form1.Controls.Add(btnCancel);
            form1.Controls.Add(dtpFechaAccion);
            form1.Controls.Add(lblAccion);
            form1.Controls.Add(lblFecha);
            form1.Controls.Add(lblHoras);
            form1.Controls.Add(txtAccionR);
            form1.Controls.Add(txtHoras);

            // Abrimos como dialogo.
            form1.ShowDialog();

            fecha = String.Format("{0:yyyy/MM/dd}", dtpFechaAccion.Value);
            accionR = txtAccionR.Text;
            hora = txtHoras.Text;
            // Determina si se ha seleccionado el boton ok o cancelar
            if (form1.DialogResult == DialogResult.OK)
            {                
                //dataGridVAccionesAdd.Rows.Add(fecha, hora, accionR);
                txtAccionR.Text = "";
                txtHoras.Text = "";
                v_dvg = 1;
            }
            else
            {
                form1.Dispose();
            }
        }


        //****************************CREA EL DIALOG PARA AGREGAR LAS REFACCIONES
        public void DialogAddRefaccion()
        {
            Form form1 = new Form();
            Button btnOk = new Button();
            Button btnCancel = new Button();
            Label lblNumR = new Label();
            Label lblCantR = new Label();
            Label lblDescrip = new Label();
            TextBox txtNumR = new TextBox();
            TextBox txtCantR = new TextBox();
            TextBox txtDescrip = new TextBox();

            // Agremos texto y localizacion de ambos botones.
            btnOk.Text = "OK";
            btnOk.Location = new Point(280, 35);
            btnCancel.Text = "Cerrar";
            btnCancel.Location = new Point(btnOk.Left, btnCancel.Height + btnOk.Top + 10);            
            //damos valor del dialog a los botones
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;            
            //Agregamos propiedades al label
            lblNumR.Text = "Numero:";
            lblNumR.Location = new Point(20, 20);
            lblNumR.Size = new Size(60, 13);
            lblCantR.Text = "Cantidad:";
            lblCantR.Location = new Point(20, 50);
            lblCantR.Size = new Size(60, 13);
            lblDescrip.Text = "Descripción:";
            lblDescrip.Location = new Point(20, 80);
            lblDescrip.Size = new Size(70, 13);

            //Agregamos propiedades a los txt
            txtNumR.Location = new Point(100, 20);
            txtCantR.Location = new Point(100, 50);
            txtDescrip.Location = new Point(100, 80);

            //Nombre del form y estilos
            form1.Text = "Refacciones";
            form1.FormBorderStyle = FormBorderStyle.FixedDialog;
            form1.AcceptButton = btnOk;
            form1.CancelButton = btnCancel;
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Size = new System.Drawing.Size(380, 200);

            // Agregamos los controles al form
            form1.Controls.Add(btnOk);
            form1.Controls.Add(btnCancel);
            form1.Controls.Add(lblNumR);
            form1.Controls.Add(lblCantR);
            form1.Controls.Add(lblDescrip);
            form1.Controls.Add(txtNumR);
            form1.Controls.Add(txtCantR);
            form1.Controls.Add(txtDescrip);

            // Abrimos como dialogo.
            form1.ShowDialog();

            numR = txtNumR.Text;
            cantR = txtCantR.Text;
            refaccion = txtDescrip.Text;
            // Determina si se ha seleccionado el boton ok o cancelar
            if (form1.DialogResult == DialogResult.OK)
            {                
                //dataGridVRefacAdd.Rows.Add(numR, cantR, refaccion);
                v_dvg1 = 1;
            }
            else
            {
                form1.Dispose();
            }
        }
    }
}