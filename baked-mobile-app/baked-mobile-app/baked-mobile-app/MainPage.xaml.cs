using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bakedmobileapp;
using Xamarin.Forms;

namespace baked_mobile_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            splashScreenButton.Clicked += SplashScreenButton_Clicked;
        }

        private void SplashScreenButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignInPage
            {

            });
        }
    }
}

