using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace LeagueInfo.Controls
{
    public partial class SquareInfo : UserControl
    {
        public SquareInfo()
        {
            InitializeComponent();
        }

        public String InfoSuperior
        {
            get { return this.textBlockInfoSuperior.Text; }
            set { this.textBlockInfoSuperior.Text = value; }
        }

        public String InfoInferior
        {
            get { return this.textBlockInfoInferior.Text; }
            set { this.textBlockInfoInferior.Text = value; }
        }

        public Brush InfoSuperiorForeground
        {
            get { return this.textBlockInfoSuperior.Foreground; }
            set { this.textBlockInfoSuperior.Foreground = value; }
        }

        public Brush InfoInferiorForeground
        {
            get { return this.textBlockInfoInferior.Foreground; }
            set { this.textBlockInfoInferior.Foreground = value; }
        }

        public Brush ColorInfoSuperior
        {
            get { return this.gridSuperior.Background; }
            set { this.gridSuperior.Background = value; }
        }

        public Brush ColorInfoInferior
        {
            get { return this.gridInferior.Background; }
            set { this.gridInferior.Background = value; }
        }
    }
}
