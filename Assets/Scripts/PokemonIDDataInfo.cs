using System;
using System.Collections.Generic;
using UnityEngine;

public class PokemonIDDataInfo : MonoBehaviour
{
	[SerializeField]
	private List<string> LabelList = new List<string>();
	[SerializeField]
	private List<Texture> TextureList = new List<Texture>();
	[SerializeField]
	private List<PantoneList> PantoneIndexList = new List<PantoneList>();
	
	// TODO
	private Color StringToColor(string colorStr) { return default; }
	
	// TODO
	public void Clear() { }
	
	// TODO
	public void AddIDData(Texture texture, TextAsset textAsset) { }
	
	// TODO
	public Texture GetTexture(string label) { return default; }
	
	// TODO
	public (string, Color) GetPantone(string label, Color idColor) { return default; }

	[Serializable]
	public class Pantone
	{
		public string Code;
		public Color RGBColor;
		public Color IDColor;
	}

	[Serializable]
	public class PantoneList
	{
		public List<Pantone> List = new List<Pantone>();
		
		public PantoneList(List<Pantone> list)
		{
			List = list;
		}
	}
}