namespace ArqsiArmario.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria(int Id, string nome)
        {
            this.Nome = Nome;
        }
        public Categoria() { }
    }
}