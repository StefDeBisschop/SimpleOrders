using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using B4.EE.DeBisschopS.Pages;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.PageModels
{
    public class SettingsPageModel
    {
        private INavigation navigation;
        public SettingsPageModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public ICommand GoToNewItemPage => new Command(
            () =>
            {
                navigation.PushAsync(new NewItemPage());
            });
    }
}
