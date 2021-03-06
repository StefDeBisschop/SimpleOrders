﻿using System;
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
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();
		    var pageModel = new SettingsPageModel(this.Navigation);
		    CurrencyOptions.ItemsSource = Statics.CurrencyOptions;
		    this.BindingContext = pageModel;
        }
	}
}