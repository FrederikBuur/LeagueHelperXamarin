using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueHelperXamarin.models
{
    public class ChampionsResponse
    {
        public string Version { get; set; }
        public Dictionary<string, Champion> Data { get; set; }
    }
}
