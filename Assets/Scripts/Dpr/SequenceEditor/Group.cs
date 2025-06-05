using System;
using System.Collections.Generic;

namespace Dpr.SequenceEditor
{
	[Serializable]
	public sealed class Group
	{
		public static Group Default = new Group();

		public string Name;
		public int GrpNo;
		public int IsOpen;
		public int GrpDebug;
		public byte BgColR;
		public byte BgColG;
		public byte BgColB;

		[Obsolete("使われていない可能性(動作しないなどがあったら対応する)")]
		public byte ColR;
        [Obsolete("使われていない可能性(動作しないなどがあったら対応する)")]
        public byte ColG;
        [Obsolete("使われていない可能性(動作しないなどがあったら対応する)")]
        public byte ColB;
        [Obsolete("使われていない可能性(動作しないなどがあったら対応する)")]
        public string GrpOption;

		public List<GroupOption> GroupOption;
		public List<Command> Commands;
	}
}