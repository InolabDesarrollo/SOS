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
    public partial class RegistroAcuses : MaterialForm
    {
        public RegistroAcuses(int BD)
        {
            InitializeComponent();
            tipoBD = BD;

            DoubleBuffered(advancedDataGridView1, true);
        }

        int tipoBD, Index, FolioAcuse;

        DataConsultas objConsultsBD = new DataConsultas();


        private void RegistroAcuses_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.V_AcusesDoc' Puede moverla o quitarla según sea necesario.
            //this.v_AcusesDocTableAdapter.Fill(this.browserDataSet.V_AcusesDoc);
            try
            {
                advancedDataGridView1.DataSource = objConsultsBD.getListaAcuses(tipoBD);
                lblTotalR.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public new static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }


        //********************* NUMERA LAS FILAS DEL GRID
        private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(advancedDataGridView1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10,
                e.RowBounds.Location.Y + 4);
            }
        }

        private void advancedDataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(string.IsNullOrEmpty(advancedDataGridView1.FilterString) == false)
            {
                lblTotalR.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
            else
            {
                lblTotalR.Text = advancedDataGridView1.Rows.Count.ToString() + " Registros";
            }
        }


        //************************ ABRE LA VENTANA PARA CREAR UN ACUSE DE CORRECCIONES
        private void generarAcuseDeCorreccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolioAcuse = Convert.ToInt32(advancedDataGridView1.Rows[Index].Cells["gridFolioFSR"].Value);
            AcuseCorreccionDoc correcion = new AcuseCorreccionDoc(tipoBD, FolioAcuse);
            correcion.Show();
        }


        //********************* DETERMINA LA POSICION DEL MOUSE PARA ABRIR EL MENU EN LA FILA CORRESPONDIENTE
        private void advancedDataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                advancedDataGridView1.Rows[e.RowIndex].Selected = true;
                Index = e.RowIndex;
                advancedDataGridView1.CurrentCell = advancedDataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                contextMenuStrip1.Show(advancedDataGridView1, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
