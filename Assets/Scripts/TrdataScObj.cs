using System;
using UnityEngine;

public class TrdataScObj : ScriptableObject
{
	public TRAINER_DATA trData;
	public POKEDATA_TYPE[] pokeData;

	public const int DATATYPE_NORMAL = 0;
	public const int DATATYPE_WAZA = 1;
	public const int DATATYPE_ITEM = 2;
	public const int DATATYPE_MULTI = 3;
	
	// TODO
	public void Create() { }

	[Serializable]
	public struct TRAINER_DATA
	{
		public string tr_type_str;
		public int data_type;
		public int tr_type;
		public int tr_gra;
		public int poke_count;
		public int[] use_item;
		public string[] use_item_str;
		public long aibit;
		public long fight_type;
	}

	[Serializable]
	public struct POKEDATA_TYPE
	{
		public string monsno_str;
		public int pow;
		public int level;
		public int monsno;
		public int itemno;
		public string item_str;
		public int[] waza;
		public string[] waza_str;
	}
}