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
    public partial class Abillity : UserControl
    {
        public Abillity()
        {
            InitializeComponent();
        }

        public Abillity(string title, string description)
        {
            InitializeComponent();
            this.title.Text = title;
            this.content.Text = description;
        }
    }
}
