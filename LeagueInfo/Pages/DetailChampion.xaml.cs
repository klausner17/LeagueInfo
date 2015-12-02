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
using LeagueInfo.ClassApi.Request;

namespace LeagueInfo.Pages
{
    public partial class DetailChampion : PhoneApplicationPage
    {
        private LeagueWS.LeagueServiceClient lsComment;
        private LeagueWS.LeagueServiceClient lsCounter;
        private LeagueWS.LeagueServiceClient lsInsertCounter;
        private LeagueWS.LeagueServiceClient lsInsertComment;
        private bool carregado = false;

        public DetailChampion()
        {
            InitializeComponent();
            Requester.OnGettingData += Requester_OnGettingData;
            if (!GlobalData.Logged)
            {
                buttonComment.Visibility = System.Windows.Visibility.Collapsed;
                textBoxComentario.Visibility = System.Windows.Visibility.Collapsed;
            }
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

        private void AddInfoComponent(List<string> strInfo, StackPanel component)
        {
            foreach (string str in strInfo)
            {
                TextBlock info = new TextBlock();
                info.Text = "\n\t" + Code.HtmlRemoval.StripTagsCharArray(str);
                info.TextWrapping = TextWrapping.Wrap;
                info.FontSize = 22;
                component.Children.Add(info);
            }
        }

        private async void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!carregado)
            {
                ChampionDto champion = new ChampionDto();
                champion = await ChampionDto.SearchChampionAllData(Convert.ToInt32(NavigationContext.QueryString["id"]));
                iconChampion.Source = await champion.GetChampionSquare();
                Random randNumSkin = new Random();
                int num = randNumSkin.Next(champion.Skins.Count);
                BitmapImage backGridInfo = champion.GetChampionSplash(num);
                ImageBrush brush = new ImageBrush();
                brush.Stretch = Stretch.UniformToFill;
                brush.ImageSource = backGridInfo;
                panorama.Background = brush;
                panorama.Background.Opacity = 0.5;
                championName.Text = champion.Name;
                TextBlock loreDescription = new TextBlock();
                lore.Text = Code.HtmlRemoval.StripTagsCharArray(champion.Lore);
                AddInfoComponent(champion.AllyTips, allytips);
                AddInfoComponent(champion.EnimyTips, enimytips);
                attackInfo.Value = champion.Info.Attack;
                defenseInfo.Value = champion.Info.Defense;
                magicInfo.Value = champion.Info.Magic;
                difficultyInfo.Value = champion.Info.Difficulty;
                //incluir habilidades
                foreach (ChampionSpellDto spell in champion.Spells)
                {
                    ControlAbillity controlAbillity = new ControlAbillity(spell);
                    abillityChampions.Children.Add(controlAbillity);
                }
                CarregarComentarios();
                CarregarCounters();
            }
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
            catch (Exception)
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

        void ls_encontrarCounterPorCampeaoCompleted(object sender, LeagueWS.encontrarCounterPorCampeaoCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    foreach (var counter in e.Result)
                    {
                        ChampionSelected championControl = new ChampionSelected();
                        championControl.Champion = ChampionListDto.AllChampions.Find(x => x.Id == counter.idChampion);
                        listBoxCounters.Items.Add(championControl);
                        championControl.Tap += championControl_Tap;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível encontrar os counter do campeão.");
            }
            finally
            {
                lsCounter.CloseAsync();
            }
        }

        void championControl_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/DetailChampion.xaml?id=" + ((ChampionSelected)sender).Champion.Id.ToString(), UriKind.RelativeOrAbsolute));
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
            catch (Exception)
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

        private void buttonEscolherCounter_Click(object sender, RoutedEventArgs e)
        {
            gridChooseCounter.Visibility = System.Windows.Visibility.Visible;
            listBoxCounterChose.Items.Clear();
            foreach (ChampionDto champ in ChampionListDto.AllChampions)
            {
                CounterControl cc = new CounterControl(champ, true, false);
                listBoxCounterChose.Items.Add(cc);
            }
        }

        private void buttonSaveCounter_Click(object sender, RoutedEventArgs e)
        {
            gridChooseCounter.Visibility = Visibility.Collapsed;
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
                    CarregarCounters();
                }
                else
                    MessageBox.Show("Não foi possível inserir o counter do campeão.");
            }
            catch (Exception)
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
            gridChooseCounter.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}