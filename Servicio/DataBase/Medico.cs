using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class Medico
    {
        public Medico()
        {
            HistoriaClinicas = new HashSet<HistoriaClinica>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public int IdAdministrador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }

        public virtual Administrador IdAdministradorNavigation { get; set; }
        public virtual ICollection<HistoriaClinica> HistoriaClinicas { get; set; }
    }
}
