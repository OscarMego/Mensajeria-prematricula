using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;
using WcfRestMensajeria.Dominio;

namespace WcfRestMensajeria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Mensajeria" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Mensajeria.svc o Mensajeria.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Mensajeria : IMensajeria
    { 

        public MensajeCorreoResponse enviarCorreo(MensajeCorreoRequest mensajeCorreo)
        {
            MensajeCorreoResponse respuesta = new MensajeCorreoResponse();

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(mensajeCorreo.destinatario);
            msg.From = new MailAddress(mensajeCorreo.emisor, "", System.Text.Encoding.UTF8);
            msg.Subject = mensajeCorreo.asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = mensajeCorreo.mensaje;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(mensajeCorreo.emisor, mensajeCorreo.clave);
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            try
            {
                client.Send(msg);
                respuesta.estado = true;
                return respuesta;
            }
            catch (Exception ex)
            {
                respuesta.estado = false;
                return respuesta;
            }
        }

        public MensajeTextoResponse enviarTexto(MensajeTextoRequest mensajeTexto)
        {
            MensajeTextoResponse respuestaTexto = new MensajeTextoResponse();
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer(); 
                HttpWebRequest request = WebRequest.Create("http://192.168.43.1:1688/services/api/messaging/?TO=" + mensajeTexto.nroCelular + "&Message=" + mensajeTexto.mensaje) as HttpWebRequest;
                request.Method = "POST"; 
                HttpWebResponse rsp = (HttpWebResponse)request.GetResponse();

                StreamReader reader = new StreamReader(rsp.GetResponseStream());
                string tramaJson = reader.ReadToEnd();
                respuestaTexto = js.Deserialize<MensajeTextoResponse>(tramaJson);
                return respuestaTexto;
            }
            catch
            {
                return respuestaTexto;
            }
            throw new NotImplementedException();
        }
    }
}
