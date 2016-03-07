using System;
using System.Linq;
using Windows.Storage.Pickers;
using Cimbalino.Toolkit.Services;

namespace Cimbalino.Toolkit.Extensions
{
    internal static class FilePickerExtensions
    {
        internal static void AddOptions(this FileOpenPicker filePicker, FilePickerOptions options)
        {
            if (!string.IsNullOrEmpty(options?.SuggestedStartLocation))
            {
                PickerLocationId location;
                if (Enum.TryParse(options.SuggestedStartLocation, true, out location))
                {
                    filePicker.SuggestedStartLocation = location;
                }
            }

            if (!string.IsNullOrEmpty(options?.ViewMode))
            {
                PickerViewMode viewMode;
                if (Enum.TryParse(options.ViewMode, true, out viewMode))
                {
                    filePicker.ViewMode = viewMode;
                }
            }

            if (options?.FileTypeFilters != null && options.FileTypeFilters.Any())
            {
                filePicker.FileTypeFilter.AddRange(options.FileTypeFilters);
            }
        }
    }
}