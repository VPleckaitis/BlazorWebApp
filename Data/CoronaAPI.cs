using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WebApp.Data
{
    public class CoronaAPI
    {
       private string APIUrl = "https://corona.lmao.ninja/v2/";

        public async Task<GlobalCoronaStats> GetTodayStatsAsync()
        {
            var stats = new GlobalCoronaStats();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(APIUrl+"all");
                    var respObject = JObject.Parse(response);


                    stats.cases = (int)respObject["cases"];
                    stats.deaths = (int)respObject["deaths"];
                    stats.recovered = (int)respObject["recovered"];
                  
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
                    var respObject = JArray.Parse(response);

                    foreach (var countryObj in respObject)
                    {
                        var country = new CoronaListByCountry();
                        country.country = (string)countryObj["country"];
                        country.cases = (int)countryObj["cases"];
                        country.todayCases = (int)countryObj["todayCases"];
                        country.deaths = (int)countryObj["deaths"];
                        country.todayDeaths = (int)countryObj["todayDeaths"];
                        country.recovered = (int)countryObj["recovered"];
                        country.critical = (int)countryObj["critical"];

                        countries.Add(country);
                    }
                }
            }
            catch
            {
               
            }

            return countries;
        }
    }
}

