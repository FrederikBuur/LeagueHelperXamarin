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
            return realm.All<MetaData>().First();
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
