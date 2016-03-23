using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Navigation
{
    /// <summary>
    /// Interface for when a page has been navigated to
    /// </summary>
    public interface INavigatedTo
    {
        /// <summary>
        /// Called when [navigated to].
        /// </summary>
        /// <param name="navigationMode">The navigation mode.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The task to be awaited</returns>
        Task OnNavigatedTo(NavigationMode navigationMode, object parameter = null);
    }
}
