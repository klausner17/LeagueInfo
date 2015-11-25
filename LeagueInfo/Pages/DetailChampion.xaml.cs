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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LeagueInfo.Controls;
using LeagueInfo.Resources;

namespace LeagueInfo.Pages
{
    public partial class DetailChampion : PhoneApplicationPage
    {
        private LeagueWS.LeagueServiceClient lsComment;
        private LeagueWS.LeagueServiceClient lsCounter;
        private LeagueWS.LeagueServiceClient lsBuild;
        private LeagueWS.LeagueServiceClient lsInsertCounter;
        private LeagueWS.LeagueServiceClient lsInsertComment;

        public DetailChampion()
        {
            InitializeComponent();
            if (!GlobalData.Logged)
            {
                buttonComment.Visibility = System.Windows.Visibility.Collapsed;
                buttonEscolherCounter.Visibility = System.Windows.Visibility.Collapsed;
                buttonSaveCounter.Visibility = System.Windows.Visibility.Collapsed;
                textBoxComentario.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void AddInfoComponent(List<string> strInfo, StackPanel component)
        {
            foreach (string str in strInfo)
            {
                TextBlock info = new TextBlock();
                info.Text = "\n\t" + str;
                info.TextWrapping = TextWrapping.Wrap;
                info.FontSize = 22;
                component.Children.Add(info);
            }
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ChampionDto champion = new ChampionDto();
            champion = await champion.SearchChampionAllData(Convert.ToInt32(NavigationContext.QueryString["id"]));
            Random randNumSkin = new Random();
            int num = randNumSkin.Next(champion.Skins.Count);
            BitmapImage backGridInfo = champion.GetChampionSplash(num);
            ImageBrush brush = new ImageBrush();
            brush.Stretch = Stretch.UniformToFill;
            brush.ImageSource = backGridInfo;
            panorama.Background = brush;
            championName.Text = champion.Name;
            TextBlock loreDescription = new TextBlock();
            lore.Text = champion.Lore.Replace("<br>", "\n");
            AddInfoComponent(champion.AllyTips, allytips);
            AddInfoComponent(champion.EnimyTips, enimytips);
            attackInfo.Value = champion.Info.Attack;
            defenseInfo.Value = champion.Info.Defense;
            magicInfo.Value = champion.Info.Magic;
            difficultyInfo.Value = champion.Info.Difficulty;
            //incluir habilidades
            foreach (ChampionSpellDto spell in champion.Spells)
            {
                Abillity controlAbillity = new Abillity(spell);
                abillityChampions.Children.Add(controlAbillity);
            }
            CarregarComentarios();
            CarregarCounters();
        }

        private void CarregarComentarios()
        {
            listBoxComments.Items.Clear();
            lsComment = new LeagueWS.LeagueServiceClient();
            lsComment.encontrarComentarioPorCampeaoCompleted += ls_encontrarComentarioPorCampeaoCompleted;
            lsComment.encontrarComentarioPorCampeaoAsync(Convert.ToInt32(NavigationContext.QueryString["id"]));
        }

        void ls_encontrarComentarioPorCampeaoCompleted(object sender, LeagueWS.encontrarComentarioPorCampeaoCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    foreach (var comment in e.Result)
                    {
                        ChampionComment cm = new ChampionComment(comment.idComment, comment.comentario, comment.idUsuario.login);
                        listBoxComments.Items.Add(cm);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível encontrar os comentários do campeão.");
            }
            finally
            {
                lsComment.CloseAsync();
            }
        }

        private void CarregarCounters()
        {
            listBoxCounters.Items.Clear();
            lsCounter = new LeagueWS.LeagueServiceClient();
            lsCounter.encontrarCounterPorCampeaoCompleted += ls_encontrarCounterPorCampeaoCompleted;
            lsCounter.encontrarCounterPorCampeaoAsync(Convert.ToInt32(NavigationContext.QueryString["id"]));
        }

        async void ls_encontrarCounterPorCampeaoCompleted(object sender, LeagueWS.encontrarCounterPorCampeaoCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    var resultado = e.Result.GroupBy(test => test.idCounter).Select(grp => grp.First()) .ToList();
                    foreach (var counter in resultado)
                    {
                        CounterControl cm = new CounterControl(await new ChampionDto().SearchChampionLowData(counter.idCounter), false, false);
                        listBoxCounters.Items.Add(cm);
                        listBoxCounters.Tap += listBoxCounters_Tap;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível encontrar os counter do campeão.");
            }
            finally
            {
                lsCounter.CloseAsync();
            }
        }

        void listBoxCounters_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new Uri("/Pages/DetailChampion.xaml?id=" + ((CounterControl)((ListBox)sender).SelectedItem).Champion.Id.ToString(), UriKind.RelativeOrAbsolute));
            }
            catch { }
        }

        private void buttonComment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBoxComentario.Text != string.Empty)
                {
                    LeagueWS.championcomments cc = new LeagueWS.championcomments();
                    cc.idUsuario = GlobalData.UserLogged;
                    cc.comentario = textBoxComentario.Text;
                    cc.idChampion = Convert.ToInt32(NavigationContext.QueryString["id"]);
                    lsInsertComment = new LeagueWS.LeagueServiceClient();
                    lsInsertComment.inserirComentarioCampeaoCompleted += ls_inserirComentarioCampeaoCompleted;
                    lsInsertComment.inserirComentarioCampeaoAsync(cc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel efetuar o comentario.Detalhes:\n" + ex.Message);
            }
            
        }

        void ls_inserirComentarioCampeaoCompleted(object sender, LeagueWS.inserirComentarioCampeaoCompletedEventArgs e)
        {
            try
            {
                if (!e.Result)
                    MessageBox.Show("Erro ao efetuar comentário.");
                else
                    CarregarComentarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao efetuar comentário.");
            }
            finally
            {
                lsInsertComment.CloseAsync();
            }
        }

        private void buttonCriarBuild_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void buttonEscolherCounter_Click(object sender, RoutedEventArgs e)
        {
            ChampionListDto listChampion = await new ChampionListDto().LoadAllChampions();
            listBoxCounterChose.Visibility = System.Windows.Visibility.Visible;
            buttonSaveCounter.Visibility = System.Windows.Visibility.Visible;
            if (listBoxCounters.Items.Count == 0)
            {
                foreach (ChampionDto champ in listChampion.Data.Values)
                {
                    CounterControl cc = new CounterControl(champ, true, false);
                    listBoxCounterChose.Items.Add(cc);
                }
            }
            else
            {
                foreach (CounterControl cc in listBoxCounters.Items)
                {
                    cc.IsSelected = false;
                }
            }
        }

        private void buttonSaveCounter_Click(object sender, RoutedEventArgs e)
        {
            listBoxCounterChose.Visibility = System.Windows.Visibility.Collapsed;
            buttonSaveCounter.Visibility = System.Windows.Visibility.Collapsed;
            foreach(CounterControl cc in listBoxCounterChose.Items)
            {
                if (cc.IsSelected)
                {
                    LeagueWS.championcounter counterWS = new LeagueWS.championcounter();
                    counterWS.idCounter = cc.Champion.Id;
                    counterWS.idChampion = Convert.ToInt16(NavigationContext.QueryString["id"]);
                    lsInsertCounter = new LeagueWS.LeagueServiceClient();
                    lsInsertCounter.inserirCounterCompleted += ls_inserirCounterCompleted;
                    lsInsertCounter.inserirCounterAsync(counterWS);
                }
            }
            
        }

        void ls_inserirCounterCompleted(object sender, LeagueWS.inserirCounterCompletedEventArgs e)
        {
            try
            {
                if (e.Result)
                {
                    listBoxCounterChose.Visibility = System.Windows.Visibility.Collapsed;
                    buttonSaveCounter.Visibility = System.Windows.Visibility.Collapsed;
                    CarregarCounters();
                }
                else
                    MessageBox.Show("Não foi possível inserir o counter do campeão.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível inserir o counter do campeão.");
            }
            finally
            {
                lsInsertCounter.CloseAsync();
            }
        }

        private void buttonCancelarCounter_Click(object sender, RoutedEventArgs e)
        {
            listBoxCounterChose.Visibility = Visibility.Collapsed;
            buttonCancelarCounter.Visibility = System.Windows.Visibility.Collapsed;
            buttonSaveCounter.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}