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

        private void ItemSelect_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ItemDto itemSelected = (sender as ItemSelect).Item;
            NavigationService.Navigate(new Uri("/Pages/ItemDetail.xaml?id="+itemSelected.Id, UriKind.RelativeOrAbsolute));
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
            buttonFilterChampion.IsEnabled = false;
            List<string> filters = new List<string>();
            if (filterChampionAssassin.IsChecked == true)
                filters.Add("Assassin");
            if (filterChampionFigther.IsChecked == true)
                filters.Add("Figther");
            if (filterChampionMarksman.IsChecked == true)
                filters.Add("Marksman");
            if (filterChampionTank.IsChecked == true)
                filters.Add("Tank");
            if (filterChampionSupport.IsChecked == true)
                filters.Add("Support");
            if (filterChampionMage.IsChecked == true)
                filters.Add("Mage");
            if (ChampionListDto.AllChampions == null)
                await ChampionListDto.LoadAllChampions();
            ChampionsList.Items.Clear();
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
            foreach (ItemDto item in ItemListDto.AllItems)
            {
                if (!filters.Contains("All"))
                {
                    if (item.Tags != null)
                    {
                        foreach (string tag in item.Tags)
                        {
                            if (filters.Contains(tag))
                            {
                                ItemSelect itemSelect = new ItemSelect();
                                itemSelect.Item = item;
                                itemSelect.Tap += ItemSelect_Tap;
                                ItensList.Items.Add(itemSelect);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    ItemSelect itemSelect = new ItemSelect();
                    itemSelect.Item = item;
                    itemSelect.Tap += ItemSelect_Tap;
                    ItensList.Items.Add(itemSelect);
                }
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
            ChampionsList.Items.Clear();
            foreach (ChampionDto champion in ChampionListDto.AllChampions)
            {
                if (champion.FreeToPlay)
                {
                    ChampionSelected item = new ChampionSelected();
                    item.Champion = champion;
                    item.Tap += item_Tap;
                    ChampionsList.Items.Add(item);
                }
            }
            buttonFilterFreeWeek.IsEnabled = true;
        }
    }
}