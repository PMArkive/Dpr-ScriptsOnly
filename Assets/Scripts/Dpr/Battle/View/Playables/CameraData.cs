using System;
using UnityEngine;

namespace Dpr.Battle.View.Playables
{
	[Serializable]
	public struct CameraData
	{
		public string name;
		public ControlType type;
		public float nearLength;
		public float farLength;
		[Header("画角(FOV)")]
		public float fovy;
		public Vector3 rotation;
		public Vector3 translate;
		public Vector3 upVector;
		public Vector3 aimPos;
		[Header("被写界深度")]
		public DofParam dofParam;
		[Header("カメラのねじれ(Z軸)")]
		public float twist;
		
		public static CameraData Factory()
		{
			return new CameraData()
			{
				rotation = Vector3.zero,
				translate = Vector3.zero,
				upVector = Vector3.up,
				farLength = 0.0f,
				fovy = 0.0f,
				aimPos = Vector3.zero,
				twist = 0.0f,
				name = null,
				type = ControlType.Srt,
				nearLength = 0.0f,
				dofParam = DofParam.Factory(),
			};
		}
	}
}