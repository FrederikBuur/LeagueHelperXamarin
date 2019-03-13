using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using LeagueHelperXamarin.models;

namespace LeagueHelperXamarin.controllers
{
    class DDController
    {
        public static async Task CheckForUpdates()
        {
            string path = "api/versions.json";
            using (HttpResponseMessage response = await ApiHelper.DDApiClient.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {
                    string[] versions = await response.Content.ReadAsAsync<string[]>();
                    var newestVersion = new Version(versions[0]);
                    var localVersion = new Version(RealmController.getMetaData().localVersion);

                    if (localVersion == null || localVersion.Equals("") ||
                        newestVersion.CompareTo(localVersion) > 0)
                    {
                        // save newest verison local and update
                        MetaData md = new MetaData(newestVersion.ToString());
                        SessionController.getInstance().metaData = md;
                        RealmController.createOrUpdateMetaData(md);
                    }
                    else
                    {
                        // everything up to date
                        Console.WriteLine("everything up to date");
                    }
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async Task FetchAndSaveChampions()
        {
            string version = SessionController.getInstance().metaData.localVersion;
            string path = $"cdn/{version}/data/en_US/champion.json";
            using (HttpResponseMessage response = await ApiHelper.DDApiClient.GetAsync(path))
            {
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
