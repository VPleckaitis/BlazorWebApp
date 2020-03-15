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
       private string APIUrl = "https://corona.lmao.ninja/";

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
    }
}
