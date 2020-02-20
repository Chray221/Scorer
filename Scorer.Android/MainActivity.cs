using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using XScaleHelper = Scorer.ScaleHelper;

namespace Scorer.Droid
{
    [Activity(Label = "Arnis Scoreboard", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation , ScreenOrientation = ScreenOrientation.Landscape )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Init(this);
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        public void Init(Context formsAppCompat)
        {
            var density = formsAppCompat.Resources.DisplayMetrics.Density;
            XScaleHelper.ScreenWidth = formsAppCompat.Resources.DisplayMetrics.WidthPixels / density;
            XScaleHelper.ScreenHeight = formsAppCompat.Resources.DisplayMetrics.HeightPixels / density;
            XScaleHelper.AppScale = density;
            XScaleHelper.DeviceType = 1;
            App.Log($"H:{XScaleHelper.ScreenHeight}");
            int resourceId = formsAppCompat.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                XScaleHelper.StatusBarHeight = formsAppCompat.Resources.GetDimensionPixelSize(resourceId) / density;
                XScaleHelper.ScreenHeight -= XScaleHelper.StatusBarHeight;
            }

            XScaleHelper.OrigScreenWidth = formsAppCompat.Resources.DisplayMetrics.WidthPixels / density;
            XScaleHelper.OrigScreenHeight = formsAppCompat.Resources.DisplayMetrics.HeightPixels / density;
            XScaleHelper.TopInsets = 0.0f;
            XScaleHelper.BottomInsets = 0.0f;

            App.Log($"W:{XScaleHelper.ScreenWidth} H:{XScaleHelper.ScreenHeight} SC:{XScaleHelper.AppScale} BH:{XScaleHelper.StatusBarHeight}");
            App.Log($"OW:{XScaleHelper.OrigScreenWidth} OH:{XScaleHelper.OrigScreenHeight} SC:{XScaleHelper.AppScale} BH:{XScaleHelper.StatusBarHeight}");

            XScaleHelper.SystemVersion = Build.VERSION.Sdk;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}