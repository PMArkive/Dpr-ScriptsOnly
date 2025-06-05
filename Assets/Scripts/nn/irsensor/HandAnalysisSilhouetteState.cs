using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.irsensor
{
	public struct HandAnalysisSilhouetteState
	{
		public long samplingNumber;
		public IrCameraAmbientNoiseLevel ambientNoiseLevel;
		public int shapeCount;
		public ShapeArray16 shapes;
		public int handCount;
		public HandArray2 hands;

		public struct ShapeArray16 : IList<Shape>, ICollection<Shape>, IEnumerable<Shape>, IEnumerable
		{
			private const int _Length = 16;

			private Shape _value0;
			private Shape _value1;
			private Shape _value2;
			private Shape _value3;
			private Shape _value4;
			private Shape _value5;
			private Shape _value6;
			private Shape _value7;
			private Shape _value8;
			private Shape _value9;
			private Shape _value10;
			private Shape _value11;
			private Shape _value12;
			private Shape _value13;
			private Shape _value14;
			private Shape _value15;

            public int Length => _Length;
            public Shape this[int index]
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
            public bool Contains(Shape item) { return default; }
			
			// TODO
			public int IndexOf(Shape item) { return default; }
			
			// TODO
			public void CopyTo(Shape[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }

            public IEnumerator<Shape> GetEnumerator()
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
            public void Add(Shape item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, Shape item) { }
			
			// TODO
			public bool Remove(Shape item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}

		public struct HandArray2 : IList<Hand>, ICollection<Hand>, IEnumerable<Hand>, IEnumerable
		{
			private const int _Length = 2;

			private Hand _value0;
			private Hand _value1;

            public int Length => _Length;
            public Hand this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0: return _value0;
                        case 1: return _value1;
                        default: throw new IndexOutOfRangeException();
                    }
                }
                set
                {
                    switch (index)
                    {
                        case 0: _value0 = value; break;
                        case 1: _value1 = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }
            public int Count => _Length;
            public bool IsReadOnly => true;

            // TODO
            public bool Contains(Hand item) { return default; }
			
			// TODO
			public int IndexOf(Hand item) { return default; }
			
			// TODO
			public void CopyTo(Hand[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }

            public IEnumerator<Hand> GetEnumerator()
            {
                yield return this[0];
                yield return this[1];
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            // TODO
            public void Add(Hand item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, Hand item) { }
			
			// TODO
			public bool Remove(Hand item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}
	}
}