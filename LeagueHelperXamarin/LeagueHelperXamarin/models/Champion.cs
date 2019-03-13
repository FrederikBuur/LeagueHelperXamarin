using System;
using System.Collections.Generic;
using System.Text;
using Realms;

namespace LeagueHelperXamarin.models
{
    public class Champion : RealmObject
    {
        public string id { get; set; }
        public int key { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public Image Image { get; set; }
    }
}
