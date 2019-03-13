using System;
using System.Collections.Generic;
using System.Text;
using LeagueHelperXamarin.models;

namespace LeagueHelperXamarin.controllers
{
    class SessionController
    {
        private static SessionController instance { get; set; } = null;

        public MetaData metaData { get; set; }
        public string currentSummoner { get; set; }

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
