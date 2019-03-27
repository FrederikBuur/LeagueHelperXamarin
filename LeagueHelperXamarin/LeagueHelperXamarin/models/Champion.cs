using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Realms;

namespace LeagueHelperXamarin.models
{
    public class Champion : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Version { get; set; }
        public int Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public Image Image { get; set; }

        [Ignored, JsonIgnore]
        public string ChampIconImageUrl
        {
            get { return $"http://ddragon.leagueoflegends.com/cdn/{Version}/img/champion/{Image.Full}"; }
        }
        [Ignored, JsonIgnore]
        public string ChampFullImageUrl
        {
            get { return $"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{Id}_0.jpg"; }
        }

    }
}
