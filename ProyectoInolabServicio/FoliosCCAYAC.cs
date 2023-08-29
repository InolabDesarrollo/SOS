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

namespace ProyectoInolabServicio
{
    public partial class FoliosCCAYAC : Form
    {
        public FoliosCCAYAC(string folio)
        {
            InitializeComponent();
            id = folio;
        }
        string id;


        private void FoliosCCAYAC_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            Ficha();
        }


        public void Ficha()
        {
            NetworkCredential myCred = new NetworkCredential("developer", "In0l4b2022#");
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri("http://INOLABSERVER01/Reportes_Inolab");
            reportViewer1.ServerReport.ReportPath = "/OC/Folio_Servicio_todos2021";

            ReportParameter coti = new ReportParameter();
            coti.Name = "ID";
            coti.Values.Add(id);

            reportViewer1.ServerReport.SetParameters(new ReportParameter[] { coti });
            reportViewer1.RefreshReport();
        }
    }
}
