using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRestMensajeria.Dominio
{
    [DataContract]
    public class MensajeCorreoResponse
    {
        [DataMember]
        public bool estado { get; set; }
    }
}