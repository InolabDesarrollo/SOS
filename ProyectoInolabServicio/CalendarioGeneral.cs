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
using System.Net;
using Microsoft.Reporting.WinForms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class CalendarioGeneral : MaterialForm
    {
        public CalendarioGeneral(int BD)
        {
            InitializeComponent();
            tipoBD = BD;
        }


        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");
        string fe1;// VALOR CON FORMATO FECHA1
        string fe2;// VALOR CON FORMATO FECHA2
        DateTime fec1; 
        DateTime fec2;
        int tipoBD;
        

        private void CalendarioGeneral_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSBrowser.Usuarios' Puede moverla o quitarla según sea necesario.
            //this.usuariosTableAdapter.Fill(this.dSBrowser.Usuarios);
            fechai();
            fechaf();
            Calendario();
            
            if(TestSpire.Usr.K == 22)
            {
                button1.Visible = false;
                btnEnviarCorreo.Visible = false;
            }
        }
        public void Calendario()
        {
            NetworkCredential myCred = new NetworkCredential("developer", "In0l4b2022#");
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri("http://INOLABSERVER01/Reportes_Inolab/");
            reportViewer1.ServerReport.ReportPath = "/Servicio/Calendario-Servicio";
            //reportViewer1.ServerReport.ReportPath = "/Servicio/Calendario-ServicioDias";

            ReportParameter fecha1 = new ReportParameter();
            fecha1.Name = "fecha1";
            fecha1.Values.Add(fe1);
            ReportParameter fecha2 = new ReportParameter();
            fecha2.Name = "fecha2";
            fecha2.Values.Add(fe2);

            reportViewer1.ServerReport.SetParameters(new ReportParameter[] { fecha1,fecha2 });
            reportViewer1.RefreshReport();
        }
        public void fechai()
        {

            SqlCommand cmd = new SqlCommand("select convert(date,DATEADD(wk,DATEDIFF(wk,0,GETDATE()),0)) as er", con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                lblf1.Text = Convert.ToString(leer["er"]);
                //textBox1.Text= Convert.ToString(leer["er"]);

                
                fec1 =Convert.ToDateTime(lblf1.Text);

                fe1 = String.Format("{0:dd/MM/yyyy}",fec1);

            }

            con.Close();
        }
        public void fechaf()
        {

            SqlCommand cmd = new SqlCommand("select DATEADD(wk,DATEDIFF(wk,0,GETDATE()),4) as er", con);
            con.Open();

            SqlDataReader leer;
            leer = cmd.ExecuteReader();
            if (leer.Read())
            {
                lblf2.Text = Convert.ToString(leer["er"]);

                
                fec2 = Convert.ToDateTime(lblf2.Text);

                fe2 = String.Format("{0:dd/MM/yyyy}", fec2);
            }

            con.Close();
        }
        DateTime ifecha;
        DateTime ffecha;
        

        private void btnsemanterior_Click(object sender, EventArgs e)
        {
            ifecha =Convert.ToDateTime(fe1);
            ffecha =Convert.ToDateTime(fe2);


            fe1 = Convert.ToString(ifecha.AddDays(-7));
            fe2 = Convert.ToString(ffecha.AddDays(-7));
            Calendario();
        }

        private void btnsemsiguiente_Click(object sender, EventArgs e)
        {
            ifecha = Convert.ToDateTime(fe1);
            ffecha = Convert.ToDateTime(fe2);

            fe1 = Convert.ToString(ifecha.AddDays(7));
            fe2 = Convert.ToString(ffecha.AddDays(7));
            Calendario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Up_CalendarioGeneral frm = new Up_CalendarioGeneral(tipoBD);
            frm.Show();
        }

        private void usuariosBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            TEST frm = new TEST(tipoBD);
            frm.Show();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            ifecha = Convert.ToDateTime(fe1);
            ffecha = Convert.ToDateTime(fe2);

            fe1 = Convert.ToString(ifecha.AddDays(-7));
            fe2 = Convert.ToString(ffecha.AddDays(-7));
            Calendario();
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            ifecha = Convert.ToDateTime(fe1);
            ffecha = Convert.ToDateTime(fe2);

            fe1 = Convert.ToString(ifecha.AddDays(7));
            fe2 = Convert.ToString(ffecha.AddDays(7));
            Calendario();
        }
    }
}
