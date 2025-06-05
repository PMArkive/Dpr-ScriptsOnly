using Dpr.SubContents;
using Pml;
using Pml.PokePara;
using System.Collections;

namespace Dpr.Demo
{
	public class Demo_Hatch : DemoBase
	{
		private TimeLineBinder timeLine;
		private PokemonParam param;
		private float waitTime = 10.5f;
		private float pokeRoarAnimTime;
		private bool isCloseHatchMsg;
		private bool isManafy;
		private MarkerReceiver receiver;
		
		public Demo_Hatch(PokemonParam param)
		{
			this.param = param;

			StartEnterFadeDuration = 0.2f;
			StartExitFadeDuration = 0.2f;
			EndEnterFadeDuration = 0.5f;
			EndExitFadeDuration = 0.5f;

			UseCamera = true;
			DisableEnvironmentController = false;
			isDisablePostProcess = true;
			isDisableMainCamera = true;

			if (param.GetMonsNo() == MonsNo.MANAFI)
				isManafy = true;
		}
		
		// TODO
		public override void Destroy() { }
		
		// TODO
		public override IEnumerator Enter() { return default; }
		
		// TODO
		public override IEnumerator Main() { return default; }
		
		// TODO
		public override IEnumerator Exit() { return default; }
		
		// TODO
		private void SetMessage() { }
		
		// TODO
		private void SetIsHauchMsg() { }
	}
}