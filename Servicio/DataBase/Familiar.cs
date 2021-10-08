using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class Familiar
    {
        public Familiar()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Parentesco { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
