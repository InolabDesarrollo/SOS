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
    public partial class RegistrosProtocolos : MaterialForm
    {
        public RegistrosProtocolos(int BD)
        {
            InitializeComponent();
            DoubleBuffered(advancedDataGridView1, true);
            tipoBD = BD;
        }


        //***********************VARIABLES
        string noLlamada;
        int tipoBD;


        //*********************CARGA EL RID CON LOS DATOS
        private void RegistrosProtocolos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.V_Protocolos' Puede moverla o quitarla según sea necesario.
            this.v_ProtocolosTableAdapter1.Fill(this.browserDataSet.V_Protocolos);
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.V_Protocolos' Puede moverla o quitarla según sea necesario.
            //this.v_ProtocolosTableAdapter.Fill(this.dSBrowser.V_Protocolos);
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


        //********************ABRE FORM PARA ACTUALIZAR LA INFORMACION DEL PROTOCOLO
        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow dvg = advancedDataGridView1.Rows[e.RowIndex];
            noLlamada = dvg.Cells[1].Value.ToString();

            ActualizaProtocolo frm = new ActualizaProtocolo(noLlamada, tipoBD);
            frm.Show();
        }
    }
}
