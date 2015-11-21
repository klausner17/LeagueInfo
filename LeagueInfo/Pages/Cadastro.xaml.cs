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
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace LeagueInfo.Pages
{
    public partial class Cadastro : PhoneApplicationPage
    {
        private LeagueWS.LeagueServiceClient ls;
        public Cadastro()
        {
            InitializeComponent();
            ls = new LeagueWS.LeagueServiceClient();
        }

        private void buttonFinalizarCadastro_Click(object sender, RoutedEventArgs e)
        {
            ls.encontrarUsuarioCompleted += Ls_encontrarUsuarioCompleted;
            ls.encontrarUsuarioAsync(NavigationContext.QueryString["summoner"]);            
        }

        private void Ls_encontrarUsuarioCompleted(object sender, LeagueWS.encontrarUsuarioCompletedEventArgs e)
        {
            try
            {
                LeagueWS.usuario user = e.Result;
                user.nome = textBoxName.Text;
                user.senha = textBoxPassword.Password;
                user.sexo = radioButtonMasculino.IsChecked == true ? "m" : "f";
                user.validado = true;
                user.dataNasc = (DateTime)datePickerBornDate.Value;
                ls.alterarUsuarioCompleted += Ls_alterarUsuarioCompleted;
                ls.alterarUsuarioAsync(user);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possivel cadastrar o usuário. Detalhes: \n" + ex.Message + ".\n" + ex.InnerException.Message);
            }
        }

        private void Ls_alterarUsuarioCompleted(object sender, LeagueWS.alterarUsuarioCompletedEventArgs e)
        {
            try
            {
                if (e.Result)
                {
                    MessageBox.Show("Cadastro efetuado.");
                    NavigationService.Navigate(new Uri("/Pages/MainPage.xaml?logado=true", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    MessageBox.Show("Cadastro não foi efetuado, tente mais tarde.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível realizar o cadastro. Detalhes: \n" + ex.Message + ".\n" + ex.InnerException.Message);
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxLogin.Text = NavigationContext.QueryString["summoner"];
        }
    }
}