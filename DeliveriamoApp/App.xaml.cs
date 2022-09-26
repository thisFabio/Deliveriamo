﻿using DeliveriamoClient;

namespace DeliveriamoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public string Token { get; set; }
        public bool IsRestaurant { get; set; }
        public bool IsSupermarket { get; set; }
        public List<ProductDto> CartItems { get; set; } = new List<ProductDto>();

    }
}