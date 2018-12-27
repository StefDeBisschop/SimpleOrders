using System;
using System.Collections.Generic;
using System.Text;
using B4.EE.DeBisschopS.Models;
using FreshMvvm;

namespace B4.EE.DeBisschopS.PageModels
{
    public class OrderPageModel : FreshBasePageModel
    {
        public List<Item> ItemList { get; set; }
        public OrderPageModel()
        {
            
        }

        public override void Init(object initData)
        {
            base.Init(initData);

            ItemList = new List<Item>
            {
                new Item {Cost = 12, Name = "TestItem"}
            };
        }
    }
}
