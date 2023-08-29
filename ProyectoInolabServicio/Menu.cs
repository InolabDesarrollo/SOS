using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class Menu : MaterialForm
    {
        public Menu(int BD)
        {
            InitializeComponent();
            //asigna variables que vienen del formulario Sesion
            tipoBD = BD;
            
            if(tipoBD == 2)
            {
                MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                // Configurar esquema de color
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Pink600, Primary.Pink900, Primary.Pink400, Accent.Pink100, TextShade.WHITE);
            }
        }

        DataConsultas objConsultasBD = new DataConsultas();


        //**************************** VARIABLES
        int tipoBD;
        string N_Folio, N_Cliente, N_Fecha, N_Comentario;
        DateTime fechad;



        private void Menu_Load(object sender, EventArgs e)
        {
            //muestra en que base se encuentra
            if(tipoBD == 1)
            {
                lblBaseD.Text = "Producción";
                lblBaseD.Font = new Font(lblBaseD.Font.Name, 7);
                lblBaseD.ForeColor = Color.White;
            }
            if(tipoBD == 2)
            {
                lblBaseD.Text = "Pruebas";
                lblBaseD.Font = new Font(lblBaseD.Font.Name, 8);
                lblBaseD.ForeColor = Color.White;
            }
            AccesoArea();

            lblUsuario.Text = TestSpire.Usr.K + " - " + TestSpire.Usr.Nombre;

            Inicio_Noti();
        }



        //************************ CIERRA EL FORMULARIO Y DETIENE EL PROGRAMA
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result;
            //result = MessageBox.Show("Esta seguro que desea salir de la Aplicación", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //if (result == System.Windows.Forms.DialogResult.Yes)
            //{
            //    Application.Exit();
            //    //this.Close();
            //}
            //if (result == System.Windows.Forms.DialogResult.No)
            //{
            //    e.Cancel = true;
            //    return;
            //}
        }
        
        

        private void btnccacyac_Click(object sender, EventArgs e)
        {
            CCAYAC frm = new CCAYAC();
            frm.Show();
        }



        private void btnLlamaSap_Click(object sender, EventArgs e)
        {
            RegistrosSAP frm = new RegistrosSAP(tipoBD);
            frm.Show();

            //Muestra reporte a usuarios especificos
            if( TestSpire.Usr.K == 76 || TestSpire.Usr.K == 8 || TestSpire.Usr.K == 91 || TestSpire.Usr.K == 88 || TestSpire.Usr.K == 71 )
            {
                ReporteLlamadas_Mensual rm = new ReporteLlamadas_Mensual();
                rm.Show();
            }            
        }

        private void btnRFsr_Click(object sender, EventArgs e)
        {
            Folios frm = new Folios(tipoBD);
            frm.Show();
        }

        private void btnLLInter_Click(object sender, EventArgs e)
        {
            //LlamadaServicio frm = new LlamadaServicio(tipoBD);
            //frm.Show();
        }

        private void btnRLlamI_Click(object sender, EventArgs e)
        {
            VerLlamadas frm = new VerLlamadas(tipoBD);
            frm.Show();
        }

        private void btnCGeneral_Click(object sender, EventArgs e)
        {
            CalendarioGeneral frm = new CalendarioGeneral(tipoBD);
            frm.Show();
        }

        private void btnCPlaneado_Click(object sender, EventArgs e)
        {
            CalendarioPlaneacion frm = new CalendarioPlaneacion();
            frm.Show();
        }

        private void btnRFsrAnt_Click(object sender, EventArgs e)
        {
            NuevoFSR frm = new NuevoFSR();
            frm.Show();
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {            
            if (TestSpire.Usr.K == 33 || TestSpire.Usr.K == 36 || TestSpire.Usr.K == 37 || TestSpire.Usr.K == 62 || TestSpire.Usr.K == 75 || TestSpire.Usr.K == 76 || TestSpire.Usr.K == 85
                || TestSpire.Usr.K == 101 || TestSpire.Usr.K == 104 || TestSpire.Usr.K == 107 || TestSpire.Usr.K == 108 || TestSpire.Usr.K == 128 || TestSpire.Usr.K == 129 || TestSpire.Usr.K == 130 ||
                TestSpire.Usr.K == 72 || TestSpire.Usr.K == 45 || TestSpire.Usr.K == 41 || TestSpire.Usr.K == 105 || TestSpire.Usr.K == 112 || TestSpire.Usr.K == 132 || TestSpire.Usr.K == 135 || TestSpire.Usr.K == 136 || TestSpire.Usr.K == 137)
            {
                RegistrosDocumentacion f = new RegistrosDocumentacion(tipoBD);
                f.Show();
            }
            else
            {
                FoliosDocumentacion frm = new FoliosDocumentacion(tipoBD);
                frm.Show();
            }
        }

        private void btnProto_Click(object sender, EventArgs e)
        {            
            FoliosProtocolos frm = new FoliosProtocolos(tipoBD);
            frm.Show();
        }

        private void btnPrerequisitos_Click(object sender, EventArgs e)
        {
            FoliosPrerrequisitos fpr = new FoliosPrerrequisitos(tipoBD);
            fpr.Show();
        }

        private void btnCalendarioDias_Click(object sender, EventArgs e)
        {
            CalendarioDias frm = new CalendarioDias(tipoBD);
            frm.Show();
        }

        private void btnCCAYAC_Click(object sender, EventArgs e)
        {
            CCAYAC frm = new CCAYAC();
            frm.Show();
        }


        //**************************** ACCESO A USUARIOS POR ID
        public void AccesoArea()
        {
            //DOCUMENTACION
            if (TestSpire.Usr.K == 33 || TestSpire.Usr.K == 35 || TestSpire.Usr.K == 36 || TestSpire.Usr.K == 37 || TestSpire.Usr.K == 40 || TestSpire.Usr.K == 62 || TestSpire.Usr.K == 76 
                || TestSpire.Usr.K == 85 || TestSpire.Usr.K == 101 || TestSpire.Usr.K == 104 || TestSpire.Usr.K == 107 || TestSpire.Usr.K == 108 || TestSpire.Usr.K == 128 || TestSpire.Usr.K == 129 || TestSpire.Usr.K == 130 
                || TestSpire.Usr.K == 135 || TestSpire.Usr.K == 136 || TestSpire.Usr.K == 137 || TestSpire.Usr.K == 75)
            {
                btnDoc.Visible = true;
                btnDoc.Location = new Point(92, 20);
                salirToolStripMenuItem.Visible = true;

            }

            //ISKRA
            if (TestSpire.Usr.K == 40)
            {
                btnDoc.Visible = true;
                btnDoc.Location = new Point(89, 18);
                btnCCAYAC.Visible = true;
                btnCCAYAC.Location = new Point(102, 62);
                salirToolStripMenuItem.Visible = true;
            }

            //ADMINISTRADORES
            if (TestSpire.Usr.K == 91 || TestSpire.Usr.K == 71 || TestSpire.Usr.K == 1 || TestSpire.Usr.K == 88 || TestSpire.Usr.K == 8)
            {
                btnLlamaSap.Visible = true;
                btnRFsr.Visible = true;
                btnLLInter.Visible = false;
                btnRLlamI.Visible = true;
                btnCGeneral.Visible = true;
                btnCPlaneado.Visible = true;
                btnRFsrAnt.Visible = true;
                btnDoc.Visible = true;
                btnProto.Visible = true;
                btnPrerequisitos.Visible = true;
                btnCalendarioDias.Visible = true;
                btnCCAYAC.Visible = true;
                menuPrincipalToolStripMenuItem.Visible = true;
            }

            //PROTOCOLOS
            if (TestSpire.Usr.K == 72 || TestSpire.Usr.K == 45 || TestSpire.Usr.K == 41 || TestSpire.Usr.K == 105 || TestSpire.Usr.K == 112 || TestSpire.Usr.K == 133 || TestSpire.Usr.K == 132)
            {
                btnDoc.Visible = true;
                btnDoc.Location = new Point(92, 18);
                btnProto.Visible = true;
                btnProto.Location = new Point(108, 62);
                btnCalendarioDias.Visible = true;
                btnCalendarioDias.Location = new Point(45, 106);
                btnPrerequisitos.Visible = true;
                btnPrerequisitos.Location = new Point(49, 150);
                salirToolStripMenuItem.Visible = true;
            }

            //PRERREQUISITOS
            if(TestSpire.Usr.K == 121)
            {
                btnPrerequisitos.Visible = true;
                btnPrerequisitos.Location = new Point(41, 18);
            }

            //COORDINACION SERVICIO
            if (TestSpire.Usr.K == 39 || TestSpire.Usr.K == 79)
            {
                btnLlamaSap.Visible = true;
                btnRFsr.Visible = true;
                btnLLInter.Visible = false;
                btnRLlamI.Visible = true;
                btnCGeneral.Visible = true;
                btnCalendarioDias.Visible = true;
                btnPrerequisitos.Visible = true;
                btnPrerequisitos.Location = new Point(41, 194);
                //btnCPlaneado.Visible = true;
                salirToolStripMenuItem.Visible = true;
                //btnCCAYAC.Visible = true;
                //btnCCAYAC.Location = new Point(108, 365);
            }

            //RAMON-OPERACIONES
            if (TestSpire.Usr.K == 74)
            {
                btnLlamaSap.Visible = true;
                btnRFsr.Visible = true;
                btnRLlamI.Visible = true;
                btnCalendarioDias.Visible = true;
                salirToolStripMenuItem.Visible = true;
            }

            //Usuario para subir FSR fisico
            if (TestSpire.Usr.K == 92)
            {
                btnLlamaSap.Visible = true;
                btnRFsr.Visible = true;
                salirToolStripMenuItem.Visible = true;
            }


            //REPORTES CALIDAD
            if (TestSpire.Usr.K == 70 || TestSpire.Usr.K == 69 )
            {
                btnLlamaSap.Visible = true;
                btnRFsr.Visible = true;
                btnRLlamI.Visible = true;
                btnCGeneral.Visible = true;
                btnDoc.Visible = true;
                btnDoc.Location = new Point(92, 168);
                salirToolStripMenuItem.Visible = true;
            }

            //Acceso a judit
            //if (TestSpire.Usr.K == 104)
            //{
            //    btnLlamaSap.Visible = true;
            //    btnRFsr.Visible = true;
            //    btnCGeneral.Visible = true;
            //    btnCGeneral.Location = new Point(74, 162);
            //    salirToolStripMenuItem.Visible = true;
            //}

            //CALIDAD
            if (TestSpire.Usr.K == 138 || TestSpire.Usr.K == 110)
            {
                btnLlamaSap.Visible = true;
                btnRFsr.Visible = true;
                btnRLlamI.Visible = true;
                btnCGeneral.Visible = true;
                btnCalendarioDias.Visible = true;
                btnDoc.Visible = true;
                btnDoc.Location = new Point(89, 194);
                btnCCAYAC.Visible = true;
                btnCCAYAC.Location = new Point(102, 237);
                salirToolStripMenuItem.Visible = true;
            }

            //CCAYAC
            if (TestSpire.Usr.K == 17)
            {
                btnCCAYAC.Visible = true;
                btnCCAYAC.Location = new Point(102, 18);
                btnCalendarioDias.Visible = true;
                btnCalendarioDias.Location = new Point(45, 106);
                salirToolStripMenuItem.Visible = true;
                btnRFsr.Visible = true;
            }

            //INGENIEROS CCAYAC
            if(TestSpire.Usr.Rick == 6)
            {
                btnCCAYAC.Visible = true;
                btnCCAYAC.Location = new Point(102, 18);
                salirToolStripMenuItem.Visible = true;
            }          
        }

        private void lblBaseD_Click(object sender, EventArgs e)
        {

        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Esta seguro que desea salir de la Aplicación", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //foreach(Form form in Application.OpenForms)
                //{
                //    if(form != this)
                //    {
                //        form.Close();
                //    }
                //}
                //Sesion lg = new Sesion();
                //lg.Show();
                FormCollection frm = Application.OpenForms;

                for(int i = 0; i < frm.Count; i++)
                {
                    if(frm[i].Name != "Sesion")
                    {
                        frm[i].Close();
                    }                    
                }
                Sesion lg = new Sesion();
                lg.Show();
            }
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Esta seguro que desea Cerrar Sesión", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(r == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();

                Sesion lg = new Sesion();
                lg.Show();
            }
        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

            MenuPrincipal mp = new MenuPrincipal(tipoBD);
            mp.Show();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemMostrar_Click(object sender, EventArgs e)
        {
            //Show();
            //WindowState = FormWindowState.Normal;
            //Activate();

            //Notificacion.Icon = this.Icon;
            //Notificacion.ContextMenuStrip = this.contexMSNotif;
            //MessageBox.Show("Notificacion");

        }

        private void toolStripMenuItemCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        string ruta;
        private void manualDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (TestSpire.Usr.K == 33 || TestSpire.Usr.K == 35 || TestSpire.Usr.K == 36 || TestSpire.Usr.K == 37 || TestSpire.Usr.K == 40 || TestSpire.Usr.K == 62 || TestSpire.Usr.K == 76 || TestSpire.Usr.K == 85
                || TestSpire.Usr.K == 101 || TestSpire.Usr.K == 104 || TestSpire.Usr.K == 107 || TestSpire.Usr.K == 108 || TestSpire.Usr.K == 128 || TestSpire.Usr.K == 129 || TestSpire.Usr.K == 130 || TestSpire.Usr.K == 132)
                {
                    ruta = @"\\INOLABSERVER01\Desarrollo\Manuales de usuario\SOS-DocumentacionV2.pdf";
                }
                else if (TestSpire.Usr.K == 72 || TestSpire.Usr.K == 45 || TestSpire.Usr.K == 41 || TestSpire.Usr.K == 105 || TestSpire.Usr.K == 112 || TestSpire.Usr.K == 133)
                {
                    ruta = @"\\INOLABSERVER01\Desarrollo\Manuales de usuario\SOS-ProtocolosV1.pdf";
                }
                else if (TestSpire.Usr.K == 39 || TestSpire.Usr.K == 79)
                {
                    ruta = @"\\INOLABSERVER01\Desarrollo\Manuales de usuario\SOS-CoordinacionV1.pdf";
                    //ruta = @"\\INOLABSERVER01\Desarrollo\Acuses Documentacion\F-26607AcuseInicial.pdf";
                }
                else
                {
                    ruta = @"\\INOLABSERVER01\Desarrollo\Manuales de usuario\SOS-CompletoV1.pdf";
                }

                Process.Start(ruta);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR CON ARCHIVO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void Notificacion_BalloonTipClicked(object sender, EventArgs e)
        {
            SeguimientoFolios fr = new SeguimientoFolios(tipoBD);
            fr.ShowDialog();
        }

        int area;
        public void Inicio_Noti()
        {
            try
            {
                if(TestSpire.Usr.K == 39)
                {
                    area = 1;
                }
                if(TestSpire.Usr.K == 76)
                {
                    area = 2;
                }
                if(TestSpire.Usr.K == 79)
                {
                    area = 3;
                }

                SqlDataReader leer;

                int result = objConsultasBD.getExisteNotif(tipoBD, area);

                if(result >= 1)
                {
                    leer = objConsultasBD.getDatosNotificacion(tipoBD, area);
                    while(leer.Read())
                    {
                        N_Cliente = Convert.ToString(leer["Cliente"]);
                        fechad = Convert.ToDateTime(leer["FechaNotif"]);
                        N_Fecha = String.Format("{0:dd/MM/yyyy}", fechad);
                        N_Folio = Convert.ToString(leer["FolioFSR"]);
                        N_Comentario = Convert.ToString(leer["Comentarios"]);

                        Notificacion.Text = "Coordinacion-Servicio";
                        Notificacion.BalloonTipIcon = ToolTipIcon.Info;
                        Notificacion.BalloonTipText = "Folio: " + N_Folio + " para la Empresa: " + N_Cliente + ". Notas: " + N_Comentario;
                        Notificacion.BalloonTipTitle = TestSpire.Usr.Nombre + ", Recordatorio para el dia: " + N_Fecha;
                        //Notificacion.B
                        Notificacion.ShowBalloonTip(1000);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
