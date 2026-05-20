using AK;

namespace Dpr.Field.Walking
{
	public class UG_FoundState : UGBaseState
	{
		protected Balloon balloon;
		
		public UG_FoundState(AIModel model) : base(model)
		{
			// Empty
		}
		
		public override void Enter()
		{
			balloon = model.charaModel.controller.emoticon.Show(0, false);
			model.charaModel.controller.emoticon.PlaySeDirect(EVENTS.UI_EMOTIONAL_EXCLAMATION3);
		}
		
		protected override void StateUpdate()
		{
			if (isDontEnterArea(player.position, 3.0f))
			{
				model.AI.ChangeState(typeof(UG_NormalState));
				(model.AI.GetState<UG_NormalState>() as UG_NormalState).searchWait = 2.0f;
				model.charaModel.controller.emoticon.Delete();
			}
		}
	}
}