using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using LeagueHelperXamarin.models;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace LeagueHelperXamarin.controllers
{
    public class DDController
    {
        public static async Task CheckForUpdates()
        {
            string path = "api/versions.json";
            try
            {
                using (HttpResponseMessage response = await ApiHelper.DDApiClient.GetAsync(path))
                {
                    var localVersion = RealmController.getMetaData().localVersion;
                    if (response.IsSuccessStatusCode)
                    {
                        //var formatters = new MediaTypeFormatter[] { new JsonMediaTypeFormatter() };
                        //string[] versions = await response.Content.ReadAsAsync<string[]>(formatters);

                        var asString = await response.Content.ReadAsStringAsync();

                        string[] versions = JsonConvert.DeserializeObject<string[]>(asString);

                        var newestVersion = versions[0];

                        if (versionShouldUpdate(localVersion, newestVersion))
                        {
                            // save newest verison local and update
                            Console.WriteLine("save newest verison local and update");
                            MetaData md = new MetaData(newestVersion.ToString());
                            SessionController.getInstance().metaData = md;
                            RealmController.createOrUpdateMetaData(md); // TODO: remember to use this
                            // update champions
                            await FetchAndSaveChampions();
                        }
                        else
                        {
                            SessionController.getInstance().metaData = RealmController.getMetaData();

                            if (RealmController.getChampions() == null)
                            {
                                await FetchAndSaveChampions();
                            }
                            // everything up to date
                            Console.WriteLine("everything up to date");
                        }
                    }
                    else
                    {
                        Console.WriteLine("error getting version");
                        //throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static async Task FetchAndSaveChampions()
        {
            string version = SessionController.getInstance().metaData.localVersion;
            string path = $"cdn/{version}/data/en_US/champion.json";
            try
            {
                using (HttpResponseMessage response = await ApiHelper.DDApiClient.GetAsync(path))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var championResponse = await response.Content.ReadAsAsync<ChampionsResponse>();
                        List<Champion> champions = new List<Champion>();
                        foreach (Champion c in championResponse.Data.Values)
                        {
                            champions.Add(c);
                        }
                        RealmController.createOrUpdateChampions(champions);
                    }
                    else
                    {
                        Console.WriteLine("Error?");
                        //throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static bool versionShouldUpdate(string localVersion, string newestVersion)
        {

            var nv = new Version(newestVersion);
            var lv = new Version(localVersion);

            if (lv == null ||
                lv.Equals("") ||
                nv.CompareTo(lv) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
