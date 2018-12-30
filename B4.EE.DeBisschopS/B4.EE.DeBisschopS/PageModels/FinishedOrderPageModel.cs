using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using B4.EE.DeBisschopS.Pages;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.PageModels
{
    public class FinishedOrderPageModel
    {
        private INavigation navigation;
        public FinishedOrderPageModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
        public ICommand GoToOrderPage => new Command(
            () =>
            {
                navigation.PushAsync(new OrderPage());
            });
    }
}
