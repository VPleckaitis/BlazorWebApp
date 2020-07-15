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
    public class CoronaAPI
    {
       private readonly string APIUrl = "https://corona.lmao.ninja/v2/";

        public async Task<CoronaGlobalStats> GetTodayStatsAsync()
        {
            CoronaGlobalStats stats = new CoronaGlobalStats();
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
                stats.cases = -1;
                stats.deaths = -1;
                stats.recovered = -1;
               
            }

            return stats;
        }

        public async Task<List<CoronaListByCountry>> GetListWithCountriesAsync()
        {
            List<CoronaListByCountry> countries = new List<CoronaListByCountry>();
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
               
            }

            return countries;
        }
    }
}

