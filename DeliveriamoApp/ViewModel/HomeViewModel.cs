using Android.Database;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriamoApp.ViewModel
{
    internal class HomeViewModel : ObservableObject
    {
        public HomeViewModel()
        {
            if (String.IsNullOrEmpty(((App)App.Current).Token))
            {

            }
        }
    }
}
