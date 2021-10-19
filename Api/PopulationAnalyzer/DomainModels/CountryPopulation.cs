using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.DomainModels
{
    public class CountryPopulation : PopulationDemography
    {
        public string Name { get; set; }
        public List<StatePopulation> States { get; set; }

        public CountryPopulation()
        {
            States = new List<StatePopulation>();
        }
    }
}
