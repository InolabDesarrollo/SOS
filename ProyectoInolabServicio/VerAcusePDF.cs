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
using System.IO;
using System.Diagnostics;
using System.Net;
using Microsoft.Reporting.WinForms;

namespace ProyectoInolabServicio
{
    public partial class VerAcusePDF : MaterialForm
    {
        public VerAcusePDF(string folioA)
        {
            InitializeComponent();
            FolioAcuse = folioA;
        }

        string FolioAcuse;


        private void VerAcusePDF_Load(object sender, EventArgs e)
        {
            Reporte();
        }

        public void Reporte()
        {
            NetworkCredential myCred = new NetworkCredential("developer", "In0l4b2022#");
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri("http://INOLABSERVER01/Reportes_Inolab/");
            reportViewer1.ServerReport.ReportPath = "/Servicio/Acuse_Documentacion";

            ReportParameter folio = new ReportParameter();
            folio.Name = "FolioAcuse";
            folio.Values.Add(FolioAcuse);

            reportViewer1.ServerReport.SetParameters(new ReportParameter[] { folio });
            reportViewer1.RefreshReport();
        }
    }
}
