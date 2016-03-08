#if WINDOWS_UWP
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Cimbalino.Toolkit.Extensions;
#elif WINDOWS_PHONE_APP
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Extensions;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Storage.Pickers;
using Windows.Storage;
#elif WINDOWS_APP
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Cimbalino.Toolkit.Extensions;
#elif WINDOWS_PHONE
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Helpers;

#endif

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Implementation of the IFilePickerService interface
    /// </summary>
    public class FilePickerService : IFilePickerService
    {
        /// <summary>
        /// Opens the single file picker asynchronous.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>A FilePickerResult</returns>
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

        /// <summary>
        /// Opens the multiple files picker asynchronous.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>
        /// A list of FilePickerResult objects
        /// </returns>
        public virtual async Task<List<FilePickerResult>> OpenMultipleFilesPickerAsync(FilePickerOptions options)
        {
            if (options?.FileTypeFilters == null || !options.FileTypeFilters.Any())
            {
                throw new ArgumentNullException(nameof(options), "You need to provide a file type filter");
            }

            var filePicker = new FileOpenPicker();
            filePicker.AddOptions(options);

            IReadOnlyList<StorageFile> files = null;
            List<FilePickerResult> results = null;
#if WINDOWS_APP || WINDOWS_UWP
            files = await filePicker.PickMultipleFilesAsync();
#elif WINDOWS_PHONE_APP
            var view = CoreApplication.GetCurrentView();
            var tcs = new TaskCompletionSource<IReadOnlyList<StorageFile>>();
            TypedEventHandler<CoreApplicationView, IActivatedEventArgs> handler = null;

            handler = (a, e) =>
            {
                view.Activated -= handler;

                IReadOnlyList<StorageFile> f = null;

                var continuationEventArgs = e as IContinuationActivatedEventArgs;
                if (continuationEventArgs != null)
                {
                    switch (continuationEventArgs.Kind)
                    {
                        case ActivationKind.PickFileContinuation:
                            FileOpenPickerContinuationEventArgs arguments = continuationEventArgs as FileOpenPickerContinuationEventArgs;
                            f = arguments?.Files;
                            break;
                    }
                }

                tcs.SetResult(f);
            };

            view.Activated += handler;
            filePicker.PickMultipleFilesAndContinue();
            files = await tcs.Task;
#elif WINDOWS_PHONE
            return ExceptionHelper.ThrowNotSupported<List<FilePickerResult>>("This is not supported on silverlight");
#endif

            var taskList = files.Select(ProcessFileResult);
            var taskResult = await Task.WhenAll(taskList);
            results = taskResult.ToList();

            return results;
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
