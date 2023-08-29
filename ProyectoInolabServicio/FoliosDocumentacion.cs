using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace ProyectoInolabServicio
{
    public partial class FoliosDocumentacion : MaterialForm
    {
        public FoliosDocumentacion(int BD)
        {
            InitializeComponent();
            DoubleBuffered(advancedDataGridView1, true);
            tipoBD = BD;
        }

        //******************VARIABLES
        string folio, respNom, docuNom;
        int IdComboDoc, IdComboResp, IDDoc, IDResp;
        int tipoBD, Index;


        //****************** INSTANCIA DE CLASE CONSULTAS
        DataConsultas objConsultasBD = new DataConsultas();



        //*********************CARGA TODOS LOS FOLIOS QUE NECESITAN DOCUMENTACION
        private void FoliosDocumentacion_Load(object sender, EventArgs e)
        {
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getFoliosDocument(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch (Exception ex)
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



        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        //**********************ASIGNA COLOR A CELDA DEPENDIENTO DEL ESTATUS
        private void advancedDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs a)
        {
            //Da color a la celda Estado dependiendo del estatus de los folios
            if (a.Value != null)
            {
                if (a.Value.GetType() != typeof(System.DBNull))
                {
                    if (a.Value.ToString() == "Asignado")
                    {
                        //e.CellStyle.ForeColor = Color.Red;
                        a.CellStyle.BackColor = Color.LightGreen;
                    }
                    if (a.Value.ToString() == "Sin Asignar")
                    {
                        //e.CellStyle.ForeColor = Color.Green;
                        a.CellStyle.BackColor = Color.FromArgb(247, 67, 67);
                    }
                    if (a.Value.ToString() == "En Proceso")
                    {
                        a.CellStyle.BackColor = Color.LightSteelBlue;

                    }
                    if (a.Value.ToString() == "Finalizado")
                    {
                        a.CellStyle.BackColor = Color.Green;

                    }
                    if (a.Value.ToString() == "Cerrado")
                    {
                        a.CellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }


        //***************ABRE FORM QUE CONTIENE LOS REGISTROS ASIGNADOS A DOCUMENTACION
        private void registrosDocumentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrosDocumentacion frm = new RegistrosDocumentacion(tipoBD);
            frm.Show();
        }


        //**************ABRE FORM QUE PERMITE ASIGNAR EL FOLIO A DOCUMENTACION EN CASO DE NO EXISTIR
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dvg = advancedDataGridView1.Rows[e.RowIndex];
            folio = dvg.Cells["gridTxtFolio"].Value.ToString();

            //verificamos que el registro inicial ya se encuentre dentro de documentacion
            int cont;

            if(TestSpire.Usr.K == 70 || TestSpire.Usr.K == 69)
            {
                MessageBox.Show("No cuenta con acceso a esta función.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    cont = objConsultasBD.getExsiteFolioDoc(tipoBD, folio);

                    if (cont >= 1)
                    {
                        MessageBox.Show("El Folio ya esta asignado a Documentación.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Documentacion frm = new Documentacion(folio, tipoBD);
                        frm.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        //*****************MUESTRA TODOS LOS FOLIOS PARA DOCUMENTACION
        private void todosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getFoliosDocument(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //*******************CARGA DATOS QUE NO TIENEN UN DOCUMENTADOR ASIGNADO
        private void sinDocuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getFolioSinDoc(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TcmbFiltroMes_Click(object sender, EventArgs e)
        {

        }



        //***************************** DESCARGA LA EVIDENCIA QUE SE ENCUENTRA EN EL SERVIDOR
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
            catch(Exception)
            {
                MessageBox.Show("No se ha encontrado la evidencia", "ERROR DE DESCARGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }


        //****************************** ENUMERA LAS FILAS DEL GRID
        private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(advancedDataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
            }
        }
        

        //****************************** MUESTRA EL CONTEO DE REGISTROS EN PANTALLA
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



        //************************CARGA FOLIOS DEPEDIENDO DEL MES SELECCIONADO
        private void TcmbFiltroMes_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int mes = TcmbFiltroMes.SelectedIndex + 1;

            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getFoliosMes(tipoBD, mes);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //**********************PERMITE VER EL FSR DE LOS FOLIOS CON EL MENU DE CLIC DERECHO
        private void verFSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            folio = advancedDataGridView1.Rows[Index].Cells["gridTxtFolio"].Value.ToString();
            ReporteFolio frm = new ReporteFolio(folio);
            frm.Show();
        }

        private void cbDocument_Click(object sender, EventArgs e)
        {

        }


        //******************DETERMINA LA POSICION DEL MOUSE PARA MOSTRAR MENU SECUNDARIO
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


        //************************ASIGNA DOCUMENTADOR CON MENU SECUNDARIO DE CLIC DERECHO
        private void documentadorToolStripMenuItem_Click(object sender, EventArgs e)
        {//Compara si la seleccion del combo esta vacia
            IdComboDoc = cbDocument.SelectedIndex + 1;
            int result;
            if (cbDocument.SelectedItem == null)
            {
                MessageBox.Show("Es necesario seleccionar un Documentador", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //Toma el id del combo para asignar el id de la BD
                docuNom = Convert.ToString(cbDocument.SelectedItem);

                if (IdComboDoc == 1)
                { IDDoc = 109; }
                if (IdComboDoc == 2)
                { IDDoc = 36; }
                if (IdComboDoc == 3)
                { IDDoc = 107; }
                if (IdComboDoc == 4)
                { IDDoc = 22; }
                if (IdComboDoc == 5)
                { IDDoc = 33; }
                if (IdComboDoc == 6)
                { IDDoc = 85; }
                if (IdComboDoc == 7)
                { IDDoc = 37; }
                if (IdComboDoc == 8)
                { IDDoc = 45; }
                if (IdComboDoc == 9)
                { IDDoc = 40; }
                if (IdComboDoc == 10)
                { IDDoc = 95; }
                if (IdComboDoc == 11)
                { IDDoc = 106; }
                if (IdComboDoc == 12)
                { IDDoc = 108; }
                if (IdComboDoc == 13)
                { IDDoc = 104; }
                if (IdComboDoc == 14)
                { IDDoc = 35; }
                if (IdComboDoc == 15)
                { IDDoc = 70; }
                if (IdComboDoc == 16)
                { IDDoc = 72; }
                if (IdComboDoc == 17)
                { IDDoc = 34; }
                if (IdComboDoc == 18)
                { IDDoc = 69; }
                if (IdComboDoc == 19)
                { IDDoc = 101; }
                if(IdComboDoc == 20)
                { IDDoc = 62; }
                if(IdComboDoc == 21)
                { IDDoc = 128; }
                if(IdComboDoc == 22)
                { IDDoc = 129; }
                if(IdComboDoc == 23)
                { IDDoc = 130; }
                if(IdComboDoc == 24)
                { IDDoc = 132; }
                if(IdComboDoc == 25)
                { IDDoc = 137; }


                MessageBox.Show("Se asiganara como Documentador: " + docuNom + " al folio: " + folio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    result = objConsultasBD.UpdateAsignaDocument(tipoBD, IDDoc, folio);
                    if(result == 1)
                    {
                        MessageBox.Show("Se actualizaron los datos correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //*******************ASIGNA RESPONSABLE CON MENU SECUNDARIO, CLIC DERECHO
        private void responsableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int result;
            //Compara si la seleccion de nombre esta vacia
            IdComboResp = cbResponsable.SelectedIndex + 1;
            if (cbResponsable.SelectedItem == null)
            {
                MessageBox.Show("Es necesario seleccionar un Responsable", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //nombre responsable
                respNom = Convert.ToString(cbResponsable.SelectedItem);
                //index responsable
                if (IdComboResp == 1)
                {
                    IDResp = 22;
                }
                if (IdComboResp == 2)
                {
                    IDResp = 40;
                }
                if (IdComboResp == 3)
                {
                    IDResp = 35;
                }
                MessageBox.Show("Se asiganara como Responsable: " + respNom + "al folio: " + folio, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                try
                {
                    result = objConsultasBD.UpdateAsignaResp(tipoBD, IDResp, folio);
                    if(result == 1)
                    {
                        MessageBox.Show("Se actualizaron los datos correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

