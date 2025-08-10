using System;

namespace Dpr.SequenceEditor
{
	[AttributeUsage(AttributeTargets.Field)]
	public class ShortNameAttribute : Attribute
	{
		public string ShortName { get; private set; }
		
		public ShortNameAttribute(string shortName)
		{
			ShortName = shortName;
		}
	}
}