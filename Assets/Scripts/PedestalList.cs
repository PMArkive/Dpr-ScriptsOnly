using UnityEngine;

[CreateAssetMenu(menuName = "SecretBase/PedestalList", fileName = "PedestalList")]
public class PedestalList : ScriptableObject
{
	[SerializeField]
	public GameObject[] assets;
}