using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PacienteEntity : Person
    {
        public int IdFamiliar { get; set; }
        public FamiliarDesigado Familiar { get; set; }
        public EnfermeraDesignada Enfermera { get; set; }
        public DoctorDesignado Doctor { get; set; }
        public List<RegistroMedico> HistoriaClinica { get; set; }
    }
}
