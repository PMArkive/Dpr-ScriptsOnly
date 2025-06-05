using System.Text;
using UnityEngine;

namespace Dpr.GMS
{
	public class PointHistoryData
	{
		public Sprite sendMonsIconSpr;
		public Sprite receiveMonsIconSpr;
		public Sprite receiveMonsSexIconSpr;
		public Sprite receiveMonsLangIconSpr;
		public Sprite receiveMonsParentLangIconSpr;
		protected IntermediatePointData currentPointData;
		protected StringBuilder receiveMonsNameSb = new StringBuilder();
		protected StringBuilder receiveMonsNicknameSb = new StringBuilder();
        protected StringBuilder receiveMonsParentNameSb = new StringBuilder();
        protected StringBuilder dateTimeSb = new StringBuilder();
        protected int dataIndex;
	}
}