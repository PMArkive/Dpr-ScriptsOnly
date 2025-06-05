using nn.util;
using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.hid
{
	public struct GestureState
	{
		public long eventNumber;
		public long contextNumber;
		public int _type;
		public int _direction;
		public int x;
		public int y;
		public int deltaX;
		public int deltaY;
		public Float2 velocity;
		public GestureAttribute attributes;
		public float scale;
		public float rotationAngle;
		public int pointCount;
		public GesturePointArray4 points;
		
		// TODO
		public void SetDefault() { }
		
		// TODO
		public GestureType type { get; }
		
		// TODO
		public GestureDirection direction { get; }
		
		// TODO
		public bool isDoubleTap { get; }
		
		// TODO
		public override string ToString() { return default; }

		public struct GesturePointArray4 : IList<GesturePoint>, ICollection<GesturePoint>, IEnumerable<GesturePoint>, IEnumerable
		{
			private const int _Length = 4;

			private GesturePoint _value0;
			private GesturePoint _value1;
			private GesturePoint _value2;
			private GesturePoint _value3;

			public int Length => _Length;
			public GesturePoint this[int index]
			{
                get
                {
                    switch (index)
                    {
                        case 0: return _value0;
                        case 1: return _value1;
                        case 2: return _value2;
                        case 3: return _value3;
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
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }
			public int Count => _Length;
			public bool IsReadOnly => true;
			
			// TODO
			public bool Contains(GesturePoint item) { return default; }
			
			// TODO
			public int IndexOf(GesturePoint item) { return default; }
			
			// TODO
			public void CopyTo(GesturePoint[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }
			
			public IEnumerator<GesturePoint> GetEnumerator()
			{
                yield return this[0];
                yield return this[1];
                yield return this[2];
                yield return this[3];
            }
			
			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
			
			// TODO
			public void Add(GesturePoint item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, GesturePoint item) { }
			
			// TODO
			public bool Remove(GesturePoint item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}
	}
}