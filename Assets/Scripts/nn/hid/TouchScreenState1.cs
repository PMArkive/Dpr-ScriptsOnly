using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.hid
{
	public struct TouchScreenState1
	{
		public const int TouchCount = 1;

		public long samplingNumber;
		public int count;
		private int _reserved;
		public TouchStateArray1 touches;
		
		// TODO
		public void SetDefault() { }

		public struct TouchStateArray1 : IList<TouchState>, ICollection<TouchState>, IEnumerable<TouchState>, IEnumerable
		{
			private const int _Length = 1;

			private TouchState _value0;

			public int Length => _Length;
            public TouchState this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0: return _value0;
                        default: throw new IndexOutOfRangeException();
                    }
                }
                set
                {
                    switch (index)
                    {
                        case 0: _value0 = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }
            public int Count => _Length;
			public bool IsReadOnly => true;
			
			// TODO
			public bool Contains(TouchState item) { return default; }
			
			// TODO
			public int IndexOf(TouchState item) { return default; }
			
			// TODO
			public void CopyTo(TouchState[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }
			
			public IEnumerator<TouchState> GetEnumerator()
			{
                yield return this[0];
            }
			
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
			
			// TODO
			public void Add(TouchState item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, TouchState item) { }
			
			// TODO
			public bool Remove(TouchState item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}
	}
}