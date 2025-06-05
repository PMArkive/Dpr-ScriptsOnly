using UnityEngine;
#if SWITCH
using UnityEngine.Switch;
#endif

public class SwitchNotification
{
    public static NotificationEvent ExitRequest;
    public static NotificationEvent FocusStateChanged;
    public static NotificationEvent Resume;
    public static NotificationEvent OperationModeChanged;
    public static NotificationEvent PerformanceModeChanged;
    public static NotificationEvent InFocus;
    public static NotificationEvent OutOfFocus;
    public static NotificationEvent Background;
#if SWITCH
    public static Notification.FocusHandlingMode CurrentFocusHandlingMode;
#endif

    // TODO
    public static void SetFocusHandlingModeNotify() { }

    // TODO
    public static void SetFocusHandlingModeSuspend() { }

    // TODO
    private static extern void SwitchInvokeNotificationNativeExample();

#if SWITCH
    // TODO
    private static void NotificationMessageReceived(Notification.Message message) { }
#endif

    // TODO
    [RuntimeInitializeOnLoadMethod]
    private static void OnRuntimeMethodLoad() { }

    // TODO
    private static void OnMessage_ExitRequest() { }

    // TODO
    private static void OnMessage_FocusStateChanged() { }

    // TODO
    private static void OnMessage_Resume() { }

    // TODO
    private static void OnMessage_OperationModeChanged() { }

    // TODO
    private static void OnMessage_PerformanceModeChanged() { }

    // TODO
    private static void OnFocusState_InFocus() { }

    // TODO
    private static void OnFocusState_OutOfFocus() { }

    // TODO
    private static void OnFocusState_Background() { }

    public delegate void NotificationEvent(int value);
}