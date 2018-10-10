using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class Dimensao
    {
        public int Id { get; set; }

        public DimensaoContinua DimContinua { get; set; }

        public List<DimensaoDiscreta> DimDiscreta { get; set; }

    }
}