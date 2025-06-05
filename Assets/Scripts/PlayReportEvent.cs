using System;

public class PlayReportEvent
{
    public const int PLAYREPORT_SIZE = 56;
    public const int DEFAULT_BUFFER_SIZE = 512;
    private IntPtr _playReportPtr;
    private IntPtr _buffer;

    // TODO
    private static extern int GetPlayReportSize();

    // TODO
    private static extern void CreatePlayReportEvent(string eventName, IntPtr prepoEventPtr, IntPtr buffer, int bufferSize);

    // TODO
    private static extern void SavePlayReportEvent(IntPtr eventPtr, ulong uid0, ulong uid1);

    // TODO
    private static extern void AddBoolValue(IntPtr eventPtr, string key, bool value);

    // TODO
    private static extern void AddLongValue(IntPtr eventPtr, string key, long value);

    // TODO
    private static extern void AddCharValue(IntPtr eventPtr, string key, string value);

    // TODO
    public PlayReportEvent(string eventName, int bufferSize = DEFAULT_BUFFER_SIZE) { }

    // TODO
    ~PlayReportEvent() { }

    // TODO
    public void SaveEvent() { }

    // TODO
    public void AddBool(string key, bool value) { }

    // TODO
    public void AddLong(string key, long value) { }

    // TODO
    public void AddString(string key, string value) { }
}