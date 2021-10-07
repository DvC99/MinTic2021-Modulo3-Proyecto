using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class Hisotiaclinica
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdEnfermera { get; set; }
        public DateTime Fechavisita { get; set; }
        public string Comentarios { get; set; }
    }
}
