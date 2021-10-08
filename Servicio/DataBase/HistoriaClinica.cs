using System;
using System.Collections.Generic;

#nullable disable

namespace Persistencia.DataBase
{
    public partial class HistoriaClinica
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdEnfermera { get; set; }
        public string Oximetria { get; set; }
        public string FrecuenciaRespitario { get; set; }
        public string FrecuenciaCardiaca { get; set; }
        public string Temperatura { get; set; }
        public string PrecionArterial { get; set; }
        public string Glicemia { get; set; }
        public DateTime Fechavisita { get; set; }
        public string Comentarios { get; set; }

        public virtual Enfermera IdEnfermeraNavigation { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
