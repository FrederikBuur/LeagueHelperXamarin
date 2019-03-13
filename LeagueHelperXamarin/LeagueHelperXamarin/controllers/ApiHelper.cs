using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LeagueHelperXamarin.controllers
{
    public static class ApiHelper
    {
        public static HttpClient DDApiClient { get; set; }

        public static void InitDDClient()
        {
            if (DDApiClient == null)
            {
                DDApiClient = new HttpClient();
                DDApiClient.BaseAddress = new Uri("https://ddragon.leagueoflegends.com/");
                DDApiClient.DefaultRequestHeaders.Accept.Clear();
                DDApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicaiton/json"));
            }
        }
    }
}
