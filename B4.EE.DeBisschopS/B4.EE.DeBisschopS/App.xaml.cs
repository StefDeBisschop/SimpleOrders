using System;
using System.Collections.ObjectModel;
using B4.EE.DeBisschopS.Models;
using B4.EE.DeBisschopS.PageModels;
using B4.EE.DeBisschopS.Pages;
using B4.EE.DeBisschopS.Storage;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace B4.EE.DeBisschopS
{
    public partial class App : Application
    {
        public MemoryService InitialMS;
        public ObservableCollection<Item> InitialItems;
        public App()
        {
            InitializeComponent();

            MainPage = new LoadingPage();
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            InitialMS = new MemoryService();
            InitialItems = await InitialMS.GetAllItems();

            MainPage = new NavigationPage(new OrderPage(InitialItems))
            {
                BackgroundColor = Color.Transparent,
                BarTextColor = Color.DarkOrange
            };
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
