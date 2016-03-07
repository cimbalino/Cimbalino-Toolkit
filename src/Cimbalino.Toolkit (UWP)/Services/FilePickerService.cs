using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Cimbalino.Toolkit.Extensions;

namespace Cimbalino.Toolkit.Services
{
    public class FilePickerService : IFilePickerService
    {
        public virtual async Task<FilePickerResult> OpenSingleFilePickerAsync(FilePickerOptions options)
        {
            if (options?.FileTypeFilters == null || !options.FileTypeFilters.Any())
            {
                throw new ArgumentNullException(nameof(options), "You need to provide a file type filter");
            }

            var filePicker = new FileOpenPicker();
            filePicker.AddOptions(options);

            var file = await filePicker.PickSingleFileAsync();
            var result = new FilePickerResult();
            if (file == null)
            {
                result.IsCancelled = true;
            }
            else
            {
                result.FileName = file.Name;
                result.FileStream = await file.OpenStreamForReadAsync();
            }

            return result;
        }
    }
}
