using System;

[Serializable]
public struct MT_DATA
{
    public const int BUFFER_SIZE = 1024;
    private byte[] buffer;

    public void Clear()
    {
        buffer = new byte[BUFFER_SIZE];
    }
}