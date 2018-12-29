using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
