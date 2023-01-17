using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace baked_mobile_app
{
    public partial class App : Application
    {
        public static string FolderPath { get; set;}

        public App ()
        {
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage (new MainPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

