using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using B4.EE.DeBisschopS.Models;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.PageModels
{
    public class ConfirmationPageModel : INotifyPropertyChanged
    {
        private INavigation navigation;
        private ObservableCollection<Item> _OrderedItems;
        public bool isChecked;
        public bool isInHands;
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Item> OrderedItems
        {
            get
            {
                return _OrderedItems;
            }

            set
            {
                _OrderedItems = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderedItems)));
            }
        }
        private int _ItemCount;
        public int ItemCount
        {
            get
            {
                return _ItemCount;
            }

            set
            {
                _ItemCount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemCount)));
            }
        }
        private int _FullCost;
        public int FullCost
        {
            get
            {
                return _FullCost;
            }

            set
            {
                _FullCost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullCost)));
            }
        }
        private Color _bgColorChecked = Color.DarkOrange;
        public Color bgColorChecked
        {
            get { return _bgColorChecked; }
            set
            {
                if (value == _bgColorChecked)
                    return;

                _bgColorChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(bgColorChecked)));
            }
        }
        private Color _bgColorInHands = Color.DarkOrange;
        public Color bgColorInHands
        {
            get { return _bgColorInHands; }
            set
            {
                if (value == _bgColorInHands)
                    return;

                _bgColorInHands = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(bgColorInHands)));
            }
        }

        public ConfirmationPageModel(INavigation navigation, ObservableCollection<Item> _orderedItems)
        {
            this.OrderedItems = _orderedItems;
            calculateTotals();
            this.navigation = navigation;
        }

        public void calculateTotals()
        {
            int count = 0;
            int cost = 0;
            foreach (Item item in OrderedItems)
            {
                count += item.Count;
                cost += item.Cost;
            }

            ItemCount = count;
            FullCost = cost;
        }

        public ICommand ChangeColor => new Command(
            (obj) =>
            {
                Button buttonClicked = (Button)obj;

                switch (buttonClicked.StyleId)
                {
                    case "btnChecked":
                        isChecked = true;
                        bgColorChecked = Color.Red;
                        break;
                    case "btnInHands":
                        if (isChecked)
                        {
                            bgColorInHands = Color.Red;
                            isInHands = true;
                        }
                        break;
                }
            });
    }
}
