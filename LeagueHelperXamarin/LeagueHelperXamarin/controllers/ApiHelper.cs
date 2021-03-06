﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LeagueHelperXamarin.controllers
{
    public static class ApiHelper
    {
        public static string API_KEY = "RGAPI-64c30f10-c697-4bd6-9380-198c59ce6b77";

        public static HttpClient DDApiClient { get; set; }
        public static HttpClient RiotApiClient { get; set; }

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

        public static void InitRiotClient()
        {
            if (RiotApiClient == null)
            {
                RiotApiClient = new HttpClient();
                RiotApiClient.BaseAddress = new Uri("https://euw1.api.riotgames.com/lol/");
                RiotApiClient.DefaultRequestHeaders.Accept.Clear();
                RiotApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicaiton/json"));
                //RiotApiClient.DefaultRequestHeaders.Add("api_key", API_KEY);
            }
        }
    }
}
