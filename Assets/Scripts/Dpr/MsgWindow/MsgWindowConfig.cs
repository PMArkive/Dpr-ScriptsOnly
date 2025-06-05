using UnityEngine;

namespace Dpr.MsgWindow
{
    [CreateAssetMenu(fileName = "MsgWindowConfig", menuName = "ScriptableObjects/Msg/MsgWindowConfig")]
    public class MsgWindowConfig : ScriptableObject
    {
        [Header("【再生速度(1文字表示にかかる時間) : 0 : おそい 1 : ふつう 2 : はやい】")]
        public float[] msgSpeed;
        [Header("ウィンドウの幅補正値")]
        public float windowWidthOffset;
        [Header("話者名の幅補正値")]
        public float speakerFrameWidthOffset;
        [Header("矢印表示の際のメッセージ位置補正値")]
        public float offsetMessagePosX;
        [Header("矢印アイコンの移動距離")]
        public float iconMoveDist;
        [Header("矢印の移動速度(sinを利用)")]
        public float addAngleSec;
        [Header("早送り時の速度")]
        public float fastForwardMagnification;
        [Header("行送りにかかる時間")]
        public float scrollTextDuration;
        [Header("メッセージ再生終了後の待機フレーム")]
        public int waitAfterFinishMsgFrame = 4;
        [Header("メッセージの行幅補正値")]
        public float textLinePaddingOffset;
        [Header("開閉時のTweenAnimation")]
        public WindowAnimator.AnimType wndAnimType;
    }
}