using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class Asignacion
    {
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdEnfermera { get; set; }
        public int IdHistoriaClinica { get; set; }
        public DateTime Fechainicio { get; set; }
        public DateTime Fechafinal { get; set; }

        public virtual Enfermera IdEnfermeraNavigation { get; set; }
        public virtual HistoriaClinica IdHistoriaClinicaNavigation { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
