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
                MetaData m = new MetaData("9.1.1");
                createOrUpdateMetaData(m);
                return m;
            }
            else
            {
                return md.First();
            }
        }

        public static SummonerData getSummonerData()
        {
            var realm = Realm.GetInstance();
            List<SummonerData> sd = realm.All<SummonerData>().ToList();

            if (sd.Count > 1)
            {
                return sd.Single();
            }
            else
            {
                return null;
            }

        }

        public static List<Champion> getChampions()
        {
            var realm = Realm.GetInstance();
            List<Champion> champions = realm.All<Champion>().ToList();

            if (champions.Count < 1)
            {
                return null;
            }
            else
            {
                return champions;
            }
        }

        public static Champion getChampion(int id)
        {
            var realm = Realm.GetInstance();
            Champion champion = realm.All<Champion>().Where(c => c.Key == id).FirstOrDefault();
            return champion;
        }

        public static void createOrUpdateMetaData(MetaData metaData)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(metaData, true);
            });
        }

        public static void createOrUpdateSummonerData(SummonerData summonerData)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                realm.Add(summonerData, true);
            });
        }

        public static void createOrUpdateChampions(List<Champion> champions)
        {
            var realm = Realm.GetInstance();
            realm.Write(() =>
            {
                foreach (Champion c in champions)
                {
                    realm.Add(c, true);
                }
            });
        }
    }
}
