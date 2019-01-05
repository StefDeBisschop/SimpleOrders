using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using B4.EE.DeBisschopS.Models;

namespace B4.EE.DeBisschopS.Storage
{
    interface IStorage
    {
        Task<Item> AddNewItem(string name, decimal cost, string imageNameF);
        Task<ObservableCollection<Item>> GetAllItems();
        Task<Settings> ChangeCurrency(string currencyName);
        Task<Settings> ChangeNotificationsEnabled(bool areNotificationsEnabled);
        Task<Settings> GetSettings();
    }
}
