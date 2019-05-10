using Realms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

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

        public static bool nameIsValid(string name)
        {
            string regex = "^[0-9\\p{L}\\ _\\.]{3,16}$";

            bool isValidName = Regex.IsMatch(name, regex);

            return isValidName;
        }

    }

}
