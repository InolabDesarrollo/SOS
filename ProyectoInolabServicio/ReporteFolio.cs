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
    public partial class ReporteFolio : MaterialForm
    {
        public ReporteFolio(string foliofsr)
        {
            InitializeComponent();
            fol = foliofsr;
        }
        string fol;
        private void ReporteFolio_Load(object sender, EventArgs e)
        {

            Informe();
            
        }
        public void Informe()
        {
            NetworkCredential myCred = new NetworkCredential("developer", "In0l4b2022#");
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri("http://INOLABSERVER01/Reportes_Inolab");
            reportViewer1.ServerReport.ReportPath = "/OC/FSR Servicio V2";

            //ACCION PARA SABER QUE REPORTE ABRIRA DE LA LINEA EQUIPO, CONSUMIBLE SERVICIO
            ReportParameter folio = new ReportParameter();
            folio.Name = "folio";
            folio.Values.Add(fol);
            //folio.Values.Add("2");// solo hacer referencia al numero de cotizacion

            reportViewer1.ServerReport.SetParameters(new ReportParameter[] { folio });
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
