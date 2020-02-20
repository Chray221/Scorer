using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using XScaleHelper = Scorer.ScaleHelper;
using Foundation;
using UIKit;

namespace Scorer.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            global::Xamarin.Forms.Forms.Init();
            Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public static void Init()
        {

            XScaleHelper.ScreenWidth = (float)UIScreen.MainScreen.Bounds.Width;
            XScaleHelper.ScreenHeight = (float)UIScreen.MainScreen.Bounds.Height;

            //If app launched in landscape mode
            //if (CrossDeviceOrientation.Current.CurrentOrientation != Plugin.DeviceOrientation.Abstractions.DeviceOrientations.Portrait)
            //{
            //    XScaleHelper.ScreenWidth = (float)(UIScreen.MainScreen.NativeBounds.Width / UIScreen.MainScreen.Scale);
            //    XScaleHelper.ScreenHeight = (float)(UIScreen.MainScreen.NativeBounds.Height / UIScreen.MainScreen.Scale);
            //    Console.WriteLine("Corrected wrong height and width");
            //}

            XScaleHelper.OrigScreenWidth = XScaleHelper.ScreenWidth;
            XScaleHelper.OrigScreenHeight = XScaleHelper.ScreenHeight;

            XScaleHelper.AppScale = (float)UIScreen.MainScreen.Scale;
            XScaleHelper.DeviceType = 0;
            XScaleHelper.StatusBarHeight = (float)UIApplication.SharedApplication.StatusBarFrame.Height;

            XScaleHelper.TopInsets = 0.0f;
            XScaleHelper.BottomInsets = 0.0f;



            UIWindow w = new UIWindow();
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            {
                if (w.SafeAreaInsets.Top > 0 && w.SafeAreaInsets.Bottom > 0)
                {
                    XScaleHelper.ScreenHeight = 667;
                    XScaleHelper.IsAddNavHeight = true;
                    XScaleHelper.TopInsets = (float)w.SafeAreaInsets.Top;
                    XScaleHelper.BottomInsets = (float)w.SafeAreaInsets.Bottom;
                }
            }

            XScaleHelper.SystemVersion = UIDevice.CurrentDevice.SystemVersion;

        }
    }
}
