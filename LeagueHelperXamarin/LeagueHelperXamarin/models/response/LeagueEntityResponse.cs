using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueHelperXamarin.models.response
{
    class LeagueEntityResponse
    {
        public string QueueType { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Tier { get; set; }
        public string Rank { get; set; }
        public int LeaguePoints { get; set; }
    }
}
