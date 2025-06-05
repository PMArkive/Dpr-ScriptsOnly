using System;
using UnityEngine;

namespace SmartPoint.AssetAssistant
{
	public class Serializer
	{
		static Serializer()
		{
			if (Application.platform == RuntimePlatform.IPhonePlayer)
				Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
		}
		
		// TODO
		public static string ToBase64String(object content) { return default; }
		
		// TODO
		public static object FromBase64String(string base64string) { return default; }
	}
}