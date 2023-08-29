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

namespace ProyectoInolabServicio
{
    public partial class FoliosProtocolos : MaterialForm
    {
        public FoliosProtocolos(int BD)
        {
            InitializeComponent();
            DoubleBuffered(advancedDataGridView1, true);
            DoubleBuffered(advancedDataGridView1, true);
            tipoBD = BD;
        }

        //*********************VARIABLES
        int tipoBD, Index, idActividad;
        string noLlamada, Folio;
        string fechaIni, fechaFin;


        //**********INSTANCIA DE CLASE DATA CONSULTAS
        DataConsultas objConsultasBD = new DataConsultas();

               
        //*******************CARGA LA VISTA PARA PROTOCOLOS
        private void FoliosProtocolos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.V_LlamadasSAP' Puede moverla o quitarla según sea necesario.
            this.v_LlamadasSAPTableAdapter.Fill(this.browserDataSet.V_LlamadasSAP);
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getProtocolosMes(tipoBD);
                lblTipoFiltro.Text = "Mes de: " + DateTime.Now.ToString("MMMM");
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


        //********************ABRE EL FORM PARA ACTUALIZAR EL FOLIO EN PROTOCOLOS
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dvg = advancedDataGridView1.Rows[e.RowIndex];
            noLlamada = dvg.Cells["dgvNoLlamada"].Value.ToString();
            Folio = dvg.Cells["FolioFSR"].Value.ToString();

            ActualizaProtocolo frm = new ActualizaProtocolo(noLlamada, tipoBD);
            frm.Show();
        }

        
        //*********************MUESTRA LOS REGISTROS QUE TIENE PROTOCOLO ASIGNADO
        private void registrosProtocolosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrosProtocolos frm = new RegistrosProtocolos(tipoBD);
            frm.Show();
        }


        //*********************MUESTRA TODOS LOS REGISTROS QUE HAY EN PROTOCOLOS
        private void todosLosRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Todos los Registros";
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getFoliosProtocolos(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //**********************FILTRA LOS FOLIO POR MES DE FECHA COMERCIAL Y ESTATUS
        private void TcmbMesAsig_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int mes = TcmbMesAsig.SelectedIndex + 1;
            lblTipoFiltro.Text = "Asignados";

            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getProtocolosFiltroMes(tipoBD, mes, 1);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //**********************FILTRA LOS FOLIO POR MES DE FECHA COMERCIAL Y ESTATUS
        private void TcmbMesSinA_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int mes = TcmbMesSinA.SelectedIndex + 1;
            lblTipoFiltro.Text = "Sin Asignar";

            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getProtocolosFiltroMes(tipoBD, mes, 2);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


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

        private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(advancedDataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
            }
        }

        private void hoyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Hoy: " + DateTime.Now.ToLongDateString();
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getProtocolosHoy(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void semanaAnteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTipoFiltro.Text = "Semana Anteriror de: " + String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-7)) + " al " + String.Format("{0:dd/MM/yyyy}", DateTime.Now.AddDays(-1));
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getProtocolosSenamaAnt(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
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
                advancedDataGridView1.DataSource = objConsultasBD.getProtocolosMes(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
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
                advancedDataGridView1.DataSource = objConsultasBD.getProtocolosMesAnterior(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";

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
                advancedDataGridView1.DataSource = objConsultasBD.getProtocolosAntiguos(tipoBD);
                lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void asignadosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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
                    if (a.Value.ToString() == "Sin Asignar")
                    {
                        a.CellStyle.BackColor = Color.FromArgb(247, 67, 67);
                    }
                    if(advancedDataGridView1.Columns[a.ColumnIndex].Name == "gridFechaCoordinacion")
                    {
                        TimeSpan dif = Convert.ToDateTime(a.Value.ToString()) - DateTime.Now.Date;
                        int dias = dif.Days;

                        if (dias <= 2)
                        {
                            a.CellStyle.BackColor = Color.FromArgb(247, 121, 121);
                        }
                        if (dias == 3 || dias == 4)
                        {
                            a.CellStyle.BackColor = Color.FromArgb(247, 234, 121);
                        }
                        if (dias >= 5)
                        {
                            a.CellStyle.BackColor = Color.FromArgb(159, 247, 121);
                        }

                    }
                }
            }
        }



        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idActividad = Convert.ToInt32(advancedDataGridView1.Rows[Index].Cells["iDActividadDataGridViewTextBoxColumn"].Value);

            DetalleComentarios frm = new DetalleComentarios(idActividad, 0, tipoBD, 1);
            frm.Show();

        }


        //******************ABRE EL DIALOG PARA FILTRAR POR FECHA 
        private void rangoDeFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogFiltroFecha();
        }


        //*******************GENERA EL DIALOG CON LOS COMPONENTES Y SELECCION DE FECHAS
        public void  DialogFiltroFecha()
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
                    advancedDataGridView1.DataSource = objConsultasBD.getProtocoloFiltroFechas(tipoBD, fechaIni, fechaFin);
                    lblTipoFiltro.Text = "Rango de Fecha de: " + String.Format("{0:dd/MM/yyyy}", fechaIni) + " al " + String.Format("{0:dd/MM/yyyy}", fechaFin);
                    lblRegistros.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);  
                }               
                form1.Dispose();
            }
            else
            {
                MessageBox.Show("No se aplicara filtro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                form1.Dispose();
            }
        }
    }
}
