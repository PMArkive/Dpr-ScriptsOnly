using Dpr.SubContents;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Dpr.FureaiHiroba
{
	public class DebugManager : MonoBehaviour
	{
		private const string TEXT_PARENT_NAME = "DebugTexts";

		private static Dictionary<string, Text> Texts = new Dictionary<string, Text>();

		[Button("CreateDebugDraw", "CreateDebugDraw", new object[0])]
		public int Button01;
		
		private static Transform TextsParent { get => GameObject.Find(TEXT_PARENT_NAME).transform; }
		
		// TODO
		private void CreateDebugDraw() { }
		
		// TODO
		private void ClearDebugView() { }
		
		// TODO
		public static Text CreateText(string TextName, float lineSpace = 0.0f) { return default; }
		
		// TODO
		public static Text GetText(string TextName) { return default; }
		
		// TODO
		private RectTransform CreateTextParent(Transform parent, Vector2 Pos) { return default; }
		
		// TODO
		private static void SetParentAndAlign(GameObject child, GameObject parent) { }
		
		// TODO
		public static Canvas CreateCanvas([Optional] GameObject parent, string name = "Canvas") { return default; }
		
		// TODO
		public static EventSystem CreateEventSystem([Optional] GameObject parent, string name = "EventSystem") { return default; }
	}
}