using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NexAssets
{
	public abstract class RankingBoardBase : MonoBehaviour
	{
		protected const int MENU_WIDTH = 320;
		protected const int MENU_HEIGHT = 240;
		protected const int COLUMN_SIZE = 48;
		protected const float GUI_BASE_ALPHA = 1.0f;

		private Image m_RankingPanel;
		private Image m_RankingNoneDataPanel;
		private Image m_HeaderScrollArea;
		private Image m_HeaderScrollPanel;
		private Image m_ScrollArea;
		private Image m_ScrollPanel;
		private Scrollbar m_VScrollbar;
		private Scrollbar m_HScrollbar;
		private GameObject[] m_HeaderObj;
		private GameObject[] m_CellObj;
		protected List<COLUMN_ARG> m_ColumnList = new List<COLUMN_ARG>();
		public RankingBoardParam m_RankingBoardParam = new RankingBoardParam();
		
		// TODO
		private Image RankingPanel { get; }
		
		// TODO
		private Image RankingNoneDataPanel { get; }
		
		// TODO
		private Image HeaderScrollArea { get; }
		
		// TODO
		private Image HeaderScrollPanel { get; }
		
		// TODO
		private Image ScrollArea { get; }
		
		// TODO
		private Image ScrollPanel { get; }
		
		// TODO
		private Scrollbar VScrollbar { get; }
		
		// TODO
		private Scrollbar HScrollbar { get; }
		
		// TODO
		private GameObject[] HeaderObj { get; }
		
		// TODO
		private GameObject[] CellObj { get; }
		
		// TODO
		public float VScroll { get; set; }
		
		// TODO
		public float HScroll { get; set; }
		
		// TODO
		protected void Start() { }
		
		// TODO
		public void SetRankingBoardEnable(bool enable) { }
		
		protected abstract string HeaderTextTag { get; }
		protected abstract string ParamTextTag { get; }

		protected abstract void CreateColumnIndex();

		protected abstract string GetContent(COLUMN_ARG columnArg);

		protected abstract int GetDataCount();
		
		// TODO
		protected void CreateColumn(COLUMN_ARG columnArg) { }
		
		// TODO
		protected void RankingBoard(bool enable = true) { }

		public enum SIZE_TYPE : int
		{
			PIXEL = 0,
			PERCENTAGE = 1,
		}

		public enum POSITION_TYPE : int
		{
			ALIGN = 0,
			INPUT = 1,
		}

		public enum POSITION_ALIGN_V : int
		{
			TOP = 0,
			CENTER = 1,
			BOTTOM = 2,
		}

		public enum POSITION_ALIGN_H : int
		{
			LEFT = 0,
			CENTER = 1,
			RIGHT = 2,
		}

		[Serializable]
		public struct COLUMN_ARG
		{
			public int indexType;
			public int priority;
			public int param;
			public int size;
			public string title;
			public bool disp;
			
			public COLUMN_ARG(int indexType_, string title_)
			{
				title = title_;
				indexType = indexType_;
				priority = 0;
				param = 0;
				size = 48;
				disp = false;
			}
		}

		[Serializable]
		public class RankingBoardParam
		{
			public bool GuiFold;
			public GUISkin GuiSkin;
			public string ScoreboardTitle = "title";
			public int TitleHeight = 24;
			public SIZE_TYPE GuiSizeType;
			public POSITION_TYPE GuiPosType = POSITION_TYPE.INPUT;
			public POSITION_ALIGN_V GuiPosAlign_v = POSITION_ALIGN_V.CENTER;
			public POSITION_ALIGN_H GuiPosAlign_h = POSITION_ALIGN_H.CENTER;
			public int GuiPosMargin_v;
			public int GuiPosMargin_h;
			public Vector2 RankingBoardPosition = new Vector2(0.0f, 0.0f);
			public Vector2 RankingBoardSize = new Vector2(MENU_WIDTH, MENU_HEIGHT);
			public Vector2 RankingBoardPercentage = new Vector2(100.0f, 100.0f);
		}
	}
}