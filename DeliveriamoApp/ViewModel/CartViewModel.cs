using CommunityToolkit.Mvvm.ComponentModel;
using DeliveriamoClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveriamoApp.ViewModel
{
    public class CartViewModel : ObservableObject
    {

        private List<ProductDto> productList = ((App)App.Current).CartItems;

        public List<ProductDto> ProductList
        {
            get
            {
                return productList;
            }
            set
            {
                this.SetProperty(ref productList, value);

            }

        }


    }
}
