using System;
using B4.EE.DeBisschopS.PageModels;
using B4.EE.DeBisschopS.Pages;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace B4.EE.DeBisschopS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new OrderPage());

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<OrderPageModel>());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
