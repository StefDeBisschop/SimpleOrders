using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4.EE.DeBisschopS.Models;
using B4.EE.DeBisschopS.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.EE.DeBisschopS.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmationPage : ContentPage
	{
		public ConfirmationPage (ObservableCollection<Item> OrderedItems)
		{
		    InitializeComponent();
		    var pageModel = new ConfirmationPageModel(this.Navigation, OrderedItems);
		    this.BindingContext = pageModel;
        }
	}
}