using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class TbVerAcuses : MaterialForm
    {
        //public delegate void FolioAcuseFSR(string folio);
        //public event FolioAcuseFSR F_Acuse;
        DataConsultas objConsultasBD = new DataConsultas();


        public TbVerAcuses(int BD, string FSR, int Bq)
        {
            InitializeComponent();
            tipoBD = BD;
            FolioFSR = FSR;
            buscaA = Bq;
        }

        int tipoBD, buscaA;
        int FolioAcuse, existe;
        string FolioFSR, tipoFolio, rutaAcuse, tipoAcuse;


        private void TbVerAcuses_Load(object sender, EventArgs e)
        {
            try
            {
                if(buscaA == 1)
                {
                    adgvListaAcuses.Visible = true;
                    adgvListaAcuseFirma.Visible = false;
                    adgvListaAcuses.DataSource = objConsultasBD.getAcusesDocument(tipoBD, FolioFSR, 1);
                    if(adgvListaAcuses.Rows.Count <= 0)
                    {
                        MessageBox.Show("El Folio no cuenta con Acuses Digitales", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    
                }
                if(buscaA == 2)
                {
                    adgvListaAcuseFirma.Visible = true;
                    adgvListaAcuses.Visible = false;
                    adgvListaAcuseFirma.DataSource = objConsultasBD.getAcusesDocument(tipoBD, FolioFSR, 2);
                    if(adgvListaAcuseFirma.Rows.Count <= 0)
                    {
                        MessageBox.Show("El Folio no cuenta con Acuses Adjunto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void adgvListaAcuses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            DataGridViewRow dgv = adgvListaAcuses.Rows[e.RowIndex];
            FolioAcuse = Convert.ToInt32(dgv.Cells["FolioAcuses"].Value);
            tipoFolio = dgv.Cells["TipoAcuses"].Value.ToString();

            if(tipoFolio == "FolioA_Inicial")
            {
                tipoAcuse = "AcuseInicial";
            }else if (tipoFolio.Equals("FolioA_CE1"))
            {
                tipoAcuse = "Acuse_CE1";
            }else if (tipoFolio.Equals("FolioA_CE2"))
            {
                tipoAcuse = "Acuse_CE2";
            }else if (tipoFolio.Equals("FolioA_CE3"))
            {
                tipoAcuse = "Acuse_CE3";
            }else if (tipoFolio.Equals("FolioA_CE4"))
            {
                tipoAcuse = "Acuse_CE4";
            }else if (tipoFolio.Equals("FolioA_CE5"))
            {
                tipoAcuse = "Acuse_CE5";
            }else if (tipoFolio.Equals("FolioA_CE6"))
            {
                tipoAcuse = "Acuse_CE6";
            }else if (tipoFolio.Equals("FolioA_CE7"))
            {
                tipoAcuse = "Acuse_CE7";
            }else if (tipoFolio.Equals("FolioA_CE8"))
            {
                tipoAcuse = "Acuse_CE8";
            }else if (tipoFolio.Equals("FolioA_CE9"))
            {
                tipoAcuse = "Acuse_CE9";
            }else if (tipoFolio.Equals("FolioA_CE10"))
            {
                tipoAcuse = "Acuse_CE10";
            }


            VerificaFolioA();
        }

        public void VerificaFolioA()
        {
            if(buscaA == 1)
            {
                try
                {
                    existe = objConsultasBD.getExisteAcuseDigital(tipoBD, FolioAcuse);
                    if (existe >= 1)
                    {
                        VerAcusePDF va = new VerAcusePDF(Convert.ToString(FolioAcuse));
                        va.Show();
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //if(buscaA == 2)
            //{
            //    try
            //    {
            //        existe = objConsultasBD.getExistenAcuses(tipoBD, tipoAcuse, Convert.ToString(FolioFSR));
            //        if(existe >= 1)
            //        {
            //            rutaAcuse = objConsultasBD.getRutasAcuses(tipoBD, tipoAcuse, Convert.ToString(FolioFSR));
            //            if(rutaAcuse != "")
            //            {
            //                Process.Start(rutaAcuse);
            //                this.Dispose();
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("La opcion seleccionada pertenece a un Acuse Digital.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        }
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            
        }


        private void adgvListaAcuseFirma_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }
            try
            {
                DataGridViewRow dgv = adgvListaAcuseFirma.Rows[e.RowIndex];
                string rutaA = dgv.Cells["Ruta"].Value.ToString();

                if(rutaA != "")
                {
                    Process.Start(rutaA);
                    this.Dispose();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al recuperar la ruta del archivo " + ex.Message + " " + ex.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
