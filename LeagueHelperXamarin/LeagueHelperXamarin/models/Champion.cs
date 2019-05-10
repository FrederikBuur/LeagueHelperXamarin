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
            get { return ChampionImageUrl(Version, Image.Full); }
        }
        [Ignored, JsonIgnore]
        public string ChampFullImageUrl
        {
            get { return $"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/{Id}_0.jpg"; }
        }

        public static string ChampionImageUrl(string version, string champ)
        {
            return $"http://ddragon.leagueoflegends.com/cdn/{version}/img/champion/{champ}";
        }

        public static string SummonerSpellImageUrl(string verison, int id)
        {
            string sumSpellName = "";
            switch (id)
            {
                case 3:
                    sumSpellName = "SummonerExhaust";
                    break;
                case 4:
                    sumSpellName = "SummonerFlash";
                    break;
                case 6:
                    sumSpellName = "SummonerHaste";
                    break;
                case 7:
                    sumSpellName = "SummonerHeal";
                    break;
                case 11:
                    sumSpellName = "SummonerSmite";
                    break;
                case 12:
                    sumSpellName = "SummonerTeleport";
                    break;
                case 14:
                    sumSpellName = "SummonerDot";
                    break;
                case 21:
                    sumSpellName = "SummonerBarrier";
                    break;
                case 32:
                    sumSpellName = "SummonerSnowball";
                    break;
                default:
                    sumSpellName = "SummonerOdysseyRevive";
                    break;
            }
            return $"http://ddragon.leagueoflegends.com/cdn/{verison}/img/spell/{sumSpellName}.png";
        }

    }
}
