using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRestMensajeria.Dominio
{
    [DataContract]
    public class MensajeTextoResponse
    {
        [DataMember]
        public Message message { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public bool isSuccessful { get; set; }
        [DataMember]
        public string requestMethod { get; set; }
    }
}