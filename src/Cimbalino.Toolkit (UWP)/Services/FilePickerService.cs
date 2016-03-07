#if WINDOWS_UWP
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Cimbalino.Toolkit.Extensions;
#elif WINDOWS_PHONE_APP
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Cimbalino.Toolkit.Extensions;
#elif WINDOWS_APP
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Cimbalino.Toolkit.Extensions;
#elif WINDOWS_PHONE
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Helpers;

#endif

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

            StorageFile file = null;

#if WINDOWS_APP || WINDOWS_UWP
            file = await filePicker.PickSingleFileAsync();
#elif WINDOWS_PHONE_APP
            var view = CoreApplication.GetCurrentView();
            var tcs = new TaskCompletionSource<StorageFile>();
            TypedEventHandler<CoreApplicationView, IActivatedEventArgs> handler = null;

            handler = (a, e) =>
            {
                view.Activated -= handler;

                StorageFile f = null;

                var continuationEventArgs = e as IContinuationActivatedEventArgs;
                if (continuationEventArgs != null)
                {
                    switch (continuationEventArgs.Kind)
                    {
                        case ActivationKind.PickFileContinuation:
                            FileOpenPickerContinuationEventArgs arguments = continuationEventArgs as FileOpenPickerContinuationEventArgs;
                            f = arguments?.Files?.FirstOrDefault();
                            break;
                    }
                }

                tcs.SetResult(f);
            };

            view.Activated += handler;
            filePicker.PickSingleFileAndContinue();

            file = await tcs.Task;
#else
            ExceptionHelper.ThrowNotSupported("This isn't supported in Silverlight apps");
#endif
            return await ProcessFileResult(file).ConfigureAwait(false);
        }

        private static async Task<FilePickerResult> ProcessFileResult(StorageFile file)
        {
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
