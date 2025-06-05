using Audio;
using Dpr.Battle.View.Systems;
using Effect;
using Pml;
using ScriptableObjectFormat;
using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using XLSXContent;

public class Viewer : MonoBehaviour
{
	[SerializeField]
	private PokemonData _pokemonData;
	[SerializeField]
	private CharacterTable _characterData;
	[SerializeField]
	private EffectTable _effectData;
	[SerializeField]
	private AudioTable _audioData;
	[SerializeField]
	private TextMeshProUGUI _selectedObjectLabel;
	[SerializeField]
	private EnvironmentSettings _renderSettings;
	[SerializeField]
	private SkyColorSettings _skyColorSettings;
	[SerializeField]
	private Camera _screenEffectCamera;
	[SerializeField]
	private PetrifyData petrifyData;
	[SerializeField]
	private Shader petrifyShader;
	[SerializeField]
	private Shader petrifyFireShader;
	[SerializeField]
	private Shader petrifySmokeShader;
	[SerializeField]
	private Texture2D _fieldCloudTex;
	[SerializeField]
	private Texture2D _battleCloudTex;
	private MapInfo _mapInfo;
	private ArenaInfo _arenaInfo;
	private StatueEffectRawData _statueData;
	private DebugMenu.MenuInstance _rootMenu;
	private DebugMenu.MenuInstance _fieldPokemonMenu;
	private DebugMenu.MenuInstance _battlePokemonMenu;
	private DebugMenu.MenuInstance _instanceMenu;
	private DebugMenu.MenuInstance _animationMenu;
	private DebugMenu.MenuInstance _settingMenu;
	private List<PokemonInfo> _pokemonInfos = new List<PokemonInfo>();
	private Dictionary<GameObject, LayoutScrollView.Cell> _instancePlayableLookup = new Dictionary<GameObject, LayoutScrollView.Cell>();
	private Dictionary<GameObject, LayoutScrollView.Cell> _instanceSettingLookup = new Dictionary<GameObject, LayoutScrollView.Cell>();
	private LayoutScrollView.Cell _effectMenuAdd;
	private LayoutScrollView.Cell _effectMenuBoot;
	private string _savedInputAxisH;
	private string _savedInputAxisV;
	private int _currentPokemonIndex;
	private int _currentStatueIndex;
	private int _theaterTrackIndex;
	private GameObject _bgPrefab;
	private Coroutine _loadingCoroutine;
	private SimpleCamera _simpleCamera;
	private Camera _camera;
	private BtlvWeather _weather;
	private List<EffectInstance> _effecctInstances = new List<EffectInstance>();
	private DebugMenu.MenuInstance _effectStopMenu;
	private List<AudioInstance> _seInstances = new List<AudioInstance>();
	private DebugMenu.MenuInstance _seStopMenu;
	private Dictionary<string, DebugMenu.MenuInstance> _audioGroupDict = new Dictionary<string, DebugMenu.MenuInstance>();
	private Mesh _boxMesh;
	private Material _boxMat;
	
	// TODO
	[SceneBeforeActivateOperationMethod]
	private IEnumerator OnInitialize(Transform cluster) { return default; }
	
	// TODO
	private void OnEnable() { }
	
	// TODO
	private void OnDisable() { }
	
	// TODO
	private void Awake() { }
	
	// TODO
	private void SetTimeZone(int index) { }
	
	// TODO
	private void SetWeather(BtlvWeather weather) { }
	
	// TODO
	private IEnumerator Start() { return default; }
	
	// TODO
	private void CreateLoadMenu(DebugMenu.MenuInstance parentMenu) { }
	
	// TODO
	private void CreateSelectionMenu(DebugMenu.MenuInstance parentMenu) { }
	
	// TODO
	private void CreateCameraMenu(DebugMenu.MenuInstance parentMenu) { }
	
	// TODO
	private void CreateEffectMenu(DebugMenu.MenuInstance parentMenu) { }
	
	// TODO
	private void SetupEffectStopMenu() { }
	
	// TODO
	private void AddEffectStopInstance(EffectInstance effectInstance) { }
	
	// TODO
	private void CreateAudioMenu(DebugMenu.MenuInstance parentMenu) { }
	
	// TODO
	private void PlaySe(uint playEventId, uint stopEventId) { }
	
	// TODO
	private void PlayVoice(uint playEventId, uint stopEventId) { }
	
	// TODO
	private void SetupAudioStopMenu() { }
	
	// TODO
	private void AddAudioStopInstance(AudioInstance audioInstance) { }
	
	// TODO
	private void AddInstanceItem(string label, GameObject instance) { }
	
	// TODO
	private void OnRequestCharacter(object reference) { }
	
	// TODO
	private void OnSelectModel(object reference) { }
	
	// TODO
	private void OnSelectModel(object reference, bool fit) { }
	
	// TODO
	private bool HasPokemonInstance() { return default; }
	
	// TODO
	private void ClearInstanceItems() { }
	
	// TODO
	private void OnRemoveModel(object reference) { }
	
	// TODO
	private void OnRequestField(object reference) { }
	
	// TODO
	private IEnumerator LoadFieldOperation(MapInfo.SheetZoneData zoneData) { return default; }
	
	// TODO
	private IEnumerator LoadArenaOperation(ArenaInfo.SheetArenaData arenaData) { return default; }
	
	// TODO
	private void OnSelectPokemonChanged(int index, int category) { }
	
	// TODO
	private void OnSelectVariationChanged(int index, int category) { }
	
	// TODO
	private void OnShinyColorChanged(int selected, int category) { }
	
	// TODO
	private void OnRequestFieldPokemon(object reference) { }
	
	// TODO
	private void OnRequestBattlePokemon(object reference) { }
	
	// TODO
	private void OnRequestPokemon(int category) { }
	
	// TODO
	private void OnRequestStatue(object reference) { }
	
	// TODO
	private void CreateBoxMesh() { }
	
	// TODO
	private void DrawBox() { }
	
	// TODO
	private IEnumerator AssetBundleLoadingOperation(string assetBundleName, UnityAction<Object> callback) { return default; }
	
	// TODO
	private void OnUpdate(float deltaTime) { }
	
	// TODO
	private void SetCell(GameObject instance) { }
	
	// TODO
	private void OnDestroy() { }

	public class PokemonInfo
	{
		public static readonly string[] Locations = new string[]
		{
            "カント―(RG)", "ホウエン(GS)", "ジョウト(RS)", "シンオウ(DP)",
        };
		public static readonly RangeInt[] LocationRanges = new RangeInt[]
		{
			new RangeInt((int)MonsNo.HUSIGIDANE, MonsNo.MYUU - MonsNo.HUSIGIDANE + 1),
			new RangeInt((int)MonsNo.TIKORIITA, MonsNo.SEREBHI - MonsNo.TIKORIITA + 1),
			new RangeInt((int)MonsNo.KIMORI, MonsNo.DEOKISISU - MonsNo.KIMORI + 1),
			new RangeInt((int)MonsNo.NAETORU, MonsNo.ARUSEUSU - MonsNo.NAETORU + 1),
		};
		public int index;
		public int currentVariation;
		public bool shinyColor;
		public int petrify;
		public List<PokemonData.ModelData> variations;
		
		// TODO
		public static int GetLocation(int index) { return default; }
		
		// TODO
		public string[] GetVariationNames() { return default; }
	}
}