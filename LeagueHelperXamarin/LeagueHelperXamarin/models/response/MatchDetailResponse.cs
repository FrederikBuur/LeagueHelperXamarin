using System;
using System.Collections.Generic;
using System.Text;

namespace LeagueHelperXamarin.models.response
{
    class MatchDetailResponse
    {
        public long gameId { get; set; }
        public int queueId { get; set; }
        public Team[] teams { get; set; }
        public Participant[] participants { get; set; }
        public ParticipantIdentity[] participantIdentities { get; set; }
    }

    class Team
    {
        public int teamId { get; set; }
        public string win { get; set; }

    }

    class Participant
    {
        public int teamId { get; set; }
        public int championId { get; set; }
        public int spell1Id { get; set; }
        public int spell2Id { get; set; }
        public Stats stats { get; set; }
    }

    class Stats
    {
        public int participantId { get; set; }
        public bool win { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
    }

    class ParticipantIdentity
    {
        public int participantId { get; set; }
        public Player player { get; set; }
    }

    class Player
    {
        public string summonerId { get; set; }
        public string summonerName { get; set; }
    }
}
