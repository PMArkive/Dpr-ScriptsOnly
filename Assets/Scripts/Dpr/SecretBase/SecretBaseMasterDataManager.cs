using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

namespace Dpr.SecretBase
{
	public class SecretBaseMasterDataManager : MonoBehaviour
	{
		[SerializeField]
		private SecretbaseUpgrade secretbase;
        public SecretbaseUpgrade Secretbase { get => secretbase; }

        private StatueEffectRawData statueEffectRawData;

		public List<StatueEffectData> StatueEffectData { get; } = new List<StatueEffectData>();

        [SerializeField]
		private Pedestal pedestal;
		public Pedestal PedestalData { get => pedestal; }
		
		// TODO
		public IEnumerator Load() { return default; }
		
		// TODO
		public StatueEffectData GetStatueEffectData(int id) { return default; }
		
		// TODO
		public RectInt GetStatueRect(StatueItemData data) { return default; }
		
		// TODO
		public Vector2Int GetRoomSize() { return default; }
	}
}