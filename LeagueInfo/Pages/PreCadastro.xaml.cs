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
    public partial class Cadastro : PhoneApplicationPage
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            textBlockSummonerName.Text = NavigationContext.QueryString["summoner"];
            string dicionario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            textBlockValidateNumber.Text = string.Empty;
            for (int i = 0; i < 8; i++)
                textBlockValidateNumber.Text += dicionario[rand.Next(dicionario.Count())];
            LeagueWS.LeagueServiceClient ls = new LeagueWS.LeagueServiceClient();
            ls.preCadastroCompleted += ls_preCadastroCompleted;
            ls.preCadastroAsync(textBlockSummonerName.Text, textBlockValidateNumber.Text);
        }

        void ls_preCadastroCompleted(object sender, LeagueWS.preCadastroCompletedEventArgs e)
        {
            if (!e.Result)
                MessageBox.Show("O pré cadastro não foi efetivado com sucesso.");
        }

        private async void buttonDone_Click(object sender, RoutedEventArgs e)
        {
            bool achou = false;
            try
            {
                long idSummoner = Convert.ToInt64(NavigationContext.QueryString["idSummoner"]);
                MasteryPagesDto masteryPages = await MasteryPagesDto.SearchMateryPages(idSummoner);
                for (int i = 0; i < masteryPages.Pages.Count(); i++)
                {
                    if (masteryPages.Pages[i].Name == textBlockValidateNumber.Text)
                    {
                        NavigationService.Navigate(new Uri("/Pages/Cadastro.xaml?summoner=" + textBlockSummonerName.Text, UriKind.RelativeOrAbsolute));
                        achou = true;
                        break;
                    }                        
                }
                if (!achou)
                {
                    MessageBox.Show("Não foi encontrado a pagina de runa com a descrição do validador.");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Não foi encontrar as informações do invocador.");
            }
            
        }
    }
}