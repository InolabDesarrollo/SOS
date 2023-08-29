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
using System.Web;
using System.IO;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ProyectoInolabServicio
{
    public partial class TEST : MaterialForm
    {
        public TEST(int BD)
        {
            InitializeComponent();
            tipoBD = BD;
        }


        int tipoBD;

        DataConsultas objConsultasBD = new DataConsultas();


        private void TEST_Load(object sender, EventArgs e)
        {
            //Consulta();
        }
        string idfolio, folioFSR, resp, cliente, equipo, marca, modelo, idEquipo;
        string fechaServicio, hora, ing, noLlamada, correo;

        public void Consulta()
        {
            folioFSR = txtfolio.Text;

            SqlDataReader leer;
            leer = objConsultasBD.SetDatosCorreo(tipoBD, folioFSR);
            if (leer.Read())
            {
                folioFSR = Convert.ToString(leer["Folio"]);
                resp = Convert.ToString(leer["N_Responsable"]);
                cliente = Convert.ToString(leer["Cliente"]);
                equipo = Convert.ToString(leer["Equipo"]);
                marca = Convert.ToString(leer["Marca"]);
                modelo = Convert.ToString(leer["Modelo"]);
                idEquipo = Convert.ToString(leer["IdEquipo_C"]);
                fechaServicio = Convert.ToString(leer["FechaServicio"]);
                hora = Convert.ToString(leer["Horaservicio"]);
                ing = Convert.ToString(leer["Ingeniero"]);
                noLlamada = Convert.ToString(leer["NoLlamada"]);
                correo = Convert.ToString(leer["Mail"]);
                txtdireccionemail.Text = Convert.ToString(leer["Mail"]);

                envioCorreo();

            }
            else
            {
                MessageBox.Show("El folio " + folioFSR + " no se encuentra Asignado o esta Finalizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }

        public void envioCorreo()
        {
            Correo correo = new Correo
            {
                correo = "notificaciones@inolab.com",
                alias = "Notificaciones INOLAB",
                asunto = "Confirmacion de Servicio para el Equipo",
                contraseña = "Notificaciones2021*",
                puerto = 1025,
                smtp = "smtp.inolab.com",
                destinatarios = txtdireccionemail.Text, //"sandraovando@inolab.com",
                cuerpo = "<h3>Estimado " + resp + " de " + cliente + "</h3>" +
                "<p> Se le informa que se ha programado el(los) siguiente(s) servicio(s):</p>" +
                "<table style = 'width: 100%; border-collapse: collapse;' border = '0'>" +
                "<tbody> " +
                "<tr>" +
                "<td style = 'width: 40.0585%;'><strong><span style = 'color: #000080;'> Equipo:</span></strong></td> " +
                "<td style = 'width: 59.9415%;'>" + equipo + "</td> " +
                "</tr>" +
                "<tr>" +
                "<td style = 'width: 40.0585%;'><strong><span style = 'color: #000080;'> Marca:</span></strong></td> " +
                "<td style = 'width: 59.9415%;'> " + marca + " </td>" +
                "</tr>" +
                "<tr>" +
                "<td style = 'width: 40.0585%;'><strong><span style = 'color: #000080;'> Modelo:</span></strong></td> " +
                "<td style = 'width: 59.9415%;'>" + modelo + " </td>" +
                "</tr>" +
                "<tr>" +
                "<td style = 'width: 40.0585%;'><strong><span style = 'color: #000080;'> Id Equipo:</span></strong></td> " +
                "<td style = 'width: 59.9415%;'> " + idEquipo + " </td>" +
                "</tr>" +
                "<tr>" +
                "<td style = 'width: 40.0585%;'><strong><span style = 'color: #000080;'> Fecha de Servicio:</span></strong></td> "+
                "<td style = 'width: 59.9415%;'> " + fechaServicio + " </td>" +
                "</tr>" +
                "<tr>" +
                "<td style = 'width: 40.0585%;'><strong><span style = 'color: #000080;'> Hora de Servicio:</span></strong></td>" +
                "<td style = 'width: 59.9415%;'> " + hora + "</td>" +
                "</tr>" +
                "<tr>" +
                "<td style = 'width: 40.0585%;'><strong><span style ='color: #000080;'> Ingeniero Asignado:</span></strong></td> " +
                "<td style = 'width: 59.9415%;'> " + ing + "</td>" +
                "</tr>" +
                "<tr>" +
                "<td style = 'width: 40.0585%;'> &nbsp;</td>" +
                "<td style = 'width: 59.9415%;'> &nbsp;</td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "<p> Para confirmar o proponer la fecha de este servicio ingrese al siguiente link: http://23.102.185.149:8020/ConfirmacionServicio.aspx?vlrtknfkgt=" + noLlamada + "</p>" +
                "<p> &nbsp;</p>" +
                "<p> Este correo se envia automaticamente, favor de NO responder al mismo </p> "         

        };

            if (Correo.Send(correo))
            {
                MessageBox.Show("Se ha enviado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Limpiar()
        {
            txtfolio.Text = "";
            idfolio = "";
            folioFSR = "";
            resp = "";
            cliente = "";
            equipo = "";
            marca = "";
            modelo = "";
            idEquipo = "";
            fechaServicio = "";
            hora = "";
            ing = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnenviarcorreo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:50455/ConfirmacionServicio.aspx?vlrtknfkgt="+idfolio);
        }

        private void btnenviar_Click(object sender, EventArgs e)
        {
            Consulta();            
            Limpiar();
        }
    }
}
