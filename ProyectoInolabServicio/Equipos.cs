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

    public partial class Equipos : MaterialForm
    {
        string empresaid;


        public delegate void EquipoID(string equipo);
        public event EquipoID p_equipoid;


        public Equipos(string idempresa)
        {
            InitializeComponent();
            empresaid = idempresa;
            //lblidempresa.Text =Convert.ToString(empresaid);
        }

        //***************************** LLAMA LAS CONSULTAS DE LA CLASE 
        DataConsultas objConsultasBD = new DataConsultas();


        private void Equipos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.V_Equipos' Puede moverla o quitarla según sea necesario.
            this.v_EquiposTableAdapter.equipoCliente(this.browserDataSet.V_Equipos, empresaid);
        }


        //*********************SELECCIONA EL DATO AL REALIZAR EL CLIC SOBRE LA CELDA
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            DataGridViewRow dvg = dataGridView1.Rows[e.RowIndex];
            p_equipoid(dvg.Cells[0].Value.ToString());           
            this.Close();
        }


        //*********************************** CARGA LOS DATOS DE LOS EQUIPOS EN EL GRID
        public void cargar()
        {
            try
            {
                dataGridView1.DataSource = objConsultasBD.setEquipoCliente(1, empresaid);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //************************** ABRE LA VENTANA PARA CREAR UN NUEVO EQUIPO
        private void nuevoEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NuevoEquipo frm = new NuevoEquipo(empresaid);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cargar();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
