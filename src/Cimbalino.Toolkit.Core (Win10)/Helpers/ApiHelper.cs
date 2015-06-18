#if WINDOWS_UAP
using Windows.Foundation.Metadata;
#endif

namespace Cimbalino.Toolkit.Core.Helpers
{
    /// <summary>
    /// Helper class to define what functionality is available on each platform
    /// </summary>
    public static class ApiHelper
    {
#if WINDOWS_UAP
        public static bool SupportsBackButton => ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
        public static bool SupportsMemoryManager => ApiInformation.IsTypePresent("Windows.System.MemoryManager");
        public static bool SupportsPhoneCalls => ApiInformation.IsTypePresent("Windows.ApplicationModel.Calls.PhoneCallManager");
        public static bool SupportsChat => ApiInformation.IsTypePresent("Windows.ApplicationModel.Chat.ChatMessage");
        public static bool SupportsVibrate => ApiInformation.IsTypePresent("Windows.Phone.Devices.Notification.VibrationDevice");
        public static bool SupportsStatusBar => ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar");
#elif WINDOWS_PHONE_APP
        public static bool SupportsBackButton => true;
        public static bool SupportsMemoryManager => true;
        public static bool SupportsPhoneCalls => true;
        public static bool SupportsChat => true;
        public static bool SupportsVibrate => true;
        public static bool SupportsStatusBar => true;
#elif WINDOWS_PHONE
        public static bool SupportsBackButton => true;
        public static bool SupportsMemoryManager => false;
        public static bool SupportsPhoneCalls => false;
        public static bool SupportsChat => false;
        public static bool SupportsVibrate => false;
        public static bool SupportsStatusBar => false;
#else
        public static bool SupportsBackButton => false;
        public static bool SupportsMemoryManager => false;
        public static bool SupportsPhoneCalls => false;
        public static bool SupportsChat => false;
        public static bool SupportsVibrate => false;
        public static bool SupportsStatusBar => false;
#endif
    }
}
