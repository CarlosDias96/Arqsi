namespace ArqsiArmario.Models
{
    public class DimensaoDiscreta
    {
       
        public int Id { get; set; }

        public float Altura { get; set; }

        public float Largura { get; set; }

        public float Profundidade { get; set; }

        public DimensaoDiscreta() { }
        public DimensaoDiscreta(float Altura, float Largura, float Profundidade)
        {
            this.Altura = Altura;
            this.Largura = Largura;
            this.Profundidade = Profundidade;
        }
    }

}