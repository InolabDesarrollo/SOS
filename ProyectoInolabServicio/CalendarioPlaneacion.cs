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
    public partial class CalendarioPlaneacion : MaterialForm
    {
        public CalendarioPlaneacion()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=INOLABSERVER03;Initial Catalog=Browser;Persist Security Info=True;User ID=ventas;Password=V3ntas_17");
        string fe1;
        string fe2;
        DateTime fec1;
        DateTime fec2;

        private void CalendarioPlaneacion_Load(object sender, EventArgs e)
        {
            //this.llamadas_SAPTableAdapter1.Fill(this.dSBrowser.Llamadas_SAP);

            fechai();
            fechaf();
            Calendario();
            //this.reportViewer1.RefreshReport();
        }

        public void Calendario()
        {
            
            NetworkCredential myCred = new NetworkCredential("developer", "In0l4b2022#");
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri("http://INOLABSERVER01/Reportes_Inolab/");
            reportViewer1.ServerReport.ReportPath = "/Servicio/Calendario-Planeacion2";

            ReportParameter fecha1 = new ReportParameter();
            fecha1.Name = "fecha1";
            fecha1.Values.Add(fe1);
            ReportParameter fecha2 = new ReportParameter();
            fecha2.Name = "fecha2";
            fecha2.Values.Add(fe2);

            reportViewer1.ServerReport.SetParameters(new ReportParameter[] { fecha1, fecha2 });
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

                fec1 = Convert.ToDateTime(lblf1.Text);

                fe1 = String.Format("{0:dd/MM/yyyy}", fec1);

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

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
