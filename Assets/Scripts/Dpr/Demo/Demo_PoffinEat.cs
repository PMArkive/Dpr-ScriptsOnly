using DPData;
using Effect;
using Pml.PokePara;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.Demo
{
	public class Demo_PoffinEat : DemoBase
	{
		private List<GameObject> Points = new List<GameObject>();
		private PokemonParam pokePara;
		private PoffinData poffin;
		private GameObject Poffin3D;
		private FieldPokemonEntity pokeEntity;
		private EffectData bgEff;
		private bool isEndThrow;

		public ConditionParam ConditionParam { get; set; }
		
		public Demo_PoffinEat()
        {
            is2DBG = true;
            bgType = BGType.PoffinEat;

			pokePara = PlayerWork.playerParty.GetMemberPointer(0);
			poffin = new PoffinData(0, 1, 1, new byte[] { 1, 1, 1, 1, 1 });
        }
		
		public Demo_PoffinEat(PokemonParam pokePara, PoffinData poffin)
		{
			bgType = BGType.PoffinEat;
			is2DBG = true;

			this.pokePara = pokePara;
			this.poffin = poffin;

			DisableEnvironmentController = true;
		}
		
		// TODO
		public override void Destroy() { }
		
		// TODO
		public override void Init() { }
		
		// TODO
		private IEnumerator test() { return default; }
		
		// TODO
		public override IEnumerator Enter() { return default; }
		
		// TODO
		private void CreateCurvePoint(GameObject poke) { }
		
		// TODO
		public override IEnumerator Main() { return default; }
		
		// TODO
		private void MotionUpdate(float deltaTime) { }
		
		// TODO
		public override IEnumerator Exit() { return default; }
		
		// TODO
		public Vector3 PofinThrow() { return default; }
		
		// TODO
		private Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t) { return default; }
		
		// TODO
		public override void LightUpdate() { }
		
		// TODO
		private void Calc_EatPoffin() { }
	}
}