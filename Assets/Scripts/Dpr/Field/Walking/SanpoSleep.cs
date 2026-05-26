using Dpr.SubContents;
using SmartPoint.AssetAssistant;
using System.Collections;
using UnityEngine;

namespace Dpr.Field.Walking
{
	public class SanpoSleep : ActionModel
	{
		public SanpoSleep()
        {
            // Empty, declared explicitly
        }

        public override IEnumerator DoAction(AIModel m)
        {
            var model = m as AIFureaiModel;

            model.walkData.nowSpeed = 0.0f;
            model.corSys.OnCancel(() => model.charaModel.SleepLevel = 0);

            float targetTime = Random.Range(2, 5);
            float WaitTime = Random.Range(6, 20);
            var monsNo = model.fureaiModel.monsNo;
            var isPikaV = Utils.IsPikaV(monsNo);
            var voicePlayer = model.charaModel.controller.voicePlayer;

            yield return new MyWaitForSeconds(targetTime);

            model.charaModel.SleepLevel = 1;

            if (isPikaV)
                Utils.PlayVoicePikaBui_Drowse(monsNo, 0, voicePlayer);

            yield return new MyWaitForSeconds(1.0f);

            model.charaModel.SleepLevel = 2;

            var elapsedTime = 0.0f;

            while (WaitTime > 0.0f)
            {
                elapsedTime += Sequencer.elapsedTime;
                WaitTime -= Sequencer.elapsedTime;

                if (WaitTime > 4.0f && elapsedTime > 4.0f)
                {
                    elapsedTime = 0.0f;

                    if (isPikaV)
                        Utils.PlayVoicePikaBui_Drowse(monsNo, 1, voicePlayer);
                }

                yield return null;
            }

            model.charaModel.SleepLevel = 3;

            if (isPikaV)
                Utils.PlayVoicePikaBui_Drowse(monsNo, 2, voicePlayer);

            yield return new MyWaitForSeconds(2.0f);

            model.charaModel.SleepLevel = 0;

            yield return null;
        }
	}
}