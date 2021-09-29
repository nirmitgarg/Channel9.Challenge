using System.Collections.Generic;

namespace Channel9.Challenge.Models
{
    public class CommercialBreak
    {
        public string BreakId { get; set; }

        public List<BreakCommercial> Commercials { get; set; }
    }

    public class BreakCommercial
    {
        public string CommercialId { get; set; }

        public DemographicType Demography { get; set; }

        public CommercialType Type { get; set; }

        public int Rating { get; set; }
    }
}
