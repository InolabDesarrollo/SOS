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
using System.Diagnostics;
using System.Reflection;
using MaterialSkin;
using MaterialSkin.Controls;




namespace ProyectoInolabServicio
{
    public partial class RegistrosSAP : MaterialForm
    {
        public RegistrosSAP(int BD)
        {
            InitializeComponent();
            DoubleBuffered(advancedDataGridView1, true);
            DoubleBuffered(adgvLlamadasSinArea, true);
            tipoBD = BD;                        
        }

        //variables 
        string IdLlamada, estatus, tipoBusq;
        string fechaIni, fechaFin, folio, noLlamada;
        string folioAsig = "";
        int MesF, Index, tipoBD;
        
        //**********Instancia de clase Consultas
        DataConsultas objConsultasBD = new DataConsultas();

        //*************CARGA LOS DATOS DEL MES CORRIENTE
        private void RegistrosSAP_Load(object sender, EventArgs e)
        {
            mesActualToolStripMenuItem.Checked = true;
            tabControl1.SelectedTab = tPageArea;

            lblTipoFiltro.Text = "Mes de: " + DateTime.Now.ToString("MMMM");

            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMes(tipoBD, 2, "2, 3");
                    //lblRegistros.Text = rowCount + " Registros";
                }
                else if (TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMes(tipoBD, 2, "1");
                }
                else
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMes(tipoBD, 1, "");
                }

                adgvLlamadasSinArea.DataSource = objConsultasBD.getLlamadasSinArea(tipoBD);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
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

        private void verTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hoyToolStripMenuItem.Checked = false;
            semanaPasadaToolStripMenuItem.Checked = false;
            mesPasadoToolStripMenuItem.Checked = false;
            másAntiguosToolStripMenuItem.Checked = false;
            asignadosToolStripMenuItem2.Checked = false;
            sinAsignarToolStripMenuItem1.Checked = false;
            rangoDeFechaToolStripMenuItem.Checked = false;
            asignadosToolStripMenuItem1.Checked = false;
            mesActualToolStripMenuItem.Checked = false;
            txtBuscar.Visible = false;
            btnBusqueda.Visible = false;
            cmbBusqueda.Text = null;

        }

        
        //****************ABRE VENTANA DE FOLIOS
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Folios frm = new Folios(tipoBD);
            frm.Show();
        }
        

        //***************REGRESA AL MENU PRINCIPAL
        private void menúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu frm = new Menu(tipoBD);         
            frm.Show(); 
        }
        

        //****************COLOR DE CELDA SEGUN ESTATUS
        private void advancedDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs a)
        {
             if(a.Value != null)
             {
                    if(a.Value.GetType() != typeof(System.DBNull))
                    {
                        if(a.Value.ToString() == "Asignado")
                        {
                            a.CellStyle.BackColor = Color.LightGreen;
                        }
                        if(a.Value.ToString() == "Sin Asignar")
                        {
                            a.CellStyle.BackColor = Color.FromArgb(247, 67, 67);
                        }
                        if(a.Value.ToString() == "En Proceso")
                        {
                            a.CellStyle.BackColor = Color.LightSteelBlue;
                        }
                        if(a.Value.ToString() == "Finalizado")
                        {
                            a.CellStyle.BackColor = Color.Green;
                        }
                        if(a.Value.ToString() == "Cerrado")
                        {
                            a.CellStyle.BackColor = Color.Yellow;
                        }
                        //Color de texto Servicio Confirmado
                        if(a.Value.ToString() == "No")
                        {
                            a.CellStyle.ForeColor = Color.DarkRed;
                        }
                        if(a.Value.ToString() == "Si")
                        {   
                            a.CellStyle.ForeColor = Color.DarkGreen;
                        }
                    }
             }
        }


        //********************OBTIENE NUMERO DE LLAMADA AL HACER CLIC EN CELDA DEL GRID
        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Verifica seleccion dentro del grid
            if(tabControl1.SelectedIndex == 0)
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                else
                {
                    DataGridViewRow dvg = advancedDataGridView1.Rows[e.RowIndex];
                    noLlamada = dvg.Cells["Llamada"].Value.ToString();
                }
            }
            if(tabControl1.SelectedIndex == 1)
            {
                if (e.RowIndex == -1)
                {
                    return;
                }
                else
                {
                    DataGridViewRow dvg = adgvLlamadasSinArea.Rows[e.RowIndex];
                    noLlamada = dvg.Cells["LlamadaS"].Value.ToString();
                }
            }
                   
        }


        //*********************NUMERACION DE LAS FILAS DEL GRID
        private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //Numeración de filas
            using (SolidBrush b = new SolidBrush(advancedDataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
            }
        }


        //*****************ABRE FORM DEPENDIENTO DEL ESTATUS
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow dvg = advancedDataGridView1.Rows[e.RowIndex];            
            //Bloquea usuario
            if(TestSpire.Usr.K == 22)
            {
                MessageBox.Show("No tiene acceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            }
            else
            {
                if (dvg.Cells[0].Value.ToString() == "Asignado")
                {
                    MessageBox.Show("Ese registro cuenta con un Folio FSR Asignado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dvg.Cells[0].Value.ToString() == "Finalizado")
                {
                    noLlamada = dvg.Cells[3].Value.ToString();
                    try
                    {
                        folio = objConsultasBD.generaFolio(tipoBD, noLlamada);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ReporteFolio rp = new ReporteFolio(folio);
                    rp.Show();
                }
                if (dvg.Cells[0].Value.ToString() == "Sin Asignar")
                {
                    IdLlamada = dvg.Cells[2].Value.ToString();

                    FSR frm = new FSR(IdLlamada, tipoBD);
                    frm.Show();
                }
                if (dvg.Cells[0].Value.ToString() == "En Proceso")
                {
                    noLlamada = dvg.Cells[3].Value.ToString();
                    try
                    {
                        folio = objConsultasBD.generaFolio(tipoBD, noLlamada);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ActualizaFSR fsr = new ActualizaFSR(folio, tipoBD);
                    fsr.Show();
                }
            }            
        }
        
        
        private void advancedDataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(advancedDataGridView1.FilterString) == false)
                {
                    lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
                }
                else
                {
                    lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
                }
            }                     
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        //*************MUESTRA LOS DETALLES DEL FOLIO SI ESTA ASIGNADO
        private void DestallestoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Abre el formulario de Actualizar para visualizar los datos del folio asignado o finalizado
            if(tabControl1.SelectedIndex == 0)
            {
                estatus = advancedDataGridView1.Rows[Index].Cells["txtEstatus"].Value.ToString();
                folioAsig = advancedDataGridView1.Rows[Index].Cells["IdFSR"].Value.ToString();
            }
            if(tabControl1.SelectedIndex == 1)
            {
                estatus = adgvLlamadasSinArea.Rows[Index].Cells["txtEstatus2"].Value.ToString();
                folioAsig = adgvLlamadasSinArea.Rows[Index].Cells["IdFSR2"].Value.ToString();
            }
            

            if (estatus == "Sin Asignar")
            {
                MessageBox.Show("No cuenta con un Folio Asignado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                
                ActualizaFSR frm = new ActualizaFSR(folioAsig, tipoBD);
                frm.Show();
                folioAsig = null;
            }
        }

        
        //****************DETERMINA LA POSICION DEL MOUSE 
        private void advancedDataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Desplega el menu secundario al click, movimiento del mouse
            if (e.Button == MouseButtons.Right)
            {
                this.advancedDataGridView1.Rows[e.RowIndex].Selected = true;
                this.Index = e.RowIndex;
                this.advancedDataGridView1.CurrentCell = this.advancedDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.contextMenuStrip1.Show(this.advancedDataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


        //***************ABRE FORM DE LLAMADAS INTERNAS
        private void llamadasInternasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerLlamadas vl = new VerLlamadas(tipoBD);
            vl.Show();
        }


        //***************GENERA REPORTE CON FILTRO DE FECHAS, EXPORTABLE A EXCEL
        private void exportarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            ReporteRegistrosSAP r = new ReporteRegistrosSAP();
            r.Show();
        }
        

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
        }


        //**************CARGA FOLIOS ASIGNADOS POR MES DE FECHA COMERCIAL / SE DESACTIVA
        private void toolStripComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MesF = TcmbMesesAsig.SelectedIndex + 1;
                        
            lblTipoFiltro.Text = "Asignados en: " + TcmbMesesAsig.Text;

            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getFiltroLlamadaMesAsignada(tipoBD, MesF, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getFiltroLlamadaMesAsignada(tipoBD, MesF, 2, "1");
                }
                else
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getFiltroLlamadaMesAsignada(tipoBD, MesF, 1, "");
                }
                //advancedDataGridView1.DataSource = objConsultasBD.getFiltroLlamadaMesAsignada(tipoBD, MesF, 1, 0);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void asignadosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
        }


        //*****************CARGA TODOS LOS REGISTROS DE SAP
        private void asignadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Todos los registros";

            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getTodasLlamadasSAP(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getTodasLlamadasSAP(tipoBD, 2, "1");
                }
                else
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getTodasLlamadasSAP(tipoBD, 1, "");
                }
                //advancedDataGridView1.DataSource = objConsultasBD.getTodasLlamadasSAP(tipoBD, 1, 0);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void mesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verComentariosDeLlamadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 0)
            {
                int activ = Convert.ToInt32(advancedDataGridView1.Rows[Index].Cells["IDActividad"].Value);
                DetalleComentarios dc = new DetalleComentarios(activ, 0, tipoBD, 1);
                dc.ShowDialog();
            }
            if(tabControl1.SelectedIndex == 1)
            {
                int activ = Convert.ToInt32(adgvLlamadasSinArea.Rows[Index].Cells["IDActividad2"].Value);
                DetalleComentarios dc = new DetalleComentarios(activ, 0, tipoBD, 1);
                dc.ShowDialog();
            }            
        }



        private void hoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Hoy: " + DateTime.Now.ToLongDateString();

            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasHoy(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasHoy(tipoBD, 2, "1");
                }
                else
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasHoy(tipoBD, 1, "");
                }
                //advancedDataGridView1.DataSource = objConsultasBD.getLlamadasHoy(tipoBD, 1, 0);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void semanaPasadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Semana Anteriror de: " + String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-7)) + " al " + String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-1));
            
            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasSemanaAnterior(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasSemanaAnterior(tipoBD, 2, "1");
                }
                else
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasSemanaAnterior(tipoBD, 1, "");
                }
                //advancedDataGridView1.DataSource = objConsultasBD.getLlamadasSemanaAnterior(tipoBD, 1, 0);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mesPasadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime f1, f2;

            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMesAnterior(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMesAnterior(tipoBD, 2, "1");
                }
                else
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMesAnterior(tipoBD, 1, "");
                }
                //advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMesAnterior(tipoBD, 1, 0);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";

                SqlDataReader leer;
                leer = objConsultasBD.getFechasFiltroLlam(tipoBD, 1);
                if (leer.Read())
                {
                    f1 = Convert.ToDateTime(leer["primero"]);
                    f2 = Convert.ToDateTime(leer["ultimo"]);
                    lblTipoFiltro.Text = "Mes Anterior de: " + f1.ToString("dd/MM/yyyy") + " al " + f2.ToString("dd/MM/yyyy");
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void másAntiguosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Más Antiguos";

            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMasAntiguas(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMasAntiguas(tipoBD, 2, "1");
                }
                else
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMasAntiguas(tipoBD, 1, "");
                }
                //advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMasAntiguas(tipoBD, 1, 0);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TcmbMesesSinA_Click(object sender, EventArgs e)
        {

        }


        //***************CARGA FOLIOS SIN ASIGNAR POR MES DE FECHA COMERCIAL
        private void TcmbMesesSinA_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MesF = TcmbMesesSinA.SelectedIndex + 1;
            lblTipoFiltro.Text = "Sin Asignar de: " + TcmbMesesSinA.Text;

            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getFiltroLlamadaMesSinAsignar(tipoBD, MesF, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getFiltroLlamadaMesSinAsignar(tipoBD, MesF, 2, "1");
                }
                else
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getFiltroLlamadaMesSinAsignar(tipoBD, MesF, 1, "");
                }
                //advancedDataGridView1.DataSource = objConsultasBD.getFiltroLlamadaMesSinAsignar(tipoBD, MesF, 1, 0);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        //**************ABRE DIALOG PARA FILTRAR POR RANGO DE FECHA
        private void rangoDeFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFiltroFecha();
            lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
            lblTipoFiltro.Text = "Rango Fechas de: " + fechaIni + " al " + fechaFin;
        }

        //***********************MUESTRA LA PRIMER PAGINA DE LOS REGISTROS
        private void primeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        //************************MUESTRA LA PAGINA ANTERIOR DE LOS REGISTROS
        private void anterirorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        //*********************MUESTRA LA PAGINA SIGUIENTE DE LOS REGISTROS 
        private void siguienteToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            
        }


        //******************************MUESTRA LA ULTIMA PAGINA DE LOS REGISTROS
        private void ultimoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void adgvLlamadasSinArea_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(advancedDataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
            }
        }


        private void adgvLlamadasSinArea_CellFormatting(object sender, DataGridViewCellFormattingEventArgs a)
        {
            if (a.Value != null)
            {
                if (a.Value.GetType() != typeof(System.DBNull))
                {
                    if (a.Value.ToString() == "Asignado")
                    {
                        a.CellStyle.BackColor = Color.LightGreen;
                    }
                    if (a.Value.ToString() == "Sin Asignar")
                    {
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
                    //Color de texto Servicio Confirmado
                    if (a.Value.ToString() == "No")
                    {
                        a.CellStyle.ForeColor = Color.DarkRed;
                    }
                    if (a.Value.ToString() == "Si")
                    {
                        a.CellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        private void adgvLlamadasSinArea_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.adgvLlamadasSinArea.Rows[e.RowIndex].Selected = true;
                this.Index = e.RowIndex;
                this.adgvLlamadasSinArea.CurrentCell = this.adgvLlamadasSinArea.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.contextMenuStrip1.Show(this.adgvLlamadasSinArea, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void adgvLlamadasSinArea_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                if (string.IsNullOrEmpty(adgvLlamadasSinArea.FilterString) == false)
                {
                    lblRegistros.Text = adgvLlamadasSinArea.RowCount.ToString() + " Registros";
                }
                else
                {
                    lblRegistros.Text = adgvLlamadasSinArea.RowCount.ToString() + " Registros";
                }
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
                lblTipoFiltro.Visible = true;
                verTodoToolStripMenuItem.Visible = true;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                lblRegistros.Text = adgvLlamadasSinArea.RowCount.ToString() + " Rgistros";
                lblTipoFiltro.Visible = false;
                verTodoToolStripMenuItem.Visible = false;
            }
        }

        private void adgvLlamadasSinArea_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow dvg = adgvLlamadasSinArea.Rows[e.RowIndex];
            //Bloquea usuario
            if (TestSpire.Usr.K == 22)
            {
                MessageBox.Show("No tiene acceso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dvg.Cells[0].Value.ToString() == "Asignado")
                {
                    MessageBox.Show("Ese registro cuenta con un Folio FSR Asignado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dvg.Cells[0].Value.ToString() == "Finalizado")
                {
                    noLlamada = dvg.Cells[3].Value.ToString();
                    try
                    {
                        folio = objConsultasBD.generaFolio(tipoBD, noLlamada);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ReporteFolio rp = new ReporteFolio(folio);
                    rp.Show();
                }
                if (dvg.Cells[0].Value.ToString() == "Sin Asignar")
                {
                    IdLlamada = dvg.Cells[2].Value.ToString();

                    FSR frm = new FSR(IdLlamada, tipoBD);
                    frm.Show();
                }
                if (dvg.Cells[0].Value.ToString() == "En Proceso")
                {
                    noLlamada = dvg.Cells[3].Value.ToString();
                    try
                    {
                        folio = objConsultasBD.generaFolio(tipoBD, noLlamada);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    ActualizaFSR fsr = new ActualizaFSR(folio, tipoBD);
                    fsr.Show();
                }
            }
        }


        //******************CREA DIALOG PARA SELECCIONAR FECHAS DE FILTRO
        public void FormFiltroFecha()
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
                    if (TestSpire.Usr.K == 79)
                    {
                        advancedDataGridView1.DataSource = objConsultasBD.getLlamadaRango(tipoBD, fechaIni, fechaFin, 2, "2, 3");
                    }
                    else if (TestSpire.Usr.K == 39)
                    {
                        advancedDataGridView1.DataSource = objConsultasBD.getLlamadaRango(tipoBD, fechaIni, fechaFin, 2, "1");
                    }
                    else
                    {
                        advancedDataGridView1.DataSource = objConsultasBD.getLlamadaRango(tipoBD, fechaIni, fechaFin, 1, "");
                    }
                    //advancedDataGridView1.DataSource = objConsultasBD.getLlamadaRango(tipoBD, fechaIni, fechaFin, 1, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }           
                form1.Dispose();                
            }
            else
            {
                MessageBox.Show("No se aplicara Filtro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form1.Dispose();
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {   
            string valor = txtBuscar.Text;
            lblTipoFiltro.Text = tipoBusq;

            try
            {
                if(tabControl1.SelectedTab == tPageArea)
                {
                    if (TestSpire.Usr.K == 79)
                    {
                        advancedDataGridView1.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 2, "2, 3");
                    }
                    else if (TestSpire.Usr.K == 39)
                    {
                        advancedDataGridView1.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 2, "1");
                    }
                    else
                    {
                        advancedDataGridView1.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 1, "");
                    }
                }
                if(tabControl1.SelectedTab == tPageSin)
                {
                    adgvLlamadasSinArea.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 3, "");
                }
                
                //advancedDataGridView1.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 1, 0);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
                               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mesActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Mes de: " + DateTime.Now.ToString("MMMM"); 

            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMes(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMes(tipoBD, 2, "1");
                }
                else
                {
                    advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMes(tipoBD, 1, "");
                }
                //advancedDataGridView1.DataSource = objConsultasBD.getLlamadasMes(tipoBD, 1, 0);
                lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string valor = txtBuscar.Text;
                lblTipoFiltro.Text = tipoBusq;

                try
                {
                    if (tabControl1.SelectedTab == tPageArea)
                    {
                        if (TestSpire.Usr.K == 79)
                        {
                            advancedDataGridView1.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 2, "2, 3");
                        }
                        else if (TestSpire.Usr.K == 39)
                        {
                            advancedDataGridView1.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 2, "1");
                        }
                        else
                        {
                            advancedDataGridView1.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 1, "");
                        }
                    }
                    else if (tabControl1.SelectedTab == tPageSin)
                    {
                        adgvLlamadasSinArea.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 3, "");
                    }
                    //advancedDataGridView1.DataSource = objConsultasBD.getLlamadaBusqueda(tipoBD, tipoBusq, valor, 1, 0);
                    lblRegistros.Text = advancedDataGridView1.RowCount.ToString() + " Registros";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            mesActualToolStripMenuItem.Checked = false;
            int tipo = cmbBusqueda.SelectedIndex + 1;

            string valor = txtBuscar.Text;
            lblTipoFiltro.Text = tipoBusq;

            txtBuscar.Text = null;
            btnBusqueda.Visible = true;
            txtBuscar.Visible = true;

            if(tipo == 1)
            {
                tipoBusq = "NoLlamada";
            }
            if (tipo == 2)
            {
                tipoBusq = "IDActividad";
            }
            if(tipo == 3)
            {
                tipoBusq = "Cliente";
            }
            if(tipo == 4)
            {
                tipoBusq = "Tiposervicio";
            }
            if(tipo == 5)
            {
                tipoBusq = "Equipo";
            }
            if(tipo == 6)
            {
                tipoBusq = "Marca";
            }
            if(tipo == 7)
            {
                tipoBusq = "Modelo";
            }
            if(tipo == 8)
            {
                tipoBusq = "Asignado";
            }
            if (tipo == 9)
            {
                tipoBusq = "Noserie";
            }
        }

        private void sinAsignarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }


    }
}
