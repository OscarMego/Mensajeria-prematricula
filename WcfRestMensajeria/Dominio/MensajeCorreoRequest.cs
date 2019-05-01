using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRestMensajeria.Dominio
{
    [DataContract]
    public class MensajeCorreoRequest
    {
        [DataMember]
        public string emisor { get; set; }
        [DataMember]
        public string clave { get; set; }
        [DataMember]
        public string destinatario { get; set; }
        [DataMember]
        public string asunto { get; set; }
        [DataMember]
        public string mensaje { get; set; }

    }
}