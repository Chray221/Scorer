using System;
//using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Scorer
{
    [Preserve(AllMembers = true)]
    public static class ScaleCS
    {

        static ScaleCS()
        {
            ScaleLogger.Log($"{heightMin} W:{widthMin}");
        }
        static float heightMin { get { return ScaleHelper.ScreenHeight > ScaleHelper.ScreenWidth ? 568.0F : 320.0F; } }
        static float widthMin { get { return ScaleHelper.ScreenHeight > ScaleHelper.ScreenWidth ? 320.0F : 568.0F; } }
        /// <summary>
        /// Scales the height.
        /// </summary>
        /// <returns>The height.</returns>
        /// <param name="number">Number.</param>
        /// <param name="iOS">Value for iOS.</param>
        public static float ScaleHeight(this int number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;
            return (float)(number * (ScaleHelper.ScreenHeight / heightMin));
        }

        /// <summary>
        /// Scales the height.
        /// </summary>
        /// <returns>The height.</returns>
        /// <param name="number">Number.</param>
        /// <param name="iOS">Value for iOS.</param>
        public static float ScaleHeight(this double number, double? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;
            return (float)(number * (ScaleHelper.ScreenHeight / heightMin));
        }

        /// <summary>
        /// Scales the height.
        /// </summary>
        /// <returns>The height.</returns>
        /// <param name="number">Number.</param>
        /// <param name="iOS">Value for iOS.</param>
        public static float ScaleHeight(this float number, float? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (float)(number * (ScaleHelper.ScreenHeight / heightMin));
        }

        /// <summary>
        /// Scales the width.
        /// </summary>
        /// <returns>The width.</returns>
        /// <param name="number">Number.</param>
        /// <param name="iOS">Value for iOS.</param>
        public static float ScaleWidth(this int number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;
            ScaleLogger.Log($"asdasd {ScaleHelper.ScreenWidth} {widthMin}");
            return (float)(number * (ScaleHelper.ScreenWidth / widthMin));
        }

        /// <summary>
        /// Scales the width.
        /// </summary>
        /// <returns>The width.</returns>
        /// <param name="number">Number.</param>
        /// <param name="iOS">Value for iOS.</param>
        public static float ScaleWidth(this double number, double? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;
            ScaleLogger.Log($"asdasd {ScaleHelper.ScreenWidth} {widthMin}");
            return (float)(number * (ScaleHelper.ScreenWidth / widthMin));
        }

        /// <summary>
        /// Scales the width.
        /// </summary>
        /// <returns>The width.</returns>
        /// <param name="number">Number.</param>
        /// <param name="iOS">Value for iOS.</param>
        public static float ScaleWidth(this float number, float? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;
            ScaleLogger.Log($"asdasd {ScaleHelper.ScreenWidth} {widthMin}");
            return (float)(number * (ScaleHelper.ScreenWidth / widthMin));
        }

        /// <summary>
        /// Scales the font.
        /// </summary>
        /// <returns>The font.</returns>
        /// <param name="number">Number.</param>
        /// <param name="iOS">Value for iOS.</param>
        public static double ScaleFont(this int number, int? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (number * GetMinSize() - (Device.RuntimePlatform == Device.iOS ? 0.5 : 0));
        }

        /// <summary>
        /// Scales the font.
        /// </summary>
        /// <returns>The font.</returns>
        /// <param name="number">Number.</param>
        /// <param name="iOS">Value for iOS.</param>
        public static double ScaleFont(this double number, double? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return (number * GetMinSize() - (Device.RuntimePlatform == Device.iOS ? 0.5 : 0));
        }

        public static Thickness ScaleThickness(this Thickness number, Thickness? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;
            number.Left = number.Left.ScaleWidth();
            number.Top = number.Top.ScaleHeight();
            number.Right = number.Right.ScaleWidth();
            number.Bottom = number.Bottom.ScaleHeight();
            return number;
        }

        public static CornerRadius ScaleCornerRadius(this CornerRadius number, CornerRadius? iOS = null)
        {
            if (iOS.HasValue && Device.RuntimePlatform == Device.iOS)
                number = iOS.Value;

            return new CornerRadius(number.TopLeft.ScaleHeight(),number.TopRight.ScaleHeight(),number.BottomLeft.ScaleHeight(),number.BottomRight.ScaleHeight());
        }

        public static double GetMinSize()
        {
            return Math.Min((ScaleHelper.ScreenHeight / heightMin), (ScaleHelper.ScreenWidth / widthMin));
        }

        /// <summary>
        /// Clone the specified source. Para dili ma usab ang source.
        /// </summary>
        /// <returns>The clone.</returns>
        /// <param name="source">Source.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        //public static T Clone<T>(this T source)
        //{
        //    var serialized = JsonConvert.SerializeObject(source);
        //    return JsonConvert.DeserializeObject<T>(serialized);
        //}
    }
}
