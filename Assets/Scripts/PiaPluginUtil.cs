using System.Diagnostics;
using UnityEngine;

public class PiaPluginUtil : MonoBehaviour
{
	// TODO
	[Conditional("DEVELOPMENT_BUILD")]
	public static void UnityLog(string msg) { }
}