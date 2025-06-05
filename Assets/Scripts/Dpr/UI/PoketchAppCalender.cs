using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class PoketchAppCalender : PoketchAppBase
	{
		[SerializeField]
		private Image _monthImage01;
		[SerializeField]
		private Image _monthImage10;
		[SerializeField]
		private Sprite[] _numberSprites;

		private int _minDayIndex = -1;
		private int _maxDayIndex = -1;
		private int _currentMonth = 1;
		private List<int> _selectDaysList = new List<int>();
		
		// TODO
		protected override void OnInitialize() { }
		
		// TODO
		protected override void OnOpen() { }
		
		// TODO
		protected override void OnClose() { }
		
		// TODO
		protected override void OnUpdateDraw() { }
		
		// TODO
		protected override void OnUpdateControl([Optional][DefaultParameterValue(false)] bool isAppControlEnable, [Optional] PoketchButton targetButton, PoketchWindow.TouchState state = PoketchWindow.TouchState.None) { }
		
		// TODO
		private void LoadSelectDays() { }
		
		// TODO
		private void SaveSelectDays() { }
		
		// TODO
		private void SettingLayout() { }
		
		// TODO
		private void SelectDay(int index) { }
	}
}