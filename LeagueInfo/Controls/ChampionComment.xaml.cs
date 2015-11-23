using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LeagueInfo.Controls
{
    public partial class ChampionComment : UserControl
    {
        /// <summary>
        /// Id do comentario.
        /// </summary>
        public int IdComment { get; set; }
        /// <summary>
        /// Comentário do UserControl.
        /// </summary>
        public String Comment
        {
            get { return this.textBlockComment.Text; }
            set { this.textBlockComment.Text = value; }
        }
        /// <summary>
        /// Usuario que postou o comentário.
        /// </summary>
        public String User
        {
            get { return this.textBlockUser.Text; }
            set { this.textBlockUser.Text = value; }
        }
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public ChampionComment()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Construtor full.
        /// </summary>
        /// <param name="comment">Comentário.</param>
        /// <param name="user">Usuario.</param>
        public ChampionComment(int id, String comment, string user)
        {
            InitializeComponent();
            IdComment = id;
            Comment = comment;
            User = user;
        }
    }
}
