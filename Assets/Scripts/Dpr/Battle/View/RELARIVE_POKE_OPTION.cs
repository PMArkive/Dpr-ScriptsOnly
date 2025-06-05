using Dpr.Battle.Logic;
using Dpr.SequenceEditor;
using UnityEngine;

namespace Dpr.Battle.View
{
	public struct RELARIVE_POKE_OPTION
	{
		public BtlvPos m_vpos;
		public BtlvPos m_vposSub;
		public SEQ_DEF_NODE m_node;
		public Vector3 m_offset;
		public int m_rate;
		public int m_moveType;
		public bool m_adjustFlip;
		public bool m_adjustScale;
		public bool m_autoRotateModel;
		public bool m_autoRotatePos;
		public bool m_forceUpdate;
		public bool[] m_targetElem;
		
		// TODO
		public static RELARIVE_POKE_OPTION Factory() { return default; }
		
		// TODO
		public void ClearOtherElem(bool[] otherElems) { }
	}
}