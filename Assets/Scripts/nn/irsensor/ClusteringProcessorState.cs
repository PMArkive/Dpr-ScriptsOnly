using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.irsensor
{
	public struct ClusteringProcessorState
	{
		public long samplingNumber;
		public long timeStampNanoSeconds;
		public sbyte objectCount;
		public byte _reserved0;
		public byte _reserved1;
		public byte _reserved2;
		public IrCameraAmbientNoiseLevel ambientNoiseLevel;
		public ClusteringDataArray16 objects;
		
		// TODO
		public void SetDefault() { }
		
		// TODO
		public override string ToString() { return default; }

		public struct ClusteringDataArray16 : IList<ClusteringData>, ICollection<ClusteringData>, IEnumerable<ClusteringData>, IEnumerable
		{
			private const int _Length = 16;

			private ClusteringData _value0;
			private ClusteringData _value1;
			private ClusteringData _value2;
			private ClusteringData _value3;
			private ClusteringData _value4;
			private ClusteringData _value5;
			private ClusteringData _value6;
			private ClusteringData _value7;
			private ClusteringData _value8;
			private ClusteringData _value9;
			private ClusteringData _value10;
			private ClusteringData _value11;
			private ClusteringData _value12;
			private ClusteringData _value13;
			private ClusteringData _value14;
			private ClusteringData _value15;

            public int Length => _Length;
            public ClusteringData this[int index]
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
            public bool Contains(ClusteringData item) { return default; }
			
			// TODO
			public int IndexOf(ClusteringData item) { return default; }
			
			// TODO
			public void CopyTo(ClusteringData[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }

            public IEnumerator<ClusteringData> GetEnumerator()
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
            public void Add(ClusteringData item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, ClusteringData item) { }
			
			// TODO
			public bool Remove(ClusteringData item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}
	}
}