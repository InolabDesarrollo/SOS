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
    public partial class ActualizaProtocolo : MaterialForm
    {
        public ActualizaProtocolo(string llamada, int BD)
        {
            InitializeComponent();
            NoLlamada = llamada;
            tipoBD = BD;
        }

        //********************VARIALES
        string NoLlamada, tipo_F, IdActiv, Estatus, Realiza;
        int IdEstatus, IdRealiza, tipoBD;
        int IdE, IdR, cont;
        string Est, Rsp;



        //********************INSTANCIA PARA CALSE D CONSULTAS
        DataConsultas objConsultasBD = new DataConsultas();
               

        private void ActualizaProtocolo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.V_LlamadasSAP' Puede moverla o quitarla según sea necesario.
            this.v_LlamadasSAPTableAdapter.Fill(this.browserDataSet.V_LlamadasSAP);
            // TODO: esta línea de código carga datos en la tabla 'browserDataSet.Llamadas_SAP2' Puede moverla o quitarla según sea necesario.
            //this.llamadas_SAP2TableAdapter.Fill(this.browserDataSet.Llamadas_SAP2);

            CargaDatosCliente();
            CargaDatosServicio();
            vistaP();
            UFolioP();
        }


        //***********************MUESTRA DATOS DEL CLIENTE DE LA LLAMADA
        public void CargaDatosCliente()
        {
            SqlDataReader leer;
            try
            {
                leer = objConsultasBD.setDatosClienteP(tipoBD, NoLlamada);
                if (leer.Read())
                //si trae datos
                {
                    txtLlamada.Text = Convert.ToString(leer["NoLlamada"]);
                    txtCliente.Text = Convert.ToString(leer["ClienteFiscal"]);
                    txtDireccion.Text = Convert.ToString(leer["Calle"]) + " Col. " + Convert.ToString(leer["Colonia"]) + " C.P. " + Convert.ToString(leer["CP"]) + ", " + Convert.ToString(leer["Ciudad"]);
                    txtTelefono.Text = Convert.ToString(leer["Telefono"]);
                    txtResponsable.Text = Convert.ToString(leer["Nombre"]);
                    txtMailResp.Text = Convert.ToString(leer["Correo"]);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }


        //********************CARGA GRID CON LOS SERVICIOS QUE REQUIEREN PROTOCOLO
        public void CargaDatosServicio()
        {
            try
            {
                advancedDataGridView1.DataSource = objConsultasBD.getDatosServicioP(tipoBD, NoLlamada);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        //********************BUSCA SI LA ACTIVIDAD ESTA DENTRO DEL REGISTRO DE PROTOCOLOS Y MUESTRA SU ESTATUS Y RESPONSABLE 
        public void vistaP()
        {//VERIFICAR EL DATO DE LA FECHA COMERCIAL 
            int count;

            try
            {
                for (int i = 0; i < advancedDataGridView1.Rows.Count; i++)
                {
                    if (advancedDataGridView1.Rows != null && advancedDataGridView1.Rows.Count != 0)
                    {
                        IdActiv = Convert.ToString(advancedDataGridView1.Rows[i].Cells["IDActividad"].Value);

                        try
                        {
                            count = objConsultasBD.getExisteProtocolo(tipoBD, IdActiv);

                            if (count >= 1)
                            {
                                SqlDataReader leer;
                                leer = objConsultasBD.getDatosActivP(tipoBD, IdActiv);
                                if (leer.Read())
                                {
                                    if (leer.IsDBNull(6))
                                    {
                                        advancedDataGridView1.Rows[i].Cells["cmbRealiza"].Value = "";
                                    }
                                    else
                                    {
                                        IdR = Convert.ToInt32(leer["IdRealiza"]);
                                        if (IdR == 41) { Rsp = "Bianca"; }
                                        if (IdR == 45) { Rsp = "Fernanda"; }
                                        if (IdR == 72) { Rsp = "Monica"; }
                                        if (IdR == 111) { Rsp = "Maria Fernanda"; }
                                        if (IdR == 112) { Rsp = "Ricardo"; }
                                        if(IdR == 133) { Rsp = "Clara Lizbeth"; }
                                    }
                                    if (leer.IsDBNull(4))
                                    {
                                        advancedDataGridView1.Rows[i].Cells["cmbEstatusP"].Value = "";
                                    }
                                    else
                                    {
                                        IdE = Convert.ToInt32(leer["IdEstatus"]);
                                        if (IdE == 14) { Est = "Sin Asignar"; }
                                        if (IdE == 6) { Est = "Realizando"; }
                                        if (IdE == 8) { Est = "Revision"; }
                                        if (IdE == 13) { Est = "Correccion"; }
                                        if (IdE == 17) { Est = "Aprobado"; }
                                        if (IdE == 15) { Est = "Enviado electronico"; }
                                        if (IdE == 16) { Est = "Enviado Fisico"; }
                                    }
                                }

                                advancedDataGridView1.Rows[i].Cells["cmbEstatusP"].Value = Est;
                                advancedDataGridView1.Rows[i].Cells["cmbRealiza"].Value = Rsp;
                            }
                            else
                            {
                                advancedDataGridView1.Rows[i].Cells["cmbEstatusP"].Value = "";
                                advancedDataGridView1.Rows[i].Cells["cmbRealiza"].Value = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar grid: " + ex.Message + " - " + ex.ToString());
            }
            
        }      


        //**********************LLAMA FUNCION DE GUARDADO INSERT-UPDATE
        private void btnActualizar_Click(object sender, EventArgs e)
        {         
            Existe();
        }


        //***********************ACTUALIZA EL FOLIO DE PROTOCOLO CADA 5S
        private void timer1_Tick(object sender, EventArgs e)
        {
            UFolioP();
        }


        //************************ASIGNA VALOR AL ESTATUS DEPENDIENDO DE SELECCION
        private void cmbEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int s_status = cmbEstatus.SelectedIndex;
        }


        //************************ASIGNA VALOR A RSPONSABLE DEPENDIENDO SELECCION
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sR = comboBox1.SelectedIndex;
        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
        }


        //******************REALIZA EL UPDATE AL FOLIO EN CASO DE SER REQUERIDO
        public void UpdateP()
        {
            int result;

            try
            {
                result = objConsultasBD.UpdateProtocolo(tipoBD, IdEstatus, IdRealiza, tipo_F, IdActiv);

                if(result == 1)
                {
                    MessageBox.Show("Llamada No. " + NoLlamada + " se ha actualizado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnActualizar.Visible = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //***********************REALIZA EL INSERT AL FOLIO EN CASO DE SER REQUERIDO
        public void SaveP()
        {
            int result;
            UFolioP();

            try
            {
                result = objConsultasBD.SaveProtocolo(tipoBD, tipo_F, txtLlamada.Text, lblProto.Text, IdEstatus, IdRealiza, IdActiv);

                if(result == 1)
                {
                    MessageBox.Show("Se ha guardado la llamada " + txtLlamada.Text + " para Protocolos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //********************BUSCA EL REGISTRO EN PROTOCOLOS PARA REALIZAR UN UPDATE O UN INSERTE DEPENDIENDO SI EXISTE O NO        
        public void Existe()
        {
            for (int i = 0; i < advancedDataGridView1.Rows.Count; i++)
            {
                //Comprobamos el grid de los servicios no este vacio
                if (advancedDataGridView1.Rows != null && advancedDataGridView1.Rows.Count != 0)
                {
                    try
                    {
                        cont = objConsultasBD.getExisteProtocolo(tipoBD, advancedDataGridView1.Rows[i].Cells["IDActividad"].Value.ToString());

                        //Obtenemos los valores necesarios para el guardado
                        Estatus = Convert.ToString(advancedDataGridView1.Rows[i].Cells["cmbEstatusP"].Value);
                        IdActiv = Convert.ToString(advancedDataGridView1.Rows[i].Cells["IDActividad"].Value);
                        Realiza = Convert.ToString(advancedDataGridView1.Rows[i].Cells["cmbRealiza"].Value);

                        //comparamos valores del grid para asignar Id
                        if (Realiza == "Bianca")
                        {
                            IdRealiza = 41;
                        }
                        else if (Realiza == "Fernanda")
                        {
                            IdRealiza = 45;
                        }
                        else if (Realiza == "Monica")
                        {
                            IdRealiza = 72;
                        }
                        else if(Realiza == "Maria Fernanda")
                        {
                            IdRealiza = 111;
                        }
                        else if(Realiza == "Ricardo")
                        {
                            IdRealiza = 112;
                        }
                        else if(Realiza == "Clara Lizbeth")
                        {
                            IdRealiza = 133;
                        }

                        //Comparamos estatus para asignar Id
                        if (Estatus == "Sin Asignar")
                        {
                            IdEstatus = 14;
                            tipo_F = "F_SinAsignar";
                        }
                        else if (Estatus == "Realizando")
                        {
                            IdEstatus = 6;
                            tipo_F = "F_Realizando";
                        }
                        else if (Estatus == "Revision")
                        {
                            IdEstatus = 8;
                            tipo_F = "F_Revision";
                        }
                        else if (Estatus == "Correccion")
                        {
                            IdEstatus = 13;
                            tipo_F = "F_Correccion";
                        }
                        else if (Estatus == "Aprobado")
                        {
                            IdEstatus = 17;
                            tipo_F = "F_Aprobado";
                        }
                        else if (Estatus == "Enviado electronico")
                        {
                            IdEstatus = 15;
                            tipo_F = "F_EnvioE";
                        }
                        else if (Estatus == "Enviado Fisico")
                        {
                            IdEstatus = 16;
                            tipo_F = "F_EnvioF";
                        }

                        //Revisamos si el contador encuentra los registros hace update, si es 0 hace insert
                        if (cont >= 1)
                        {
                            UpdateP();
                        }
                        else
                        {
                            SaveP();
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        //**********************BUSCA EL FOLIO CONTINUO PARA LA NUEVA ASIGNACION
        public void UFolioP()
        {
            try
            {
                lblProto.Text = objConsultasBD.getUltimoFolioP(tipoBD);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
