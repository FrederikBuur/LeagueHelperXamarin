using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace LeagueHelperXamarin.models
{
    public class MetaData : RealmObject
    {
        [PrimaryKey]
        public int id { get; set; } = 1;
        public string localVersion { get; set; } = "";

        public MetaData()
        {

        }

        public MetaData(string localVersion)
        {
            this.localVersion = localVersion;
        }
    }
}
