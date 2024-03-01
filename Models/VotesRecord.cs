namespace VotoSeguro.Models
{
    public class VotesRecord
    {

        public int Id { get; set; }
        public String UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public String CantidadVotos { get; set; }
    }
}
