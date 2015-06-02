using System;

namespace Cimbalino.Toolkit.Services
{
    public interface ITitleBarService
    {
        void SetExtendViewIntoTitleBar(bool extend);
        event EventHandler<TitleBarIsVisibleChangedArgs> IsVisibleChanged;
        double Height { get; }
    }
}
