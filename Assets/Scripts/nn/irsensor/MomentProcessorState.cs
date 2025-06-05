using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.irsensor
{
	public struct MomentProcessorState
	{
		public long samplingNumber;
		public long deltaTimeNanoSeconds;
		public IrCameraAmbientNoiseLevel ambientNoiseLevel;
		private byte _reserved0;
		private byte _reserved1;
		private byte _reserved2;
		private byte _reserved3;
		public MomentStatisticArray48 blocks;

		public struct MomentStatisticArray48 : IList<MomentStatistic>, ICollection<MomentStatistic>, IEnumerable<MomentStatistic>, IEnumerable
		{
			private const int _Length = 48;

			private MomentStatistic _value0;
			private MomentStatistic _value1;
			private MomentStatistic _value2;
			private MomentStatistic _value3;
			private MomentStatistic _value4;
			private MomentStatistic _value5;
			private MomentStatistic _value6;
			private MomentStatistic _value7;
			private MomentStatistic _value8;
			private MomentStatistic _value9;
			private MomentStatistic _value10;
			private MomentStatistic _value11;
			private MomentStatistic _value12;
			private MomentStatistic _value13;
			private MomentStatistic _value14;
			private MomentStatistic _value15;
			private MomentStatistic _value16;
			private MomentStatistic _value17;
			private MomentStatistic _value18;
			private MomentStatistic _value19;
			private MomentStatistic _value20;
			private MomentStatistic _value21;
			private MomentStatistic _value22;
			private MomentStatistic _value23;
			private MomentStatistic _value24;
			private MomentStatistic _value25;
			private MomentStatistic _value26;
			private MomentStatistic _value27;
			private MomentStatistic _value28;
			private MomentStatistic _value29;
			private MomentStatistic _value30;
			private MomentStatistic _value31;
			private MomentStatistic _value32;
			private MomentStatistic _value33;
			private MomentStatistic _value34;
			private MomentStatistic _value35;
			private MomentStatistic _value36;
			private MomentStatistic _value37;
			private MomentStatistic _value38;
			private MomentStatistic _value39;
			private MomentStatistic _value40;
			private MomentStatistic _value41;
			private MomentStatistic _value42;
			private MomentStatistic _value43;
			private MomentStatistic _value44;
			private MomentStatistic _value45;
			private MomentStatistic _value46;
			private MomentStatistic _value47;

            public int Length => _Length;
            public MomentStatistic this[int index]
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
                        case 16: return _value16;
                        case 17: return _value17;
                        case 18: return _value18;
                        case 19: return _value19;
                        case 20: return _value20;
                        case 21: return _value21;
                        case 22: return _value22;
                        case 23: return _value23;
                        case 24: return _value24;
                        case 25: return _value25;
                        case 26: return _value26;
                        case 27: return _value27;
                        case 28: return _value28;
                        case 29: return _value29;
                        case 30: return _value30;
                        case 31: return _value31;
                        case 32: return _value32;
                        case 33: return _value33;
                        case 34: return _value34;
                        case 35: return _value35;
                        case 36: return _value36;
                        case 37: return _value37;
                        case 38: return _value38;
                        case 39: return _value39;
                        case 40: return _value40;
                        case 41: return _value41;
                        case 42: return _value42;
                        case 43: return _value43;
                        case 44: return _value44;
                        case 45: return _value45;
                        case 46: return _value46;
                        case 47: return _value47;
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
                        case 16: _value16 = value; break;
                        case 17: _value17 = value; break;
                        case 18: _value18 = value; break;
                        case 19: _value19 = value; break;
                        case 20: _value20 = value; break;
                        case 21: _value21 = value; break;
                        case 22: _value22 = value; break;
                        case 23: _value23 = value; break;
                        case 24: _value24 = value; break;
                        case 25: _value25 = value; break;
                        case 26: _value26 = value; break;
                        case 27: _value27 = value; break;
                        case 28: _value28 = value; break;
                        case 29: _value29 = value; break;
                        case 30: _value30 = value; break;
                        case 31: _value31 = value; break;
                        case 32: _value32 = value; break;
                        case 33: _value33 = value; break;
                        case 34: _value34 = value; break;
                        case 35: _value35 = value; break;
                        case 36: _value36 = value; break;
                        case 37: _value37 = value; break;
                        case 38: _value38 = value; break;
                        case 39: _value39 = value; break;
                        case 40: _value40 = value; break;
                        case 41: _value41 = value; break;
                        case 42: _value42 = value; break;
                        case 43: _value43 = value; break;
                        case 44: _value44 = value; break;
                        case 45: _value45 = value; break;
                        case 46: _value46 = value; break;
                        case 47: _value47 = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }
            public int Count => _Length;
            public bool IsReadOnly => true;

            // TODO
            public bool Contains(MomentStatistic item) { return default; }
			
			// TODO
			public int IndexOf(MomentStatistic item) { return default; }
			
			// TODO
			public void CopyTo(MomentStatistic[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }

            public IEnumerator<MomentStatistic> GetEnumerator()
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
                yield return this[16];
                yield return this[17];
                yield return this[18];
                yield return this[19];
                yield return this[20];
                yield return this[21];
                yield return this[22];
                yield return this[23];
                yield return this[24];
                yield return this[25];
                yield return this[26];
                yield return this[27];
                yield return this[28];
                yield return this[29];
                yield return this[30];
                yield return this[31];
                yield return this[32];
                yield return this[33];
                yield return this[34];
                yield return this[35];
                yield return this[36];
                yield return this[37];
                yield return this[38];
                yield return this[39];
                yield return this[40];
                yield return this[41];
                yield return this[42];
                yield return this[43];
                yield return this[44];
                yield return this[45];
                yield return this[46];
                yield return this[47];
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            // TODO
            public void Add(MomentStatistic item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, MomentStatistic item) { }
			
			// TODO
			public bool Remove(MomentStatistic item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}
	}
}