using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Dpr
{
    public class CacheList<T>
    {
        private List<T> _caches;
        private int _num;

        public List<T> caches { get => _caches; }
        public int maxNum { get => _num; }

        public CacheList(int num)
        {
            _num = num;
            _caches = new List<T>();
        }

        public void Add(T item)
        {
            int index = _caches.IndexOf(item);
            if (index > -1)
                _caches.RemoveAt(index);

            _caches.Add(item);
        }

        public void Remove(T item)
        {
            _caches.Remove(item);
        }

        public T Find(Func<T, bool> onCompare)
        {
            return _caches.FirstOrDefault(x => onCompare.Invoke(x));
        }

        public void MoveLast(T item, [Optional] Func<T, bool> onRemove)
        {
            _caches.Remove(item);
            _caches.Add(item);

            if (onRemove == null)
                return;

            for (int i=_caches.Count-_num-1; i>=0; i--)
            {
                if (onRemove.Invoke(_caches[i]))
                    _caches.RemoveAt(i);
            }
        }

        public void Clear([Optional] Action<T> onRemove)
        {
            if (onRemove != null)
            {
                for (int i=_caches.Count-1; i>=0; i--)
                    onRemove.Invoke(_caches[i]);
            }

            _caches.Clear();
        }

        public void Reset([Optional, DefaultParameterValue(0)] int num, [Optional] Action<T> onRemove)
        {
            _num = num;

            for (int i=_caches.Count-1; i>=num; i--)
            {
                onRemove?.Invoke(_caches[i]);
                _caches.Remove(_caches[i]);
            }
        }

        public int Count()
        {
            return _caches.Count;
        }

        public T this[int i] => _caches[i];
    }
}