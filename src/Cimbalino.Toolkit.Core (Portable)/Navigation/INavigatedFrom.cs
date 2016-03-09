using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Navigation
{
    public interface INavigatedFrom
    {
        Task OnNavigatedFrom(NavigationMode navigationMode, object parameter = null);
    }
}