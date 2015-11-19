using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LeagueInfo.Pages
{
    public partial class Login : PhoneApplicationPage
    {
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

        private void HyperlinkButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            e.ca
        }
    }
}