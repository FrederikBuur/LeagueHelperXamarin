using LeagueHelperXamarin.models;
using LeagueHelperXamarin.models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeagueHelperXamarin.controllers
{
    class RiotController
    {
        public static async Task<SummonerData> SearchSummoner(string summonerName)
        {
            string path = $"summoner/v4/summoners/by-name/{summonerName}?api_key={ApiHelper.API_KEY}";
            try
            {
                using (HttpResponseMessage response = await ApiHelper.RiotApiClient.GetAsync(path))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        SummonerResponse summonerResponse = await response.Content.ReadAsAsync<SummonerResponse>();
                        SummonerData sd = new SummonerData(summonerResponse.Id,
                            summonerResponse.AccountId,
                            summonerResponse.Name,
                            summonerResponse.SummonerLevel,
                            summonerResponse.ProfileIconId);
                        SessionController.getInstance().summonerData = sd;
                        //RealmController.createOrUpdateSummonerData(sd); // TODO use this to save fetched summoner
                        return sd;
                    }
                    else
                    {
                        Console.WriteLine("error getting summoner");
                        Console.WriteLine(response);
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task<LeagueEntityResponse> FetchSummonerRank(string summonerId)
        {
            string path = $"league/v4/entries/by-summoner/{summonerId}?api_key={ApiHelper.API_KEY}";
            try
            {
                using (HttpResponseMessage response = await ApiHelper.RiotApiClient.GetAsync(path))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        LeagueEntityResponse[] leaguesResponse = await response.Content.ReadAsAsync<LeagueEntityResponse[]>();

                        var le = from LeagueEntityResponse entity
                        in leaguesResponse
                                 where entity.QueueType == "RANKED_SOLO_5x5"
                                 select entity;

                        SessionController.getInstance().leagueEntityResponse = le.First();
                        return le.First();
                    }
                    else
                    {
                        Console.WriteLine("error getting summoner leauge");
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task<MatchListResponse> FetchSummonerMatches(string accountId)
        {
            string path = $"match/v4/matchlists/by-account/{accountId}";
            try
            {
                using (HttpResponseMessage response = await ApiHelper.RiotApiClient.GetAsync(path))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        MatchListResponse matchesResponse = await response.Content.ReadAsAsync<MatchListResponse>();
                        return matchesResponse;
                    }
                    else
                    {
                        Console.WriteLine("error getting summoner match history");
                        return null;
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
