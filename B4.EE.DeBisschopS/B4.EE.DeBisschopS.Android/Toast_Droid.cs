using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using B4.EE.DeBisschopS.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Toast_Droid))]
namespace B4.EE.DeBisschopS.Droid
{
    public class Toast_Droid : Toast
    {
        public void ShowToast(string message)
        {
            Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}