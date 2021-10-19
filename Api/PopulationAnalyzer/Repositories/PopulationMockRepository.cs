using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using PopulationAnalyzer.DataModels;
using PopulationAnalyzer.DomainModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.Repositories
{
    public class PopulationMockRepository: IPopulationMockRepository
    {
        private readonly AppSettings _appSettings;
        public PopulationMockRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public List<Population> GetAllPopulationByCountry(string countryName)
        {
            List<Population> resp = new List<Population>();
            var filePath = _appSettings.DataFilePath;

            // simple csv parsing;
            // assuming data file will be valid
            // assuming only one country. so no filtering based on param.
            // skip first row (header)
            var dataRows = File.ReadAllLines(filePath).Skip(1).ToList();

            dataRows.ForEach(row =>
            {
                var columns = row.Split(",");
                resp.Add(new Population
                {
                    Country = columns[0],
                    State = columns[1],
                    Gender = columns[2],
                    Age = columns[3],
                    TotalPopulation = Convert.ToInt64(columns[4])
                });
            });

            return resp.Where(w => w.Country == countryName).ToList();
        }


    }
}
