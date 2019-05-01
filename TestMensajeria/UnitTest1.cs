using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WcfRestMensajeria.Dominio;

namespace TestMensajeria
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnviarCorreo()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MensajeCorreoRequest solicitudCorreo = new MensajeCorreoRequest()
            {
                emisor = "ggaribay.pe@gmail.com",
                clave = "",///AQUI DEBEN PONER LA CONTRASEÑA DEL CORREO EMISOR
                destinatario = "gggl.pe@gmail.com",
                asunto = "correo test rest",
                mensaje = "Ojala funacione"        
            };

            string jsonSolicitud = js.Serialize(solicitudCorreo);
            byte[] ByteCorreo = Encoding.UTF8.GetBytes(jsonSolicitud);
            HttpWebRequest request = WebRequest.Create("http://localhost:49764/Mensajeria.svc/MensajeCorreo") as HttpWebRequest;
            request.Method = "POST";
            request.ContentLength = ByteCorreo.Length;
            request.ContentType = "application/json";
            var rqt = request.GetRequestStream();

            rqt.Write(ByteCorreo, 0, ByteCorreo.Length);
            HttpWebResponse rsp = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(rsp.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            MensajeCorreoResponse respuestaCorreo = js.Deserialize<MensajeCorreoResponse>(tramaJson);
            Assert.AreEqual(true, respuestaCorreo.estado);
        }

        [TestMethod]
        public void EnviarMsm()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MensajeTextoRequest solicitudTexto = new MensajeTextoRequest()
            {
                nroCelular = "992430180",
                mensaje = "es solo una prueba para el final"              
            };

            string jsonSolicitud = js.Serialize(solicitudTexto);
            byte[] ByteTexto = Encoding.UTF8.GetBytes(jsonSolicitud);
            HttpWebRequest request = WebRequest.Create("http://localhost:49764/Mensajeria.svc/MensajeTexto") as HttpWebRequest;
            request.Method = "POST";
            request.ContentLength = ByteTexto.Length;
            request.ContentType = "application/json";
            var rqt = request.GetRequestStream();

            rqt.Write(ByteTexto, 0, ByteTexto.Length);
            HttpWebResponse rsp = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(rsp.GetResponseStream());
            string tramaJson = reader.ReadToEnd();
            MensajeTextoResponse respuestaTexto = js.Deserialize<MensajeTextoResponse>(tramaJson);
            Assert.AreEqual(true, respuestaTexto.isSuccessful);
        }
    }
}
