using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfRestMensajeria.Dominio;

namespace WcfRestMensajeria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMensajeria" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMensajeria
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "MensajeCorreo", ResponseFormat = WebMessageFormat.Json)]
        MensajeCorreoResponse enviarCorreo(MensajeCorreoRequest mensajeCorreo);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "MensajeTexto", ResponseFormat = WebMessageFormat.Json)]
        MensajeTextoResponse enviarTexto(MensajeTextoRequest mensajeTexto);

    }
}
