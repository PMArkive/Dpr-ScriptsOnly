using UnityEngine;

namespace Dpr.Contest
{
	[CreateAssetMenu(fileName = "ResultSettings", menuName = "ScriptableObjects/Contest/ResultSettings")]
	public class ResultSettings : ScriptableObject
	{
		[Header("【ランクゲージの増加時間】")]
		public float addRankGaugeDuration;
		[Header("【全体成績のスコアゲージ増加時間】")]
		public float addScoreGaugeDuration;
		[Header("【花吹雪FXの表示座標】")]
		public Vector3 confettiPos;
		[Header("【各待機時間などのデータ】")]
		public WaitTimeData waitTimeData;
	}
}