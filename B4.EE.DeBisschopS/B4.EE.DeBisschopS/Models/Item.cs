using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.Models
{
    public class Item : INotifyPropertyChanged
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public decimal Cost { get; set; }
        
        private int _Count;
        public int Count
        {
            get
            {
                return _Count;
            }

            set
            {
                _Count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        public string ImageNameF { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
