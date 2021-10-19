using PopulationAnalyzer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.Repositories
{
    public interface IPopulationMockRepository
    {
        List<Population> GetAllPopulationByCountry(string countryName);
    }
}
