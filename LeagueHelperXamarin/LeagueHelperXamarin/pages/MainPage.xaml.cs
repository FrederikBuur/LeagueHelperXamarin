using LeagueHelperXamarin.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeagueHelperXamarin
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await DDController.CheckForUpdates();
            }
            catch (Exception e)
            {
                await DisplayAlert("Error", e.Message, "Ok");
            }
        }
    }
}
