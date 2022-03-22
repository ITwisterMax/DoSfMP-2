using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Settings;

namespace XamarinApp.Services
{
    /// <summary>
    ///     Language service for application
    /// </summary>
    [ContentProperty("Text")]
    public class LanguageService : IMarkupExtension
    {
        /// <summary>
        ///     Languafe resource
        /// </summary>
        private const string LanguageResource = "XamarinApp.Resources.AppContentText";

        /// <summary>
        ///     Culture info
        /// </summary>
        private readonly CultureInfo CultureInfo;

        /// <summary>
        ///     Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     Default constructor
        /// </summary>
        public LanguageService()
        {
            CultureInfo = new CultureInfo(DefaultSettings.Language);
        }

        /// <summary>
        ///     Get current language (translator for this language)
        /// </summary>
        ///
        /// <param name="serviceProvider">Service provider</param>
        ///
        /// <returns>object</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
            {
                return "";
            }

            var resourceManager = new ResourceManager(LanguageResource, typeof(LanguageService).GetTypeInfo().Assembly);

            string translation = resourceManager.GetString(Text, CultureInfo);

            if (translation == null)
            {
                translation = Text;
            }

            return translation;
        }
    }
}