using System;
using UnityEngine;

namespace Dpr.Contest
{
	[Serializable]
	public class WaitTimeData
	{
		[Header("【メッセージ表示後の待機時間】")]
		public float waitMsgTime;
        [Header("【リザルト開始までの待機時間】")]
        public float waitStartResult;
        [Header("【ランクゲージ増加後の待機時間】")]
        public float waitAddRankGaugeAfter;
        [Header("【スコアゲージ上昇後から勝者発表までの待機時間】")]
        public float waitTransitionAnnounceWinner;
        [Header("【花吹雪後からポケモンに近づくまでの待機時間】")]
        public float waitTransitionPersonalScore;
        [Header("【ベストパフォーマー発表時のメッセージ待機時間】")]
        public float waitAnnounceBestPerformer;
	}
}