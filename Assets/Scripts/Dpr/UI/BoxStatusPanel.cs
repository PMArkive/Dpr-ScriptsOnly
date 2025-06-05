using Dpr.Message;
using Pml.PokePara;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dpr.UI
{
	public class BoxStatusPanel : MonoBehaviour
	{
		[SerializeField]
		private Image _ballImage;
		[SerializeField]
		private UIText _nickNameText;
		[SerializeField]
		private Image _sexImage;
		[SerializeField]
		private UIText _levelText;
		[SerializeField]
		private GameObject _statusFrame;
		[SerializeField]
		private GameObject _judgeFrame;
		[SerializeField]
		private UIText _noText;
		[SerializeField]
		private UIText _nameText;
		[SerializeField]
		private Image _langIcon;
		[SerializeField]
		private TypePanel[] _types;
		[SerializeField]
		private Image _pokerusImage;
		[SerializeField]
		private Image _RereImage;
		[SerializeField]
		private PokemonSick _condition;
		[SerializeField]
		private Sprite[] _pokerusSprites;
		[SerializeField]
		private UIText[] _statusValues;
		[SerializeField]
		private GameObject _wazaFrame;
		[SerializeField]
		private UIText _judgeTotalText;
		[SerializeField]
		private Image[] _wazaBgs;
		[SerializeField]
		private UIText[] _wazaTexts;
		[SerializeField]
		private Sprite[] _wazaTypeSprites;
		[SerializeField]
		private Image[] _markImages;

		private Color32[] _markColorSet;
		private float _openPosX;
		private float _closePosX;
		private const string _msgCodeBaseString = "SS_box_";
		private const int _msgItemNo = 30;
		private const int _msgJudgeTotalBaseNo = 228;
		private const int _msgJudgeBaseNo = 232;
		private const int _msgTraningedNo = 577;
		private const string langIconSoriteNameBase = "cmn_ico_txt_lang_{0}_00";

		private static Dictionary<MessageEnumData.MsgLangId, string> LangageIconSpriteNames = new Dictionary<MessageEnumData.MsgLangId, string>()
		{
			{ MessageEnumData.MsgLangId.JPN, "jpn" },
			{ MessageEnumData.MsgLangId.USA, "eng" },
			{ MessageEnumData.MsgLangId.FRA, "fra" },
			{ MessageEnumData.MsgLangId.ITA, "ita" },
			{ MessageEnumData.MsgLangId.DEU, "ger" },
			{ MessageEnumData.MsgLangId.ESP, "spa" },
			{ MessageEnumData.MsgLangId.KOR, "kor" },
			{ MessageEnumData.MsgLangId.SCH, "chs" },
			{ MessageEnumData.MsgLangId.TCH, "cht" },
		};
		
		// TODO
		public void Initialize() { }
		
		// TODO
		public void Open(BoxWindow.StatusType mode, PokemonParam pokemonParam) { }
		
		// TODO
		public void Close() { }
		
		// TODO
		public bool SetUp(BoxWindow.StatusType mode, PokemonParam pokemonParam) { return default; }
		
		// TODO
		public void SetMarks(PokemonParam pokemonParam) { }
		
		// TODO
		private void OpenProc() { }
		
		// TODO
		private string GetJudgeTextCode(PokemonParam pokemonParam, PowerID powerId) { return default; }

		private enum StatusType : int
		{
			Hp = 0,
			Attack = 1,
			Defence = 2,
			SpAttack = 3,
			SpDefence = 4,
			Speed = 5,
			Personality = 6,
			Tokusei = 7,
			Item = 8,
			JudgeHP = 9,
			JudgeAttack = 10,
			JudgeDefence = 11,
			JudgeSpAttack = 12,
			JudgeSpDefence = 13,
			JudgeSpeed = 14,
			Num = 15,
		}
	}
}