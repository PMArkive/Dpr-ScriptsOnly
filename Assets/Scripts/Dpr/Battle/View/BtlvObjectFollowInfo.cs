using UnityEngine;

namespace Dpr.Battle.View
{
	public sealed class BtlvObjectFollowInfo
	{		
		public ITranslationObject HdlFollowModel { get; set; }
		public Transform FollowJoint { get; set; }
		public bool FollowPos { get; set; }
		public bool FollowRot { get; set; }
		public bool FollowScl { get; set; }
		public bool FollowAnimScl { get; set; }
		public bool FollowLocalScl { get; set; }
		
		public BtlvObjectFollowInfo()
		{
			HdlFollowModel = null;
			FollowJoint = null;
			FollowLocalScl = false;
			FollowPos = false;
			FollowRot = false;
			FollowScl = false;
			FollowAnimScl = false;
		}
		
		public BtlvObjectFollowInfo(ITranslationObject model, Transform joint, bool isFollowPos, bool isFollowRot, bool isFollowScl, bool followAnimScl, bool followLocalScl)
		{
			HdlFollowModel = model;
			FollowJoint = joint;
			FollowPos = isFollowPos;
			FollowRot = isFollowRot;
			FollowScl = isFollowScl;
			FollowAnimScl = followAnimScl;
			FollowLocalScl = followLocalScl;
		}
	}
}