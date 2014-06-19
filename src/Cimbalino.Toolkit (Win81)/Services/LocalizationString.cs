using Windows.ApplicationModel.Resources;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// The localization string.
    /// </summary>
    public class LocalizationString : ILocalizationString
    {
        private readonly ResourceLoader _resourceLoader;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationString"/> class.
        /// </summary>
        public LocalizationString()
        {
            _resourceLoader = new ResourceLoader();
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Get(string key)
        {
            return _resourceLoader.GetString(key);
        }
    }
}
