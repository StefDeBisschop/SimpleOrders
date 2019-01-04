using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using B4.EE.DeBisschopS.Models;
using B4.EE.DeBisschopS.Pages;
using B4.EE.DeBisschopS.Storage;
using Newtonsoft.Json;
using Plugin.LocalNotifications;
using Xamarin.Forms;
using Constants = B4.EE.DeBisschopS.Storage.Constants;

namespace B4.EE.DeBisschopS.PageModels
{
    public class OrderPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Item> _ItemList;
        private INavigation navigation;
        public ObservableCollection<Item> ItemList
        {
            get
            {
                return _ItemList;
            }

            set
            {
                _ItemList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ItemList)));
            }
        }

        private bool _IsEmpty;
        public bool IsEmpty
        {
            get
            {
                return _IsEmpty;
            }

            set
            {
                _IsEmpty = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsEmpty)));
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

        public MemoryService ms;
        public OrderPageModel(INavigation navigation, ObservableCollection<Item> InitialItems)
        {
            this.navigation = navigation;
            ItemList = InitialItems;
            checkList();
        }

        public OrderPageModel(INavigation navigation)
        {
            this.navigation = navigation;
            InitializeAsync();
        }

        public async void InitializeAsync()
        {
            ms = new MemoryService();
            ItemList = await ms.GetAllItems();
            checkList();
        }

        public void checkList()
        {
            if (ItemList.Count <= 0)
                IsEmpty = true;
            else
                IsEmpty = false;
        }

        public void ChangeItemCount(bool countUp)
        {
            if (countUp)
                ItemCount++;
            else
                ItemCount--;
        }

        public ICommand GoToSettingsPage => new Command(
            () =>
            {
                navigation.PushAsync(new SettingsPage());
            });

        public ICommand GoToConfirmationPage => new Command(
            () =>
            {
                ObservableCollection<Item> OrderedItems = new ObservableCollection<Item>(ItemList);

                for (int i = ItemList.Count - 1; i >= 0; i--)
                {
                    if (OrderedItems[i].Count <= 0)
                    {
                        OrderedItems.RemoveAt(i);
                    }
                }

                if (OrderedItems.Count > 0)
                {
                    navigation.PushAsync(new ConfirmationPage(OrderedItems));

                    CrossLocalNotifications.Current.Show("Simple Orders", "You are taking an order", 0);
                }
                else
                    Application.Current.MainPage.DisplayAlert("Error", "There are no orders", "OK");

            });

        public ICommand RaiseItem => new Command(
            (obj) =>
            {
                Item item = (Item)obj;
                try
                {
                    Item itemFound = ItemList.FirstOrDefault(_item => _item.Id == item.Id);
                    if (itemFound.Count >= 0)
                    {
                        itemFound.Count++;
                        ChangeItemCount(true);
                    }

                }
                catch { }
            });

        public ICommand LowerItem => new Command(
            (obj) =>
            {
                Item item = (Item)obj;
                try
                {
                    Item itemFound = ItemList.FirstOrDefault(_item => _item.Id == item.Id);
                    if (itemFound.Count > 0)
                    {
                        itemFound.Count--;
                        ChangeItemCount(false);
                    }

                }
                catch { }
            });

    }
}
