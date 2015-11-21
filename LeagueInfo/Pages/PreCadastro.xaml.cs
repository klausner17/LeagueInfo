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
    public partial class PreCadastro : PhoneApplicationPage
    {
        public PreCadastro()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            textBlockSummonerName.Text = NavigationContext.QueryString["summoner"];
            if (NavigationContext.QueryString["validador"] == string.Empty)
            {
                string dicionario = "ACDEFGHIJKLMPSTWXYZ1234578";
                Random rand = new Random();
                textBlockValidateNumber.Text = string.Empty;
                for (int i = 0; i < 6; i++)
                    textBlockValidateNumber.Text += dicionario[rand.Next(dicionario.Count())];
                LeagueWS.LeagueServiceClient ls = new LeagueWS.LeagueServiceClient();
                ls.preCadastroCompleted += ls_preCadastroCompleted;
                ls.preCadastroAsync(textBlockSummonerName.Text, textBlockValidateNumber.Text);
            }
            else
            {
                textBlockValidateNumber.Text = NavigationContext.QueryString["validador"];
            }
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
                        string uri = "/Pages/Cadastro.xaml?summoner=" + NavigationContext.QueryString["summoner"];
                        NavigationService.Navigate(new Uri(uri, UriKind.RelativeOrAbsolute));
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