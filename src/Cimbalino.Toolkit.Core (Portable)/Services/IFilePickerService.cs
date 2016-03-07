using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    public interface IFilePickerService
    {
        Task<FilePickerResult> OpenSingleFilePickerAsync(FilePickerOptions options);
    }
}
