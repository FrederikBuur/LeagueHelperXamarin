using System;
using System.Collections.Generic;
using System.Text;
using LeagueHelperXamarin.models;
using LeagueHelperXamarin.models.response;

namespace LeagueHelperXamarin.controllers
{
    class SessionController
    {
        private static SessionController instance { get; set; } = null;

        public MetaData metaData { get; set; }
        public SummonerData summonerData { get; set; }
        public LeagueEntityResponse leagueEntityResponse { get; set; }

        public static SessionController getInstance()
        {
            if (instance == null)
            {
                instance = new SessionController();
            }
            return instance;
        }
    }
}
