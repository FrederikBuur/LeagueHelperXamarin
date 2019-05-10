using LeagueHelperXamarin.controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LeagueHelperXamarin.models.response
{
    public class MatchDetailResponse
    {
        public long gameId { get; set; }
        public int queueId { get; set; }
        public Team[] teams { get; set; }
        public Participant[] participants { get; set; }
        public ParticipantIdentity[] participantIdentities { get; set; }

        public string currentChampScore { get; set; }

        //[Ignored, JsonIgnore]
        public Participant currentSummoner
        {
            get
            {
                string sumId = SessionController.getInstance().summonerData.SummonerId;

                if (sumId == null) return null;

                foreach (var participantId in participantIdentities)
                {
                    if (participantId.player.summonerId == sumId)
                    {
                        foreach (var participant in participants)
                        {
                            if (participantId.participantId == participant.participantId)
                            {
                                return participant;
                            }
                        }
                    }
                }
                return null;
            }
        }


    }

    public class Team
    {
        public int teamId { get; set; }
        public string win { get; set; }

    }

    public class Participant
    {
        public int participantId { get; set; }
        public int teamId { get; set; }
        public int championId { get; set; }
        public int spell1Id { get; set; }
        public int spell2Id { get; set; }
        public Stats stats { get; set; }

        public string champIconImageUrl
        {
            get
            {
                string version = SessionController.getInstance().metaData.localVersion;
                Champion c = RealmController.getChampion(championId);
                return Champion.ChampionImageUrl(version, c.Image.Full);
            }
        }

        public string summonerSpell1ImageUrl
        {
            get
            {
                string version = SessionController.getInstance().metaData.localVersion;
                return Champion.SummonerSpellImageUrl(version, spell1Id);
            }
        }

        public string summonerSpell2ImageUrl
        {
            get
            {
                string version = SessionController.getInstance().metaData.localVersion;
                return Champion.SummonerSpellImageUrl(version, spell2Id);
            }
        }

        public Color resultColor
        {
            get
            {
                if (stats.win)
                {
                    return Color.ForestGreen;
                }
                else
                {
                    return Color.IndianRed;
                }
            }
        }
    }

    public class Stats
    {
        public int participantId { get; set; }
        public bool win { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }

        public string score
        {
            get
            {
                return $"{kills}/{deaths}/{assists}";
            }
        }
    }

    public class ParticipantIdentity
    {
        public int participantId { get; set; }
        public Player player { get; set; }
    }

    public class Player
    {
        public string summonerId { get; set; }
        public string summonerName { get; set; }
    }

}
