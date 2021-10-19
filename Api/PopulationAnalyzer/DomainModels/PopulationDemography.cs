using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.DomainModels
{
    public class PopulationDemography: GenderDemography
    {
        public List<AgeDemography> AgeGroups { get; set; }

        public PopulationDemography()
        {
            AgeGroups = new List<AgeDemography>();
        }
    }
}
