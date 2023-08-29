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
    public partial class Cliente : MaterialForm
    {
        public delegate void EmpresaID(string empresa);
        public event EmpresaID p_empresid;
        public Cliente()
        {
            InitializeComponent();
        }

        //*********************LLAMA LAS CONSULTAS DE LA CLASE 
        DataConsultas objConsultasBD = new DataConsultas();

        private void Cliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter.Fill(this.browserDataSet.Clientes);
        }


        //*******************************REALIZA LA BUSQUEDA DEL CLIENTE 
        private void txtempresa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                dataGridView1.DataSource = objConsultasBD.setCliente(1, txtempresa.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //********************************TOMA EL DATO DEL GRID AL SELECCIONAR EL CONTENIDO
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow dvg = dataGridView1.Rows[e.RowIndex];
            p_empresid(dvg.Cells[0].Value.ToString());
            this.Close();
        }


        //************************************** ARE LA VENTANA PARA CREAR UN NUEVO CLIENTE
        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoCliente frm = new NuevoCliente();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cargar();
            }
        }


        //************************************ CARGA TODOS LOS CLIENTES 
        public void cargar()
        {
            this.clientesTableAdapter.Fill(this.browserDataSet.Clientes);
        }

        private void txtempresa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
