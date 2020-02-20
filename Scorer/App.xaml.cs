using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Scorer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ScaleLogger.LogEnabled = true;  
            MainPage = new MainPage();
        }

        public static void Log(string msg, string title = "Hava", [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
        {
            string comple_msg = $"{DateTime.Now.ToString("HH: mm: ss.fff tt")} [{title}] -[ {memberName} ]: {msg}";
#if DEBUG
            System.Diagnostics.Debug.WriteLine(comple_msg);
#else
            Console.WriteLine(comple_msg);
#endif
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
