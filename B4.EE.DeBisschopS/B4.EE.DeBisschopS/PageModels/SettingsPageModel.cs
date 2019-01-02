using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using B4.EE.DeBisschopS.Models;
using B4.EE.DeBisschopS.Pages;
using B4.EE.DeBisschopS.Storage;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.PageModels
{
    public class SettingsPageModel : INotifyPropertyChanged
    {
        private INavigation navigation;
        public event PropertyChangedEventHandler PropertyChanged;
        private MemoryService ms;
        private string _currencySetting;
        public string currencySetting
        {
            get
            {
                return _currencySetting;
            }

            set
            {
                _currencySetting = value;
                ChangeCurrency(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(currencySetting)));
            }
        }

        public SettingsPageModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public async void InitializeAsync()
        {
            ms = new MemoryService();
            Settings allSettings = await ms.GetSettings();
            currencySetting = allSettings.currency;
        }

        public ICommand GoToNewItemPage => new Command(
            () =>
            {
                navigation.PushAsync(new NewItemPage());
            });

        public async Task ChangeCurrency(string currencyName)
        {
            ms = new MemoryService();
            await ms.ChangeCurrency(currencySetting);
        }
    }
}
