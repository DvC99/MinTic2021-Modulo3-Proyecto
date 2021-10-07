using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class Enfermera
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Pasaporte { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Especialidad { get; set; }
        public string Cargo { get; set; }
    }
}
