using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PopulationAnalyzer.DomainModels;
using PopulationAnalyzer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationAnalyzer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationController : ControllerBase
    {
        private readonly ILogger<PopulationController> _logger;
        private IPopulationService _populationService;
        public PopulationController(ILogger<PopulationController> logger, IPopulationService populationService)
        {
            _logger = logger;
            _populationService = populationService;
        }

        [HttpPost]
        [Route("GetCountryPopulation")]
        public IActionResult GetCountryPopulation(GetCountryPopulationRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _populationService.GetCountryPopulation(request);
            return Ok(response);
        }

    }
}
