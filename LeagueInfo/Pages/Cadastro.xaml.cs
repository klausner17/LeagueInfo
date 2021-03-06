﻿using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using LeagueInfo.Resources;

namespace LeagueInfo.Pages
{
    public partial class Cadastro : PhoneApplicationPage
    {
        private LeagueWS.LeagueServiceClient ls;

        public Cadastro()
        {
            InitializeComponent();
        }

        private void buttonFinalizarCadastro_Click(object sender, RoutedEventArgs e)
        {
            ls = new LeagueWS.LeagueServiceClient();
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
                GlobalData.UserLogged = user;
                ls.finalizarCadastroCompleted += Ls_finalizarCadastroCompleted;
                ls.finalizarCadastroAsync(user, user.senha);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel cadastrar o usuário. Detalhes: \n" + ex.Message + ".\n" + ex.InnerException.Message);
            }
        }

        private void Ls_finalizarCadastroCompleted(object sender, LeagueWS.finalizarCadastroCompletedEventArgs e)
        {
            try
            {
                if (e.Result)
                {
                    MessageBox.Show("Cadastro efetuado.");
                    GlobalData.Logged = true;
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
            finally
            {
                ls.CloseAsync();
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            textBoxLogin.Text = NavigationContext.QueryString["summoner"];
        }
    }
}