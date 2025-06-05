using DG.Tweening;
using UnityEngine;
using XLSXContent;

namespace Dpr.SecretBase
{
	public class StatePedestalWindow : StateBase<StatuePlacementEditController.State, StatuePlacementEditController>
	{
		private PlacementData placement;
		private Pedestal.SheetInfo prevPedestal;
		private bool hasEnableItem;
		private bool isPedestalInstalled;
		private Tweener windowAnimationhandler;
		private Vector3 baseWindowPos;
		
		public StatePedestalWindow() : base(StatuePlacementEditController.State.PedestalWindow)
		{
			// Empty
		}
		
		// TODO
		public void Enter_PedestalWindow(PlacementData placement) { }
		
		// TODO
		public override void Enter(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Execute(StatuePlacementEditController owner) { }
		
		// TODO
		public override void Exit(StatuePlacementEditController owner) { }
		
		// TODO
		private void UpdateModelView(StatuePlacementEditController owner) { }
		
		// TODO
		private void SetLayerRecursively(GameObject gameObject, int layer) { }
	}
}