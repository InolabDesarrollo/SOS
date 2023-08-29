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

namespace ProyectoInolabServicio
{
    public partial class ReporteLlamadas_Mensual : MaterialForm
    {
        public ReporteLlamadas_Mensual()
        {
            InitializeComponent();
        }
               

        private void ReporteLlamadas_Mensual_Load(object sender, EventArgs e)
        {

            NetworkCredential myCred = new NetworkCredential("developer", "In0l4b2022#");
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri("http://INOLABSERVER01/Reportes_Inolab/");
            reportViewer1.ServerReport.ReportPath = "/Servicio/ReporteMensual-Llamadas";

            reportViewer1.RefreshReport();
        }


        private void reportViewer1_Load(object sender, EventArgs e)
        {


        }
    }
}
