using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4.EE.DeBisschopS.Models;
using B4.EE.DeBisschopS.PageModels;
using B4.EE.DeBisschopS.Storage;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.EE.DeBisschopS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        private ObservableCollection<Item> initialItems;
        private bool isStarted;
        private OrderPageModel newPageModel;
        public OrderPage(ObservableCollection<Item> InitialItems)
        {
            InitializeComponent();
            initialItems = InitialItems;
        }

        protected override void OnAppearing()
        {
            if (isStarted)
                newPageModel = new OrderPageModel(this.Navigation);
            else
            {
                newPageModel = new OrderPageModel(this.Navigation, initialItems);
                isStarted = true;
            }
            this.BindingContext = newPageModel;
            base.OnAppearing();
        }
    }
}