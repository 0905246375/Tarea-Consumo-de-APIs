using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_Creacion_de_API
{
     public  class Usuario
    {
        internal object phone;
        internal object website;
        internal object address;
        internal object addres;

        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
    }

    public class Direccion
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
    }

    public class Usuarios
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Direccion address { get; set; }
    }

}
