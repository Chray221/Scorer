using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Scorer
{
    public partial class NewMainPage : ContentPage
    {
        public NewMainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(3000);
            Navigation.PushAsync(new MainPage());
        }
    }
}
