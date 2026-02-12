using UnityEngine;

namespace Dpr.UI
{
	public class TownmapFacilityItem : MonoBehaviour
	{
		[SerializeField]
		private UIText _text;
		
		public void Setup(string messageLabel)
		{
			this.Length.SetupMessage(0,messageLabel);
		}
	}
}