﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBusca_CEP.View;

namespace AppBusca_CEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.BairrosPorCidade());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}