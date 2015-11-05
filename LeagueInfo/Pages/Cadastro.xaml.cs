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
    public partial class Cadastro : PhoneApplicationPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private async void buttonGerar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClassApi.SummonerDto summoner = new ClassApi.SummonerDto();
                summoner = await summoner.SearchSummoner(textBoxSummonerName.Text);
                string dicionario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                Random rand = new Random();
                string validador = string.Empty;
                for (int i = 0; i < 8; i++)
                    validador += dicionario[rand.Next(dicionario.Count())];
                textBlockValidateNumber.Text = validador.Substring(0, 4) + "-" + validador.Substring(3, 4);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Nome de invocador não encontrado.", "Erro", MessageBoxButton.OK);
            }
        }
    }
}