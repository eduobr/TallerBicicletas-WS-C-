using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfMasterBikes.CapaAccesoDatos
{
    [DataContract]
    public class Cl_Persona
    {
        [DataMember]
        public string rut { get; set; }
        [DataMember]
        public string  nombre { get; set; }
        [DataMember]
        public string apellido { get; set; }
        [DataMember]
        public int edad { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string correo { get; set; }

        [DataMember]
        public string comuna { get; set; }

        [DataMember]
        public int idComuna { get; set; }

    }
}