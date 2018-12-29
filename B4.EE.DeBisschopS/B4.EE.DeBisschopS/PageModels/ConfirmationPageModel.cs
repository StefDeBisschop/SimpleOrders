using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using B4.EE.DeBisschopS.Models;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.PageModels
{
    public class ConfirmationPageModel : INotifyPropertyChanged
    {
        private INavigation navigation;
        private ObservableCollection<Item> _OrderedItems;

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

        public ConfirmationPageModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
