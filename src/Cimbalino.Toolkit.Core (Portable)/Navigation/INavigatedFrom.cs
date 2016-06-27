using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Navigation
{
    /// <summary>
    /// Interface for when a page has been navigated from
    /// </summary>
    public interface INavigatedFrom
    {
        /// <summary>
        /// Called when [navigated from].
        /// </summary>
        /// <param name="navigationMode">The navigation mode.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The task to be awaited</returns>
        Task OnNavigatedFrom(NavigationMode navigationMode, object parameter = null);
    }
}