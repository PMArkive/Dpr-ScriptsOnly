using UnityEngine;

namespace Dpr.Contest
{
	[CreateAssetMenu(fileName = "DanceSettings", menuName = "ScriptableObjects/Contest/DanceSettings")]
	public class DanceSettings : ScriptableObject
	{
		[Header("【ハートエフェクトの出力間隔間】")]
		public float waitEmitHeartSpan = 0.15f;
		[Header("【端まで到達したノートのフェード時間】")]
		public float notesFadeDuration = 0.2f;
		[Header("【テンションアイコンのアニメーション時間】")]
		public float tensionIconTweenDuration = 0.3f;
		[Header("【テンションアイコンの移動距離】")]
		public float tensionIconJumpPower = 20.0f;
		[Header("【技発動FXと効果中FXの間隔(s)】")]
		public float waitWazaStartTime = 0.38f;
		[Header("【スコアゲージの増加速度(1sに増える割合値】")]
		public float addScoreGaugeValue = 0.03f;
		[Header("【スコアゲージに再生するエフェクトの制御時間")]
		public float lockGaugeFxTime = 1.0f;
		[Header("【進行アイコンのジャンプアニメーション時間】")]
		public float gaugeIconJumpDuration = 1.2f;
		[Header("【進行アイコンのジャンプ移動距離】")]
		public float gaugeIconJumpPower = 27.0f;
		[Header("【進行アイコンのジャンプ回数】")]
		public int gaugeIconJumpCount = 3;
		[Header("【進行アイコンの揺れる最大角度(z)】")]
		public float limitIconRotZ = 15.0f;
	}
}