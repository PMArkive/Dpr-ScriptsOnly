using System;
using System.Diagnostics;

public class SimpleStopwatch : IDisposable
{
    private string _label = string.Empty;
    private Stopwatch _stopwatch;
    private long _lastTime;

    public long elapsedMilliseconds { get => _stopwatch?.ElapsedMilliseconds ?? -1; }
    public long elapsedMillisecondsSinceLastCall
    {
        get
        {
            if (_stopwatch == null)
                return -1;

            long lastTime = _lastTime;
            _lastTime = _stopwatch.ElapsedMilliseconds;

            return _stopwatch.ElapsedMilliseconds - lastTime;
        }
    }

    public SimpleStopwatch(string label)
    {
        _label = label;
        _stopwatch = new Stopwatch();
        _stopwatch.Start();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_stopwatch != null && disposing)
        {
            _stopwatch.Stop();
            UnityEngine.Debug.Log(string.Format("{0}: {1}ms", _label, _stopwatch.ElapsedMilliseconds));
            _stopwatch = null;
        }
    }

    ~SimpleStopwatch()
    {
        Dispose(false);
    }
}