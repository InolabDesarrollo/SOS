using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO.Compression;
using Microsoft.VisualBasic;

namespace ProyectoInolabServicio
{
    public partial class RegistrosDocumentacion : MaterialForm
    {
        public RegistrosDocumentacion(int BD)
        {
            InitializeComponent();
            DoubleBuffered(advancedDataGridView1, true);
            tipoBD = BD;
        }

        //******************VARIABLES
        string folio;
        int Index, tipoBD, areaE;
        string userArea, fechaIni, fechaFin;


        //********************INSTANCIA PARA DATA CONSULTAS
        DataConsultas objConsultasBD = new DataConsultas();


        //******************CARGA EL GRID DE REGISTROS DEPENDIENDO DEL TIPO DE USUARIO
        private void RegistrosDocumentacion_Load(object sender, EventArgs e)
        {
            if (TestSpire.Usr.K == 33 || TestSpire.Usr.K == 36 || TestSpire.Usr.K == 37 || TestSpire.Usr.K == 62 || TestSpire.Usr.K == 76 || TestSpire.Usr.K == 75
                || TestSpire.Usr.K == 85 || TestSpire.Usr.K == 101 || TestSpire.Usr.K == 107 || TestSpire.Usr.K == 108 || TestSpire.Usr.K == 128 || TestSpire.Usr.K == 129 ||
                TestSpire.Usr.K == 72 || TestSpire.Usr.K == 45 || TestSpire.Usr.K == 41 || TestSpire.Usr.K == 105 || TestSpire.Usr.K == 112 || TestSpire.Usr.K == 132 || TestSpire.Usr.K == 130 || TestSpire.Usr.K == 137)
            {
                AccesosArea();
                
            }
            else
            {
                filtrarPorToolStripMenuItem.Visible = true;
                rangoDeFechaToolStripMenuItem.Visible = true;
                try
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getRegistrosDocumentacion(tipoBD);
                    lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (TestSpire.Usr.K == 136 || TestSpire.Usr.K == 88)
            {
                editarFSRToolStripMenuItem.Visible = true;
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



        //*******************ASIGNA COLOR A LA CENDA DEPENDIENDO DEL ESTATUS EN EL QUE SE ENCUENTRE
        private void advancedDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs a)
        {
            //Da color a la celda Estado dependiendo del estatus de los folios
            if (a.Value != null)
            {
                //CAMBIAR VALORES PARA SWITCH
                switch (a.Value.ToString())
                {
                    //case "Realizando":
                    //    a.CellStyle.BackColor = Color.Aquamarine;
                    //    break;
                    case "Sin Asignar_D":
                        a.CellStyle.BackColor = Color.FromArgb(247, 238, 101);
                        break;
                    case "Sin Resultados":
                        a.CellStyle.BackColor = Color.FromArgb(84, 90, 247);
                        break;
                    case "Resultados Incompletos":
                        a.CellStyle.BackColor = Color.FromArgb(64, 124, 245);
                        break;
                    case "Resultados Completos":
                        a.CellStyle.BackColor = Color.FromArgb(64, 170, 245);
                        break;
                    case "Realizando":
                        a.CellStyle.BackColor = Color.FromArgb(64, 224, 245);
                        break;
                    case "Revision":
                        a.CellStyle.BackColor = Color.FromArgb(135, 167, 222);
                        break;
                    case "Correccion interna":
                        a.CellStyle.BackColor = Color.FromArgb(247, 135, 74);
                        break;
                    case "Pendiente de firma":
                        a.CellStyle.BackColor = Color.Pink;
                        break;
                    case "Firmado":
                        a.CellStyle.BackColor = Color.MediumPurple;
                        break;
                    case "Liberado":
                        a.CellStyle.BackColor = Color.LightGreen;
                        break;
                    case "Correcciones externas":
                        a.CellStyle.BackColor = Color.FromArgb(247, 99, 99);
                        break;
                    case "Cancelado":
                        a.CellStyle.BackColor = Color.FromArgb(176, 174, 174);
                        break;
                }


                if (a.Value.GetType() != typeof(System.DBNull))
                {
                    if (advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE1"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(175, 235, 169);//VERDE
                    }
                    if(advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE2"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(173, 217, 240);//AZUL
                    }
                    if (advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE3"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(247, 240, 139);//AMARILLO
                    }
                    if (advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE4"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(201, 176, 247);//morado
                    }
                    if (advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE5"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(184, 151, 125);//cafe
                    }
                    if (advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE6"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(156, 214, 193);//aqua
                    }
                    if (advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE7"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(220, 247, 161); //lima
                    }
                    if (advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE8"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(255, 189, 238);//rosa
                    }
                    if (advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE9"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(250, 175, 125);//naranja
                    }
                    if (advancedDataGridView1.Rows[a.RowIndex].Cells["Acuse_CE10"].Value.ToString() != "0" && advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCorrecExterna")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(247, 136, 136);//Rojo
                    }
                }
            }
        }


        //*****************ABRE EL FORM CORRESPONDIENTE PARA ACTUALIZAR EL FOLIO
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dvg = advancedDataGridView1.Rows[e.RowIndex];
            folio = dvg.Cells[1].Value.ToString();

            ActualizaDocument frm = new ActualizaDocument(folio, tipoBD);
            frm.Show();
        }


        //*******************ABRE FORM QUE CONTIENE EL FSR DEL FOLIO CON CLIC SECUNDARIO
        private void verFSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folio = advancedDataGridView1.Rows[Index].Cells[1].Value.ToString();
            ReporteFolio frm = new ReporteFolio(folio);
            frm.Show();
        }


        //********************DETERMINA LA POSICION DEL MOUSE PARA MOSTRAR MENU SECUNDARIO, CLIC DERECHO
        private void advancedDataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.advancedDataGridView1.Rows[e.RowIndex].Selected = true;
                this.Index = e.RowIndex;
                this.advancedDataGridView1.CurrentCell = this.advancedDataGridView1.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.advancedDataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }


        //***************NUMERA LAS FILAS DEL GRID
        private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(advancedDataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
            }
        }

        private void TcmbFiltroMes_Click(object sender, EventArgs e)
        {

        }


        //******************** ABRE LA VENTANA PARA EL LISTADO DE ACUSES
        private void listaDeAcusesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroAcuses ra = new RegistroAcuses(tipoBD);
            ra.Show();
        }
        

        //******************MUESTRA LOS REGISTROS POR MES SELECCIONADO
        private void TcmbFiltroMes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int mes = TcmbFiltroMes.SelectedIndex + 1;

            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getRegistrosMesD(tipoBD, mes);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //******************************** CUENTA LOS REGISTROS SI HAY ALGUN FILTRO ESTABLECIDO
        private void advancedDataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(string.IsNullOrEmpty(advancedDataGridView1.FilterString) == false)
            {
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            else
            {
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
        }


        //********************* DESCARGA LA EVIDENCIA DEL INGENIERO QUE SE ENCUENTRA EN EL SERVIDOR
        private void descargarEvidenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                folio = advancedDataGridView1.Rows[Index].Cells["gridTxtFolio"].Value.ToString();

                string userFolder = Environment.UserName;

                string pathOrigen = @"\\INOLABSERVER01\Imagenes\" + folio;
                string pathSave = @"C:\Users\" + userFolder + @"\Downloads\" + folio + ".zip";
                //@"\\INOLABSERVER01\Imagenes\prueba.zip";

                ZipFile.CreateFromDirectory(pathOrigen, pathSave);

                MessageBox.Show("Archivo Guardado en Descargas");
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha encontrado la evidencia", "ERROR DE DESCARGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        //****************************** ABRE VENTANA PARA CREAR UN ACUSE DIGITAL
        private void generarAcuseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AcuseDocumentacion acuse = new AcuseDocumentacion(tipoBD);
            acuse.Show();
        }

        
        //*************************** ABRE EL ACUSE ADJUNTO, SI ESTE EXISTE
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow dvg = advancedDataGridView1.Rows[e.RowIndex];
            folio = dvg.Cells[1].Value.ToString();

            if (e.ColumnIndex >= 0 && advancedDataGridView1.Columns[e.ColumnIndex].Name == "AcusePDF" && e.RowIndex >= 0)
            {
                TbVerAcuses tb = new TbVerAcuses(tipoBD, folio, 2);
                tb.ShowDialog();              
            }


            if (e.ColumnIndex >= 0 && advancedDataGridView1.Columns[e.ColumnIndex].Name == "AcuseDigital" && e.RowIndex >= 0)
            {    
                TbVerAcuses tb = new TbVerAcuses(tipoBD, folio, 1);
                tb.ShowDialog();
            }            
        }

        private void editarFSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string respuesta;
            //ActualizaFSR actuliza = new ActualizaFSR(,tipoBD);
            respuesta = Interaction.InputBox("Folio a Editar: ", "Edición", "", 500, 300);

            if (String.IsNullOrEmpty(respuesta))
            {
                MessageBox.Show("Es Necesario Colocar un FSR", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string id = objConsultasBD.getIdFolio(tipoBD, respuesta);
                if (String.IsNullOrEmpty(id))
                {
                    MessageBox.Show("El folio no se Encuentra Finalizado. favor de Verificarlo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ActualizaFSR frm = new ActualizaFSR(id, tipoBD);
                    frm.Show();
                }
            }
        }

        private void rangoDeFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if(TestSpire.Usr.K == 91 || TestSpire.Usr.K == 1 || TestSpire.Usr.K == 71 || TestSpire.Usr.K == 8 || TestSpire.Usr.K == 88)
            //{
            //    rangoDeFechaToolStripMenuItem.Visible = true;

            //}
            //else
            //{
            //    rangoDeFechaToolStripMenuItem.Visible = false;
            //}
            formFiltroFechas();
        }


        //********************CARGA TODOS LOS REGISTROS DE DOCUMENTACION
        private void todosLosRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getRegistrosDocumentacion(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   
        

        public void AccesosArea()
        {           
            if(TestSpire.Usr.K == 62) //Cinthia Torres
            {
                areaE = 1;
                userArea = "62, 85, 107";
            }
            else if(TestSpire.Usr.K == 36) //Alejandra
            {
                areaE = 1;
                userArea = "36, 37, 75, 132, 101";
            }
            else if(TestSpire.Usr.K == 33 || TestSpire.Usr.K == 76) //Rosario, Carmen
            {
                areaE = 1;
                userArea = "33, 34, 76, 108, 128, 129, 130";
            }
            else
            {
                areaE = 2;
                userArea = TestSpire.Usr.K.ToString();
            }

            try
            {
                if(areaE == 1)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getRegistrosUsuarioDoc(tipoBD, userArea, 1);
                    lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
                }
                if(areaE == 2)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getRegistrosUsuarioDoc(tipoBD, userArea, 2);
                    lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void formFiltroFechas()
        {
            Form form1 = new Form();
            Button btnOk = new Button();
            Button btnCancel = new Button();
            DateTimePicker dtpF_ini = new DateTimePicker();
            DateTimePicker dtpF_Fin = new DateTimePicker();
            Label lblFI = new Label();
            Label lblFF = new Label();

            // Agremos texto y localizacion de ambos botones.
            btnOk.Text = "OK";
            btnOk.Location = new Point(204, 20);
            btnCancel.Text = "Cancelar";
            btnCancel.Location = new Point(btnOk.Left, btnCancel.Height + btnOk.Top + 10);


            //damos valor del dialog a los botones
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            //Agregamos propiedades al picket            
            dtpF_ini.Format = DateTimePickerFormat.Custom;
            dtpF_ini.CustomFormat = "yyyy-MM-dd";
            dtpF_ini.Size = new System.Drawing.Size(94, 19);
            dtpF_ini.Location = new Point(100, 20);
            //Agregamos propiedades al picket           
            dtpF_Fin.Format = DateTimePickerFormat.Custom;
            dtpF_Fin.CustomFormat = "yyyy-MM-dd";
            dtpF_Fin.Size = new System.Drawing.Size(94, 19);
            dtpF_Fin.Location = new Point(100, 55);
            //Agregamos propiedades al label
            lblFI.Text = "Fecha inicio: ";
            lblFI.Location = new Point(20, 20);
            lblFF.Text = "Fecha fin: ";
            lblFF.Location = new Point(20, 55);

            //Nombre del form y estilos
            form1.Text = "Filtro de Fechas";
            form1.FormBorderStyle = FormBorderStyle.FixedDialog;
            form1.AcceptButton = btnOk;
            form1.CancelButton = btnCancel;
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.Size = new System.Drawing.Size(380, 160);

            // Agregamos los controles al form
            form1.Controls.Add(btnOk);
            form1.Controls.Add(btnCancel);
            form1.Controls.Add(dtpF_ini);
            form1.Controls.Add(dtpF_Fin);
            form1.Controls.Add(lblFI);
            form1.Controls.Add(lblFF);
            // Abrimos como dialogo.
            form1.ShowDialog();

            // Determina si se ha seleccionado el boton ok o cancelar
            if (form1.DialogResult == DialogResult.OK)
            {
                fechaIni = String.Format("{0:yyyy/MM/dd}", dtpF_ini.Value);
                fechaFin = String.Format("{0:yyyy/MM/dd}", dtpF_Fin.Value);

                try
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getRegistrosRangoDocumentacion(tipoBD, fechaIni, fechaFin);
                    lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                form1.Dispose();
            }
            else
            {
                form1.Dispose();
            }
        }
    }
}
