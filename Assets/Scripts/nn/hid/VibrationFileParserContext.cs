using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.hid
{
	public struct VibrationFileParserContext
	{
		public IntPtrArray10 _storage;

		public struct IntPtrArray10 : IList<IntPtr>, ICollection<IntPtr>, IEnumerable<IntPtr>, IEnumerable
		{
			private const int _Length = 10;

			private IntPtr _value0;
			private IntPtr _value1;
			private IntPtr _value2;
			private IntPtr _value3;
			private IntPtr _value4;
			private IntPtr _value5;
			private IntPtr _value6;
			private IntPtr _value7;
			private IntPtr _value8;
			private IntPtr _value9;

            public int Length => _Length;
            public IntPtr this[int index]
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
                        case 6: return _value6;
                        case 7: return _value7;
                        case 8: return _value8;
                        case 9: return _value9;
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
                        case 6: _value6 = value; break;
                        case 7: _value7 = value; break;
                        case 8: _value8 = value; break;
                        case 9: _value9 = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }
            public int Count => _Length;
            public bool IsReadOnly => true;

            // TODO
            public bool Contains(IntPtr item) { return default; }
			
			// TODO
			public int IndexOf(IntPtr item) { return default; }
			
			// TODO
			public void CopyTo(IntPtr[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }

            public IEnumerator<IntPtr> GetEnumerator()
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
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            // TODO
            public void Add(IntPtr item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, IntPtr item) { }
			
			// TODO
			public bool Remove(IntPtr item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}
	}
}