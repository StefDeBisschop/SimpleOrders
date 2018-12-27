using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using B4.EE.DeBisschopS.Models;
using FreshMvvm;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.PageModels
{
    public class OrderPageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Item> _ItemList;
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

        public Command RaiseItem { get; }
        public Command LowerItem { get; }
        public OrderPageModel()
        {
            ItemList = new ObservableCollection<Item>
            {
                new Item {Cost = 12, Name = "TestItem"},
                new Item {Cost = 10, Name = "TestItem2"}
            };

            RaiseItem = new Command((obj) =>
            {
                Item item = (Item)obj;
                ObservableCollection<Item> listCopy = new ObservableCollection<Item>(ItemList);
                try
                {
                    listCopy.FirstOrDefault(_item => _item.Id == item.Id).Count++;
                    ItemList = listCopy;
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
                    }
                }
                catch { }


            });
        }

    }
}
