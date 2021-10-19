using Microsoft.Extensions.Logging;
using PopulationAnalyzer.DataModels;
using PopulationAnalyzer.DomainModels;
using PopulationAnalyzer.Helpers;
using PopulationAnalyzer.Repositories.UnitOfWork;
using PopulationAnalyzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PopulationAnalyzer.Helper.Common;

namespace PopulationAnalyzer.Services
{
    public class PopulationService: IPopulationService
    {
        private IUnitOfWork _unitOfWork;
        private readonly ILogger<PopulationService> _logger;

        public PopulationService(IUnitOfWork unitOfWork, ILogger<PopulationService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public GetCountryPopulationResponse GetCountryPopulation(GetCountryPopulationRequest request)
        {
            try
            {
                GetCountryPopulationResponse resp = new GetCountryPopulationResponse();

                var dbPopulation = _unitOfWork.PopulationMockRepository.GetAllPopulationByCountry(request.CountryName);


                if(dbPopulation != null && dbPopulation.Any())
                {
                    CountryPopulation countryPopulation = new CountryPopulation();

                    countryPopulation.Male = dbPopulation.Where(w => w.Gender == PopulationCSVConstants.Male).Sum(s => s.TotalPopulation);
                    countryPopulation.Female = dbPopulation.Where(w => w.Gender == PopulationCSVConstants.Female).Sum(s => s.TotalPopulation);
                    countryPopulation.Name = dbPopulation.FirstOrDefault().Country;
                    dbPopulation.GroupBy(g => g.Age).ToList().ForEach(ageGroup =>
                    {
                        countryPopulation.AgeGroups.Add(new AgeDemography
                        {
                            AgeGroup = ageGroup.Key,
                            Male = ageGroup.Where(w => w.Gender == PopulationCSVConstants.Male).Sum(s => s.TotalPopulation),
                            Female = ageGroup.Where(w => w.Gender == PopulationCSVConstants.Female).Sum(s => s.TotalPopulation)
                        });
                    });

                    // populate State Data
                    this.PopulateState(dbPopulation, countryPopulation, request.NoOfTopStates);
                    resp.CountryPopulation = countryPopulation;
                }

                return resp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new AppException("Error while populate Country");
            }
        }

        private void PopulateState(List<Population> dbPopulation, CountryPopulation countryPopulation, int noOfStates = 10)
        {
            try
            {
                var top10States = dbPopulation.GroupBy(g => g.State).OrderByDescending(o => o.Sum(s => s.TotalPopulation)).Take(noOfStates).ToList();
                if (top10States.Any())
                {
                    top10States.ForEach(state =>
                    {
                        var statePopulation = new StatePopulation
                        {
                            Name = state.Key,
                            Female = state.Where(w => w.Gender == PopulationCSVConstants.Female).Sum(s => s.TotalPopulation),
                            Male = state.Where(w => w.Gender == PopulationCSVConstants.Male).Sum(s => s.TotalPopulation),
                        };

                        state.GroupBy(g => g.Age).ToList().ForEach(ageGroup =>
                        {
                            statePopulation.AgeGroups.Add(new AgeDemography
                            {
                                AgeGroup = ageGroup.Key,
                                Male = ageGroup.Where(w => w.Gender == PopulationCSVConstants.Male).Sum(s => s.TotalPopulation),
                                Female = ageGroup.Where(w => w.Gender == PopulationCSVConstants.Female).Sum(s => s.TotalPopulation)
                            });
                        });

                        countryPopulation.States.Add(statePopulation);
                    });
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                throw new AppException("Error while populate state");
            }
        }
    }
}
