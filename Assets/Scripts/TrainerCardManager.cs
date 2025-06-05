using UnityEngine;

public class TrainerCardManager : MonoBehaviour
{
	[SerializeField]
	private int a = PlayerWork.GetMoney();
	[SerializeField]
	private TrainerCard myData;
	
	// TODO
	private void Start() { }
	
	// TODO
	public void AddTrainerCardData() { }
	
	// TODO
	public void CatchTrainerCardData(TrainerCard data) { }

	public struct TrainerCard
	{
		public uint id;
		public int monry;
		public int count;
		public ushort hour;
		public ushort minute;
	}
}