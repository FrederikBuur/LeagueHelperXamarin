using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeagueHelperXamarin.controllers
{
    class RiotController
    {
        public static async Task SearchSummoner(string summonerName)
        {
            string path = $"summoner/v4/summoners/by-name/{summonerName}";
            try
            {
                using (HttpResponseMessage response = await ApiHelper.RiotApiClient.GetAsync(path))
                {

                    if (response.IsSuccessStatusCode)
                    {

                    }
                    else
                    {
                        Console.WriteLine("error getting summoner");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
