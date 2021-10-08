using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class Paciente
    {
        public Paciente()
        {
            HistoriaClinicas = new HashSet<HistoriaClinica>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public int IdAdministrador { get; set; }
        public int IdFamiliar { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }

        public virtual Administrador IdAdministradorNavigation { get; set; }
        public virtual Familiar IdFamiliarNavigation { get; set; }
        public virtual ICollection<HistoriaClinica> HistoriaClinicas { get; set; }
    }
}
