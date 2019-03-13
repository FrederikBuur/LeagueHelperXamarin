using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace LeagueHelperXamarin.models
{
    public class MetaData : RealmObject
    {
        private int id = 1;
        public string localVersion { get; set; } = "";

        public MetaData(string localVersion)
        {
            this.localVersion = localVersion;
        }
    }
}
