using nn.util;
using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.hid
{
	public struct ControllerSupportArg
	{
		private const int ExplainTextSize = 1032;

		public byte playerCountMin;
		public byte playerCountMax;
		public bool enableTakeOverConnection;
		public bool enableLeftJustify;
		public bool enablePermitJoyDual;
		public bool enableSingleMode;
		public bool enableIdentificationColor;
		public Color4u8Array8 identificationColor;
		public bool enableExplainText;
		private byte[] explainText;
		
		// TODO
		public void SetDefault() { }
		
		// TODO
		public override string ToString() { return default; }

		public struct Color4u8Array8 : IList<Color4u8>, ICollection<Color4u8>, IEnumerable<Color4u8>, IEnumerable
		{
			private const int _Length = 8;

			private Color4u8 _value0;
			private Color4u8 _value1;
			private Color4u8 _value2;
			private Color4u8 _value3;
			private Color4u8 _value4;
			private Color4u8 _value5;
			private Color4u8 _value6;
			private Color4u8 _value7;
			
			public int Length => _Length;
			public Color4u8 this[int index]
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
			public bool Contains(Color4u8 item) { return default; }
			
			// TODO
			public int IndexOf(Color4u8 item) { return default; }
			
			// TODO
			public void CopyTo(Color4u8[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }
			
			public IEnumerator<Color4u8> GetEnumerator()
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
			public void Add(Color4u8 item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, Color4u8 item) { }
			
			// TODO
			public bool Remove(Color4u8 item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}
	}
}