using LeagueHelperXamarin.controllers;
using LeagueHelperXamarin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueHelperXamarin.pages
{
    public partial class SummonerSearch : ContentPage
    {
        public SummonerSearch()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            var sd = SessionController.getInstance().summonerData;

            //look for summoner locally
            if (sd != null &&
                sd.SummonerId != null)
            {
                NavigateToSummonerOverview(sd);
            }
            else
            {
                var sum = RealmController.getSummonerData();
                if (sum != null)
                {
                    SessionController.getInstance().summonerData = sum;
                    NavigateToSummonerOverview(sum);
                }
            }

        }

        private async void SearchSummonerClick(object sender, EventArgs e)
        {
            string summonerSearch = SearchInput.Text;

            //validate name local
            if (nameIsValid(summonerSearch))
            {
                SummonerData sum = null;
                //validate name remote
                await RiotController.SearchSummoner(summonerSearch)
                    .ContinueWith(task =>
               {
                   sum = task.Result;
                   if (sum == null)
                   {
                       Device.BeginInvokeOnMainThread(() =>
                       {
                           DisplayAlert("Summoner Not Found", "A summoner with that names does not exist", "OK");
                       });
                   }
                   else
                   {
                        //push to summoner overview TEMP
                        NavigateToSummonerOverview(sum);
                   }
               });
            }
            else
            {
                await DisplayAlert("Invalid search", "The Summoner name is invalid", "Ok");
            }
        }

        private bool nameIsValid(string name)
        {
            string regex = "^[0-9\\p{L}\\ _\\.]{3,16}$";

            bool isValidName = Regex.IsMatch(name, regex);

            return isValidName;
        }

        private void NavigateToSummonerOverview(SummonerData sumData)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Navigation.PushAsync(new SummonerOverview(sumData));
            });

        }
    }


}