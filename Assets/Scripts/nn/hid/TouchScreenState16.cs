using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.hid
{
	public struct TouchScreenState16
	{
		public const int TouchCount = 16;

		public long samplingNumber;
		public int count;
		private int _reserved;
		public TouchStateArray16 touches;
		
		// TODO
		public void SetDefault() { }

		public struct TouchStateArray16 : IList<TouchState>, ICollection<TouchState>, IEnumerable<TouchState>, IEnumerable
		{
			private const int _Length = 16;

			private TouchState _value0;
			private TouchState _value1;
			private TouchState _value2;
			private TouchState _value3;
			private TouchState _value4;
			private TouchState _value5;
			private TouchState _value6;
			private TouchState _value7;
			private TouchState _value8;
			private TouchState _value9;
			private TouchState _value10;
			private TouchState _value11;
			private TouchState _value12;
			private TouchState _value13;
			private TouchState _value14;
			private TouchState _value15;

            public int Length => _Length;
            public TouchState this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0:  return _value0;
                        case 1:  return _value1;
                        case 2:  return _value2;
                        case 3:  return _value3;
                        case 4:  return _value4;
                        case 5:  return _value5;
                        case 6:  return _value6;
                        case 7:  return _value7;
                        case 8:  return _value8;
                        case 9:  return _value9;
                        case 10: return _value10;
                        case 11: return _value11;
                        case 12: return _value12;
                        case 13: return _value13;
                        case 14: return _value14;
                        case 15: return _value15;
                        default: throw new IndexOutOfRangeException();
                    }
                }
                set
                {
                    switch (index)
                    {
                        case 0:  _value0 = value;  break;
                        case 1:  _value1 = value;  break;
                        case 2:  _value2 = value;  break;
                        case 3:  _value3 = value;  break;
                        case 4:  _value4 = value;  break;
                        case 5:  _value5 = value;  break;
                        case 6:  _value6 = value;  break;
                        case 7:  _value7 = value;  break;
                        case 8:  _value8 = value;  break;
                        case 9:  _value9 = value;  break;
                        case 10: _value10 = value; break;
                        case 11: _value11 = value; break;
                        case 12: _value12 = value; break;
                        case 13: _value13 = value; break;
                        case 14: _value14 = value; break;
                        case 15: _value15 = value; break;
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
                yield return this[6];
                yield return this[7];
                yield return this[8];
                yield return this[9];
                yield return this[10];
                yield return this[11];
                yield return this[12];
                yield return this[13];
                yield return this[14];
                yield return this[15];
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