using System.Collections.Generic;

namespace Dominio
{
    public class EnfermeraDesignada : Person
    {
        public string Especialidad { get; set; }
        public Paciente Paciente { get; set; }
    }
}