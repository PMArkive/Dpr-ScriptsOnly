using nn.account;
using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.irsensor
{
	public struct Hand : IEquatable<Hand>
	{
		public int shapeId;
		public int protrusionCount;
		public ProtrusionArray8 protrusions;
		public HandChirality chirality;
		public Fingers fingers;
		public bool areIndexMiddleFingersTouching;
		public bool areMiddleRingFingersTouching;
		public bool areRingLittleFingersTouching;
		public Palm palm;
		public Arm arm;
		
		// TODO
		public static bool operator ==(Hand lhs, Hand rhs) { return default; }
		
		// TODO
		public static bool operator !=(Hand lhs, Hand rhs) { return default; }
		
		// TODO
		public override bool Equals(object right) { return default; }
		
		// TODO
		public bool Equals(Hand other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }

		public struct ProtrusionArray8 : IList<Protrusion>, ICollection<Protrusion>, IEnumerable<Protrusion>, IEnumerable
		{
			private const int _Length = 8;

			private Protrusion _value0;
			private Protrusion _value1;
			private Protrusion _value2;
			private Protrusion _value3;
			private Protrusion _value4;
			private Protrusion _value5;
			private Protrusion _value6;
			private Protrusion _value7;

            public int Length => _Length;
            public Protrusion this[int index]
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
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }
            public int Count => _Length;
            public bool IsReadOnly => true;

            // TODO
            public bool Contains(Protrusion item) { return default; }
			
			// TODO
			public int IndexOf(Protrusion item) { return default; }
			
			// TODO
			public void CopyTo(Protrusion[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }

            public IEnumerator<Protrusion> GetEnumerator()
            {
                yield return this[0];
                yield return this[1];
                yield return this[2];
                yield return this[3];
                yield return this[4];
                yield return this[5];
                yield return this[6];
                yield return this[7];
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            // TODO
            public void Add(Protrusion item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, Protrusion item) { }
			
			// TODO
			public bool Remove(Protrusion item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}

		public struct Fingers : IList<Finger>, ICollection<Finger>, IEnumerable<Finger>, IEnumerable
		{
			private const int _Length = 5;
			public Finger thumb;
			public Finger index;
			public Finger middle;
			public Finger ring;
			public Finger little;

            public int Length => _Length;
            public Finger this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0: return thumb;
                        case 1: return this.index;
                        case 2: return middle;
                        case 3: return ring;
                        case 4: return little;
                        default: throw new IndexOutOfRangeException();
                    }
                }
                set
                {
                    switch (index)
                    {
                        case 0: thumb = value;      break;
                        case 1: this.index = value; break;
                        case 2: middle = value;     break;
                        case 3: ring = value;       break;
                        case 4: little = value;     break;
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }
            public int Count => _Length;
            public bool IsReadOnly => true;

            // TODO
            public bool Contains(Finger item) { return default; }
			
			// TODO
			public int IndexOf(Finger item) { return default; }
			
			// TODO
			public void CopyTo(Finger[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }

            public IEnumerator<Finger> GetEnumerator()
            {
                yield return this[0];
                yield return this[1];
                yield return this[2];
                yield return this[3];
                yield return this[4];
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            // TODO
            public void Add(Finger item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, Finger item) { }
			
			// TODO
			public bool Remove(Finger item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}
	}
}