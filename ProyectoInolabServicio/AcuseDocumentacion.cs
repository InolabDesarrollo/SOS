using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Reporting.WinForms;

namespace ProyectoInolabServicio
{
    public partial class AcuseDocumentacion : MaterialForm
    {
        public AcuseDocumentacion(int BD)
        {
            InitializeComponent();
            //N_Responsable = Resp;
            //FolioFSR = folio;
            tipoBD = BD;
        }


        //**************** VARIABLES
        string codCliente;
        int tipoBD, dgv_D, folioA, cambioF;
        string fsr, fecha, atencion, depto, observaciones, direccion, telefono, empresa;
        int result;
        int exist, bandera;


        //************** INSTANCIA DE CLASE DE CONSULTAS
        DataConsultas objConsultaBD = new DataConsultas();


        //**********OBTIENE EL NOMBRE DE EQUIPO DEL USUARIO
        string hostname = System.Net.Dns.GetHostName();


        //**************** ACTUALIZA EL FOLIO CADA 5S.
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblFolio.Text = objConsultaBD.getFolioAcuse(tipoBD);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //******************** ACTIVA LA VISUALIZACION DEL TEXTBOX PARA COLOCAR FOLIO 
        private void chkbEnvio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbEnvio.Checked)
            {
                lblGuia.Visible = true;
                txtNoGuia.Visible = true;
            }
            else
            {
                lblGuia.Visible = false;
                txtNoGuia.Visible = false;
            }
        }

        private void cmbFolios_Click(object sender, EventArgs e)
        {
            cambioF = 1;
        }



        private void AcuseDocumentacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.V_Documentacion' Puede moverla o quitarla según sea necesario.
            //this.v_DocumentacionTableAdapter.Fill(this.browserDataSet.V_Documentacion);
            //Reporte();
            try
            {
                lblFolio.Text = objConsultaBD.getFolioAcuse(tipoBD);                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            timer1.Start();
        }


        //************************** ABRE VENTANA QUE MUESTRA LOS ACUSES CREADOS
        private void listaDeAcusesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroAcuses ra = new RegistroAcuses(tipoBD);
            ra.Show();
        }

        private void cmbClientes_Validating(object sender, CancelEventArgs e)
        {

        }


        //************************** VERIFICA QUE AL BUSCAR CLIENTE SOLO SE INTRODUZCAN LETRAS Y ESPACIOS
        private void cmbClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("No se Admiten Caracteres Especiales", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //********************** AL SELECCIONAR ALGUN FOLIO SE AGREGA AL GRID
        private void cmbFolios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cambioF == 1)
            {
                string folio = cmbFolios.Text;
                dgv_D = 1;

                int partida = Convert.ToInt32(adgvDatosFolios.Rows.Count) + 1;

                try
                {
                    SqlDataReader leer;

                    leer = objConsultaBD.setDatosFolioA(tipoBD, folio);
                    if (leer.Read())
                    {
                        adgvDatosFolios.Rows.Add(leer["Folio"].ToString(), leer["TipoServicio"].ToString(), leer["Equipo"].ToString(), leer["NoSerie"].ToString());
                        btnVistaP.Enabled = true;
                        btnGuardar.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        //************************ AL PRESIONAR ENTER SE MUESTRAN LOS RESULTADOS EN EL COMBO
        private void cmbClientes_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                cmbClientes.DisplayMember = "Cliente";
                cmbClientes.ValueMember = "CodCliente";

                try
                {
                    //cmbClientes.Visible = true;
                    cmbClientes.DataSource = objConsultaBD.getClientesAcuse(tipoBD, cmbClientes.Text);
                    
                    if (cmbClientes.Items.Count < 1)
                    {
                        MessageBox.Show("No se encontraron resultados similares", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    codCliente = cmbClientes.SelectedValue.ToString();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }


        //******************************* AL CAMBIAR DE CLIENTE SE CARGAN LOS DATOS CORRESPONDIENTES AL CLIENTE EN LOS COMBOS
        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambioF = 0;
            codCliente = cmbClientes.SelectedValue.ToString();
            CargaDatos();
            //MessageBox.Show("cliente " + codCliente);
        }


        //*********************** ABRE LA VISTA PREVIA DE ACUSE DIGITAL 
        private void btnVistaP_Click(object sender, EventArgs e)
        {
            VerAcusePDF va = new VerAcusePDF(lblFolio.Text);
            va.Show();
        }


        //*********************** VERIFICA QUE LOS CAMPOS NO ESTEN VACIOS 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //dgv_D == 1
            if (string.IsNullOrEmpty(cmbClientes.Text))
            {
                MessageBox.Show("No se ha seleccionado Cliente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(cmbDireccion.Text))
            {
                MessageBox.Show("El Campo Dirección no puede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(cmbTelefono.Text))
            {
                MessageBox.Show("El Campo Telefono no puede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(cmbResponsable.Text))
            {
                MessageBox.Show("El Campo Atención no puede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(cmbDepartamento.Text))
            {
                MessageBox.Show("El Campo Departamento no puede estar vacío", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Guardado();
        }


        //********************************** GUARDA LOS DATOS DEL ACUSE
        public void Guardado()
        {
            if (adgvDatosFolios.Rows.Count >= 1)
            {
                //MessageBox.Show(cmbClientes.SelectedValue + "");

                int e = ExisteInicialF();
                if (e >= 1)
                {
                    MessageBox.Show("Ya se ha creado un Acuse Inicial para este Folio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bandera = 0;
                    return;
                }
                else
                {
                    for (int i = 0; i < adgvDatosFolios.Rows.Count; i++)
                    {
                        folioA = Convert.ToInt32(lblFolio.Text);
                        fsr = adgvDatosFolios.Rows[i].Cells["Folio"].Value.ToString();
                        fecha = dtpFechaAcuse.Value.ToString();
                        atencion = cmbResponsable.Text;
                        depto = cmbDepartamento.Text;
                        observaciones = txtObservaciones.Text;
                        direccion = cmbDireccion.Text;
                        telefono = cmbTelefono.Text;
                        empresa = cmbClientes.Text;

                        try
                        {
                            if (chkbEnvio.Checked)
                            {
                                result = objConsultaBD.SaveAcuse(tipoBD, folioA, fsr, empresa, direccion, atencion, depto, fecha, observaciones, TestSpire.Usr.K, hostname, telefono, txtNoGuia.Text);
                                GuardaGuiaDoc();
                                UpdateFolioAcuseDoc();
                            }
                            else
                            {
                                result = objConsultaBD.SaveAcuse(tipoBD, folioA, fsr, empresa, direccion, atencion, depto, fecha, observaciones, TestSpire.Usr.K, hostname, telefono, "");
                                UpdateFolioAcuseDoc();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (result == 1)
                    {
                        MessageBox.Show("Acuse Guardado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VerAcusePDF va = new VerAcusePDF(Convert.ToString(folioA));
                        va.Show();
                        btnGuardar.Enabled = false;
                        //Limpiar();
                        bandera = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se han agregado Folios.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        //************************* OBTIENE Y CARGA LOS DATOS PARA LOS COMBOS
        public void CargaDatos()
        {
            cmbDepartamento.Enabled = true;
            cmbDepartamento.DisplayMember = "Departamento";

            cmbResponsable.Enabled = true;
            cmbResponsable.DisplayMember = "N_Responsable";

            cmbFolios.Enabled = true;
            cmbFolios.DisplayMember = "Folio";

            cmbDireccion.Enabled = true;
            cmbDireccion.DisplayMember = "Direccion";

            cmbTelefono.Enabled = true;
            cmbTelefono.DisplayMember = "Telefono";

            try
            {
                cmbResponsable.DataSource = objConsultaBD.getResponsableAcuses(tipoBD, codCliente);
                cmbDepartamento.DataSource = objConsultaBD.getDeptoAcuse(tipoBD, codCliente);
                cmbDireccion.DataSource = objConsultaBD.getDireccionClienteA(tipoBD, codCliente);
                cmbTelefono.DataSource = objConsultaBD.getTelefonoAcuse(tipoBD, codCliente);
                cmbFolios.DataSource = objConsultaBD.getFoliosAcuse(tipoBD, codCliente, cmbClientes.Text);

                cmbFolios.Text = "";
                //cmbFolios.SelectedItem = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //**************************** REALIZA UPDATE CON GUIA EN DOCUMENTACION
        int r;
        public void GuardaGuiaDoc()
        {            
            try
            {   
                r = objConsultaBD.updateGuiaDocumentacion(tipoBD, txtNoGuia.Text, fsr);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        //*********************** REALIZA UPDATE DE FOLIO A ACUSE DOCUMENTACION
        public void UpdateFolioAcuseDoc()
        {
            int resultado;
            try
            {
                resultado = objConsultaBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_Inicial", lblFolio.Text, fsr);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        public int ExisteInicialF()
        {            
            for (int i = 0; i < adgvDatosFolios.Rows.Count; i++)
            {                
                try
                {
                    fsr = adgvDatosFolios.Rows[i].Cells["Folio"].Value.ToString();

                    exist = objConsultaBD.getExisteFolioInicial(tipoBD, fsr);
                    bandera += exist;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return bandera;
        }


        //********************* LIMPIA TODOS LOS CONTENEDORES
        public void Limpiar()
        {
            cmbClientes.Text = null;
            cmbDireccion.Text = null;
            cmbResponsable.Text = null;
            cmbDepartamento.Text = null;
            cmbTelefono.Text = null;
            chkbEnvio.Checked = false;
            txtNoGuia.Text = null;
            txtObservaciones.Text = null;
            dgv_D = 0;

            adgvDatosFolios.Rows.Clear();
            adgvDatosFolios.Refresh();
        }
    }
}
