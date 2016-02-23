using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading.Tasks;
using LeagueInfo.ClassApi;

namespace LeagueInfo.Pages
{
    public partial class Splash : PhoneApplicationPage
    {
        public Splash()
        {
            InitializeComponent();
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            progress.Visibility = System.Windows.Visibility.Visible;
            await Loading();
            this.NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async Task Loading()
        {
            textBlockStatus.Text = "carregando informações basicas";
            await EndPointDDragon.GetVersions();
            textBlockStatus.Text = "carregando campeões";
            await ChampionListDto.LoadAllChampions();
            textBlockStatus.Text = "carregando itens";
            await ItemListDto.LoadAllItens();
        }
    }
}