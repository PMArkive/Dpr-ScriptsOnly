using System;

namespace Dpr.SequenceEditor
{
	[AttributeUsage(AttributeTargets.Field)]
	public class GroupOptionAttribute : Attribute
	{
		public Type GrpOptEnum { get; private set; }
		
		public GroupOptionAttribute(Type enumType)
		{
			GrpOptEnum = enumType;
		}
	}
}