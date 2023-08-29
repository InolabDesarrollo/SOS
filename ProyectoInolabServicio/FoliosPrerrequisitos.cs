using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using System.Diagnostics;

namespace ProyectoInolabServicio
{
    public partial class FoliosPrerrequisitos : MaterialForm
    {
        public FoliosPrerrequisitos(int BD)
        {
            InitializeComponent();
            DoubleBuffered(advancedDataGridView1, true);
            tipoBD = BD;
        }


        //****************VARIABLES
        int Index, idActividad, tipoBD;
        string F_Envio;
        DateTime fechaE;
        string archivo, carpeta, rutaPDF, rutaPrerreq;
        int existe;


        //***********INSTANCIA DE LA CLASE CONSULTAS
        DataConsultas ObjConsultasBD = new DataConsultas();


        //**********OBTIENE EL NOMBRE DE EQUIPO DEL USUARIO
        string name = System.Net.Dns.GetHostName();


        private void FoliosPrerrequisitos_Load(object sender, EventArgs e)
        {
            try
            {
                if (TestSpire.Usr.K == 79 || TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = ObjConsultasBD.getPrerrequisitosEnviado(tipoBD);
                }
                else
                {
                    // TODO: esta línea de código carga datos en la tabla 'browserDataSet.V_Prerrequisitos' Puede moverla o quitarla según sea necesario.
                    this.v_PrerrequisitosTableAdapter1.Fill(this.browserDataSet.V_Prerrequisitos);
                    lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
                }                
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


        //********************COLOREA LAS CELDAS DEPENDIENDO DE LOS DIAS DE ENTREGA
        private void advancedDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
            {
                if(e.Value.GetType() != typeof(System.DBNull))
                {
                    if(advancedDataGridView1.Columns[e.ColumnIndex].Name == "gridFechaEntrega")
                    {
                        TimeSpan dif = Convert.ToDateTime(e.Value.ToString()) - DateTime.Now.Date;
                        int dias = dif.Days;
                        //ROJO
                        if (dias <= 1)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(247, 121, 121);
                        }
                        //AMARILLO
                        if (dias == 2)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(247, 234, 121);
                        }
                        //VERDE
                        if (dias >= 3)
                        {
                            e.CellStyle.BackColor = Color.FromArgb(159, 247, 121);
                        }
                    }
                }
            }
        }


        //**********************NUMERA LAS FILAS
        private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(advancedDataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
            }
        }


        //**************OBTIENE LA POSICION DEL MOUSE PARA MOSTRAR LAS OPCIONES
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


        //******************EDICION DE LA CASILLA DE FECHA
        private void advancedDataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl txt = (DataGridViewTextBoxEditingControl)e.Control;
            txt.KeyUp -= new KeyEventHandler(text_KeyUp);
            txt.KeyUp += new KeyEventHandler(text_KeyUp);
        }


        //**********************TERMINA LA EDICION DE LA CELDA AL ENTER
        private void advancedDataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            advancedDataGridView1.BeginEdit(false);
        }


        //********************PROCESO PARA SELECCIONAR Y GUARDAR ARCHIVO EN SERVIDOR Y RUTA EN BD
        private void adjuntarPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idActividad = Convert.ToInt32(advancedDataGridView1.Rows[Index].Cells["gridIdActividad"].Value);

            try
            {
                int d = ObjConsultasBD.getExisteFechaPrerreq(tipoBD, idActividad);
                if(d >= 1)
                {
                    OpenDialog();
                    int r = GuardaPDF();
                    if (r == 1)
                    {
                        updateArchivoBD();
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario agregar una Fecha de Envio antes de Adjuntar Archivo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //********************MUESTRA LOS COMENTARIOS DE LA ACTIVIDAD
        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idActividad = Convert.ToInt32(advancedDataGridView1.Rows[Index].Cells["gridIdActividad"].Value);

            DetalleComentarios frm = new DetalleComentarios(idActividad, 0, tipoBD, 2);
            frm.Show();
        }


        //***********************AL DETECTAR ENTER SE GUARDA LA FECHA DE ENVIO EN LA BD
        public void text_KeyUp(object sender, KeyEventArgs e)
        {
            int res, existe;
            // OBTIENE EL INDICE DONDE SE ENCUENTRA EL MOUSE 
            int rowIndex = ((System.Windows.Forms.DataGridViewTextBoxEditingControl)(sender)).EditingControlRowIndex;

            if (e.KeyCode == Keys.Enter)
            {
                idActividad = Convert.ToInt32(advancedDataGridView1.Rows[rowIndex - 1].Cells["gridIdActividad"].Value);
                fechaE = Convert.ToDateTime(advancedDataGridView1.Rows[rowIndex - 1].Cells["gridFechaEnvio"].Value);
                F_Envio = String.Format("{0:yyyy-MM-dd}", fechaE);
                
                try
                {
                    //VERIFICA SI EL REGISTRO EXISTE PARA NO DUPLICARLOS / INSERTA NUEVO REGISTRO
                    existe = ObjConsultasBD.getExistePrerreq(tipoBD, idActividad);

                    if (existe >= 1)
                    {
                        res = ObjConsultasBD.updatePrerrequisitos(tipoBD, F_Envio, idActividad, name);
                        if (res == 1)
                        {
                            MessageBox.Show("Se Actualizo la Información Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        res = ObjConsultasBD.savePrerrequisito(tipoBD, idActividad, F_Envio, name);
                        if (res == 1)
                        {
                            MessageBox.Show("Se Guardo la Información Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        
        //*******************ABRE EL ARCHIVO ADJUNTO EN CASO DE TENER UNO 
        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow dgv = advancedDataGridView1.Rows[e.RowIndex];
            idActividad = Convert.ToInt32(dgv.Cells[0].Value);

            //VERIFICA QUE EL CLICK SEA EN LA FILA CORRECTA, BOTON
            if(e.ColumnIndex >= 0 && advancedDataGridView1.Columns[e.ColumnIndex].Name == "VerArchivo" && e.RowIndex >= 0)
            {
                try
                {
                    existe = ObjConsultasBD.getExistePrerreqPDF(tipoBD, idActividad);
                    if (existe >= 1)
                    {
                        rutaPrerreq = ObjConsultasBD.getRutaPrerreq(tipoBD, idActividad);
                        if (rutaPrerreq != "")
                        {
                            Process.Start(rutaPrerreq);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La Actividad no cuenta con Archivo Adjunto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }


        //****************ABRE LA VENTANA PARA SELECCIONAR EL ARCHIVO
        public void OpenDialog()
        {
            try
            {
                //PARAMETROS DE BUSQUEDA PARA LA SECCION DE ARCHIVOS CON UNA EXT
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Archivos de texto (*.pdf)|*.pdf";
                openFileDialog1.RestoreDirectory = true;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    archivo = openFileDialog1.FileName;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cargar el archivo: " + ex.ToString() + "\n Intentelo nuevamente.");
            }
        }


        //***********************GUARDA EL PDF EN EL SERVIDOR Y GENERA LA RUTA PARA LA BD
        public int GuardaPDF()
        {
            try
            {
                //genera la ruta para guardar el archivo
                carpeta = Path.Combine(Application.StartupPath, String.Format(@"\\INOLABSERVER01\Desarrollo\Prerrequisitos de instalacion\A-" + idActividad + ".pdf", Path.GetFileName(openFileDialog1.FileName)));
                //copia el archivo a la nueva carpeta
                File.Copy(openFileDialog1.FileName, carpeta);

                //MessageBox.Show("Documento guardado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                rutaPDF = @"\\INOLABSERVER01\Desarrollo\Prerrequisitos de instalacion\A-" + idActividad + ".pdf";
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un problema al Guardar el archivo " + ex.ToString() + "\n Intentelo nuevamente.");
                return 0;
            }
        }


        //***************************GUARDA LA RUTA DEL ARCHIVO EN LA BD
        public void updateArchivoBD()
        {
            try
            {
                int res = ObjConsultasBD.saveArchivoPrerrequisito(tipoBD, idActividad, rutaPDF, name);
                if(res == 1)
                {
                    MessageBox.Show("Archivo Guardado con Exito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
