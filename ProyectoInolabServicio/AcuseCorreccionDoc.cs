using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class AcuseCorreccionDoc : MaterialForm
    {
        public AcuseCorreccionDoc(int BD, int Folio)
        {
            InitializeComponent();
            tipoBD = BD;
            //Folio_Acuse = acuse;
            f = Folio;
        }


        //********************** VARIABLE 
        int tipoBD, Folio_Acuse, f;
        int folioA, cambioF;
        string fsr, cliente, direccion, atencion, depto, fechaA, observaciones, telefono;
        string codCliente;
        
        //********************* INSTANCIA DE CLASE CONSULTAS
        DataConsultas objConsultasBD = new DataConsultas();


        //******************** OBTIENE EL NOMBRE DE EQUIPO DEL USUARIO
        string hostname = System.Net.Dns.GetHostName(); 

        //********************* HACE VISIBLE EL TEXTBOX PARA COLOCAR GUIA O FOLIO
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


       
        private void AcuseCorreccionDoc_Load(object sender, EventArgs e)
        {
            try
            {
                //txtAcuseAnterior.Text = Convert.ToString(Folio_Acuse);
                lblFolio.Text = objConsultasBD.getFolioAcuse(tipoBD);
                ExisteEnAcuses();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            timer1.Start();
            //CargaDatosCliente();
        }


        //****************** AL PRESIONAR ENTER BUSCA LOS DATOS CORRECPONDIENTES AL FOLIO DEL ACUSE
        private void txtAcuseAnterior_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                CargaDatosCliente();
            }
        }


        //*************************** CARGA LOS DATOS CORRESPONDIENTES AL ACUSE
        public void CargaDatosCliente()
        {
            try
            {
                SqlDataReader leer;
                leer = objConsultasBD.setDatosClienteAcuse(tipoBD, Convert.ToInt32(txtAcuseAnterior.Text));

                if (leer.Read())
                {
                    txtCliente.Text = leer["Empresa"].ToString();
                    txtDireccion.Text = leer["Direccion"].ToString();
                    txtTelefono.Text = leer["Telefono"].ToString();
                    txtAtencion.Text = leer["Atencion"].ToString();
                    txtDepto.Text = leer["Depto"].ToString();
                    txtObservaciones.Text = leer["Observaciones"].ToString();
                }
                else
                {
                    Limpiar();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargaDatosFolios();           
        }


        //******************************* ABRE LA VENTANA PARA LA VISTA PREVIA DEL ACUSE DIGITAL
        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            folioA = Convert.ToInt32(lblFolio.Text);
            VerAcusePDF va = new VerAcusePDF(Convert.ToString(folioA));
            va.Show();
        }


        //************************** CARGA DATOS DEL FSR
        public void CargaDatosFolios()
        {
            try
            {
                adgvFoliosAcuse.DataSource = objConsultasBD.getDatosFoliosAcuse(tipoBD, Convert.ToInt32(txtAcuseAnterior.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //*************************** ACTUALZIZA EL FOLIO DE ACUSE CADA 5S
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblFolio.Text = objConsultasBD.getFolioAcuse(tipoBD);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //******************************* GUARDA LOS DATOS EN ACUSE FOLIO
        int resul;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("El campo Cliente nopuede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("El campo Dirección no puede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                MessageBox.Show("El campo Telefono no puede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtAtencion.Text))
            {
                MessageBox.Show("El campo Atención no puede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtDepto.Text))
            {
                MessageBox.Show("El campo Departamento no puede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(adgvFoliosAcuse.Rows.Count <= 0)
            {
                MessageBox.Show("No se han agregado Folios.", "Inofrmación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(chkbEnvio.Checked && string.IsNullOrEmpty(txtNoGuia.Text))
            {
                MessageBox.Show("El Campo Guia no puede estar vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }     

            GuardaDatosA();
        }

        private void cmbFolios_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cambioF == 1)
            {
                try
                {
                    string folio = cmbFolios.Text;

                    SqlDataReader leer;

                    leer = objConsultasBD.setDatosFolioA(tipoBD, folio);
                    if (leer.Read())
                    {
                        adgvFoliosAcuse.Rows.Add(leer["Folio"].ToString(), leer["TipoServicio"].ToString(), leer["Equipo"].ToString(), leer["NoSerie"].ToString());
                        //btnVistaP.Enabled = true;
                        btnGuardar.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }

        private void cmbFolios_Click(object sender, EventArgs e)
        {
            cambioF = 1;
        }


        //************************ LIMPIA LOS CONTROLES
        public void Limpiar()
        {
            txtCliente.Text = null;
            txtDireccion.Text = null;
            txtTelefono.Text = null;
            txtAtencion.Text = null;
            txtDepto.Text = null;
            txtObservaciones.Text = null;
        }


        public void GuardaDatosA()
        {
            if (adgvFoliosAcuse.Rows.Count >= 1)
            {
                for (int i = 0; i < adgvFoliosAcuse.Rows.Count; i++)
                {
                    folioA = Convert.ToInt32(lblFolio.Text);
                    fsr = adgvFoliosAcuse.Rows[i].Cells["FolioFSR"].Value.ToString();
                    cliente = txtCliente.Text;
                    direccion = txtDireccion.Text;
                    atencion = txtAtencion.Text;
                    depto = txtDepto.Text;
                    fechaA = dtpFecha.Value.ToString();
                    observaciones = txtObservaciones.Text;
                    telefono = txtTelefono.Text;

                    CuentaAcuses();
                    if (conteo >= 11 || conteoFis >= 11)
                    {
                        MessageBox.Show("Se han creado los Folios de Correcciones Permitidos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        if (chkbEnvio.Checked)
                        {                            
                            resul = objConsultasBD.SaveAcuse(tipoBD, folioA, fsr, cliente, direccion, atencion, depto, fechaA, observaciones, TestSpire.Usr.K, hostname, telefono, txtNoGuia.Text);
                            GuardaGuiaDoc();
                            UpdateFolioAcuseDoc();
                        }
                        else
                        {                            
                            resul = objConsultasBD.SaveAcuse(tipoBD, folioA, fsr, cliente, direccion, atencion, depto, fechaA, observaciones, TestSpire.Usr.K, hostname, telefono, "");
                            UpdateFolioAcuseDoc();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
                if (resul == 1)
                {
                    MessageBox.Show("Acuse Guardado Correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VerAcusePDF va = new VerAcusePDF(Convert.ToString(folioA));
                    va.Show();
                    btnGuardar.Enabled = false;
                }
            }
        }


        //******************************* GUARDA LA GUIA EN DOCUMENTACION
        int r;
        public void GuardaGuiaDoc()
        {
            try
            {
                r = objConsultasBD.updateGuiaDocumentacion(tipoBD, txtNoGuia.Text, fsr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //***************************** VERIFICA CUANTOS FOLIOS DE ACUSES EXISTEN EN DOCUMENTACION PARA GUARDAR EN EL CONSECUTIVO 
        int conteo, conteoFis;
        public void UpdateFolioAcuseDoc()
        {
            int resultado;
           
            try
            {
                conteo = objConsultasBD.getConteoFoliosAcuse(tipoBD, fsr, 1) -1;
                conteoFis = objConsultasBD.getConteoFoliosAcuse(tipoBD, fsr, 2);
                if(conteo == 1 || conteoFis == 1)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE1", lblFolio.Text, fsr);
                }
                if(conteo == 2 || conteoFis == 2)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE2", lblFolio.Text, fsr);
                }
                if(conteo == 3 || conteoFis == 3)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE3", lblFolio.Text, fsr);
                }
                if(conteo == 4 || conteoFis == 4)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE4", lblFolio.Text, fsr);
                }
                if(conteo == 5 || conteoFis == 5)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE5", lblFolio.Text, fsr);
                }
                if(conteo == 6 || conteoFis == 6)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE6", lblFolio.Text, fsr);
                }
                if(conteo == 7 || conteoFis == 7)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE7", lblFolio.Text, fsr);
                }
                if(conteo == 8 || conteoFis == 8)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE8", lblFolio.Text, fsr);
                }
                if(conteo == 9 || conteoFis == 9)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE9", lblFolio.Text, fsr);
                }
                if(conteo == 10 || conteoFis == 10)
                {
                    resultado = objConsultasBD.UpdateFolioAcuseDoc(tipoBD, "FolioA_CE10", lblFolio.Text, fsr);
                }
                if(conteo >= 11)
                {
                    MessageBox.Show("Se ha creado el Máximo de Folios de Correcciones Permitidos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //***************************** DETERMILA LA CANTIDAD DE ACUSES QUE EXISTEN EN EL FOLIO
        public void CuentaAcuses()
        {
            try
            {
                conteo = objConsultasBD.getConteoFoliosAcuse(tipoBD, fsr, 1);
                conteoFis = objConsultasBD.getConteoFoliosAcuse(tipoBD, fsr, 2);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExisteEnAcuses()
        {
            int e;
            try
            {
                e = objConsultasBD.getExistEnAcuseD(tipoBD, Convert.ToString(f));
                if(e >= 1)
                {
                    Folio_Acuse = objConsultasBD.getBuscaUFolioAcuse(tipoBD, Convert.ToString(f));
                    txtAcuseAnterior.Text = Convert.ToString(Folio_Acuse);
                    cmbFolios.Enabled = false;
                    CargaDatosCliente();
                    btnGuardar.Enabled = true;
                }
                else
                {
                    SqlDataReader leer;
                    txtAcuseAnterior.Text = "";
                    txtAcuseAnterior.Enabled = false;
                    leer = objConsultasBD.setDatosAcuseFisico(tipoBD, f);
                    if (leer.Read())
                    {
                        codCliente = leer["CodCliente"].ToString();
                        txtCliente.Text = leer["Cliente"].ToString();
                        txtDireccion.Text = leer["Direccion"].ToString();
                        txtDepto.Text = leer["Departamento"].ToString();
                        txtAtencion.Text = leer["N_Responsable"].ToString();
                        txtTelefono.Text = leer["Telefono"].ToString();                        
                    }                    
                }
                LlenaFolios();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LlenaFolios()
        {
            try
            {
                cmbFolios.Enabled = true;
                cmbFolios.DisplayMember = "Folio";

                cmbFolios.DataSource = objConsultasBD.getFoliosAcuse(tipoBD, codCliente, txtCliente.Text);

                cmbFolios.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
