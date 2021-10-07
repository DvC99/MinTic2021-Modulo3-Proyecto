using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class Asignacion
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdEnfermera { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechafinal { get; set; }
        public DateTime Duracion { get; set; }
    }
}
