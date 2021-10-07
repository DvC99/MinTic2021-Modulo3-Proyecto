using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente : Person
    {
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public FamiliarDesigado Familiar { get; set; }
        public EnfermeraDesignada Enfermera { get; set; }
        public DoctorDesignado Doctor { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
    }
}
