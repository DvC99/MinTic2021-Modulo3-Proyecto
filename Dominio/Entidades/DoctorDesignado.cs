using System.Collections.Generic;

namespace Dominio
{
    public class DoctorDesignado : Person
    {
        public string Especialidad { get; set; }
        public List<Paciente> Pacientes {get;set;}
    }
}