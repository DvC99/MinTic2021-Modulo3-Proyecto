using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente : Person
    {
        public FamiliarDesigado Familiar { get; set; }
        public EnfermeraDesignada Enfermera { get; set; }
        public DoctorDesignado Doctor { get; set; }
        public List<RegistroMedico> HistoriaClinica { get; set; }
    }
}
