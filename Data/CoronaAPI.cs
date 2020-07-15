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
            var stats = new CoronaGlobalStats();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(APIUrl+"all");
                    //// var respObject = JObject.Parse(response);


                    // stats.cases = (int)respObject["cases"];
                    // stats.deaths = (int)respObject["deaths"];
                    // stats.recovered = (int)respObject["recovered"];
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
            var countries = new List<CoronaListByCountry>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(APIUrl+ "countries");
                    //var respObject = JArray.Parse(response);

                    //foreach (var countryObj in respObject)
                    //{
                    //    var country = JsonConvert.DeserializeObject<GlobalCoronaStats>(countryObj.ToString());//new CoronaListByCountry();
                    //    country.country = (string)countryObj["country"];
                    //    country.cases = (int)countryObj["cases"];
                    //    country.todayCases = (int)countryObj["todayCases"];
                    //    country.deaths = (int)countryObj["deaths"];
                    //    country.todayDeaths = (int)countryObj["todayDeaths"];
                    //    country.recovered = (int)countryObj["recovered"];
                    //    country.critical = (int)countryObj["critical"];

                    //    countries.Add(country);
                    //}

                    countries = JsonConvert.DeserializeObject<List<CoronaListByCountry>>(response);
                }
            }
            catch
            {
               
            }

            return countries;
        }
    }
}

