using LeagueHelperXamarin.controllers;
using LeagueHelperXamarin.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueHelperXamarin.pages
{
    public partial class Champions : ContentPage
    {
        private List<Champion> championList;

        public Champions()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            championList = RealmController.getChampions();
            listView.ItemsSource = championList;
        }

        private async void ChampionOnClick(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var selectedChampion = e.SelectedItem as Champion;
            await Navigation.PushAsync(new ChampionDetail(selectedChampion));

            ((ListView)sender).SelectedItem = null;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (championList == null) return;

            if (e.NewTextValue.Length < 1)
            {
                listView.ItemsSource = championList;
            }
            else
            {
                listView.ItemsSource = championList.Where(c => c.Name.ToLower().StartsWith(e.NewTextValue.ToLower()));
            }
        }
    }
}