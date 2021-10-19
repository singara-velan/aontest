using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.DataModels
{
    public class Population
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public long TotalPopulation { get; set; } 
    }
}
