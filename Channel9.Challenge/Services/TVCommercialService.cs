using Channel9.Challenge.Repositories;
using Channel9.Challenge.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Channel9.Challenge.Services
{
    public interface ITVCommercialService
    {
        List<CommercialBreak> GetOptimizedCommercialBreaks(Dictionary<string, int> rules);
    }

    public class TVCommercialService : ITVCommercialService
    {
        private readonly IRepository<Break> _breakRepo;
        private readonly IRepository<Commercial> _CommercialRepo;

        public TVCommercialService(IRepository<Break> breakRepo, IRepository<Commercial> commercialRepo)
        {
            _breakRepo = breakRepo;
            _CommercialRepo = commercialRepo;
        }

        public List<CommercialBreak> GetOptimizedCommercialBreaks(Dictionary<string, int> rules)
        {
            var commercialBreaks = new List<CommercialBreak>();

            var breaks = _breakRepo.GetAll();
            var commercials = _CommercialRepo.GetAll();

            if (rules.Sum(x => x.Value) > commercials.Count())
            {
                throw new Exception("Commercials requested are higher than available commercials");
            }

            foreach (var breakItem in breaks)
            {
                int maxCommercialsForBreak = rules[breakItem.Id];

                var demographiesForBreak = breakItem.Demographies.OrderByDescending(x => x.Rating).ToList();

                var breakCommercials = new List<BreakCommercial>();

                var index = 0;

                var lastAddedType = CommercialType.Undefined;

                while (breakCommercials.Count() < maxCommercialsForBreak)
                {
                    var demographicCommercials = commercials.Where(x => x.Demographic == demographiesForBreak[index].Demographic).ToList();

                    foreach (var commercial in demographicCommercials)
                    {
                        if (commercial.Type != lastAddedType
                        && (breakItem.Id != "Break2" || commercial.Type != CommercialType.Finance))
                        {
                            {
                                breakCommercials.Add(new BreakCommercial
                                {
                                    CommercialId = commercial.Id,
                                    Demography = commercial.Demographic,
                                    Type = commercial.Type,
                                    Rating = demographiesForBreak[index].Rating
                                });
                                lastAddedType = commercial.Type;
                                commercials.Remove(commercial);

                                if (breakCommercials.Count() >= maxCommercialsForBreak)
                                    break;
                            }
                        }
                    }

                    index++;
                }

                commercialBreaks.Add(new CommercialBreak { BreakId = breakItem.Id, Commercials = breakCommercials });
            }

            return commercialBreaks;
        }
    }
}
