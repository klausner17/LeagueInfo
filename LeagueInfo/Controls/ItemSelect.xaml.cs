using System.Windows.Controls;
using LeagueInfo.Json;
using System.Windows;
using System;

namespace LeagueInfo.Controls
{
    public partial class ItemSelect : UserControl
    {
        private ItemDto item;

        private Point coordMouseDown;

        public delegate void OnClick(object sender);

        public event OnClick OnTouch;

        public ItemDto Item
        {
            get { return this.item; }
            set
            {
                item = value;
                descriptionItem.Text = item.Name;
                custItem.Text = item.Gold.Total.ToString();
            }
        }

        public ItemSelect()
        {
            InitializeComponent();
            item = new ItemDto();
        }

        private void UserControl_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            coordMouseDown = e.GetPosition(this);
        }

        private void UserControl_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point finalPosition = e.GetPosition(this);
            if (finalPosition == coordMouseDown)
                OnTouchEvent();
        }

        private void OnTouchEvent()
        {
            if (OnTouch != null)
                OnTouch(this);
        }
    }
}
