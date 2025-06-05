using System.Collections.Generic;
using UnityEngine;
using XLSXContent;

public class OpcFactry : MonoBehaviour
{
	private const string ASSET_PASS_FIELD = "persons/field/";

	[SerializeField]
	private List<OpcController> _OpcControllers;
	[SerializeField]
	private UnionCharacterTable.SheetSheet1[] _DataTable;
	[SerializeField]
	private int _CreateMaxCharacterCount = 16;
}