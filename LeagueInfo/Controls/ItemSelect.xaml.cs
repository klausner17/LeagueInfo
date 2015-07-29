using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace LeagueInfo
{
    public partial class ItemSelect : UserControl
    {

        public Image Icon
        {
            get { return this.icon; }
            set { this.icon = value; }
        }

        public String Title
        {
            get { return this.title.Text; }
            set { this.title.Text = value; }
        }

        public String Description 
        { 
            get { return this.description.Text; } 
            set { this.description.Text = value; } 
        }

        public ItemSelect()
        {
            InitializeComponent();
        }
    }
}
