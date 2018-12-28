using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.Models
{
    public class Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Count { get; set; } = 0;
        public string ImageNameF { get; set; }
    }
}
