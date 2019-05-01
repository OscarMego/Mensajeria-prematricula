using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRestMensajeria.Dominio
{
    [DataContract]
    public class MensajeTextoRequest
    {
        [DataMember]
        public string nroCelular { get; set; }
        [DataMember]
        public string mensaje { get; set; }
    }
}