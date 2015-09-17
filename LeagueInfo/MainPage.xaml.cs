using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using LeagueInfo.ClassApi;
using System.Windows.Media.Imaging;
using LeagueInfo.ClassApi.Request;
using System.Threading.Tasks;
using LeagueInfo.Controls;

namespace LeagueInfo
{
    public partial class MainPage : PhoneApplicationPage
    {
        private delegate void ProgressCallBack(bool status);
		private bool loadedChampions = false;
        private bool loadingChampions = false;

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

        void item_OnTouch(object sender)
        {
            ChampionDto championSelected = (sender as ChampionSelected).Champion;
            NavigationService.Navigate(new Uri("/Pages/DetailChampion.xaml?id="+championSelected.Id, UriKind.Relative));
        }

        private void ItemSelect_OnTouch(object sender)
        {
            MessageBox.Show((sender as ItemSelect).Item.SanitizedDescriprion);
        }

        private void CarregarCampeoes()
        {

        }

        private async void Panorama_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string panoramaItemSelectedName = ((PanoramaItem)panoramaMain.SelectedItem).Name;
            switch (panoramaItemSelectedName)
            {
                case "panoramaCampeoes":
                    ChampionsList.Items.Clear();
                    ChampionListDto champions = new ChampionListDto();
                    champions = await champions.LoadAllChampions();
                    try
                    {
                        foreach (ChampionDto champion in champions.Data.Values)
                        {
                            ChampionSelected item = new ChampionSelected();
                            item.Margin = new Thickness(10);
                            item.Champion = champion;
                            item.OnTouch += item_OnTouch;
                            ChampionsList.Items.Add(item);
                            await Task.Delay(1);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "panoramaItens":
                    ItensList.Children.Clear();
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
                            await Task.Delay(50);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }
    }
}