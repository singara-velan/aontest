using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PopulationAnalyzer.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.Repositories.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private PopulationMockRepository populationMockRepository;

        private readonly IOptions<AppSettings> _appSettings;
        public UnitOfWork(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }


        public IPopulationMockRepository PopulationMockRepository
        {
            get
            {
                return populationMockRepository ?? (populationMockRepository = new PopulationMockRepository(_appSettings));
            }
        }
    }
}
