using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;
using AutoUpdaterDotNET;
using System.Reflection;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class Sesion : MaterialForm
    {
        public Sesion()
        {
            InitializeComponent();

            // Administrador de temas de materiales y agrega formulario para administrar (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            // Configurar esquema de color
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue900, Primary.Blue400, Accent.LightBlue400, TextShade.WHITE);

            //Ejecuta la actualizacion en caso de existir

            Console.WriteLine(System.Reflection.Assembly.GetEntryAssembly().GetName().Version);
            AutoUpdater.Start(@"\\INOLABSERVER01\Ejecutables\Coordinacion\version.xml");
            lblVer.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();

            //timerActualizacion.Start();
        }

        //conexion al servidor y BD
        //SqlConnection con = new SqlConnection("Data Source=INOLABSERVER01;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");

        //****************CONSULTAS A BD COORDINACION  O COPIAS
        DataConsultas objConsultasBD = new DataConsultas();
        TestSpire.Functions objConsultasCC = new TestSpire.Functions();


        //variables
        string us, ps;
        int id, rUser, rPass, idA;
        string query;
        string usuario, password;


        private void Sesion_Load(object sender, EventArgs e)
        {
            //Agrega tamaño y color a la fuente 
            lblVer.Font = new Font(lblVer.Font.Name, 8);
            lblVer.ForeColor = Color.DarkSlateBlue;

            lblF.Font = new Font(lblF.Font.Name, 8);
            lblF.ForeColor = Color.DarkSlateBlue;
        }     
        
        
        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Ingresar();
            }
        }

        private void timerActualizacion_Tick(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void txtPsd_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void txtPsd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Ingresar();
            }
        }


        public void Ingresar()
        {
            usuario = txtUser.Text;
            password = txtPsd.Text;

            try
            {
                SqlDataReader Log = objConsultasBD.getLogin(1, usuario);

                if (Log.Read())
                {
                    TestSpire.Usr.Rick = (int)Log.GetValue(Log.GetOrdinal("IdArea"));
                    TestSpire.Usr.Joi = (int)Log.GetValue(Log.GetOrdinal("IdRol"));
                    TestSpire.Usr.K = (int)Log.GetValue(Log.GetOrdinal("IdUsuario"));
                    TestSpire.Usr.Nombre = (string)Log.GetValue(Log.GetOrdinal("Nombre"));
                    TestSpire.Usr.Password = (string)Log.GetValue(Log.GetOrdinal("Password_"));
                    TestSpire.Usr.User = (string)Log.GetValue(Log.GetOrdinal("Usuario"));
                    if (Log.GetValue(Log.GetOrdinal("Firma")) is DBNull)
                    {

                    }
                    else
                    {
                        TestSpire.Usr.Firma = objConsultasCC.byteArrayToImage((byte[])Log.GetValue(Log.GetOrdinal("Firma")));
                    }

                    //Compara usuario y contraseña para verificar que sean iguales
                    rUser = String.Compare(usuario, TestSpire.Usr.User, false);
                    rPass = String.Compare(password, TestSpire.Usr.Password, false);

                    if (rUser == 0 && rPass == 0)
                    {
                        //Usuario adminstrador
                        if (TestSpire.Usr.Rick == 7 || TestSpire.Usr.K == 1 || TestSpire.Usr.K == 71 || TestSpire.Usr.K == 88)
                        {
                            MessageBox.Show("Administrador. \n Bienvenido al sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EleccionBD frm = new EleccionBD();
                            this.Hide();
                            frm.Show();
                        }
                        //else if (TestSpire.Usr.K == 35 || TestSpire.Usr.K == 40 || TestSpire.Usr.K == 22 || TestSpire.Usr.K == 8 || TestSpire.Usr.K == 27 || TestSpire.Usr.K == 75)
                        //{
                        //    MessageBox.Show("Bienvenido al Sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    MenuPrincipal frm = new MenuPrincipal(1);
                        //    this.Hide();
                        //    frm.Show();
                        //}
                        else if (TestSpire.Usr.K == 79 || TestSpire.Usr.K == 39)
                        {
                            MessageBox.Show("Bienvenido al Sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Menu frm = new Menu(1);
                            this.Hide();
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Bienvenido al Sistema.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MenuPrincipal frm = new MenuPrincipal(1);
                            this.Hide();
                            frm.Show();
                            //Menu frm = new Menu(1);
                            //this.Hide();
                            //frm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o Contraseña incorectos. Favor de verificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña incorectos. Favor de verificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.ToString());
            }
        }

        public void Actualizar()
        {
            Console.WriteLine(System.Reflection.Assembly.GetEntryAssembly().GetName().Version);            
            AutoUpdater.Start(@"\\INOLABSERVER01\Ejecutables\Coordinacion\version.xml");
            MessageBox.Show("Existe una nueva Version. Actualizacion en proceso. Espere", "ACTUALIZANDO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            lblVer.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
        }


        private void Sesion_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Esta seguro que desea salir de la Aplicación", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //if(Application.MessageLoop == true)
                //{
                //    Application.Exit();
                //}
                //else
                //{
                //    Environment.Exit(0);
                //}

                Environment.Exit(0);
            }
            if (result == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
