using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArqsiArmario.DTOs;

namespace ArqsiArmario.Models
{
    public class DimensaoDC
    {
        public DimensaoDC() { }
        public DimensaoDC(float AlturaMin, float AlturaMax, ICollection<Valor> ListaDiscreta)
        {
            this.ListaDiscreta = ListaDiscreta;
            this.AlturaMin = AlturaMin;
            this.AlturaMax = AlturaMax;
        }
        public int Id { get; set; }
        public ICollection<Valor> ListaDiscreta { get; set; }
        public float AlturaMin { get; set; }
        public float AlturaMax { get; set; }
    }

    /*public DimensaoDCDto toDTO()
    {
        DimensaoDCDto dimensaoDCDto = new DimensaoDCDto(this.AlturaMin, this.AlturaMax, this.ListaDiscreta,);
        return dimensaoDCDto;
    }
    public static DimensaoDC fromDTO(DimensaoDCDto dimensaoDCDto)
    {
        DimensaoDC dimensaodc = new DimensaoDC(dimensaoDCDto.AlturaMin,dimensaoDCDto.AlturaMax, dimensaoDCDto.ListaDiscreta);
        return dimensaodc;
    }
   */
}
