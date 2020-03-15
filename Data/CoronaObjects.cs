using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data
{
    
    public class GlobalCoronaStats
    {
        //https://corona.lmao.ninja/all
        public int cases { get; set; }
        public int deaths { get; set; }
        public int recovered { get; set; }
    }
    public class CoronaListByCountry
    {
        //{"country":"France","cases":4469,"todayCases":0,"deaths":91,"todayDeaths":0,"recovered":12,"critical":300}
        public string country { get; set; }
        public int cases { get; set; }
        public int todayCases { get; set; }
        public int deaths { get; set; }
        public int todayDeaths { get; set; }
        public int recovered { get; set; }
        public int critical { get; set; }
    }


}
