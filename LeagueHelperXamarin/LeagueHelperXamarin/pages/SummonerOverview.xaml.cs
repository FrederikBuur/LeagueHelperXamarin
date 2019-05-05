using LeagueHelperXamarin.controllers;
using LeagueHelperXamarin.models;
using LeagueHelperXamarin.models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Image = LeagueHelperXamarin.models.Image;

namespace LeagueHelperXamarin.pages
{
    public partial class SummonerOverview : ContentPage
    {

        private LeagueEntityResponse leagueEntityResponse { get; set; }
        private string[] matchHistory { get; set; }
        private SummonerData summonerData { get; set; }

        public SummonerOverview(SummonerData summonerData)
        {
            this.summonerData = summonerData;

            //NavigationPage.SetHasNavigationBar(this, false);
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //setupViews();
        }

        private async void setupViews()
        {

            await RiotController.FetchSummonerRank(summonerData.SummonerId).ContinueWith(task =>
           {
               LeagueEntityResponse ler = task.Result;
               Device.BeginInvokeOnMainThread(() =>
               {
                   //summonerName.Text = summonerData.Name;
                   //level.Text = summonerData.Level.ToString();
                   //rank.Text = $"{ler.Tier} {ler.Rank} ({ler.LeaguePoints} LP)";
                   //profileIcon.Source = Image.getProfileIconImagePath(summonerData.profileIconId,
                   //    SessionController.getInstance().metaData.localVersion);
                   // insert win ratio
               });
           });

            /*
            await RiotController.FetchSummonerMatches(summonerData.AccountId).ContinueWith(task =>
            {
                //TODO
            });
            */
        }

    }
}