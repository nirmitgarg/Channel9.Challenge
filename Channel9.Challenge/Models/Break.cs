using System.Collections.Generic;

namespace Channel9.Challenge.Models
{
    public class Break
    {
        public string Id { get; set; }
        public List<Demography> Demographies { get; set; }
    }

    public class Demography
    {
        public DemographicType Demographic { get; set; }
        public int Rating { get; set; }
    }
}
