using System.Globalization;

namespace XamarinApp.Settings
{
    /// <summary>
    ///     Default settings for application
    /// </summary>
    public class DefaultSettings
    {
        /// <summary>
        ///     Language
        /// </summary>
        public static string Language { get; set; } = CultureInfo.CurrentCulture.Name;

        /// <summary>
        ///     Font family
        /// </summary>
        public static string FontFamily { get; set; } = "fantasy";

        /// <summary>
        ///     Font size
        /// </summary>
        public static double FontSize { get; set; } = 18;
    }
}