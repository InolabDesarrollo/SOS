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

namespace ProyectoInolabServicio
{
    public partial class SeguimientoFolios : MaterialForm
    {
        public SeguimientoFolios(int BD)
        {
            InitializeComponent();
            DoubleBuffered(advancedDataGridView2, true);
            tipoBD = BD;
        }

        //******************* VARIABLES
        string folio, comentarios, fecha_notif;
        int tipoBD, idIng, Index;


        //*************************** INSTANCIA DE CONSULTAS SQL
        DataConsultas ObjConsultasBD = new DataConsultas();

        //******************* OBTIENE EL NOMBRE DE EQUIPO DEL USUARIO
        string host = System.Net.Dns.GetHostName();
                     


        public new static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }


        public void CargaDatos()
        {
            if(TestSpire.Usr.K == 39)
            {
                advancedDataGridView2.DataSource = ObjConsultasBD.setSeguimientoFolios(tipoBD, 1, 1);
            }
            else if(TestSpire.Usr.K == 76)
            {
                advancedDataGridView2.DataSource = ObjConsultasBD.setSeguimientoFolios(tipoBD, 1, 2);
            }
            else if(TestSpire.Usr.K == 79)
            {
                advancedDataGridView2.DataSource = ObjConsultasBD.setSeguimientoFolios(tipoBD, 1, 3);
            }
            else
            {
                advancedDataGridView2.DataSource = ObjConsultasBD.setSeguimientoFolios(tipoBD, 2, 0);     
            }
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void dateTimePicker1_OnTextChange(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
        }

        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void observacionesFSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int folio = Convert.ToInt32(advancedDataGridView2.Rows[Index].Cells["gridFolio"].Value);
            DetalleComentarios dc = new DetalleComentarios(0, folio, tipoBD, 4);
            dc.ShowDialog();
        }


        private void advancedDataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Desplega el menu secundario al click, movimiento del mouse
            if (e.Button == MouseButtons.Right)
            {
                this.advancedDataGridView2.Rows[e.RowIndex].Selected = true;
                this.Index = e.RowIndex;
                this.advancedDataGridView2.CurrentCell = this.advancedDataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.contextMenuStrip2.Show(this.advancedDataGridView2, e.Location);
                contextMenuStrip2.Show(Cursor.Position);
            }
        }


        //*************************** ABRE EL REPORTE DEL FOLIO
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }

            folio = advancedDataGridView2.Rows[e.RowIndex].Cells["gridFolio"].Value.ToString();
            ReporteFolio frm = new ReporteFolio(folio);
            frm.Show();
        }

        private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(advancedDataGridView2.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
            }
        }

        private void SeguimientoFolios_Load(object sender, EventArgs e)
        {
            CargaDatos();
            lblRegistro.Text = advancedDataGridView2.Rows.Count.ToString() + " Registros";
        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void advancedDataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(string.IsNullOrEmpty(advancedDataGridView2.FilterString) == false)
            {
                lblRegistro.Text = advancedDataGridView2.Rows.Count.ToString() + " Registros";
            }
            else
            {
                lblRegistro.Text = advancedDataGridView2.Rows.Count.ToString() + " Registros";
            }
        }


        //************************ CIERRA EL MODO EDICION PARA LAS CELDAS AL DAR ENTER 
        private void AdvancedDataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            advancedDataGridView2.BeginEdit(false);
        }    
        

        //*********************** CONTROLA LA EDICION DE LAS CELDAS PARA SELECCIONAR O ESCRIBIR SOBRE ELLAS 
        private void AdvancedDataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(e.Control is ComboBox)
            {
                ((ComboBox)e.Control).SelectionChangeCommitted -= new EventHandler(cboDgvHardware_SelectionChanged);
                ((ComboBox)e.Control).SelectionChangeCommitted += new EventHandler(cboDgvHardware_SelectionChanged);

            }
            else
            {
                DataGridViewTextBoxEditingControl txt = (DataGridViewTextBoxEditingControl)e.Control;
                txt.KeyUp -= new KeyEventHandler(text_KeyUp);
                txt.KeyUp += new KeyEventHandler(text_KeyUp);
            }
            
        }


        //************************** CONTROLA LA SELECCION DEL COMBO DENTRO DEL GRID
        private void cboDgvHardware_SelectionChanged(object sender, EventArgs e)
        {
            string result = ((ComboBox)sender).SelectedItem.ToString();
        }


        //***************************** TOMA LOS DATOS DEL GRID AL DAR ENTER 
        public void text_KeyUp(object sender, KeyEventArgs e)
        {
            int rowIndex = ((System.Windows.Forms.DataGridViewTextBoxEditingControl)(sender)).EditingControlRowIndex;
           
            int res, existe;

            if (e.KeyCode == Keys.Enter)
            {
                folio = advancedDataGridView2.Rows[rowIndex - 1].Cells["gridFolio"].Value.ToString();
                fecha_notif = advancedDataGridView2.Rows[rowIndex - 1].Cells["gridTxtF_Notificar"].Value.ToString();
                comentarios = advancedDataGridView2.Rows[rowIndex - 1].Cells["gridTxtSeguimiento"].Value.ToString();
                idIng = Convert.ToInt32(advancedDataGridView2.Rows[rowIndex - 1].Cells["gridIdIngeniero"].Value);
                //DateTime dt = Convert.ToDateTime(fecha_notif);
                //Boolean bl = DateTime.TryParse(advancedDataGridView1.Rows[rowIndex - 1].Cells["gridF_Notificar"].Value.ToString(), out dt);
                //if (bl)
                //{
                //    advancedDataGridView1.Rows[rowIndex - 1].Cells["gridF_Notificar"].Value = String.Format("{0:dd/MM/yyyy}", dt);
                //}
                //else
                //{
                //    advancedDataGridView1.Rows[rowIndex - 1].Cells["gridF_Notificar"].Value = "";
                //}

                //comentarios = advancedDataGridView1.Rows[rowIndex - 1].Cells["gridComentseguimiento"].Value.ToString();
                //idIng = Convert.ToInt32(advancedDataGridView1.Rows[rowIndex - 1].Cells["gridCmbIdIngeniero"].Value);
                                             
                try
                {
                    //VERIFICA SI EL REGISTRO EXISTE PARA NO DUPLICARLOS / INSERTA NUEVO REGISTRO
                    existe = ObjConsultasBD.getExisteSeguimiento(tipoBD, folio);
                    if(existe >= 1)
                    {
                        res = ObjConsultasBD.UpdateSeguimientoFolio(tipoBD, folio, idIng, host, comentarios, fecha_notif);
                        if (res == 1)
                        {
                            MessageBox.Show("Se Actualizo la Información Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        res = ObjConsultasBD.SaveSeguimientoFolio(tipoBD, folio, fecha_notif, comentarios, idIng, TestSpire.Usr.K, host);
                        if (res == 1)
                        {
                            MessageBox.Show("Se Guardo la Información Correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
