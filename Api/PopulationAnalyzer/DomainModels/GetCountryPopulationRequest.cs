using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.DomainModels
{
    public class GetCountryPopulationRequest
    {
        [Required]
        public string CountryName { get; set; }
        [Required]
        public int NoOfTopStates { get; set; }
    }
}
