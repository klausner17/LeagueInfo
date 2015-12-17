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

namespace LeagueInfo.Controls
{
    public partial class SkinControl : UserControl
    {
        public SkinControl()
        {
            InitializeComponent();
        }

        public SkinControl(ImageSource imageSource, string titulo)
        {
            InitializeComponent();
            this.skinImage.Source = imageSource;
            this.titulo.Text = titulo;
        }
    }
}
