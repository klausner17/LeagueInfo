using System.Windows.Controls;
using LeagueInfo.ClassApi;
using System.Windows;
using System;
using System.Windows.Media.Imaging;

namespace LeagueInfo.Controls
{
    public partial class ItemSelect : UserControl
    {
        private ItemDto item;

        public ItemDto Item
        {
            get { return this.item; }
            set
            {
                item = value;
                descriptionItem.Text = item.Name;
                custItem.Text = "Custo: " + item.Gold.Total.ToString() + " gold";
                LoadIcon();
            }
        }

        public ItemSelect()
        {
            InitializeComponent();
            item = new ItemDto();
        }

        private async void LoadIcon()
        {
            iconItem.Source = await item.GetImage();
        }
    }
}
