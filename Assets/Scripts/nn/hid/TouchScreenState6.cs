using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.hid
{
	public struct TouchScreenState6
	{
		public const int TouchCount = 6;

		public long samplingNumber;
		public int count;
		private int _reserved;
		public TouchStateArray6 touches;
		
		// TODO
		public void SetDefault() { }

		public struct TouchStateArray6 : IList<TouchState>, ICollection<TouchState>, IEnumerable<TouchState>, IEnumerable
		{
			private const int _Length = 6;

			private TouchState _value0;
			private TouchState _value1;
			private TouchState _value2;
			private TouchState _value3;
			private TouchState _value4;
			private TouchState _value5;

            public int Length => _Length;
            public TouchState this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0: return _value0;
                        case 1: return _value1;
                        case 2: return _value2;
                        case 3: return _value3;
                        case 4: return _value4;
                        case 5: return _value5;
                        default: throw new IndexOutOfRangeException();
                    }
                }
                set
                {
                    switch (index)
                    {
                        case 0: _value0 = value; break;
                        case 1: _value1 = value; break;
                        case 2: _value2 = value; break;
                        case 3: _value3 = value; break;
                        case 4: _value4 = value; break;
                        case 5: _value5 = value; break;
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
                yield return this[1];
                yield return this[2];
                yield return this[3];
                yield return this[4];
                yield return this[5];
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