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
using Microsoft.Phone.Tasks;
using System.Windows.Controls;
using System.Linq;

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

        private async void buttonFilterChampion_Click(object sender, RoutedEventArgs e)
        {
            buttonFilterChampion.IsEnabled = false;
            List<string> filters = new List<string>();
            if (filterChampionAssassin.IsChecked == true)
                filters.Add("assassino");
            if (filterChampionFigther.IsChecked == true)
                filters.Add("lutador");
            if (filterChampionMarksman.IsChecked == true)
                filters.Add("atirador");
            if (filterChampionTank.IsChecked == true)
                filters.Add("tanque");
            if (filterChampionSupport.IsChecked == true)
                filters.Add("suporte");
            if (filterChampionMage.IsChecked == true)
                filters.Add("mago");
            ChampionsList.ItemsSource = (from champion in ChampionListDto.AllChampions
                                         where filters.Intersect(from tag in champion.Tags select tag.Description).Count() > 0
                                         select champion); 
            buttonFilterChampion.IsEnabled = true;
        }


        private async void buttonFilterItem_Click(object sender, RoutedEventArgs e)
        {
            buttonFilterItem.IsEnabled = false;
            List<string> filters = new List<string>();
            if (filterItemAbillity.IsChecked == true)
                filters.Add("SpellDamage");
            if (filterItemArmor.IsChecked == true)
                filters.Add("Armor");
            if (filterItemAttackSpeed.IsChecked == true)
                filters.Add("AttackSpeed");
            if (filterItemConsumable.IsChecked == true)
                filters.Add("Comsumable");
            if (filterItemCooldownReduction.IsChecked == true)
                filters.Add("CooldownReduction");
            if (filterItemCritic.IsChecked == true)
                filters.Add("CriticalStrike");
            if (filterItemDamage.IsChecked == true)
                filters.Add("Damage");
            if (filterItemLife.IsChecked == true)
                filters.Add("Health");
            if (filterItemLifeRegen.IsChecked == true)
                filters.Add("HealthRegen");
            if (filterItemLifeSteal.IsChecked == true)
                filters.Add("LifeSteal");
            if (filterItemMagicResistence.IsChecked == true)
                filters.Add("SpellBlock");
            if (filterItemMana.IsChecked == true)
                filters.Add("Mana");
            if (filterItemManaRegen.IsChecked == true)
                filters.Add("ManaRegen");
            if (filterItemTrinket.IsChecked == true)
                filters.Add("Trinket");
            if (filterItemVision.IsChecked == true)
                filters.Add("Vision");
            if (filterItemMagicPen.IsChecked == true)
                filters.Add("MagicPenetration");
            if (filterItemSpellVamp.IsChecked == true)
                filters.Add("SpellVamp");
            if (filterItemGoldPer.IsChecked == true)
                filters.Add("GoldPer");
            if (filterItemJungle.IsChecked == true)
                filters.Add("Jungle");
            if (filterItemSpeed.IsChecked == true)
            {
                filters.Add("Boots");
                filters.Add("NonbootsMovement");
            }
            if (filterItemArmorPenetration.IsChecked == true)
                filters.Add("ArmorPenetration");
            if (filters.Count == 0)
                filters.Add("All");
            ItensList.Items.Clear();
            if (ItemListDto.AllItems == null)
                await ItemListDto.LoadAllItens();
            if (filters.Contains("All"))
                ItensList.ItemsSource = ItemListDto.AllItems;
            else
            {

                ItensList.ItemsSource = (from item in ItemListDto.AllItems
                                         where item.Tags != null && filters.Intersect(item.Tags).Count() > 0
                                         select item);
            }
            expanderDamage.IsExpanded = false;
            expanderDesfense.IsExpanded = false;
            expanderSpell.IsExpanded = false;
            expanderUtil.IsExpanded = false;
            buttonFilterItem.IsEnabled = true;
        }

        private async void buttonFilterFreeWeek_Click(object sender, RoutedEventArgs e)
        {
            buttonFilterFreeWeek.IsEnabled = false;
            if (ChampionListDto.AllChampions == null)
                await ChampionListDto.LoadAllChampions();
            ChampionsList.ItemsSource = from champion in ChampionListDto.AllChampions
                                        where champion.Free == "free"
                                        select champion;
            buttonFilterFreeWeek.IsEnabled = true;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            MarketplaceReviewTask task = new MarketplaceReviewTask();
            task.Show();
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Sobre.xaml" + textBlockInvocador.Text, UriKind.Relative));
        }

        private void ChampionsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ChampionDto championSelected = ((ChampionDto)((ListBox)sender).SelectedItem);
            NavigationService.Navigate(new Uri("/Pages/DetailChampion.xaml?id=" + championSelected.Id, UriKind.Relative));          
        }
    }
}