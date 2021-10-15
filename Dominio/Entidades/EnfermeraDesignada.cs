using System.Collections.Generic;

namespace Dominio
{
    public class EnfermeraDesignada : Person
    {
        public string Especialidad { get; set; }
        public PacienteEntity Paciente { get; set; }
    }
}