using Dpr.Battle.View.Objects;
using Dpr.SequenceEditor;

namespace Dpr.Battle.View
{
	public class PokeFollowInfo
	{
		public BOPokemon Pokemon { get; set; }
		public SEQ_DEF_NODE Node { get; set; }
		public bool IsFollowPos { get; set; }
		public bool IsFollowRot { get; set; }
		public bool IsFollowScl { get; set; }
		public bool IsFollowAnimRot { get; set; }
		
		public PokeFollowInfo(BOPokemon pokemon, SEQ_DEF_NODE node, bool isFollowPos, bool isFollowRot, bool isFollowScl, bool isFollowAnimRot)
		{
			Pokemon = pokemon;
			IsFollowPos = isFollowPos;
			IsFollowRot = isFollowRot;
			IsFollowScl = isFollowScl;
            Node = node;
            IsFollowAnimRot = isFollowAnimRot;
		}
	}
}