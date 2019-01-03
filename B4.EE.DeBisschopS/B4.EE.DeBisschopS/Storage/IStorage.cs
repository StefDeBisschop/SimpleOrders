﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using B4.EE.DeBisschopS.Models;

namespace B4.EE.DeBisschopS.Storage
{
    interface IStorage
    {
        Task<Item> AddNewItem(string name, float cost, string imageNameF);
        Task<ObservableCollection<Item>> GetAllItems();
        Task<Settings> ChangeCurrency(string currencyName);
        Task<Settings> GetSettings();
    }
}
