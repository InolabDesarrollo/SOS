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
    public partial class Up_CalendarioGeneral : MaterialForm
    {
        public Up_CalendarioGeneral(int BD)
        {
            InitializeComponent();
            tipoBD = BD;
        }


        //*************************VARIABLES
        int tipoBD;
        string fechaServ, motivo;
        int IdIng, folio, result;


        //************************** INSTANCIA CLASE DE CONSULTAS
        DataConsultas objConsultaBD = new DataConsultas();


        //************************** OBTIENE EL NOMBRE DE EQUIPO DEL USUARIO
        string name = System.Net.Dns.GetHostName();


        //******************************* CARGA OS DATOS
        private void Up_CalendarioGeneral_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Usuarios' Puede moverla o quitarla según sea necesario.
            this.usuariosTableAdapter1.FillByIng(this.browserDataSet.Usuarios);

            limpia();
            btnagregar.Enabled = false;
        }


        //
        private void btnActualizaCalendario_Click(object sender, EventArgs e)
        {
            guardar();
        }


        //************************** LIMPIA LOS CONTROLES
        public void limpia()
        {
            txtFolio.Text = null;
            cmbing.Text = null;
            txtMotivoR.Text = null;
        }


        //********************** AGREGA LOS DATOS AL GRID
        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFolio.Text))
            {
                MessageBox.Show("El campo Folio no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(txtMotivoR.Text))
            {
                MessageBox.Show("El campo Motivo de Reasignación no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int status = objConsultaBD.getEstatusFSR(tipoBD, txtFolio.Text);
                if(status == 3)
                {
                    MessageBox.Show("El Folio " + txtFolio.Text + " se encuentra Finalizado. No es posible Modificarlo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpia();

                }
                else
                {
                    dataGridView1.Rows.Add(txtFolio.Text, dtpfecha.Text, cmbing.Text, cmbing.SelectedValue, txtMotivoR.Text);
                    btnActualizaCalendario.Enabled = true;
                    limpia();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }


        //*************************** ACTUALIZA LA INFORMACION DEL FOLIO
        public void guardar()
        {           
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                fechaServ = row.Cells["FechaServicio"].Value.ToString();
                IdIng = Convert.ToInt32(row.Cells["Iding"].Value);
                folio = Convert.ToInt32(row.Cells["Folio"].Value);
                motivo = row.Cells["MotivoReasig"].Value.ToString();

                try
                {
                    result = objConsultaBD.UpdateCalendarioReasigna(tipoBD, fechaServ, IdIng, folio, name, motivo);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(result >= 1)
            {
                MessageBox.Show("Se han actualizado las Fechas de Servicio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpia();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                btnActualizaCalendario.Enabled = false;
                btnagregar.Enabled = false;
            }
        }

        private void dtpfecha_ValueChanged(object sender, EventArgs e)
        {
            //fservicio = dtpfecha.Text + " " + dtpHora.Text + ":00.000";
            //fservicio =Convert.ToString(dtpfecha.Text) + " 00:00:00.000";

        }


        //********************** ACTIVA EL BOTON DE AGREGADO AL CAMBIO DE INGENIERO 
        private void cmbing_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnagregar.Enabled = true;
        }
    }
}
