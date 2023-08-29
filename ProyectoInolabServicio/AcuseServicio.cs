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
    public partial class AcuseServicio : Form
    {
        public AcuseServicio(string IdE)
        {
            InitializeComponent();
            IdEq = IdE;

        }
        string IdEq;

        private void AcuseServicio_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();

            Informe();
        }


        public void Informe()
        {
            NetworkCredential myCred = new NetworkCredential("developer", "In0l4b2022#");
            reportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = myCred;

            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            reportViewer1.ServerReport.ReportServerUrl = new Uri("http://INOLABSERVER01/Reportes_Inolab");
            reportViewer1.ServerReport.ReportPath = "/OC/Acuse Servicio 2022";
            
            ReportParameter IdEquipo = new ReportParameter();
            IdEquipo.Name = "ID";
            IdEquipo.Values.Add(IdEq);

            reportViewer1.ServerReport.SetParameters(new ReportParameter[] { IdEquipo });
            reportViewer1.RefreshReport();
        }
    }
}
