using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Settings;

namespace XamarinApp.Services
{
    /// <summary>
    ///     Font family service for application
    /// </summary>
    [ContentProperty("FontFamily")]
    public class FontFamilyService : IMarkupExtension
    {
        /// <summary>
        ///     Get current font family
        /// </summary>
        ///
        /// <param name="serviceProvider">Service provider</param>
        ///
        /// <returns>object</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return DefaultSettings.FontFamily;
        }
    }
}