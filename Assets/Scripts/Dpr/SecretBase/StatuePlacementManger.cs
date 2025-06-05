using System.Collections;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatuePlacementManger : MonoBehaviour
	{
		[SerializeField]
		private SecretBaseMasterDataManager masterData;
		[SerializeField]
		private GameObject placementGuide;
		[SerializeField]
		private StatuePlacementGridManager gridManager;
		[SerializeField]
		private FieldCursor fieldCursor;
		[SerializeField]
		private FieldCursor placementCursor;
		[SerializeField]
		private FieldCursor placementCursorSelect;
		[SerializeField]
		private FieldCursor impossibleField;
		[SerializeField]
		private Transform statueRoot;
		[SerializeField]
		private StatuePlacementCrystal crystal;
		[SerializeField]
		private StatuePlacementEffectManager effectManager;
		[SerializeField]
		private SecretBaseAudioManager audioManager;
		private FieldCursor currentCursor;
		private Vector2Int gridPosition = new Vector2Int(0, 0);
		private CursorMode cursorMode;
		
		public FieldCursor FieldCursor { get => fieldCursor; }
		public FieldCursor PlacementCursor { get => placementCursor; }
		public Transform StatueRoot { get => statueRoot; }
		public Vector2Int GridPosition { get => gridPosition; }
		
		// TODO
		public IEnumerator Load() { return default; }
		
		// TODO
		public bool IsLoadCompleted() { return default; }
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void SetCursorMode(CursorMode mode) { }
		
		// TODO
		public void SetActivePlaceMentGuide(bool isActive) { }
		
		// TODO
		public void CursorMoveToLeft() { }
		
		// TODO
		public void CursorMoveToRight() { }
		
		// TODO
		public void CursorMoveToUp() { }
		
		// TODO
		public void CursorMoveToDown() { }
		
		// TODO
		private void ApplyCursorPos() { }
		
		// TODO
		public void AddStatue(PlacementData info) { }
		
		// TODO
		public void SetPlacementCursorRect(RectInt rect) { }
		
		// TODO
		public bool IsCanBePlacement() { return default; }
		
		// TODO
		public bool IsCanBeSelectedField() { return default; }
		
		// TODO
		public PlacementData GetOverlapedPlacementData() { return default; }
		
		// TODO
		public bool SetStatueDir(PlacementData target, int placement_dir) { return default; }
		
		// TODO
		public void UpdateCrystalColor() { }
		
		// TODO
		private void SetCurrentCursor(FieldCursor current) { }
		
		// TODO
		public void SetSelectPedestalMode(bool isPedestalMode) { }

		public enum CursorMode : int
		{
			Field = 0,
			Placement = 1,
		}
	}
}