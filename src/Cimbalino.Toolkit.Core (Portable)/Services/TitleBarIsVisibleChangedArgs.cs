using System;

namespace Cimbalino.Toolkit.Services
{
    public class TitleBarIsVisibleChangedArgs : EventArgs
    {
        public TitleBarIsVisibleChangedArgs(bool isVisible)
        {
            IsVisible = isVisible;
        }

        public bool IsVisible { get; set; }
    }
}