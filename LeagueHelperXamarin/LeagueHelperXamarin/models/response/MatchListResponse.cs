using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueHelperXamarin.models.response
{
    class MatchListResponse
    {
        public MatchResponse[] Matches { get; set; }
        public int StartIntex { get; set; }
        public int EndIndex { get; set; }
        public int TotalGames { get; set; }

        public class MatchResponse
        {
            public string GameId { get; set; }
            public int Champion { get; set; }
            public long Timestamp { get; set; }
            public int queue { get; set; }
        }
    }
}
