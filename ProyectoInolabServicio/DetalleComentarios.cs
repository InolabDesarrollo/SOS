using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class DetalleComentarios : MaterialForm
    {
        public DetalleComentarios(int IdAct, int folio, int BD, int tipo)
        {
            InitializeComponent();

            IdActividad = IdAct;
            tipoBD = BD;
            tipoConsul = tipo;
            FSR = folio;
        }

        //*************************VARIABLES
        int IdActividad, tipoBD, tipoConsul, FSR;


        //**************************CASE DE CONSULTAS
        DataConsultas ObjConsultasBD = new DataConsultas();


        //************************CARGA EL COMENTARIO EN LA CAJA DE TEXTO
        private void DetalleProtocolo_Load(object sender, EventArgs e)
        {
            try
            {
                if(tipoConsul == 1)
                {
                    txtComentarios.Text = ObjConsultasBD.getComentariosLlamada(IdActividad, tipoBD);
                }
                if(tipoConsul == 2)
                {
                    txtComentarios.Text = ObjConsultasBD.getComentPrerrequisitos(tipoBD, IdActividad);
                }
                if(tipoConsul == 3)
                {
                    txtComentarios.Text = ObjConsultasBD.getComentFolio(tipoBD, IdActividad);
                }
                if(tipoConsul == 4)
                {
                    txtComentarios.Text = ObjConsultasBD.getObservacionesFSR(tipoBD, FSR);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
