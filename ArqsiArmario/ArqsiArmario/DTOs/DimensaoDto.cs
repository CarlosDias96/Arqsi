namespace ArqsiArmario.DTOs
{
    public class DimensaoDto
    {
        public int Id { get; set; }
        public DimensaoDCDto Altura { get; set; }
        public DimensaoDCDto Profundidade { get; set; }
        public DimensaoDCDto Largura { get; set; }
        public DimensaoDto() { }
        public DimensaoDto(DimensaoDCDto Altura, DimensaoDCDto Profundidade, DimensaoDCDto Largura)
        {
            this.Altura = Altura;
            this.Profundidade = Profundidade;
            this.Largura = Largura;
        }
    }
}
