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
        private SummonerData summonerData { get; set; }

        public MatchDetailResponse[] mdr;

        public SummonerOverview(SummonerData summonerData)
        {
            this.summonerData = summonerData;

            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            setupViews();
        }

        private void setupViews()
        {

            fetchSummonerDetails();
            fetchSummonerMacthHistory();

        }

        private void fetchSummonerDetails()
        {
            RiotController.FetchSummonerRank(summonerData.SummonerId).ContinueWith(task =>
            {
                LeagueEntityResponse ler = task.Result;
                Device.BeginInvokeOnMainThread(() =>
                {
                    name.Text = summonerData.Name;
                    level.Text = $"Level {summonerData.Level.ToString()}";
                    if (ler != null)
                    {
                        rank.Text = $"{ler.Tier} {ler.Rank} ({ler.LeaguePoints} LP) {ler.Wins}W {ler.Losses}L";
                        String wr = string.Format("{0:0.0}", (float)ler.Wins / (float)(ler.Wins + ler.Losses) * 100);
                        winrate.Text = $"Win Ratio: {wr}%";
                    }
                    profileIcon.Source = Image.getProfileIconImagePath(summonerData.profileIconId,
                          SessionController.getInstance().metaData.localVersion);
                });
            });
        }

        private void fetchSummonerMacthHistory()
        {
            RiotController.FetchSummonerMatches(summonerData.AccountId, 0, 10).ContinueWith(task =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    mdr = task.Result;
                    matchesListView.ItemsSource = mdr;
                });
            });
        }

        private void MatcheOnClick(object sender, SelectedItemChangedEventArgs e)
        {
            // TODO
        }
    }
}