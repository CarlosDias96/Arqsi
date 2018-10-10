using System.Collections.Generic;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class DimensaoContinua
    {
        public string Id { get; set; }

        List<float> MargensAlturas { get; set; }

        List<float> MargensProfundidades { get; set; }

        List<float> MargensLarguras { get; set; }
    }


}