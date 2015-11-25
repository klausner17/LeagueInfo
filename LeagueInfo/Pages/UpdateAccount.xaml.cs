using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LeagueInfo.Resources;

namespace LeagueInfo.Pages
{
    public partial class UpdateAccount : PhoneApplicationPage
    {
        LeagueWS.LeagueServiceClient ls;
        LeagueWS.usuario user;
        public UpdateAccount()
        {
            InitializeComponent();
            textBoxName.Text = GlobalData.UserLogged.nome;
            if (GlobalData.UserLogged.sexo == "m")
                radioButtonMasculino.IsChecked = true;
            else
                radioButtonFeminino.IsChecked = true;
            datePickerBornDate.Value = GlobalData.UserLogged.dataNasc;
        }

        private void buttonAlterarCadastro_Click(object sender, RoutedEventArgs e)
        {
            user = new LeagueWS.usuario();
            user.login = GlobalData.UserLogged.login;
            user.nome = textBoxName.Text;
            user.email = "not implemented";
            user.sexo = radioButtonFeminino.IsChecked == true ? "f" : "m";
            user.dataNasc = (DateTime)datePickerBornDate.Value;
            user.validado = true;
            user.validador = GlobalData.UserLogged.validador;
            ls = new LeagueWS.LeagueServiceClient();
            ls.alterarUsuarioCompleted += ls_alterarUsuarioCompleted;
            ls.alterarUsuarioAsync(user);
        }

        void ls_alterarUsuarioCompleted(object sender, LeagueWS.alterarUsuarioCompletedEventArgs e)
        {
            try
            {
                if (e.Result)
                {
                    MessageBox.Show("Alterado com sucesso.");
                    GlobalData.UserLogged = user;
                }
                else
                    MessageBox.Show("Erro ao alterar o usuario.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar o usuario.");
            }
            finally
            {
                ls.CloseAsync();
            }

        }
    }
}