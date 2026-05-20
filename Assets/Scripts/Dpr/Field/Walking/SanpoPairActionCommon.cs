using Dpr.SubContents;
using System.Collections;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class SanpoPairActionCommon : ActionModel
	{
		private int masterAnim;
		private int slaveAnim;
		private bool isCanSameTime;
		
		public SanpoPairActionCommon(int masterAnim, int slaveAnim, bool isCanSameTime = false)
		{
			this.masterAnim = masterAnim;
			this.slaveAnim = slaveAnim;
			this.isCanSameTime = isCanSameTime;
		}
		
		private IEnumerator WaitFrame(int count)
		{
			for (int i=0; i<count; i++)
				yield return null;
		}
		
		public override IEnumerator DoAction(AIModel m)
		{
			var model = m as AIFureaiModel;

			var master = model.sanpoModel.PairModel.masterPoke;
			var slave = model.sanpoModel.PairModel.slavePoke;
			var masterCorSys = master.AI.GetNowState().corSys;
			var slaveCorSys = slave.AI.GetNowState().corSys;

            deleCor dele1 = () =>
			{
				if (Utils.IsPikaV(master.controller.model.monsNo) && masterAnim == FieldPokemonEntity.Animation.Roar01)
					Utils.PlayVoicePikaBui_Roar(master.controller.model.monsNo, master.controller.voicePlayer);

				var sub = master.controller.view.AnimPlayForce(masterAnim, masterCorSys, master, 0.2f, 0.0f);
				return sub.Play(master.WaitforAnimationFinish(() => sub.isPlaying));
			};
            deleCor dele2 = () =>
			{
                if (Utils.IsPikaV(slave.controller.model.monsNo) && slaveAnim == FieldPokemonEntity.Animation.Roar01)
                    Utils.PlayVoicePikaBui_Roar(slave.controller.model.monsNo, slave.controller.voicePlayer);

                var sub = slave.controller.view.AnimPlayForce(slaveAnim, slaveCorSys, slave, 0.2f, 0.0f);
                return sub.Play(slave.WaitforAnimationFinish(() => sub.isPlaying));
            };

			var rndIndex = Random.Range(0, 2);
			if (rndIndex == 0)
			{
				var routine1 = dele1.Invoke();
				if (isCanSameTime)
					yield return WaitFrame(Random.Range(0, 45));
				else
					yield return routine1;

				yield return dele2.Invoke();
			}
			else if (rndIndex == 1)
			{
                var routine2 = dele2.Invoke();
                if (isCanSameTime)
                    yield return WaitFrame(Random.Range(0, 45));
                else
                    yield return routine2;

                yield return dele1.Invoke();
            }

			yield return WaitFrame(90);
		}

		private delegate Coroutine deleCor();
	}
}