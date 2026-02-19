using UnityEngine;

namespace Dpr.UnderGround.UgFather
{
	public class UgFatherBase : MonoBehaviour
	{
		public FieldCharacterEntity FieldCharacterEntity { get; private set; }

        protected OnEventEnd onEventEndCallback;

        public void Initialize(FieldCharacterEntity entity, OnEventEnd eventEndCallback)
		{
			FieldCharacterEntity = entity;
			onEventEndCallback = eventEndCallback;
		}
		
		public virtual void OnTalkEvent()
		{
			LookAtPlayer();
        }
		
		public virtual void OnUpdate(float deltaTime)
		{
			// Empty
		}
		
		private void LookAtPlayer()
		{
            DIR resultDir;
            switch (EntityManager.activeFieldPlayer.GetDir())
            {
                case DIR.DIR_DOWN:      resultDir = DIR.DIR_UP;        break;
                case DIR.DIR_LEFT:      resultDir = DIR.DIR_RIGHT;     break;
                case DIR.DIR_RIGHT:     resultDir = DIR.DIR_LEFT;      break;
                case DIR.DIR_LEFTUP:    resultDir = DIR.DIR_RIGHTDOWN; break;
                case DIR.DIR_RIGHTUP:   resultDir = DIR.DIR_LEFTDOWN;  break;
                case DIR.DIR_LEFTDOWN:  resultDir = DIR.DIR_RIGHTUP;   break;
                case DIR.DIR_RIGHTDOWN: resultDir = DIR.DIR_LEFTUP;    break;
                default:                resultDir = DIR.DIR_DOWN;      break;
            }

            FieldCharacterEntity.SetDir(resultDir);
        }

		public delegate void OnEventEnd();
	}
}