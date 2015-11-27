using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using LeagueInfo.ClassApi;
using System.Windows.Media.Imaging;
using LeagueInfo.ClassApi.Request;
using System.Threading.Tasks;
using LeagueInfo.Controls;
using System.Windows.Input;
using LeagueInfo.Resources;
using System.IO.IsolatedStorage;
using System.Collections.Generic;

namespace LeagueInfo
{
    public partial class MainPage : PhoneApplicationPage
    {
        private delegate void ProgressCallBack(bool status);

        private void ProgressBarVisibility(bool status)
        {
            if (status)
                loadProgress.Visibility = Visibility.Visible;
            else
                loadProgress.Visibility = Visibility.Collapsed;
        }

        public MainPage()
        {
            InitializeComponent();
            Requester.OnGettingData += Requester_OnGettingData;
            if (GlobalData.Logged)
            {
                buttonAlterarCadastro.Visibility = System.Windows.Visibility.Visible;
                buttonSair.Visibility = System.Windows.Visibility.Visible;
                textBlockInvocador.Text = GlobalData.UserLogged.login;
            }
        }

        void Requester_OnGettingData(int status)
        {
            switch (status)
            {
                case Requester.BEGINDOWNLOAD:
                    ProgressBarVisibility(true);
                    break;
                case Requester.ENDDOWNLOAD:
                    ProgressBarVisibility(false);
                    break;
            }
        }

        private void ItemSelect_OnTouch(object sender)
        {
            MessageBox.Show((sender as ItemSelect).Item.SanitizedDescriprion);
        }

        private async void Panorama_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string panoramaItemSelectedName = ((PanoramaItem)panoramaMain.SelectedItem).Name;
            switch (panoramaItemSelectedName)
            {
                
                case "panoramaItens":
                    if (ItensList.Children.Count == 0)
                    {
                        ItemListDto itens = new ItemListDto();
                        itens = await itens.LoadAllItens();
                        try
                        {
                            foreach (ItemDto item in itens.Data.Values)
                            {
                                ItemSelect itemSelect = new ItemSelect();
                                itemSelect.Margin = new Thickness(0, 5, 0, 5);
                                itemSelect.Item = item;
                                itemSelect.OnTouch += ItemSelect_OnTouch;
                                ItensList.Children.Add(itemSelect);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
            }
        }

        void item_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            ChampionDto championSelected = (sender as ChampionSelected).Champion;
            NavigationService.Navigate(new Uri("/Pages/DetailChampion.xaml?id=" + championSelected.Id, UriKind.Relative));
        }

        private void buttonBuscasInv_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SummonerDetail.xaml?name=" + textBlockInvocador.Text, UriKind.Relative));
        }

        private void textBlockInvocador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                buttonBuscasInv_Click(sender, null);
        }

        private void phoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
        }

        private void buttonAlterarCadastro_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/UpdateAccount.xaml", UriKind.RelativeOrAbsolute));
        }

        private void buttonSair_Click(object sender, RoutedEventArgs e)
        {
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings.Clear();
            NavigationService.Navigate(new Uri("/Pages/Login.xaml", UriKind.RelativeOrAbsolute));
        }


        private async void buttonFilterChampion_Click(object sender, RoutedEventArgs e)
        {
            List<string> filters = new List<string>();
            if (filterAssassin.IsChecked == true)
                filters.Add("assassin");
            if (filterFigther.IsChecked == true)
                filters.Add("figther");
            if (filterMarksman.IsChecked == true)
                filters.Add("marksman");
            if (filterTank.IsChecked == true)
                filters.Add("tank");
            if (filterSupport.IsChecked == true)
                filters.Add("support");
            if (ChampionListDto.AllChampions == null)
                await ChampionListDto.LoadAllChampions();
            {
                foreach (ChampionDto champion in ChampionListDto.AllChampions)
                {
                    foreach (string tag in champion.Tags)
                    {
                        if (filters.Contains(tag))
                        {
                            ChampionSelected item = new ChampionSelected();
                            item.Champion = champion;
                            item.Tap += item_Tap;
                            ChampionsList.Items.Add(item);
                            break;
                        }
                    }
                }
            }
        }

    }
}