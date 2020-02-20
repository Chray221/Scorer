using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scorer.VIewModel;
using Xamarin.Forms;

namespace Scorer
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _MainPageViewModel = new MainPageViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _MainPageViewModel;
        }

        protected override bool OnBackButtonPressed()
        {
            //return base.OnBackButtonPressed();
            return false;
        }

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            
        }
    }
}
