using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class DimensaoContinua
    {
        public int Id { get; set; }

        public List<float> MargensAlturas { get; set; }

        public List<float> MargensProfundidades { get; set; }

        public List<float> MargensLarguras { get; set; }
    }


}