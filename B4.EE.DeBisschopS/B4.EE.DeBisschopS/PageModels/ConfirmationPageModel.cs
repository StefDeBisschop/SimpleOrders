using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using B4.EE.DeBisschopS.Models;
using B4.EE.DeBisschopS.Pages;
using B4.EE.DeBisschopS.Storage;
using Plugin.LocalNotifications;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.PageModels
{
    public class ConfirmationPageModel : INotifyPropertyChanged
    {
        private INavigation navigation;
        private ObservableCollection<Item> _OrderedItems;
        public bool isChecked;
        public bool isInHands;
        public MemoryService ms;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _CurrencySetting;
        public string CurrencySetting
        {
            get
            {
                return _CurrencySetting;
            }

            set
            {
                _CurrencySetting = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrencySetting)));
            }
        }


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
        private string _FullCost;
        public string FullCost
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
            //InitializeAsync();
            calculateTotals();
            this.navigation = navigation;
        }

        public async void InitializeAsync()
        {
            ms = new MemoryService();
            Settings settings = await ms.GetSettings();
            CurrencySetting = settings.currency;
        }

        public void calculateTotals()
        {
            int count = 0;
            decimal cost = 0;
            foreach (Item item in OrderedItems)
            {
                count += item.Count;
                cost += item.Cost * item.Count;
            }

            ItemCount = count;
            FullCost = cost.ToString("G29");
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

        public ICommand GoToFinishedOrderPage => new Command(
            async () =>
            {
                if (isChecked && isInHands)
                {
                    await navigation.PushAsync(new FinishedOrderPage());
                    CrossLocalNotifications.Current.Cancel(0);
                }
            });
    }
}
