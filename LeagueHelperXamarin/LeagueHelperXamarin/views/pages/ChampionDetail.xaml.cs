using LeagueHelperXamarin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeagueHelperXamarin.pages
{
    public partial class ChampionDetail : ContentPage
    {
        private Champion champion { get; set; }

        public ChampionDetail(Champion champion)
        {
            this.champion = champion;

            InitializeComponent();

            container.BindingContext = this.champion;
        }
    }
}