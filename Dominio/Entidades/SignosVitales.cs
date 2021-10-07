namespace Dominio
{
    public class SignosVitales
    {
        public int Id { get; set; }
        public string Oximetria { get; set; }
        public string FrecuenciaRespitario { get; set; }
        public string FrecuenciaCardiaca { get; set; }
        public float Temperatura { get; set; }
        public string PrecionArterial { get; set; }
        public string Glicemia { get; set; }
    }
}