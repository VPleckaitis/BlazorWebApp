using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using WebApp.Models;
using Newtonsoft.Json;

namespace WebApp.Data
{
    [Obsolete]
    public class CoronaAPI
    {
       private readonly string APIUrl = "https://corona.lmao.ninja/v2/";

        public async Task<CoronaGlobalStats> GetTodayStatsAsync()
        {
            CoronaGlobalStats stats; 
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(APIUrl+"all");
                    stats = JsonConvert.DeserializeObject<CoronaGlobalStats>(response);
                }    
            }
            catch 
            {
                stats = new CoronaGlobalStats();
                stats.cases = -1;
                stats.deaths = -1;
                stats.recovered = -1;
            }

            return stats;
        }

        public async Task<List<CoronaListByCountry>> GetListWithCountriesAsync()
        {
            List<CoronaListByCountry> countries;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(APIUrl+ "countries");
                    countries = JsonConvert.DeserializeObject<List<CoronaListByCountry>>(response);
                }
            }
            catch // failed to deserialise, ignore for now
            {
               countries =  new List<CoronaListByCountry>(); // just return empty list without crashing
            }

            return countries;
        }
    }
}

