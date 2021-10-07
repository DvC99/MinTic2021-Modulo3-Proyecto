namespace Dominio
{
    public class RegistroMedico
    {
        public int ID { get; set; }
        public string Fecha { get; set; }
        public string Comentario { get; set; }
        public EnfermeraDesignada Enfermera { get; set; }
        public DoctorDesignado Doctor { get; set; }
        public SignosVitales TomaSignos { get; set; }
    }
}