public class StaticQueue<T> where T : class
{
    private T[] _param;
    private int _startIndex;
    private int _endIndex;
    private int _count;

    public int count { get => _count; }

    public StaticQueue(int Size)
    {
        _param = new T[Size];
    }

    public void Enqueue(T data)
    {
        if (_param.Length == 0)
            return;

        _endIndex++;
        _param[_endIndex-1] = data;

        if (_param.Length != 0)
            _endIndex -= _endIndex / _param.Length * _param.Length;

        _count++;
    }

    public T Dequeue()
    {
        if (_param.Length == 0)
            return null;

        var item = _param[_startIndex];
        _startIndex++;
        _param[_startIndex] = null;

        if (_param.Length != 0)
            _startIndex -= _startIndex / _param.Length * _param.Length;

        _count--;
        return item;
    }
}