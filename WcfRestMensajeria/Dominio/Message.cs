using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfRestMensajeria.Dominio
{
    [DataContract]
    public class Message
    {
        [DataMember]
        public string date { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string number { get; set; }
        [DataMember]
        public bool read { get; set; }
        [DataMember]
        public string to { get; set; }
    }
}