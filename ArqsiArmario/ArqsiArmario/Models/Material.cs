namespace ArqsiArmario.Models
{
    public class Material
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Acabamento Acabamento { get; set; }

        public int AcabamentoId { get; set; }
    }
}