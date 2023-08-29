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
    public partial class Folios : MaterialForm
    {
        public Folios(int BD)
        {
            InitializeComponent();
            DoubleBuffered(dgvDatos, true);
            //DoubleBuffered(dgvDatosAgrupados, true);
            //DoubleBuffered(advancedDataGridView3, true);
            tipoBD = BD;
        }


        //***************************VARIABLES
        string folio;
        int Index, tipoBD;
        string llamada, rutaFSR;
        string fechaIni, fechaFin;
        string busca, valor;


        //**********INSTANCIA DE CLASE DATA CONSULTAS
        DataConsultas objConsultasBD = new DataConsultas();


        //************CONEXION A BD
        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");


        //***************CARGA LOS DATOS PARA GRID
        private void Folios_Load(object sender, EventArgs e)
        {
            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMesActual(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMesActual(tipoBD, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMesActual(tipoBD, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getFSRMesActual(tipoBD, 1, 0);

                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
                lblTipoFiltro.Text = "Mes de: " + DateTime.Now.ToString("MMMM");
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


        //**********************DETERMINA USUARIOS SIN ACCESO Y ABRE VENTANA DE ACTUALIZACION
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if(TestSpire.Usr.K == 69 || TestSpire.Usr.K == 70)
            {
                MessageBox.Show("Acceso denegado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DataGridViewRow dvg = dgvDatos.Rows[e.RowIndex];
                folio = dvg.Cells["IdFSR"].Value.ToString();

                ActualizaFSR frm = new ActualizaFSR(folio, tipoBD);
                frm.Show();
            }           
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }



        //****************GENERA REPORTE DE TODOS LOS FOLIO
        private void verFolioFSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Muestra el pdf del folio seleccionado con clik secundario
           folio = dgvDatos.Rows[Index].Cells["gridFolioFSR"].Value.ToString();
           ReporteFolio frm = new ReporteFolio(folio);
           frm.Show();
        }


        //***GRID 2
        private void advancedDataGridView2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }


        //**************GRID 1
        //**************UBICA POSICION DE MOUSE AL CLIK DERECHO Y OBTIENE LOS INDICES
        private void advancedDataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dgvDatos.Rows[e.RowIndex].Selected = true;
                this.Index = e.RowIndex;
                this.dgvDatos.CurrentCell = this.dgvDatos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.contextMenuStrip1.Show(this.dgvDatos, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }


        private void advancedDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Verifica que el click sea dentro los indices
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dvg = dgvDatos.Rows[e.RowIndex];
            folio = dvg.Cells["gridFolioFSR"].Value.ToString();                        
        }


        //*****************DA COLOR A LA CELDA DEPENDIENDO DEL ESTATUS
        private void advancedDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs a)
        {       
            if (a.Value != null)
            {
                if (a.Value.GetType() != typeof(System.DBNull))
                {
                    if (a.Value.ToString() == "Asignado")
                    {
                        a.CellStyle.BackColor = Color.LightGreen;
                    }
                    if (a.Value.ToString() == "En Proceso")
                    {
                        a.CellStyle.BackColor = Color.Yellow;
                    }
                    if (a.Value.ToString() == "Finalizado")
                    {
                        a.CellStyle.BackColor = Color.LightSteelBlue;
                    }
                    if (a.Value.ToString() == "Cancelado")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(247, 67, 67);
                    }
                    if(this.dgvDatos.Columns[a.ColumnIndex].Name == "Funcionando" && a.Value.ToString() == "No")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(245, 106, 51);
                    }
                    if(dgvDatos.Columns[a.ColumnIndex].Name == "Funcionando" && a.Value.ToString() == "Si")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(159, 247, 121); //SeaGreen
                    }
                    
                }
            }
        }


        //**********************ENUMERA LAS FILAS DEL GRID
        private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(dgvDatos.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
                //lblTotalResult.Text = e.RowIndex + 1 + " Registros";
            }
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Toma el valor del folio al seleccionar una celda
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dvg = dgvDatos.Rows[e.RowIndex];
            folio = dvg.Cells["gridFolioFSR"].Value.ToString();
        }
                
       
        //*******************OBTIENE LOS FOLIOS QUE NECESITAN REPORTE
        private void requierenReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Llama la consulta de reportes
            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    dgvDatos.DataSource = objConsultasBD.getFoliosReporte(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getFoliosReporte(tipoBD, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getFoliosReporte(tipoBD, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getFoliosReporte(tipoBD, 1, 0);
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                

        private void advancedDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            //toma el valor del folio
            DataGridViewRow dvg = dgvDatos.Rows[e.RowIndex];
            folio = dvg.Cells["gridFolioFSR"].Value.ToString();

            //reliza la consulta para obtener la liga del archivo
            con.Open();
            string consul;
            consul = "select ISNULL(FileFSR, '0') AS FileFSR from FSR where Folio = " + folio;

            SqlCommand cm = new SqlCommand(consul, con);
            rutaFSR = Convert.ToString(cm.ExecuteScalar());
            con.Close();
            //determina si existe archivo para mostrar pdf
            if(rutaFSR == "0" && e.ColumnIndex >= 0 && dgvDatos.Columns[e.ColumnIndex].Name == "btnPDF" && e.RowIndex >= 0)
            {
                MessageBox.Show("No existe un archivo para el Folio " + folio, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //comprueba que se seleccione columna de boton y abre la ventana del archivo
                if (e.ColumnIndex >= 0 && dgvDatos.Columns[e.ColumnIndex].Name == "btnPDF" && e.RowIndex >= 0)
                {
                    MessageBox.Show(rutaFSR);
                    //PDFArchivoFSR frm = new PDFArchivoFSR(rutaFSR);
                    //frm.Show();
                }
            }            
        }


        //******************ABRE LA VENTANA PARA CREAR EL CORRECTIVO
        private void crearCorrectivoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            folio = dgvDatos.Rows[Index].Cells["gridFolioFSR"].Value.ToString();
            CrearCorrectivo frm = new CrearCorrectivo(TestSpire.Usr.User, folio, tipoBD);
            frm.Show();
        }
        

        //******************CARGA LA CONSULTA PARA TODOS LOS FOLIOS
        private void todosLosFoliosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    dgvDatos.DataSource = objConsultasBD.getTodosFolios(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getTodosFolios(tipoBD, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getTodosFolios(tipoBD, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getTodosFolios(tipoBD, 1, 0);
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        


        private void todosLosFoliosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Todos los Registros";
            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    dgvDatos.DataSource = objConsultasBD.getTodosFolios(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getTodosFolios(tipoBD, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getTodosFolios(tipoBD, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getTodosFolios(tipoBD, 1, 0);
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //********************MUESTRA EL FORM PARA FILTRAR POR FECHAS LOS FOLIOS
        private void inicioServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFiltroFecha();            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

                       
       
        //*****************MUESTRA LA VENTANA PARA AGREGAR LA FECHA DE FILTRO
        private void próximoServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFiltroFecha();
        }        
               
                

        //*****************MUESTRA DATOS DE BUSQUEDA, PAG 1
        private void toolStripPrimero_Click(object sender, EventArgs e)
        {
        }


        //*******************MUESTRA LA PAGINA ANTERIOR DE LA BUSQUEDA
        private void toolStripAnterior_Click(object sender, EventArgs e)
        {
        }


        //*******************MUESTRA LA PAGINA SIGUIENTE DE LA BUSQUEDA
        private void toolStripSiguiente_Click(object sender, EventArgs e)
        {
        }



        //***********************MUESTRA LA ULTIMA PAGINA DE LA BUSQUEDA
        private void toolStripUltimo_Click(object sender, EventArgs e)
        {
        }


        //******************MANDA EL TIPO DE BUSQUEDA 
        private void cmbTipoBusqueda_SelectedIndexchanged(object sender, System.EventArgs e)
        {
            int tipo = cmbTipoBusqueda.SelectedIndex + 1;
            txtBusqueda.Visible = true;
            txtBusqueda.Text = null;
            btnSearch.Visible = true;

            if(tipo == 1)
            {
                busca = "Folio";
            }
            if(tipo == 2)
            {
                busca = "Estatus";
            }
            if(tipo == 3)
            {
                busca = "NoLlamada";
            }
            if(tipo == 4)
            {
                busca = "Cliente";
            }
            if(tipo == 5)
            {
                busca = "TipoServicio";
            }
            if(tipo == 6)
            {
                busca = "Equipo";
            }
            if(tipo == 7)
            {
                busca = "Marca";
            }
            if(tipo == 8)
            {
                busca = "Modelo";
            }
            if(tipo == 9)
            {
                busca = "NoSerie";
            }
            if(tipo == 10)
            {
                busca = "Ingeniero";
            }
            if(tipo == 11)
            {
                busca = "Asesor1";
            }
        }

        
        //*******************CONSULTA PARA GENERAR LA BUSQUEDA Y EL TOTAL DE PAGINAS 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            valor = txtBusqueda.Text;

            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    dgvDatos.DataSource = objConsultasBD.getFoliosBusqueda(tipoBD, busca, valor, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getFoliosBusqueda(tipoBD, busca, valor, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getFoliosBusqueda(tipoBD, busca, valor, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getFoliosBusqueda(tipoBD, busca, valor, 1, 0);
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //**************************** MUESTRA DATOS ASIGNADOS AL DIA ACTIAL
        private void hoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Hoy: " + DateTime.Now.ToLongDateString();
            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    dgvDatos.DataSource = objConsultasBD.getFiltroFSRHoy(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getFiltroFSRHoy(tipoBD, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getFiltroFSRHoy(tipoBD, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getFiltroFSRHoy(tipoBD, 1, 0);
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
                //lblTotalResult.Text = objConsultasBD.TotalRegistros(tipoBD, 4, "", "", "", "", "") + " Registros";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //***************************** MUESRA DATOS QUE CORRESPONDEN A LA ASIGNACION DE LA SEMANA ANTERIOR
        private void semanaAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Semana Anteriror de: " + String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-7)) + " al " + String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-1));
            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRSemanaAnt(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRSemanaAnt(tipoBD, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRSemanaAnt(tipoBD, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getFSRSemanaAnt(tipoBD, 1, 0);
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
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
                    dgvDatos.DataSource = objConsultasBD.getFSRMesActual(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMesActual(tipoBD, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMesActual(tipoBD, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getFSRMesActual(tipoBD, 1, 0);
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void mesAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime f1, f2;
            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMesAnterior(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMesAnterior(tipoBD, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMesAnterior(tipoBD, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getFSRMesAnterior(tipoBD, 1, 0);
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";

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


        private void masAntiguosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Más Antiguos";
            try
            {
                if (TestSpire.Usr.K == 79)
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMasAntiguos(tipoBD, 2, "2, 3");
                }
                else if (TestSpire.Usr.K == 39)
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMasAntiguos(tipoBD, 2, "1");
                }
                else
                {
                    dgvDatos.DataSource = objConsultasBD.getFSRMasAntiguos(tipoBD, 1, "");
                }
                //dgvDatos.DataSource = objConsultasBD.getFSRMasAntiguos(tipoBD, 1, 0);
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(string.IsNullOrEmpty(dgvDatos.FilterString) == false)
            {
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
            }
            else
            {
                lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
            }
        }

        private void observacionesDeFSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idActividad = Convert.ToInt32(dgvDatos.Rows[Index].Cells["Actividad"].Value);

            DetalleComentarios dc = new DetalleComentarios(idActividad, 0, tipoBD, 3);
            dc.ShowDialog();
        }




        //**********CREA EL DIALOG PARA INSERTAR LAS FECHAS DE FILTRO
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
                if (inicioServicioToolStripMenuItem.Checked)
                {
                    try
                    {
                        if (TestSpire.Usr.K == 79)
                        {
                            dgvDatos.DataSource = objConsultasBD.getFSRFiltroFechas(tipoBD, fechaIni, fechaFin, "Inicio_Servicio", 2, "2, 3");
                        }
                        else if (TestSpire.Usr.K == 39)
                        {
                            dgvDatos.DataSource = objConsultasBD.getFSRFiltroFechas(tipoBD, fechaIni, fechaFin, "Inicio_Servicio", 2, "1");
                        }
                        else
                        {
                            dgvDatos.DataSource = objConsultasBD.getFSRFiltroFechas(tipoBD, fechaIni, fechaFin, "Inicio_Servicio", 1, "");
                        }
                        //dgvDatos.DataSource = objConsultasBD.getFSRFiltroFechas(tipoBD, fechaIni, fechaFin, "Inicio_Servicio", 1, 0);
                        lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
                        lblTipoFiltro.Text = "Inicio Servicio";
                        inicioServicioToolStripMenuItem.Checked = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (proximoServicioToolStripMenuItem.Checked)
                {
                    try
                    {
                        if (TestSpire.Usr.K == 79)
                        {
                            dgvDatos.DataSource = objConsultasBD.getFSRFiltroFechas(tipoBD, fechaIni, fechaFin, "Proximo_Servicio", 2, "2, 3");
                        }
                        else if (TestSpire.Usr.K == 39)
                        {
                            dgvDatos.DataSource = objConsultasBD.getFSRFiltroFechas(tipoBD, fechaIni, fechaFin, "Proximo_Servicio", 2, "1");
                        }
                        else
                        {
                            dgvDatos.DataSource = objConsultasBD.getFSRFiltroFechas(tipoBD, fechaIni, fechaFin, "Proximo_Servicio", 1, "");
                        }
                        //dgvDatos.DataSource = objConsultasBD.getFSRFiltroFechas(tipoBD, fechaIni, fechaFin, "Proximo_Servicio", 1, 0);
                        lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
                        lblTipoFiltro.Text = "Proximo Servicio";
                        proximoServicioToolStripMenuItem.Checked = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                form1.Dispose();
            }
            else
            {
                inicioServicioToolStripMenuItem.Checked = false;
                proximoServicioToolStripMenuItem.Checked = false;
                form1.Dispose();
            }
        }

        private void solicitudesInternasToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            SeguimientoFolios frm = new SeguimientoFolios(tipoBD);
            frm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            valor = txtBusqueda.Text;

            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (TestSpire.Usr.K == 79)
                    {
                        dgvDatos.DataSource = objConsultasBD.getFoliosBusqueda(tipoBD, busca, valor, 2, "2, 3");
                    }
                    else if (TestSpire.Usr.K == 39)
                    {
                        dgvDatos.DataSource = objConsultasBD.getFoliosBusqueda(tipoBD, busca, valor, 2, "1");
                    }
                    else
                    {
                        dgvDatos.DataSource = objConsultasBD.getFoliosBusqueda(tipoBD, busca, valor, 1, "");
                    }
                    //dgvDatos.DataSource = objConsultasBD.getFoliosBusqueda(tipoBD, busca, valor, 1, 0);
                    lblTotalResult.Text = dgvDatos.RowCount.ToString() + " Registros";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
    }
}
