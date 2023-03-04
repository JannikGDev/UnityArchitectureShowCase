using System.Runtime.InteropServices;

public static class ApplicationHelper
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public static bool IsRunningOnMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
                                     return IsMobile();
#endif
        return false;
    }
}
