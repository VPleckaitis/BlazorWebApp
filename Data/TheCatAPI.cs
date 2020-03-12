﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WebApp.Data
{
    public class TheCatAPI
    {
       private string APIUrl = "https://api.thecatapi.com/v1/images/search";

        public async Task<TheCat> GetRandomCatAsync()
        {
            var cat = new TheCat();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(APIUrl);
                    var respObject = JArray.Parse(response);

                    foreach (var catObj in respObject)
                    {
                        cat.URL = (string)catObj["url"];
                        cat.Width = (int)catObj["width"];
                        cat.Height = (int)catObj["height"];
                    }
                }    
            }
            catch 
            {
                cat = new TheCat() { URL = "https://geek.hellyer.kiwi/files/2017/06/cat-404.jpg", Width = 625, Height = 416 };
            }

            return cat;
        }
    }
}
