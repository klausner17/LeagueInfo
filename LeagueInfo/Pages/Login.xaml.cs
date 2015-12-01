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
using LeagueInfo.Resources;
using System.IO.IsolatedStorage;
using System.Threading.Tasks;
using Microsoft.Phone.Net.NetworkInformation;

namespace LeagueInfo.Pages
{
    public partial class Login : PhoneApplicationPage
    {

        SummonerDto summoner;
        private LeagueWS.LeagueServiceClient ls;
        private LeagueWS.LeagueServiceClient lsUser;
        private bool wait = true;

        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            
            if (nomeInvocador.Text != string.Empty && senha.Password != string.Empty)
            {
                buttonCadastro.IsEnabled = false;
                buttonSemCadastro.IsEnabled = false;
                buttonLogin.IsEnabled = false;
                ls = new LeagueWS.LeagueServiceClient();
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
                if (e.Result)
                {
                    lsUser = new LeagueWS.LeagueServiceClient();
                    lsUser.encontrarUsuarioCompleted += ls_encontrarUsuarioCompleted;
                    var settings = IsolatedStorageSettings.ApplicationSettings;
                    if (settings.Count > 0 && settings["Login"].ToString() != "")
                    {
                        lsUser.encontrarUsuarioAsync(settings["Login"].ToString());
                    }
                    else
                    {
                        lsUser.encontrarUsuarioAsync(nomeInvocador.Text);
                    }
                }
                else
                    MessageBox.Show("Login não efetuado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            finally
            {
                ls.CloseAsync();
            }
        }

        void ls_encontrarUsuarioCompleted(object sender, LeagueWS.encontrarUsuarioCompletedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new Uri("/Pages/MainPage.xaml?logado=true", UriKind.RelativeOrAbsolute));
                GlobalData.Logged = true;
                GlobalData.UserLogged = e.Result;
                var settings = IsolatedStorageSettings.ApplicationSettings;
                if (settings.Count == 0 || settings["Login"].ToString() == "")
                {
                    settings.Clear();
                    settings.Add("Login", nomeInvocador.Text);
                    settings.Add("Senha", senha.Password);
                    settings.Save();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao fazer login");
            }
            finally
            {
                lsUser.CloseAsync();
                wait = false;
                buttonCadastro.IsEnabled = true;
                buttonSemCadastro.IsEnabled = true;
                buttonLogin.IsEnabled = true;
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
                    ls = new LeagueWS.LeagueServiceClient();
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
                {
                    string uriNavigate = "/Pages/PreCadastro.xaml?summoner=" + summoner.Nome + "&idSummoner=" + summoner.Id.ToString()
                        + "&validador=" + (e.Result == null ? "" : e.Result.validador.ToString() + "&idUser=" + e.Result.idUsuario);
                    NavigationService.Navigate(new Uri(uriNavigate, UriKind.RelativeOrAbsolute));
                }
                else
                    MessageBox.Show("Invocador já cadastrado.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
            finally
            {
                ls.CloseAsync();
                buttonLogin.IsEnabled = true;
                buttonSemCadastro.IsEnabled = true;
                buttonLogin.IsEnabled = true;
            }
        }

        private void buttonSemCadastro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/MainPage.xaml?logado=false", UriKind.RelativeOrAbsolute));
        }

        public async Task LoginAutomatico()
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings != null && settings.Count > 0 && settings["Senha"].ToString() != string.Empty && settings["Login"].ToString() != string.Empty)
            {
                buttonLogin.IsEnabled = false;
                buttonCadastro.IsEnabled = false;
                buttonSemCadastro.IsEnabled = false;
                progresBarCarregando.Visibility = System.Windows.Visibility.Visible;
                ls = new LeagueWS.LeagueServiceClient();
                ls.loginCompleted += ls_loginCompleted;
                ls.loginAsync(settings["Login"].ToString(), settings["Senha"].ToString());
                while (wait)
                {
                    await Task.Delay(10);
                }
                buttonSemCadastro.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private async void pageLogin_Loaded(object sender, RoutedEventArgs e)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("Não foi possível encontrar a conexão com internet. Por favor verifique o sinal.");
                NavigationService.RemoveBackEntry();
                NavigationService.GoBack();
                return;
            }
            NavigationService.RemoveBackEntry();
            await LoginAutomatico();
        }
    }
}