using UnityEngine;
using UnityEngine.Playables;

public class TimeLineEffectAsset : PlayableAsset
{
	[SerializeField]
	public int mIntSample;
	
	public override Playable CreatePlayable(PlayableGraph graph, GameObject game_object)
	{
		return ScriptPlayable<TimelineEffectBehaviour>.Create(graph, new TimelineEffectBehaviour(), 0);
	}
}