using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B4.EE.DeBisschopS.PageModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.EE.DeBisschopS.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewItemPage : ContentPage
	{
		public NewItemPage ()
		{
		    var pageModel = new NewItemPageModel(this.Navigation);
		    this.BindingContext = pageModel;
            InitializeComponent ();
		}
	}
}