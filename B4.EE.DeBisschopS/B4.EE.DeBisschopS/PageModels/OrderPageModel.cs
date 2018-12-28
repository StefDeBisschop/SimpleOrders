using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using B4.EE.DeBisschopS.Models;
using B4.EE.DeBisschopS.Storage;
using FreshMvvm;
using Newtonsoft.Json;
using Xamarin.Forms;
using Constants = B4.EE.DeBisschopS.Storage.Constants;

namespace B4.EE.DeBisschopS.PageModels
{
    public class OrderPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Item> _ItemList;
        public ObservableCollection<Item> TestData;
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

        public Command RaiseItem { get; set; }
        public Command LowerItem { get; set; }
        public MemoryService ms;
        public OrderPageModel()
        {
            InitializeAsync();
        }

        public async void InitializeAsync()
        {
            ms = new MemoryService();

            //TestData pushen
            await ms.CreateFile(Constants.ITEMS_LIST_FILENAME);
            TestData = new ObservableCollection<Item>
            {
                new Item {Cost = 12, Name = "TestItem", ImageNameF = "grapes.png"},
                new Item {Cost = 10, Name = "TestItem2", ImageNameF = "carrot.png"}
            };
            string content = JsonConvert.SerializeObject(TestData);
            await ms.WriteTextAllAsync(Constants.ITEMS_LIST_FILENAME, content);
            //----
            ItemList = await ms.GetAllItems();

            RaiseItem = new Command((obj) =>
            {
                Item item = (Item)obj;
                ObservableCollection<Item> listCopy = new ObservableCollection<Item>(ItemList);
                try
                {
                    listCopy.FirstOrDefault(_item => _item.Id == item.Id).Count++;
                    ItemList = listCopy;
                    ChangeItemCount(true);
                }
                catch { }

            });

            LowerItem = new Command((obj) =>
            {
                Item item = (Item)obj;
                ObservableCollection<Item> listCopy = new ObservableCollection<Item>(ItemList);
                try
                {
                    Item itemFound = listCopy.FirstOrDefault(_item => _item.Id == item.Id);
                    if (itemFound.Count > 0)
                    {
                        itemFound.Count--;
                        ItemList = listCopy;
                        ChangeItemCount(false);
                    }
                }
                catch { }
            });
        }

        public void ChangeItemCount(bool countUp)
        {
            if (countUp)
                ItemCount++;
            else
                ItemCount--;
        }

    }
}
