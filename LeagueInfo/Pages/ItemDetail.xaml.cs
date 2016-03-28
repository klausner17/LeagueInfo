using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LeagueInfo.ClassApi.Request;
using LeagueInfo.ClassApi;
using LeagueInfo.Controls;
using System.Windows.Media;

namespace LeagueInfo.Pages
{
    public partial class ItemDetail : PhoneApplicationPage
    {
        bool carregada = false;
        
        public ItemDetail()
        {
            InitializeComponent();
            Requester.OnGettingData += Requester_OnGettingData;
        }

        private delegate void ProgressCallBack(bool status);

        private void ProgressBarVisibility(bool status)
        {
            if (status)
                loadProgress.Visibility = Visibility.Visible;
            else
                loadProgress.Visibility = Visibility.Collapsed;
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

        private async void pageItemDetail_Loaded(object sender, RoutedEventArgs e)
        {
            if (!carregada)
            {
                ItemDto item = await new ItemDto().SearchItemByIDAllData(Convert.ToInt16(NavigationContext.QueryString["id"]));
                imageItem.Source = await item.GetImage();
                textBlockNameItem.Text = item.Name;
                textBlockGoldItem.Text = item.Gold.Total.ToString() + " gold";
                textBlockItemEffect.NavigateToString(item.Description);
                if (item.From == null)
                {
                    TextBlock tb = new TextBlock();
                    tb.Foreground = (SolidColorBrush)Resources["CorDestaque"];
                    tb.FontSize = 30;
                    tb.Text = "Este item não possui receita.";
                    gridReceita.Children.Add(tb);
                }
                else
                {
                    List<ItemDto> receita = new List<ItemDto>();
                    foreach (string s in item.From)
                        receita.Add(await new ItemDto().SearchItemLowData(Convert.ToInt16(s)));
                    ListBoxReceita.ItemsSource = receita;
                }
                carregada = true;
            }
        }

        private void ListBoxReceita_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemDto itemSelected = ((ItemDto)((ListBox)sender).SelectedItem);
            NavigationService.Navigate(new Uri("/Pages/ItemDetail.xaml?id=" + itemSelected.Id, UriKind.Relative)); 
        }
    }
}