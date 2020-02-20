using System;
namespace Scorer
{
    public class ScaleHelper
    {
        public static float ScreenWidth { get; set; }
        public static float ScreenHeight { get; set; }
        public static float AppScale { get; set; }
        public static int DeviceType { get; set; }
        public static string UDID { get; set; }

        public static float StatusBarHeight { get; set; }
        public static bool IsAddNavHeight { get; set; }

        public static float OrigScreenWidth { get; set; }
        public static float OrigScreenHeight { get; set; }
        public static float TopInsets { get; set; }
        public static float BottomInsets { get; set; }

        public static float AdjustedHeight { get; set; }
        public static float AdjustedWidth { get; set; }

        public static string SystemVersion { get; set; }

        public ScaleHelper()
        {

        }
    }
}
