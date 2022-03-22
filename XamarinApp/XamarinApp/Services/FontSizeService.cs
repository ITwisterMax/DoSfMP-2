using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Settings;

namespace XamarinApp.Services
{
    /// <summary>
    ///     Font size service for application
    /// </summary>
    [ContentProperty("FontSize")]
    public class FontSizeService : IMarkupExtension
    {
        /// <summary>
        ///     Get current font size
        /// </summary>
        ///
        /// <param name="serviceProvider">Service provider</param>
        ///
        /// <returns>object</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return DefaultSettings.FontSize;
        }
    }
}