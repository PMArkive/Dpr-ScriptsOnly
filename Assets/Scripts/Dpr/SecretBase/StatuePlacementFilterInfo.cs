using Dpr.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Dpr.SecretBase
{
	public class StatuePlacementFilterInfo : MonoBehaviour
	{
		private static readonly string MESSAGE_FILE_NAME = "dlp_underground";

		private static Dictionary<int, (string main, string sub)> MESSAGE_DIC = new Dictionary<int, (string, string)>()
		{
			{ -1, ("DLP_underground_539", null) },
			{ 0,  ("DLP_underground_753", null) },
			{ 1,  ("DLP_underground_754", null) },
			{ 2,  ("DLP_underground_755", null) },
			{ 3,  ("DLP_underground_756", null) },
		};

		[SerializeField]
		private UIText mainText;
		[SerializeField]
		private GameObject subTextRoot;
		[SerializeField]
		private UIText subText;

		private int currentIndex = -1;
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Apply(int value) { }
	}
}