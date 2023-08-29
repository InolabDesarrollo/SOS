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
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class VerLlamadas : MaterialForm
    {
        public VerLlamadas(int BD)
        {
            InitializeComponent();
            tipoBD = BD;
        }

        int tipoBD;

        //**********Instancia de clase Consultas
        DataConsultas objConsultasBD = new DataConsultas();

        //SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        private void VerLlamadas_Load(object sender, EventArgs e)
        {
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getLlamadasInternas(tipoBD);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        string E_folio;
        

        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dvg = advancedDataGridView1.Rows[e.RowIndex];
            E_folio = (dvg.Cells[2].Value.ToString());


            Llamadas frm = new Llamadas(E_folio);
            frm.Show();
            //this.Close();
        }

        //private void advancedDataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs a)

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
                        a.CellStyle.BackColor = Color.Red;
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void todasLasLlamadasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void nuevaLlamadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LlamadaServicio frm = new LlamadaServicio(tipoBD);
            frm.Show();
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
