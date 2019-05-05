using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace LeagueHelperXamarin.models
{
    public class Image : RealmObject
    {
        public string Full { get; set; }

        public static string getProfileIconImagePath(int iconId, string version)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{version}/img/profileicon/{iconId}.png";
        }
    }
}
