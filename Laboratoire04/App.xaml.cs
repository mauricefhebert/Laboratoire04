using Laboratoire04.Data;
using Laboratoire04.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Laboratoire04
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        public App(string databaseLocation)
        {
            InitializeComponent();
            MainPage = new AppShell();
            DatabaseLocation = databaseLocation;
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
