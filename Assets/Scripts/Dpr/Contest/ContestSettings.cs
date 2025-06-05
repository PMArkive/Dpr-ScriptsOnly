using UnityEngine;

namespace Dpr.Contest
{
	[CreateAssetMenu(fileName = "ContestSettings", menuName = "ScriptableObjects/Contest/ContestSettings")]
	public class ContestSettings : ScriptableObject
	{
		[Header("【参加者の各座標】")]
		public ModelPosition[] modelPosArray;
        [Header("【ステージに配置されるライトの設定】")]
        public LightSetting[] stageLightParam;
        [Header("【ビジュアル審査時のハート設定】")]
        public VisualHeartParam visualHeartParam;
        [Header("【ハートマークの移動経路】")]
        public HeartBeziePath[] heartBezierPath;
        [Header("【NPCから出るハートマークの設定】")]
        public NPCHeartParam npcHeartParam;
        [Header("【リザルトのライト座標の補正値】")]
        public Vector3 resultLightOffsetPos;
        [Header("【リザルトの紙吹雪座標の補正値】")]
        public Vector3 confettiOffsetPos;
	}
}