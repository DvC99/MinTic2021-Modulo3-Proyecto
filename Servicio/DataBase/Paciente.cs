using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class Paciente
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Pasaporte { get; set; }
        public int IdAsignacion { get; set; }
        public int IdHistoriaclinica { get; set; }
        public int IdAdministrador { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Edad { get; set; }
        public string Eps { get; set; }
    }
}
