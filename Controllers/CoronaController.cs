using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("closedapi/[controller]")]
    [ApiController]
    public class CoronaController : ControllerBase
    {
        private readonly CoronaAPI corona;
        public CoronaController(CoronaAPI _api)
        {
            corona = _api;
        }


     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoronaListByCountry>>> Get(string filter)
        {
            var result = await corona.GetListWithCountriesAsync();
            if (!string.IsNullOrEmpty(filter))
                result = result.Where(o => o.country.ToLower().StartsWith(filter.ToLower())).ToList();
            return new OkObjectResult(result);
        }

        //// GET: api/Data/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

    }
}
