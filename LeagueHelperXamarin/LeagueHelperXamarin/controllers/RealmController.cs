using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueHelperXamarin.models;
using Realms;

namespace LeagueHelperXamarin.controllers
{
    class RealmController
    {
        public static MetaData getMetaData()
        {
            var realm = Realm.GetInstance();
            List<MetaData> md = realm.All<MetaData>().ToList();

            if (md.Count < 1)
            {
                MetaData m = new MetaData("0.0.0");
                createOrUpdateMetaData(m);
                return m;
            }
            else
            {
                return md.First();
            }
        }

        public static void createOrUpdateMetaData(MetaData metaData)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(metaData, true);
            });
        }
    }
}
