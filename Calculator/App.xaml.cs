using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    public partial class App : Application
    {
        public static string AutoClipboardCopy = "";

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep() {
            Clipboard.SetTextAsync(AutoClipboardCopy);
        }


        protected override void OnResume()
        {
        }
    }
}
