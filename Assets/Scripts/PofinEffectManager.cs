using Effect;
using System.Collections;
using UnityEngine;

public class PofinEffectManager
{
	private EffectData kogeEff;
	private EffectData koboshiEff;
	private EffectData smokeEff;
	private EffectData kinomiInEff;
	private Transform kogeEffTra;
	private Transform smokeEffTra;
	private Transform koboreEffTra;
	private EffectInstance kogeInstance;
	private int kogeCount;

	private const int kogeMaxCount = 7;
	
	public PofinEffectManager(Transform koge, Transform kobore, Transform smoke)
	{
		kogeEffTra = koge;
		koboreEffTra = kobore;
		smokeEffTra = smoke;

		kogeEffTra.localPosition = new Vector3(0.0f, 0.06f, 0.0f);
        smokeEffTra.localPosition = new Vector3(0.0f, 0.06f, 0.0f);
        koboreEffTra.localPosition = new Vector3(0.0f, 1.0f, 0.0f);
	}
	
	// TODO
	public void KogeEffect() { }
	
	// TODO
	public void SmokeEffect() { }
	
	// TODO
	public void KoboreEffect(Transform pofinKiji) { }
	
	// TODO
	public void KinomiInEffect(Transform pofinKiji) { }
	
	// TODO
	public IEnumerator LoadEffect() { return default; }
	
	// TODO
	public void UpdateEffScale() { }
	
	// TODO
	public void Release() { }
}