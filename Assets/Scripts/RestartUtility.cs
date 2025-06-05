using nn.account;
using System;

public class RestartUtility
{
    // TODO
    private static extern void Native_RestartProgram();

    // TODO
    public static void RestartProgram() { }

    // TODO
    private static extern bool Native_PopOpenUsers(IntPtr p);

    // TODO
    public static bool GetLastUser(ref UserHandle userHandle) { return false; }
}