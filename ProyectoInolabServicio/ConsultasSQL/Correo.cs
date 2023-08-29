using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using System.Windows.Forms;
namespace ProyectoInolabServicio
{
    class Correo
    {
        public string correo { get; set; }
        public string alias { get; set; } // para que no se vea correo

        public string contraseña { get; set; }
        public int puerto { get; set; }
        public string smtp { get; set; }
        public string asunto { get; set; }
        public string cuerpo { get; set; }

        //public List<string> destinatarios { get; set; }
        public string destinatarios { get; set; }

        public static bool Send(Correo correo)
        {
            try
            {
                SmtpClient cliente = new SmtpClient(correo.smtp,correo.puerto);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(correo.correo,correo.alias);
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;

                mail.Body = correo.cuerpo;
                //mail.Body = "cuerpo de correo";
                mail.Subject = correo.asunto;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.To.Add(correo.destinatarios);
                

                //destinatartios

                //foreach (var destinatario in correo.destinatarios)
                //    if (!string.IsNullOrWhiteSpace(destinatario))
                //    {
                //        mail.To.Add(destinatario);
                //    }

                cliente.Credentials = new NetworkCredential(correo.correo, correo.contraseña);
                cliente.EnableSsl = false;
                cliente.Send(mail);
                return true;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

}
}
