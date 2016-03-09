using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Navigation
{
    public interface INavigatedTo
    {
        Task OnNavigatedTo(NavigationMode navigationMode, object parameter = null);
    }
}
