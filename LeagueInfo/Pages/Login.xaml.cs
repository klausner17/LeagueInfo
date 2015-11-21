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
        LeagueWS.LeagueServiceClient ls;

        public Login()
        {
            InitializeComponent();
            ls = new LeagueWS.LeagueServiceClient();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            
            if (nomeInvocador.Text != string.Empty && senha.Password != string.Empty)
            {
                buttonCadastro.IsEnabled = false;
                buttonSemCadastro.IsEnabled = false;
                ls.loginCompleted += ls_loginCompleted;
                ls.loginAsync(nomeInvocador.Text, senha.Password);
            }
            else
            {
                MessageBox.Show("Insira o seu nome de invocadsor e sua senha.");
            }
        }

        void ls_loginCompleted(object sender, LeagueWS.loginCompletedEventArgs e)
        {
            try
            {
                buttonCadastro.IsEnabled = true;
                buttonSemCadastro.IsEnabled = true;
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
                    buttonLogin.IsEnabled = false;
                    buttonSemCadastro.IsEnabled = false;
                    summoner = await summoner.SearchSummoner(nomeInvocador.Text);
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
                buttonLogin.IsEnabled = true;
                buttonSemCadastro.IsEnabled = true;
                if (e.Result == null || !e.Result.validado)
                {
                    string uriNavigate = "/Pages/PreCadastro.xaml?summoner=" + summoner.Nome + "&idSummoner=" + summoner.Id.ToString()
                        + "&validador=" + (e.Result == null ? "" : e.Result.validador.ToString() + "&idUser=" + e.Result.idUsuario);
                    NavigationService.Navigate(new Uri(uriNavigate, UriKind.RelativeOrAbsolute));
                }
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