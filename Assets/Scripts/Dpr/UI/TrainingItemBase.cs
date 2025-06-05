using UnityEngine;

namespace Dpr.UI
{
	public class TrainingItemBase : MonoBehaviour
	{
		protected static readonly int animState0Normal = Animator.StringToHash("Normal");
		protected static readonly int animState0Select = Animator.StringToHash("Select");
        protected static readonly int animState1Enable = Animator.StringToHash("Enable");
        protected static readonly int animState1Disable = Animator.StringToHash("Disable");

        public int index = -1;
		protected Animator _animator;
		protected bool _isEnabled;
		protected bool _isSelected;
		
		public bool isEnabled { get => _isEnabled; }
		
		// TODO
		protected virtual void Awake() { }
		
		// TODO
		public virtual void Setup() { }
		
		// TODO
		public virtual void Select(bool enabled) { }
		
		// TODO
		public virtual void Enable(bool enabled) { }
	}
}