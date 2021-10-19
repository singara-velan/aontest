using PopulationAnalyzer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.Services.Interfaces
{
    public interface IPopulationService
    {
        GetCountryPopulationResponse GetCountryPopulation(GetCountryPopulationRequest request);
    }
}
