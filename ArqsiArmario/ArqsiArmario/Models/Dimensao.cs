using System.Collections.Generic;
using ArqsiArmario.DTOs;

namespace ArqsiArmario.Models
{
    public class Dimensao
    {
        public Dimensao() { }
        public Dimensao(DimensaoDC Altura, DimensaoDC Largura, DimensaoDC Profundidade)
        {
            this.Altura = Altura;
            this.Largura = Largura;
            this.Profundidade = Profundidade;
        }
        public int Id { get; set; }

        public DimensaoDC Altura { get; set; }
        public DimensaoDC Profundidade { get; set; }
        public DimensaoDC Largura { get; set; }


        public DimensaoDto toDTO()
        {

            DimensaoDto dimensaoDto = new DimensaoDto(this.Altura.toDTO(),this.Largura.toDTO(),this.Profundidade.toDTO());
            return dimensaoDto;
        }
        public static Dimensao fromDTO(DimensaoDto dimensaoDto)
        {
          
            Dimensao dimensao = new Dimensao(DimensaoDC.fromDTO(dimensaoDto.Altura), DimensaoDC.fromDTO(dimensaoDto.Largura), DimensaoDC.fromDTO(dimensaoDto.Profundidade));
            return dimensao;
        }
        public override bool Equals(object obj)
        {
            var dimensao = obj as Dimensao;
            return dimensao != null && this.Id == dimensao.Id;
        }
    }
}