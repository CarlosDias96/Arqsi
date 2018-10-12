namespace ArqsiArmario.Models
{
    public class Acabamento
    {



        public int Id { get; set; }
        public string Nome { get; set; }
        
        public Acabamento(string Nome) { this.Nome = Nome; }
        public Acabamento()
        {

        }
    }
}