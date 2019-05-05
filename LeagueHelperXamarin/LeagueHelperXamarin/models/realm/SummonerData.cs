using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueHelperXamarin.models
{
    public class SummonerData : RealmObject
    {
        [PrimaryKey]
        public string SummonerId { get; set; } = "";
        public string AccountId { get; set; } = "";
        public string Name { get; set; } = "";
        public int Level { get; set; } = 0;
        public int profileIconId { get; set; }

        public SummonerData()
        {
        }

        public SummonerData(string SummonerId, string AccountId, string Name, int Level, int profileIconId)
        {
            this.SummonerId = SummonerId;
            this.AccountId = AccountId;
            this.Name = Name;
            this.Level = Level;
            this.profileIconId = profileIconId;
        }

    }

}
