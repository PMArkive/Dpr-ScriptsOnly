using DG.Tweening;
using Pml;
using Pml.PokePara;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.Demo
{
	public class Demo_PokeViewer : DemoBase
	{
		private PokeRenderViewer PokemonViewer;
		private Transform RenderCamera;
		private MonsNo monsNo;
		private ushort formNo;
		private Sex sex;
		public bool isNoMotion;
		public bool isUseUIRenderSettings;
		private Image bg;
		private IEnumerator ienum;
		private Vector2 CircleSize;
		private Vector2 CirclePos;
		
		public Demo_PokeViewer(MonsNo monsNo, ushort formNo, Sex sex)
		{
			FadeSetting(false, false, false, false);

			this.monsNo = monsNo;
			this.formNo = formNo;
			this.sex = sex;

			if (sex == Sex.NUM)
				sex = new PokemonParam(monsNo, 1, 1).GetSex();

			UseCamera = false;
			DisableEnvironmentController = false;
			isUseAlpha = true;
		}
		
		// TODO
		public override void Destroy() { }
		
		// TODO
		public override void Init() { }
		
		// TODO
		public override IEnumerator Enter() { return default; }
		
		// TODO
		private void CameraReset() { }
		
		// TODO
		private Tween ExitView() { return default; }
		
		// TODO
		public override void _DebugMethod(int TestNo) { }
		
		// TODO
		public IEnumerator DebugChange() { return default; }
		
		// TODO
		public override void LightUpdate() { }
	}
}