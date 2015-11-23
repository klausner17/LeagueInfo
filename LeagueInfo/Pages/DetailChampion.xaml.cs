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
        LeagueWS.LeagueServiceClient ls;

        public DetailChampion()
        {
            InitializeComponent();
            ls = new LeagueWS.LeagueServiceClient();
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
        }

        private void CarregarComentarios()
        {
            listBoxComments.Items.Clear();
            ls.encontrarComentarioPorCampeaoCompleted += ls_encontrarComentarioPorCampeaoCompleted;
            ls.encontrarComentarioPorCampeaoAsync(Convert.ToInt32(NavigationContext.QueryString["id"]));
        }

        void ls_encontrarComentarioPorCampeaoCompleted(object sender, LeagueWS.encontrarComentarioPorCampeaoCompletedEventArgs e)
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
                    ls.inserirComentarioCampeaoCompleted += ls_inserirComentarioCampeaoCompleted;
                    ls.inserirComentarioCampeaoAsync(cc);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel efetuar o comentario.Detalhes:\n" + ex.Message);
            }
            
        }

        void ls_inserirComentarioCampeaoCompleted(object sender, LeagueWS.inserirComentarioCampeaoCompletedEventArgs e)
        {
            if (!e.Result)
            {
                MessageBox.Show("Erro ao efetuar comentário.");
            }
            else
            {
                CarregarComentarios();
            }
        }
    }
}