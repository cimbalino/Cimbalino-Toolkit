namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// The LocalizationString interface.
    /// </summary>
    public interface ILocalizationString
    {
        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string Get(string key);
    }
}
