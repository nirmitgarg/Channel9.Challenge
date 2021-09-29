using Channel9.Challenge.Models;
using System.Collections.Generic;

namespace Channel9.Challenge.Repositories
{
    public class Commercials : IRepository<Commercial>
    {
        public List<Commercial> GetAll()
        {
            return new List<Commercial>
            {
                new Commercial{ Id="Commercial 1", Type=CommercialType.Automotive, Demographic=DemographicType.W_25_30 },
                new Commercial{ Id="Commercial 2", Type=CommercialType.Travel, Demographic=DemographicType.M_18_35 },
                new Commercial{ Id="Commercial 3", Type=CommercialType.Travel, Demographic=DemographicType.T_18_40 },
                new Commercial{ Id="Commercial 4", Type=CommercialType.Automotive, Demographic=DemographicType.M_18_35 },
                new Commercial{ Id="Commercial 5", Type=CommercialType.Automotive, Demographic=DemographicType.M_18_35 },
                new Commercial{ Id="Commercial 6", Type=CommercialType.Finance, Demographic=DemographicType.W_25_30 },
                new Commercial{ Id="Commercial 7", Type=CommercialType.Finance, Demographic=DemographicType.M_18_35 },
                new Commercial{ Id="Commercial 8", Type=CommercialType.Automotive, Demographic=DemographicType.T_18_40 },
                new Commercial{ Id="Commercial 9", Type=CommercialType.Travel, Demographic=DemographicType.W_25_30 },
                new Commercial{ Id="Commercial 10", Type=CommercialType.Finance, Demographic=DemographicType.T_18_40 },
            };
        }
    }
}
