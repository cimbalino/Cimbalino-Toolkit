using System.Collections.Generic;

namespace Cimbalino.Toolkit.Services
{
    public class FilePickerOptions
    {
        public string ViewMode { get; set; }
        public string SuggestedStartLocation { get; set; }
        public List<string> FileTypeFilters { get; set; }
    }
}