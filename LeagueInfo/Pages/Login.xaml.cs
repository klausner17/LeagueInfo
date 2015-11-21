using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LeagueInfo.ClassApi;

namespace LeagueInfo.Pages
{
    public partial class Login : PhoneApplicationPage
    {

        SummonerDto summoner;

        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            LeagueWS.LeagueServiceClient ls = new LeagueWS.LeagueServiceClient();
            ls.loginCompleted += ls_loginCompleted;
            ls.loginAsync(nomeInvocador.Text, senha.Password);
        }

        void ls_loginCompleted(object sender, LeagueWS.loginCompletedEventArgs e)
        {
            try
            {
                if (e.Result)
                    NavigationService.Navigate(new Uri("/Pages/MainPage.xaml?logado=true", UriKind.RelativeOrAbsolute));
                else
                    MessageBox.Show("Login não efetuado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private async void buttonCadastro_Click(object sender, RoutedEventArgs e)
        {
            if(nomeInvocador.Text == string.Empty)
            {
                MessageBox.Show("Digite o nome do invocador antes de se cadastrar.");
            }
            else
            {
                summoner = new SummonerDto();
                try
                {
                    summoner = await summoner.SearchSummoner(nomeInvocador.Text);
                    LeagueWS.LeagueServiceClient ls = new LeagueWS.LeagueServiceClient();
                    ls.encontrarUsuarioCompleted += Ls_encontrarUsuarioCompleted;
                    ls.encontrarUsuarioAsync(nomeInvocador.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("Erro ao procurar invocador.");
                }
            }
        }

        private void Ls_encontrarUsuarioCompleted(object sender, LeagueWS.encontrarUsuarioCompletedEventArgs e)
        {
            try
            {
                if (e.Result == null || !e.Result.validado)
                    NavigationService.Navigate(new Uri("/Pages/PreCadastro.xaml?summoner=" + summoner.Nome + "&idSummoner=" + summoner.Id.ToString()
                        , UriKind.RelativeOrAbsolute));
                else
                    MessageBox.Show("Invocador já cadastrado.");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        private void buttonSemCadastro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/MainPage.xaml?logado=false", UriKind.RelativeOrAbsolute));
        }
    }
}