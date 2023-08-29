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
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;

namespace ProyectoInolabServicio
{
    public partial class ActualizaDocument : MaterialForm
    {
        public ActualizaDocument(string FSR, int BD)
        {
            InitializeComponent();
            folio = FSR;
            tipoBD = BD;
        }

        //*******************VARIABLES
        string folio, archivo, carpeta, fAcuse, rutaAcuse;
        int IdResp, IdRespC, IdDocument, IdDocumentC, Idestatus, EstatusIni, sbd, v_dvg, tipoBD;
        int index_e, index_i;
        string tipo_f, tipoAcuse, comando, tipoFolioAcuse;
        string Comentarios, OtraIn, acuseGuia;
        string AcuseIni, AcuseCE1, AcuseCE2, AcuseCE3, AcuseCE4;

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }


        //**********Instancia de clase Consultas
        DataConsultas objConsultasBD = new DataConsultas();


        //********************CONEXION BD
        //SqlConnection con = new SqlConnection("Data Source=INOLABSERVER01;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");


        //********************GUARDA INFORMACION DE DOCUMENTACION DEPENDIENDO DEL FOLIO
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbEstatus.Text))
            {
                MessageBox.Show("El campo Estatus esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbDocumenta.Text))
            {
                MessageBox.Show("El campo Documentador esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(cmbResponsable.Text))
            {
                MessageBox.Show("El campo Responsable esta vacío", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }                        
            if(Idestatus == 12 || Idestatus == 13)
            {
                if (string.IsNullOrEmpty(txtGuiaA.Text))
                {
                    MessageBox.Show("El campo Folio Acuse o Guia de Envio esta vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (string.IsNullOrEmpty(lblAcuse1.Text))
                {
                    MessageBox.Show("No se ha Seleccionado el Archivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(Idestatus == 13)
                {
                    if(chkbAcusesC.Checked == false)
                    {
                        MessageBox.Show("No ha seleccionado el número de Corrección.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                int res = GuardaAcuse();
                if (res == 1)
                {
                    UpdateDocument();
                }
            }
                if (TestSpire.Usr.K == 40 || TestSpire.Usr.K == 35 || TestSpire.Usr.K == 76 || TestSpire.Usr.K == 33 || TestSpire.Usr.K == 36 || TestSpire.Usr.K == 62 || TestSpire.Usr.K == 88 || TestSpire.Usr.K == 1)
                {
                    if (EstatusIni == 14)
                    {
                        cmbEstatus.SelectedValue = Idestatus;
                    }
                    else if (index_e < index_i)
                    {
                        string motivo;
                        motivo = Interaction.InputBox("Motivo de Cambio a Estatus Anterior: ", "Motivo de Cambio", "", 500, 300);

                        motivo += " - Modificado: " + TestSpire.Usr.Nombre;

                        objConsultasBD.UpdateMotCambio(tipoBD, motivo, lblFolio.Text);
                        //MessageBox.Show(motivo);
                    }
                }
                UpdateDocument();
            
            button1.Enabled = false;
        }        
      
        private void lblRutaG_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_Click(object sender, EventArgs e)
        {

        }

        private void chkbAcusesC_CheckedChanged(object sender, EventArgs e)
        {
            if(chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 1")
            {
                tipoAcuse = "Acuse_CE1";
                tipoFolioAcuse = "FolioA_CE1";
                rdbFolioAcuse.Checked = true;
            }
            if(chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 2")
            {
                tipoAcuse = "Acuse_CE2";
                tipoFolioAcuse = "FolioA_CE2";
                rdbFolioAcuse.Checked = true;
            }
            if(chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 3")
            {
                tipoAcuse = "Acuse_CE3";
                tipoFolioAcuse = "FolioA_CE3";
                rdbFolioAcuse.Checked = true;
            }
            if(chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 4")
            {
                tipoAcuse = "Acuse_CE4";
                tipoFolioAcuse = "FolioA_CE4";
                rdbFolioAcuse.Checked = true;
            }
            if (chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 5")
            {
                tipoAcuse = "Acuse_CE5";
                tipoFolioAcuse = "FolioA_CE5";
                rdbFolioAcuse.Checked = true;
            }
            if(chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 6")
            {
                tipoAcuse = "Acuse_CE6";
                tipoFolioAcuse = "FolioA_CE6";
                rdbFolioAcuse.Checked = true;
            }
            if(chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 7")
            {
                tipoAcuse = "Acuse_CE7";
                tipoFolioAcuse = "FolioA_CE7";
                rdbFolioAcuse.Checked = true;
            }
            if(chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 8")
            {
                tipoAcuse = "Acuse_CE8";
                tipoFolioAcuse = "FolioA_CE8";
                rdbFolioAcuse.Checked = true;
            }
            if(chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 9")
            {
                tipoAcuse = "Acuse_CE9";
                tipoFolioAcuse = "FolioA_CE9";
                rdbFolioAcuse.Checked = true;
            }
            if(chkbAcusesC.Checked && chkbAcusesC.Text == "Acuse Corrección 10")
            {
                tipoAcuse = "Acuse_CE10";
                tipoFolioAcuse = "FolioA_CE10";
                rdbFolioAcuse.Checked = true;
            }
            if (chkbAcusesC.Checked == false)
            {
                rdbFolioAcuse.Checked = false;
            }
            
        }

        private void rdbFolioAcuse_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFolioAcuse.Checked)
            {
                txtGuiaA.Visible = true;
            }
            else
            {
                txtGuiaA.Visible = false;
            }
        }

        private void rdbGuiaEnvio_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGuiaEnvio.Checked)
            {
                txtGuiaA.Visible = true;
                tipoFolioAcuse = "fAcuse_guia";
            }
            else
            {
                txtGuiaA.Visible = false;
            }
        }



        //****************ASIGNA ID DE DOCUMENTADOR DEPENDIENDO DE SELECCION
        private void cmbDocumenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdDocument = Convert.ToInt32(cmbDocumenta.SelectedValue);
            //MessageBox.Show("Documentador " + IdDocument);            
        }


        //********************ASIGNA ID DE RESPONSABLE DEPENDIENDO DE SELECCION
        private void cmbResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {
            IdResp = Convert.ToInt32(cmbResponsable.SelectedValue);
            //MessageBox.Show("Responsable " + IdResp);
        }


        //*****************AGREGA LA INCIDENCIA SELECCIONADA A GRID 
        private void cmbIncidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Id;
            v_dvg = 1;
            advancedDataGridView1.Rows.Add(cmbIncidencia.SelectedValue, cmbIncidencia.Text);

            Id = cmbIncidencia.SelectedIndex;            

            if (Id == 14)
            {
                txtOtro.Visible = true;
                lblOtro.Visible = true;
            }
        }


        //*****************ASIGNA EL ID DE ESTATUS DEPENDIENDO DE SELECCION
        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            index_e = Convert.ToInt32(cmbEstatus.SelectedIndex) + 1;
            Idestatus = Convert.ToInt32(cmbEstatus.SelectedValue);

            if(index_e == 1)
            {
                tipo_f = "F_SinAsignar";
            }
            if(index_e == 2)
            {
                tipo_f = "F_SinResult";
            }
            if(index_e == 3)
            {
                tipo_f = "F_RIncompleto";
            }
            if(index_e == 4)
            {
                tipo_f = "F_Resultado";
            }
            if(index_e == 5)
            {
                tipo_f = "F_Realizando";
            }
            if(index_e == 6)
            {
                tipo_f = "F_Revision";
            }
            if(index_e == 7)
            {
                tipo_f = "F_CorrecInterna";
            }
            if(index_e == 8)
            {
                tipo_f = "F_PendienteF";
            }
            if(index_e == 9)
            {
                tipo_f = "F_Firmado";
            }
            if(index_e == 10)
            {
                tipo_f = "F_Liberado";
            }
            if(index_e == 11)
            {
                tipo_f = "F_CorrecExtern";
            }
            if(index_e == 12)
            {
                tipo_f = "F_Cancelado";
            }
           
                //if (Idestatus == 6)
                //{
                //    tipo_f = "F_Realizando";
                //}
                //if (Idestatus == 7)                
                //{
                //    tipo_f = "F_Resultado";
                //}
                //if (Idestatus == 8)
                //{
                //    tipo_f = "F_Revision";
                //}
                //if (Idestatus == 9)
                //{
                //    tipo_f = "F_CorrecInterna";
                //}
                //if (Idestatus == 10)
                //{
                //    tipo_f = "F_PendienteF";
                //}
                //if (Idestatus == 11)
                //{
                //    tipo_f = "F_Firmado";
                //}
                //if(Idestatus == 14)
                //{
                //    tipo_f = "F_SinAsignar";
                //}
                //if(Idestatus == 5)
                //{
                //    tipo_f = "F_Cancelado";
                //}
                //***ACTIVA LA OPCION DE SUBIR ACUSE EN ESTATUS FINALES
                if (Idestatus == 12 || Idestatus == 13)
            {
                btnArchivo.Visible = true;
                lblAcuse.Visible = true;
                rdbGuiaEnvio.Visible = true;
                rdbFolioAcuse.Visible = true;
                lblLeyendaA.Visible = true;
                lblAcusesSave.Visible = true;
                lblAcusesAnt.Visible = true;
                lblAcusesAnt2.Visible = true;
                lblGuiasSave.Visible = true;
                lblGuiasAnt.Visible = true;
                //txtGuiaA.Visible = true;

                if (Idestatus == 12)
                {
                    tipo_f = "F_Liberado";
                    lblAcuseCE.Visible = false;
                    chkbAcusesC.Visible = false;
                    tipoFolioAcuse = "FolioA_Inicial";
                    tipoAcuse = "AcuseInicial";
                }
                if (Idestatus == 13)
                {
                    tipo_f = "F_CorrecExtern";
                    lblAcuseCE.Visible = true;
                    chkbAcusesC.Visible = true;
                }
            }
            else
            {
                btnArchivo.Visible = false;
                lblAcuse.Visible = false;
                lblAcuseCE.Visible = false;
                chkbAcusesC.Visible = false;
                rdbFolioAcuse.Visible = false;
                rdbGuiaEnvio.Visible = false;
                txtGuiaA.Visible = false;
                lblLeyendaA.Visible = false;
                lblAcusesSave.Visible = false;
                lblAcusesAnt.Visible = false;
                lblGuiasAnt.Visible = false;
                lblGuiasSave.Visible = false;
            }


            if (TestSpire.Usr.K != 40 && TestSpire.Usr.K != 35 && TestSpire.Usr.K != 76 && TestSpire.Usr.K != 33 && TestSpire.Usr.K != 36 && TestSpire.Usr.K != 62 && TestSpire.Usr.K != 88)
            {
                //MessageBox.Show("Entro");
                if(index_i == 1)
                {
                    cmbEstatus.SelectedValue = Idestatus;
                }
                else if(index_e < index_i)
                {
                    MessageBox.Show("No puedes cambiar a un Estatus Aterior", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbEstatus.SelectedValue = EstatusIni;
                }
            }
        }

        

        private void ActualizaDocument_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Tipo_Servicio' Puede moverla o quitarla según sea necesario.
            this.tipo_ServicioTableAdapter.Fill(this.browserDataSet.Tipo_Servicio);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter.Fill(this.browserDataSet.Usuarios);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Incidencias' Puede moverla o quitarla según sea necesario.
            this.incidenciasTableAdapter.Fill(this.browserDataSet.Incidencias);

            CargaCombos();
            CargarDatos();
            
            MuestraIncidencia();

            if(TestSpire.Usr.K == 37 || TestSpire.Usr.K == 85 || TestSpire.Usr.K == 75 || TestSpire.Usr.K == 101 || TestSpire.Usr.K == 104 || TestSpire.Usr.K == 107 
                || TestSpire.Usr.K == 108 || TestSpire.Usr.K == 128 || TestSpire.Usr.K == 129 || TestSpire.Usr.K == 130)
            {
                cmbResponsable.Enabled = false;
                cmbDocumenta.Enabled = false;
            }
            if(TestSpire.Usr.K == 104)
            {
                button1.Enabled = false;
            }
        }

        
        
        //******************ABRE LA VENTANA DE CARPETAS PARA SELECCIONAR EL ACUSE REQUERIDO
        private void btnArchivo_Click(object sender, EventArgs e)
        {
            try
            {
                //da parametros de busqueda al abrir el file dialog
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Archivos de texto (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*";
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    archivo = openFileDialog1.FileName;
                    lblRutaG.Text = archivo;
                    lblAcuse1.Text = Path.GetFileName(openFileDialog1.FileName);
                    fAcuse = lblFolio.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar el archivo: " + ex.ToString());
            }            
        }


        //*****************GUARDA EL ACUSE EN EL SERVIDOR, CREA LA RUTA Y ASIGNA NOMBRE
        private int GuardaAcuse()
        {
            try
            {
                //genera la ruta para guardar el archivo
                carpeta = Path.Combine(Application.StartupPath, String.Format(@"\\INOLABSERVER01\Desarrollo\Acuses Documentacion\F-" + folio + tipoAcuse + ".pdf", Path.GetFileName(openFileDialog1.FileName)));
                //copia el archivo a la nueva carpeta
                File.Copy(openFileDialog1.FileName, carpeta);

                MessageBox.Show("Documento guardado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                rutaAcuse = @"\\INOLABSERVER01\Desarrollo\Acuses Documentacion\F-" + folio + tipoAcuse + ".pdf";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un problema al guardar el archivo " + ex.ToString());
                return 0;
            }
        }


        //******************GUARDA LA INFORMACION DEL FOLIO Y ASIGNA TIPO DE FECHA A GUARDAR
        private void UpdateDocument()
        {
            //MessageBox.Show("Folio " + tipoFolioAcuse + ", Tipo " + tipoAcuse);
            int result;
            Comentarios = Comentarios + " " + txtComentarios.Text;
            OtraIn = OtraIn + " " + txtOtro.Text;

            try
            {
                result = objConsultasBD.UpdateDocumentacion(tipoBD, Idestatus, IdResp, IdDocument, tipo_f, TestSpire.Usr.User, Comentarios, OtraIn, folio);

                if (result == 1)
                {
                    if (IdDocumentC != IdDocument)
                    {
                        int rs = objConsultasBD.UpdateFechaDocument(tipoBD, folio);
                    }

                    for (int i = 0; i < advancedDataGridView1.Rows.Count; i++)
                    {
                        if (advancedDataGridView1.Rows != null && advancedDataGridView1.Rows.Count != 0)
                        {
                            SaveIncidencia();
                        }
                    }

                    VerificaFechas();
                    
                    if(Idestatus == 12 || Idestatus == 13)
                    {
                        saveDatosAcuse();
                    }
                    MessageBox.Show("Se han actualizado los datos del Folio " + lblFolio.Text + " correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void saveDatosAcuse()
        {
            int resulta;
            try
            {
                resulta = objConsultasBD.UpdateDocFolioAcuse(tipoBD, tipoAcuse, rutaAcuse, tipoFolioAcuse, txtGuiaA.Text, folio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //******************CARGA LOS DATOS DEL FOLIO
        public void CargarDatos()
        {
            SqlDataReader leer;
            leer = objConsultasBD.setDatosFolioDoc(tipoBD, folio);
            if (leer.Read())
            {
                lblFolio.Text = Convert.ToString(leer["FolioFSR"]);
                txtCliente.Text = Convert.ToString(leer["Cliente"]);
                txtEquipo.Text = Convert.ToString(leer["Equipo"]);
                txtMarca.Text = Convert.ToString(leer["Marca"]);
                txtModelo.Text = Convert.ToString(leer["Modelo"]);
                txtNoSerie.Text = Convert.ToString(leer["NoSerie"]);
                txtAsesor.Text = Convert.ToString(leer["AsesorV"]);
                dtpfechaServicio.Text = Convert.ToString(leer["FechaServicio"]);
                cmbIngeniero.SelectedValue = Convert.ToInt32(leer["IdIngeniero"]);
                cmbTServicio.SelectedValue = Convert.ToInt32(leer["IdT_Servicio"]);
                OtraIn = Convert.ToString(leer["OtraIncidencia"]);
                
                //verificamos que el dato en Responsable no sea nulo
                if (leer.IsDBNull(15))
                {
                    cmbResponsable.Text = null;
                }
                else
                {                     
                    IdRespC = Convert.ToInt32(leer["IdResponsable"]);
                    cmbResponsable.SelectedValue = IdRespC;
                }

                //asignamos index a combo con id de usuario documentador
                if (leer.IsDBNull(17))
                {
                    cmbDocumenta.SelectedText = null;
                }
                else
                {
                    IdDocumentC = Convert.ToInt32(leer["IdDocumentador"]);
                    cmbDocumenta.SelectedValue = IdDocumentC;
                }
                
                //valoramos si existe un documento adjuntado a acuse
                if (leer.IsDBNull(31))
                {
                    chkbAcusesC.Text = "Acuse Corrección 1";
                }
                else if (leer.IsDBNull(32))
                {
                    chkbAcusesC.Text = "Acuse Corrección 2";
                }
                else if (leer.IsDBNull(33))
                {
                    chkbAcusesC.Text = "Acuse Corrección 3";
                }
                else if (leer.IsDBNull(34))
                {
                    chkbAcusesC.Text = "Acuse Corrección 4";
                }
                else if (leer.IsDBNull(56))
                {
                    chkbAcusesC.Text = "Acuse Corrección 5";
                }
                else if (leer.IsDBNull(57))
                {
                    chkbAcusesC.Text = "Acuse Corrección 6";
                }
                else if (leer.IsDBNull(58))
                {
                    chkbAcusesC.Text = "Acuse Corrección 7";
                }
                else if (leer.IsDBNull(59))
                {
                    chkbAcusesC.Text = "Acuse Corrección 8";
                }
                else if (leer.IsDBNull(60))
                {
                    chkbAcusesC.Text = "Acuse Corrección 9";
                }
                else if (leer.IsDBNull(61))
                {
                    chkbAcusesC.Text = "Acuse Corrección 10";
                }
                else
                {
                    chkbAcusesC.Text = "Acuse Corrección 10";
                    chkbAcusesC.Enabled = false;
                    chkbAcusesC.Checked = true;
                }

                if (leer.IsDBNull(35))
                {
                    Comentarios = "";
                }
                else
                {
                    Comentarios = leer["Comentarios"].ToString();
                }

                //txtGuiaA.Text = Convert.ToString(leer["fAcuse_guia"]);
                lblAcusesAnt.Text = leer["FolioA_Inicial"].ToString() + ", " + leer["FolioA_CE1"].ToString() + ", " + leer["FolioA_CE2"].ToString() + ", " +
                     leer["FolioA_CE3"].ToString() + ", " + leer["FolioA_CE4"].ToString() + ", " + leer["FolioA_CE5"].ToString() + ", ";
                lblAcusesAnt2.Text = leer["FolioA_CE6"].ToString() + ", " + leer["FolioA_CE7"] + ", " +
                     leer["FolioA_CE8"].ToString() + ", " + leer["FolioA_CE9"].ToString() + ", " + leer["FolioA_CE10"].ToString();

                lblGuiasAnt.Text = leer["fAcuse_guia"].ToString();

                EstatusIni = Convert.ToInt32(leer["IdEstatus"]);
                cmbEstatus.SelectedValue = EstatusIni;
                index_i = cmbEstatus.SelectedIndex + 1;
                //if (EstatusIni == 5)
                //{
                //    button1.Enabled = false;
                //}
            }
        }
        

        //********************CARGA LOS ITEMS PARA LOS COMBO BOX
        /*Verificar que a los usuarios administrativos les permita cambiar a sin asignar
         cambiar la manera en que se comparan los estatus para no generar tantas operaciones*/
        public void CargaCombos()
        {
            cmbEstatus.DisplayMember = "Text";
            cmbEstatus.ValueMember = "Value";

            var items = new[]
                {
                    new{ Text = "Sin Asignar", Value = 14 },
                    new { Text = "Sin Resultados", Value = 19},
                    new { Text = "Resultados Incompletos", Value = 18},
                    new { Text = "Resultados Completos", Value = 7 },
                    new { Text = "Realizando", Value = 6 },
                    new { Text = "Revision", Value = 8 },
                    new { Text = "Correccion Interna", Value = 9 },
                    new { Text = "Pendiente de Firma", Value = 10 },
                    new { Text = "Firmado", Value = 11 },
                    new { Text = "Liberado", Value = 12 },
                    new { Text = "Correcciones Externas", Value = 13 },
                    new { Text = "Cancelado", Value = 5 }
                };
            cmbEstatus.DataSource = items;

            cmbDocumenta.DisplayMember = "Text";
            cmbDocumenta.ValueMember = "Value";

            

            var itemsD = new[]
            {
                new { Text = "Alejandra Gutierrez", Value = 36 },
                new { Text = "Alicia Ruiz", Value = 107 },
                new { Text = "Alizbeth Segura", Value = 22 },
                new { Text = "Andrea Miranda", Value = 132 },
                new { Text = "Brenda Pacheco", Value = 128 },
                new { Text = "Carmen Patiño", Value = 33},
                new { Text = "Cesar Leal", Value = 75},
                new { Text = "Cinthia Martinez", Value = 85 },
                new { Text = "Cinthia Torres", Value = 62 },
                new { Text = "Cynthia Lopez", Value = 76},
                new { Text = "Edgar Aguilar", Value = 37 },
                new { Text = "Fernanda Rodriguez", Value = 45},
                new { Text = "Iskra Cruz", Value = 40},
                new { Text = "Jennifer Velasco", Value = 106},
                new { Text = "Jessica Nieto", Value = 108},
                new { Text = "Josue Gomez", Value = 129 },
                new { Text = "Judith Tamayo", Value = 104},
                new { Text = "Lorena Reyes", Value = 35 },
                new { Text = "Marco Galicia", Value = 130},
                new { Text = "Monica Pichardo", Value = 72 },
                new { Text = "Patricia Rodriguez", Value = 101},
                new { Text = "Regina Siordia", Value = 137},
                new { Text = "Rosario Martinez", Value = 34},
            };
            cmbDocumenta.DataSource = itemsD;

            cmbResponsable.DisplayMember = "Text";
            cmbResponsable.ValueMember = "Value";

            var itemsR = new[]
            {
                new { Text = "Alizbeth Segura", Value = 22 },
                new { Text = "Iskra Cruz", Value = 40 },
                new { Text = "Lorena Reyes", Value = 35 }
            };
            cmbResponsable.DataSource = itemsR;

        }

        //***************CARGA LAS INCIDENCIAS  EN EL GRID
        public void MuestraIncidencia()
        {
            try
            {
                SqlDataReader leer;
                leer = objConsultasBD.setIncidenciasDoc(tipoBD, folio);

                while (leer.Read())
                {
                    txtAntInci.Text += Convert.ToString(leer["DescripcionI"]) + Environment.NewLine;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }


        //*******************GUARDA LAS INSIDENCIAS QUe SE ENCUENTRAN EN EL GRID
        public void SaveIncidencia()
        {
            int result;
            for (int i = 0; i < advancedDataGridView1.Rows.Count; i++)
            {
                try
                {
                    result = objConsultasBD.SaveIncidenciaDoc(tipoBD, advancedDataGridView1.Rows[i].Cells["TipoIncidencia"].Value.ToString(), Convert.ToInt32(advancedDataGridView1.Rows[i].Cells["IdIncidencia"].Value), lblFolio.Text);                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        public void VerificaFechas()
        {
            int r;
            try
            {
                //if (EstatusIni == 14 && EstatusIni != Idestatus)
                //{
                //    EstatusIni = 5;
                //}
                //if(EstatusIni == Idestatus)
                //{
                //    EstatusIni -= 1;
                //}

                int diferencia = index_e - index_i;
                int suma = index_i + diferencia;

                if (index_e == 12 && index_e != index_i)
                {
                    r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Cancelado", lblFolio.Text);
                }
                else if (index_e > index_i)
                {
                    for(int i = 1; i <= diferencia; i++)
                    {
                        index_i++;

                        if (index_i == 1)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_SinAsignar", lblFolio.Text);
                        }
                        else if(index_i == 2)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_SinResult", lblFolio.Text);
                        }
                        else if(index_i == 3)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_RIncompleto", lblFolio.Text);
                        }
                        else if(index_i == 4)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Resultado", lblFolio.Text);
                        }
                        else if(index_i == 5)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Realizando", lblFolio.Text);
                        }
                        else if(index_i == 6)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Revision", lblFolio.Text);
                        }
                        else if(index_i == 7)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_CorrecInterna", lblFolio.Text);
                        }
                        else if(index_i == 8)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_PendienteF", lblFolio.Text);
                        }
                        else if(index_i == 9)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Firmado", lblFolio.Text);
                        }
                        else if(index_i == 10)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Liberado", lblFolio.Text);
                        }
                        else if(index_i == 11)
                        {
                            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_CorrecExtern", lblFolio.Text);
                        }
                        
                    }                    
                }
                


                //int diferencia = Idestatus - EstatusIni;
                //int suma = EstatusIni + diferencia;

                //if (Idestatus > EstatusIni)
                //{
                //    for (int i = 1; i <= diferencia; i++)
                //    {
                //        EstatusIni++;

                //        if(EstatusIni == 14)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_SinAsignar", lblFolio.Text);
                //            //MessageBox.Show("F_SinAsignar");
                //        }
                //        else if(EstatusIni == 5)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Cancelado", lblFolio.Text);
                //            //MessageBox.Show("Cancelado");
                //        }
                //        else if (EstatusIni == 6)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Realizando", lblFolio.Text);
                //            //MessageBox.Show("F_Realizando");
                //        }
                //        else if (EstatusIni == 7)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Resultado", lblFolio.Text);
                //            //MessageBox.Show("F_Resultados");
                //        }
                //        else if (EstatusIni == 8)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Revision", lblFolio.Text);
                //            //MessageBox.Show("F_Revision");
                //        }
                //        else if (EstatusIni == 9)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_CorrecInterna", lblFolio.Text);
                //            //MessageBox.Show("F_CorrecInterna");
                //        }
                //        else if (EstatusIni == 10)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_PendienteF", lblFolio.Text);
                //            //MessageBox.Show("F_PendienteF");
                //        }
                //        else if (EstatusIni == 11)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Firmado", lblFolio.Text);
                //            //MessageBox.Show("F_Firmado");
                //        }
                //        else if (EstatusIni == 12)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Liberado", lblFolio.Text);
                //            //MessageBox.Show("F_Liberado");
                //        }
                //        else if (EstatusIni == 13)
                //        {
                //            r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_CorrecExtern", lblFolio.Text);
                //            //MessageBox.Show("F_CorrecExterna");
                //        }
                //    }
                //}                
                //else if (Idestatus == 5 && Idestatus != EstatusIni)
                //{
                //    r = objConsultasBD.UpdateFechasAnteriores(tipoBD, "F_Cancelado", lblFolio.Text);
                //}                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
