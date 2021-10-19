using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.DomainModels
{
    public class GenderDemography
    {
        public long Male { get; set; }
        public long Female { get; set; }
        public long TotalPopulation { get => this.Male + this.Female; }
    }
}
