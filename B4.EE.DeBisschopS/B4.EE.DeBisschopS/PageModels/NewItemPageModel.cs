using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;
using B4.EE.DeBisschopS.Models;
using B4.EE.DeBisschopS.Storage;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.PageModels
{
    public class NewItemPageModel : INotifyPropertyChanged
    {
        private INavigation navigation;
        public MemoryService ms;
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }
        private string _imageClicked;
        public string imageClicked
        {
            get
            {
                return _imageClicked;
            }

            set
            {
                _imageClicked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(imageClicked)));
            }
        }
        private int _cost;
        public int cost
        {
            get
            {
                return _cost;
            }

            set
            {
                _cost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(cost)));
            }
        }
        public NewItemPageModel(INavigation navigation)
        {
            ms = new MemoryService();
            this.navigation = navigation;
        }

        public ICommand AddItem => new Command(
            async () =>
            {
                await ms.AddNewItem(name, cost, imageClicked);
                await navigation.PopAsync();
            });

    }
}
