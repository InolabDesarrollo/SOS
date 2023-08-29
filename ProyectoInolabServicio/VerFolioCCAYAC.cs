using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoInolabServicio
{
    public partial class VerFolioCCAYAC : Form
    {
        public VerFolioCCAYAC(string folio)
        {
            InitializeComponent();
            FolioCC = folio;
        }
        string FolioCC;

        private void VerFolioCCAYAC_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            Folio();
        }

        public void Folio()
        {
            NetworkCredential myCred = new NetworkCredential("developer", "In0l4b2022#");
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri("http://INOLABSERVER01/Reportes_Inolab");
            reportViewer1.ServerReport.ReportPath = "/OC/FolioCCAYAC2022";

            ReportParameter folioN = new ReportParameter();
            folioN.Name = "ID";
            folioN.Values.Add(FolioCC);

            reportViewer1.ServerReport.SetParameters(new ReportParameter[] { folioN });
            reportViewer1.RefreshReport();
        }
    }
}
