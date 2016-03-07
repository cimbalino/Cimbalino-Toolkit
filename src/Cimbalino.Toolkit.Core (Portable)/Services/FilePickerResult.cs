using System.IO;

namespace Cimbalino.Toolkit.Services
{
    public class FilePickerResult
    {
        public string FileName { get; internal set; }
        public Stream FileStream { get; internal set; }
        public bool IsCancelled { get; internal set; }
    }
}