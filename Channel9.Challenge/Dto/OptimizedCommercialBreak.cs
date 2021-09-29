using System.Collections.Generic;
using System.Linq;

namespace Channel9.Challenge.Dto
{
    public class OptimizedCommercialBreak
    {
        public string BreakId { get; set; }

        public List<BreakCommercialInfo> Commercials { get; set; }

        public int TotalRating => Commercials.Sum(x => x.Rating);
    }

    public class BreakCommercialInfo
    {
        public string CommercialId { get; set; }

        public string Demography { get; set; }

        public string Type { get; set; }

        public int Rating { get; set; }
    }
}
