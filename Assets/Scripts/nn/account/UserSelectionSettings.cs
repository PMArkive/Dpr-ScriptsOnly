using System;
using System.Collections;
using System.Collections.Generic;

namespace nn.account
{
	public struct UserSelectionSettings : IEquatable<UserSelectionSettings>
	{
		public UidArray8 invalidUidList;
		public bool isSkipEnabled;
		public bool isNetworkServiceAccountRequired;
		public bool showSkipButton;
		public bool additionalSelect;
		public bool isUnqualifiedUserSelectable;
		
		// TODO
		public void SetDefault() { }
		
		// TODO
		public override string ToString() { return default; }
		
		// TODO
		public override bool Equals(object obj) { return default; }
		
		// TODO
		public bool Equals(UserSelectionSettings other) { return default; }
		
		// TODO
		public override int GetHashCode() { return default; }
		
		// TODO
		public static bool operator ==(UserSelectionSettings lhs, UserSelectionSettings rhs) { return default; }

		// TODO
		public static bool operator !=(UserSelectionSettings lhs, UserSelectionSettings rhs) { return default; }

		public struct UidArray8 : IList<Uid>, ICollection<Uid>, IEnumerable<Uid>, IEnumerable
		{
			private const int _Length = 8;

			private Uid _value0;
			private Uid _value1;
			private Uid _value2;
			private Uid _value3;
			private Uid _value4;
			private Uid _value5;
			private Uid _value6;
			private Uid _value7;
			
			public int Length => _Length;
			public Uid this[int index]
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
			public bool Contains(Uid item) { return default; }
			
			// TODO
			public int IndexOf(Uid item) { return default; }
			
			// TODO
			public void CopyTo(Uid[] array, int arrayIndex) { }
			
			// TODO
			public override string ToString() { return default; }
			
			public IEnumerator<Uid> GetEnumerator()
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
			public void Add(Uid item) { }
			
			// TODO
			public void Clear() { }
			
			// TODO
			public void Insert(int index, Uid item) { }
			
			// TODO
			public bool Remove(Uid item) { return default; }
			
			// TODO
			public void RemoveAt(int index) { }
		}
	}
}