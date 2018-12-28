using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace B4.EE.DeBisschopS.PageModels
{
    public class NewItemPageModel
    {
        private INavigation navigation;
        public NewItemPageModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
