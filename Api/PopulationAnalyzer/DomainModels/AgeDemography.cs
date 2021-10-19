using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.DomainModels
{
    public class AgeDemography: GenderDemography
    {
        public string AgeGroup { get; set; }
    }
}
