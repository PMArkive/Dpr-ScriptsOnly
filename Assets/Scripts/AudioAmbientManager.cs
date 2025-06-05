using Audio;
using System.Collections.Generic;

public static class AudioAmbientManager
{
    private static HashSet<AudioInstance> _audioInstanceHash = new HashSet<AudioInstance>();
    private static bool _enabled = false;

    public static bool isEnabled { get => _enabled; }

    // TODO
    public static void SetEnabled(bool enabled) { }

    // TODO
    internal static void _Add(AudioInstance audioInstance) { }

    // TODO
    internal static void _Remove(AudioInstance audioInstance) { }
}