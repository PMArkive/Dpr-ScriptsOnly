using Dpr.Battle.Logic;
using Dpr.SequenceEditor;
using Dpr.Trainer;
using System;
using UnityEngine;

namespace Dpr.Battle.View.Objects
{
	[RequireComponent(typeof(BattleCharacterEntity))]
	public sealed class BOTrainer : BattleViewCharacter
	{
		private const string SEQUENCE_BALL_NODE_NAME = "loc_ob_ball";

		public static readonly Tuple<string, int>[] CONVERT_ANIMATON_NAME_TO_SEQUENCE_ID = new Tuple<string, int>[]
		{
			new Tuple<string, int>("ba_advent01", BattleCharacterEntity.SequenceID.Advent),
			new Tuple<string, int>("ba_order01",  BattleCharacterEntity.SequenceID.Order),
		};
		public static readonly Tuple<string, JointName>[] CONVERT_ATTACH_JOINT_TO_JOINT_NAME = new Tuple<string, JointName>[]
		{
			new Tuple<string, JointName>(SEQUENCE_BALL_NODE_NAME, JointName.LItem1),
		};

		private TRAINER_DATA _trainerData;
		private BattleCharacterEntity _battlePlayerEntity;
		
		public bool IsPlayer { get => Entity != null; }
		public BattleCharacterEntity Entity { get => this.GetComponentThis(ref _battlePlayerEntity); }
		
		// TODO
		public void Initialize(BtlvPos vPos, TRAINER_DATA data) { }
		
		// TODO
		public byte GetClientId() { return default; }
		
		// TODO
		public HandDominance GetDominansHand() { return default; }
		
		// TODO
		public HandDominance GetBallHoldHand() { return default; }
		
		// TODO
		public Transform GetNodeJoint(JointName jointName) { return default; }
		
		// TODO
		public Transform GetNodeJoint(SEQ_DEF_NODE_MODEL joint) { return default; }
		
		// TODO
		private bool IsHandNode(JointName nodeName) { return default; }
		
		// TODO
		[Obsolete("Use AttachObject(GameObject obj, JointName nodeName, bool isFollowPos, bool isFollowRot, bool isFollowScl, bool isFollowAnimScl, bool isFollowLocalScl)")]
		public override void AttachObject(GameObject obj, string nodeName, bool isFollowPos, bool isFollowRot, bool isFollowScl, bool isFollowAnimScl, bool isFollowLocalScl) { }
		
		// TODO
		public void AttachObject(ObjectEntity obj, JointName nodeName, bool ignoreDominantHand, bool enableDominantHoldBallHand, bool isFollowPos, bool isFollowRot, bool isFollowScl, bool isFollowAnimScl, bool isFollowLocalScl) { }
		
		// TODO
		public void DetachObject(ObjectEntity obj) { }
		
		// TODO
		[Obsolete("ChangeAnimState(SEQ_DEF_TRAINER_MOTION motion, float duration, float startTime)を使用してください。")]
		public override void ChangeAnimState(string parameterName, bool isReset = false) { }
		
		// TODO
		public void ChangeAnimState(SEQ_DEF_TRAINER_MOTION motion, float duration = 0.15f, float startTime = 0.0f, bool isLoop = false) { }
		
		// TODO
		public void ChangeAnimStateThrowBall(float duration, SEQ_DEF_TRAINER_MOTION_THROW_BALL ballThrowType) { }
		
		// TODO
		protected override void UpdateAnimSpeed() { }
		
		// TODO
		protected override void UpdateVisible() { }
		
		// TODO
		public override void SetRenderActive(bool isActive) { }
		
		// TODO
		public override void SetVisibleShadow(bool value) { }
	}
}