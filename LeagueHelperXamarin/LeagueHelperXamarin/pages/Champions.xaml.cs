using LeagueHelperXamarin.controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueHelperXamarin.pages
{
    public partial class Champions : ContentPage
    {
        public Champions()
        {
            InitializeComponent();
            listView.ItemsSource = RealmController.getChampions();
        }
    }
}