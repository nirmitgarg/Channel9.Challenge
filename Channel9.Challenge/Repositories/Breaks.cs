using Channel9.Challenge.Models;
using System.Collections.Generic;

namespace Channel9.Challenge.Repositories
{
    public class Breaks : IRepository<Break>
    {
        public List<Break> GetAll()
        {
            return new List<Break>
                {
                    new Break
                    {
                        Id = "Break1",
                        Demographies = new List<Demography>
                        {
                            new Demography { Demographic = DemographicType.W_25_30, Rating = 80 },
                            new Demography { Demographic = DemographicType.M_18_35, Rating = 100 },
                            new Demography { Demographic = DemographicType.T_18_40, Rating = 250 }
                        },
                    },
                    new Break
                    {
                        Id = "Break2",
                        Demographies = new List<Demography>
                        {
                            new Demography { Demographic = DemographicType.W_25_30, Rating = 50 },
                            new Demography { Demographic = DemographicType.M_18_35, Rating = 120 },
                            new Demography { Demographic = DemographicType.T_18_40, Rating = 200 }
                        },
                    },
                    new Break
                    {
                        Id = "Break3",
                        Demographies = new List<Demography>
                        {
                            new Demography { Demographic = DemographicType.W_25_30, Rating = 350 },
                            new Demography { Demographic = DemographicType.M_18_35, Rating = 150 },
                            new Demography { Demographic = DemographicType.T_18_40, Rating = 500 }
                        },
                    }
                };
        }
    }
}
