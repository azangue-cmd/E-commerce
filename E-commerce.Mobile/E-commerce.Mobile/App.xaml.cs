using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using E_commerce.Models;
using Xamarin.Essentials;

namespace E_commerce.Mobile
{
    public partial class App : Application
    {
        public const string ServiceBaseAdresse = "http:// 192.168.137.1:8180/api/";
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
