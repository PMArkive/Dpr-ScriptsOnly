using Audio;
using Dpr.Battle.View.Systems;
using Effect;
using GameData;
using Pml;
using ScriptableObjectFormat;
using SmartPoint.AssetAssistant;
using SmartPoint.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
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
	
	[SceneBeforeActivateOperationMethod]
	private IEnumerator OnInitialize(Transform cluster)
	{
		ViewerSettings.Load();
		yield return null;
	}
	
	private void OnEnable()
	{
		if (EventSystem.current == null)
			return;

		var input = EventSystem.current.currentInputModule as StandaloneInputModule;
		if (input != null)
		{
			_savedInputAxisH = input.horizontalAxis;
			_savedInputAxisV = input.verticalAxis;
			input.horizontalAxis = "DPadH";
			input.verticalAxis = "DPadV";
        }

		Sequencer.update -= OnUpdate;
		Sequencer.update += OnUpdate;
	}
	
	private void OnDisable()
	{
        var input = EventSystem.current?.currentInputModule as StandaloneInputModule;
		if (input != null)
		{
			input.horizontalAxis = _savedInputAxisH;
			input.verticalAxis = _savedInputAxisV;
        }

        Sequencer.update -= OnUpdate;
    }
	
	private void Awake()
	{
		// Empty
	}
	
	private void SetTimeZone(int index)
	{
		ViewerSettings.timeZone = index;

        var ticks = GameManager.nowTime.Ticks;
        switch (index)
		{
			case 0:
				GameManager.tickOffset = 0;
				break;

			case 1:
                GameManager.tickOffset = 1008010000000 + (ticks / GameManager.ticksPerDay * GameManager.ticksPerDay - ticks);
				break;

            case 2:
                GameManager.tickOffset = 1224010000000 + (ticks / GameManager.ticksPerDay * GameManager.ticksPerDay - ticks);
                break;

            case 3:
                GameManager.tickOffset = 1476010000000 + (ticks / GameManager.ticksPerDay * GameManager.ticksPerDay - ticks);
                break;

            case 4:
                GameManager.tickOffset = 1584010000000 + (ticks / GameManager.ticksPerDay * GameManager.ticksPerDay - ticks);
                break;

            case 5:
                GameManager.tickOffset = 936010000000 + (ticks / GameManager.ticksPerDay * GameManager.ticksPerDay - ticks);
                break;

			default:
                GameManager.tickOffset = 864010000000 + (ticks / GameManager.ticksPerDay * GameManager.ticksPerDay - ticks);
                break;
        }
    }
	
	private void SetWeather(BtlvWeather weather)
	{
		_weather = weather;

		if (_skyColorSettings != null)
			_skyColorSettings.SetWeather(_weather, GameManager.currentPeriodOfDay);
	}
	
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
	
	private void SetupEffectStopMenu()
	{
		for (int i=_effectStopMenu.cells.Count-1; i>=0; i--)
			_effectStopMenu.Remove(_effectStopMenu.cells[i]);

		for (int i=0; i<_effecctInstances.Count; i++)
			AddEffectStopInstance(_effecctInstances[i]);
    }
	
	private void AddEffectStopInstance(EffectInstance effectInstance)
	{
		_effectStopMenu.AddItem(effectInstance.name, stopReference =>
		{
			effectInstance.Stop();
			_effectStopMenu.Remove(_effectStopMenu.GetCurrentCell());
		}, null, null);
	}
	
	// TODO
	private void CreateAudioMenu(DebugMenu.MenuInstance parentMenu) { }
	
	private void PlaySe(uint playEventId, uint stopEventId)
	{
		var se = AudioManager.Instance.CreateSe(playEventId, stopEventId);
		se.Play(instance =>
		{
			_seInstances.Remove(instance);
			SetupAudioStopMenu();
		});
		_seInstances.Add(se);
		AddAudioStopInstance(se);
	}
	
	private void PlayVoice(uint playEventId, uint stopEventId)
	{
        var voice = AudioManager.Instance.CreateVoice(playEventId, stopEventId);
        voice.Play(instance =>
        {
            _seInstances.Remove(instance);
            SetupAudioStopMenu();
        });
        _seInstances.Add(voice);
        AddAudioStopInstance(voice);
    }
	
	private void SetupAudioStopMenu()
	{
		for (int i=_seStopMenu.cells.Count-1; i>=0; i--)
            _seStopMenu.Remove(_seStopMenu.cells[i]);

		for (int i=0; i<_seInstances.Count; i++)
            AddAudioStopInstance(_seInstances[i]);
	}
	
	private void AddAudioStopInstance(AudioInstance audioInstance)
	{
        _seStopMenu.AddItem(audioInstance.playEventId.ToString(), stopReference =>
        {
            audioInstance.Stop();
            _seStopMenu.Remove(_seStopMenu.GetCurrentCell());
        }, null, null);
    }
	
	// TODO
	private void AddInstanceItem(string label, GameObject instance) { }
	
	private void OnRequestCharacter(object reference)
	{
        if (_loadingCoroutine != null)
            return;

        var tuple = ((string, string))reference;
		var label = tuple.Item1;
		var assetBundleName = tuple.Item2;

		Sequencer.Start(AssetBundleLoadingOperation(assetBundleName, asset =>
		{
            if (asset == null)
                return;

            if (!(asset is GameObject))
                return;

            if (!ViewerSettings.appendOpenMode)
                ClearInstanceItems();

            var go = Instantiate(asset) as GameObject;
            go.name = asset.name;

			var charaGraphic = DataManager.CharacterGraphics.Data.FirstOrDefault(x => assetBundleName.IndexOf(x.FieldGraphic) >= 0);
			if (charaGraphic != null)
				go.transform.localScale.Set(charaGraphic.Scale, charaGraphic.Scale, charaGraphic.Scale);

			AddInstanceItem(label, go);
        }));
    }
	
	private void OnSelectModel(object reference)
	{
		OnSelectModel(reference, true);
	}
	
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
	
	private void OnSelectPokemonChanged(int index, int category)
	{
		_currentPokemonIndex = index;

		switch (category)
		{
			case 0:
				_fieldPokemonMenu?.Reload();
				break;

			case 1:
				_battlePokemonMenu?.Reload();
				break;
		}

		if (HasPokemonInstance() && !ViewerSettings.appendOpenMode)
			OnRequestPokemon(category);
	}
	
	private void OnSelectVariationChanged(int index, int category)
	{
		if (_pokemonInfos[_currentPokemonIndex].currentVariation != index)
		{
			_pokemonInfos[_currentPokemonIndex].currentVariation = index;
            if (HasPokemonInstance() && !ViewerSettings.appendOpenMode)
                OnRequestPokemon(category);
        }
	}
	
	private void OnShinyColorChanged(int selected, int category)
	{
		_pokemonInfos[_currentPokemonIndex].shinyColor = selected == 1;
        if (HasPokemonInstance() && !ViewerSettings.appendOpenMode)
            OnRequestPokemon(category);
    }
	
	private void OnRequestFieldPokemon(object reference)
	{
		OnRequestPokemon(0);
	}
	
	private void OnRequestBattlePokemon(object reference)
	{
        OnRequestPokemon(1);
    }
	
	private void OnRequestPokemon(int category)
	{
		if (_loadingCoroutine != null)
			return;

		var info = _pokemonInfos[_currentPokemonIndex];
		var va = info.variations[info.currentVariation];
		var assetBundleName = info.variations[info.currentVariation].AssetBundleName;
		var pokemonData = DataManager.PokemonInfo.Catalog.FirstOrDefault(x => x.AssetBundleName == assetBundleName);

		assetBundleName = category == 0 ? "field/" : "battle/";
		assetBundleName += string.Format("pm{0,0:D4}_{1}_{2,0:D2}", info.index + 1, va.Variation.Substring(0, 2), info.shinyColor);

		Sequencer.Start(AssetBundleLoadingOperation("pokemons/" + assetBundleName, asset =>
		{
			if (asset == null)
				return;

			if (!(asset is GameObject))
				return;

			if (!ViewerSettings.appendOpenMode)
				ClearInstanceItems();

			var go = Instantiate(asset) as GameObject;
			var animPlayer = go.GetComponent<BaseEntity>()?.GetAnimationPlayer();

			go.name = asset.name;

			if (info.petrify != 0)
			{
				var petrifyUpdater = go.AddComponent<PetrifyUpdater>();
				petrifyUpdater.materialData = petrifyData.materialDatas[info.petrify - 1];

				var renderers = go.GetComponentsInChildren<SkinnedMeshRenderer>(true);
				for (int i=0; i<renderers.Length; i++)
				{
					var materials = renderers[i].sharedMaterials;
					for (int j=0; j<materials.Length; j++)
					{
						var material = materials[j];
						if (material.shader != null)
						{
							var shaderName = material.shader.name;
							if (shaderName.IndexOf("Mask") < 0 && shaderName.IndexOf("DepthOnly") < 0)
							{
								var renderQueue = material.renderQueue;

								if (shaderName.IndexOf("Fire") >= 0)
									material.shader = petrifyFireShader;
								else if (shaderName.IndexOf("Smoke") >= 0)
                                    material.shader = petrifySmokeShader;
                                else
                                    material.shader = petrifyShader;

								material.renderQueue = renderQueue;
								petrifyUpdater.materials.Add(material);
                            }
						}
					}
				}

				if (petrifyUpdater.materialData.forceSoftEdge)
				{
					var activeRenderers = go.GetComponentsInChildren<SkinnedMeshRenderer>();

					for (int i=0; i<activeRenderers.Length; i++)
						MeshNormalSmoother.Add(activeRenderers[i].sharedMesh);

					MeshNormalSmoother.Bake();
                }

                if (pokemonData != null)
                {
                    var scale = pokemonData.FieldChikaScale;
                    go.transform.localScale = new Vector3(scale, scale, scale);
                }
            }
			else
			{
				if (pokemonData != null)
				{
                    var scale = pokemonData.BattleScale;
                    go.transform.localScale = new Vector3(scale, scale, scale);
                }
			}

            var renderersForShadows = go.GetComponentsInChildren<Renderer>();
			for (int i=0; i<renderersForShadows.Length; i++)
				renderersForShadows[i].receiveShadows = false;

			AddInstanceItem(va.Name, go);

			if (animPlayer != null && info.petrify != 0)
			{
				var pokemon = go.GetComponent<FieldPokemonEntity>();

				if (pokemon != null)
					pokemon.autoBlinkEnable = false;

				animPlayer.SetSpeed(0.0f);
			}
        }));
    }
	
	private void OnRequestStatue(object reference)
	{
        if (_loadingCoroutine != null)
            return;

		var index = _currentStatueIndex;

		Sequencer.Start(AssetBundleLoadingOperation(string.Format("pokemons/statue/{0}", _statueData[index].statueId), asset =>
		{
            if (asset == null)
                return;

            if (!(asset is GameObject))
                return;

            if (!ViewerSettings.appendOpenMode)
                ClearInstanceItems();

            var go = Instantiate(asset) as GameObject;
			AddInstanceItem(string.Format("statue{0}", index), go);
        }));
    }
	
	private void CreateBoxMesh()
	{
		if (_boxMesh != null)
			return;

		_boxMat = new Material(Shader.Find("Unlit/Color"));
		_boxMat.color = new Color(1.0f, 0.0f, 0.0f);

		_boxMesh = new Mesh();
		_boxMesh.vertices = new Vector3[]
		{
			new Vector3(-1.0f, -1.0f, -1.0f),
			new Vector3(1.0f,  -1.0f, -1.0f),
			new Vector3(1.0f,  -1.0f, 1.0f),
			new Vector3(-1.0f, -1.0f, 1.0f),
			new Vector3(-1.0f, 1.0f,  -1.0f),
			new Vector3(1.0f,  1.0f,  -1.0f),
			new Vector3(1.0f,  1.0f,  1.0f),
			new Vector3(-1.0f, 1.0f,  1.0f),
		};
		_boxMesh.SetIndices(new int[]
		{
            0, 1, 1, 2,
			2, 3, 3, 0,
			4, 5, 5, 6,
			6, 7, 7, 4,
			0, 4, 1, 5,
			2, 6, 3, 7,
        }, MeshTopology.Lines, 0);
		_boxMesh.UploadMeshData(true);
	}
	
	private void DrawBox()
	{
		if (ViewerSettings.hideBoundingBox)
			return;

		if (_simpleCamera.cameraTarget == null)
			return;

		CreateBoxMesh();

		var initialMat = _simpleCamera.transform.localToWorldMatrix;
		var bounds = _simpleCamera.bounds;
		var center = bounds.center;
		var size = bounds.size;

        var mat = new Matrix4x4
        {
            m00 = initialMat.m00 * size.x,
            m01 = initialMat.m01 * size.y,
            m02 = initialMat.m02 * size.z,
            m03 = initialMat.m00 * center.x + initialMat.m01 * center.y + initialMat.m02 * center.z + initialMat.m03,
            m10 = initialMat.m10 * size.x,
            m11 = initialMat.m11 * size.y,
            m12 = initialMat.m12 * size.z,
            m13 = initialMat.m10 * center.x + initialMat.m11 * center.y + initialMat.m12 * center.z + initialMat.m13,
            m20 = initialMat.m20 * size.x,
            m21 = initialMat.m21 * size.y,
            m22 = initialMat.m22 * size.z,
            m23 = initialMat.m20 * center.x + initialMat.m21 * center.y + initialMat.m22 * center.z + initialMat.m23,
            m30 = initialMat.m30 * size.x,
            m31 = initialMat.m31 * size.y,
            m32 = initialMat.m32 * size.z,
            m33 = initialMat.m33,
        };

        Graphics.DrawMesh(_boxMesh, mat, _boxMat, LayerMask.NameToLayer("Debug"));
	}
	
	private IEnumerator AssetBundleLoadingOperation(string assetBundleName, UnityAction<UnityEngine.Object> callback)
	{
		if (callback != null)
		{
			AssetManager.AppendAssetBundleRequest(assetBundleName, true, null, null);
			yield return AssetManager.DispatchRequests((eventType, name, asset) =>
			{
				switch (eventType)
				{
					case RequestEventType.Activated:
						callback.Invoke(asset);
						break;

					case RequestEventType.Cached:
						AssetManager.UnloadAssetBundle(name);
						break;

					case RequestEventType.Complete:
						_loadingCoroutine = null;
						break;
				}
			});
		}
	}
	
	private void OnUpdate(float deltaTime)
	{
		GameManager.nowTime = DateTime.Now;

		if (_simpleCamera == null)
			return;

		if (GameManager.pause)
			return;

		DrawBox();

		if (ViewerSettings.autoRotate)
		{
			foreach (var cell in _instanceMenu.cells)
			{
				if (cell == null || cell.value == null)
					return;

				var go = (((string, GameObject))(cell.value as DebugMenuCell.Item).reference).Item2;
				if (go != null)
				{
					var quat = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
					quat.eulerAngles = new Vector3(0.0f, deltaTime * 90.0f, 0.0f);

					go.gameObject.transform.rotation *= quat;
                }
			}
		}

		if (Input.GetButtonDown("Previous"))
		{
			_instanceMenu.Previous();
			var item = _instanceMenu.GetCurrentItem();
            if (item != null)
				OnSelectModel(item.reference);
		}

		if (Input.GetButtonDown("Next"))
		{
			_instanceMenu.Next();
			var item = _instanceMenu.GetCurrentItem();
            if (item != null)
				OnSelectModel(item.reference);
		}

		if (Input.GetKeyDown(KeyCode.F))
			_simpleCamera.FitBox();

		if (!DebugMenu.visible)
		{
			if (Input.GetButtonDown("Submit"))
				_simpleCamera.FitBox();

			if (Input.GetButtonDown("Cancel") || Input.GetKeyDown(KeyCode.Escape))
			{
				_instanceMenu.SetCurrentIndex(0);
                var item = _instanceMenu.GetCurrentItem();
                if (item != null)
                    OnSelectModel(item.reference);
            }
		}

		if (!Sequencer.IntersectGUI(Input.mousePosition) && Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, 100.0f, 1 << LayerMask.NameToLayer("Clickable")))
			{
				SetCell(hitInfo.collider.gameObject);
			}
			else
			{
				if (!Input.GetKey(KeyCode.LeftAlt))
				{
                    _instanceMenu.SetCurrentIndex(0);
                    var item = _instanceMenu.GetCurrentItem();
                    if (item != null)
                        OnSelectModel(item.reference);
                }
			}
		}

		EnvironmentController.global.SetLight(_renderSettings, GameManager.currentPeriodOfDay, 0.0f);
		_simpleCamera.controllable = !DebugMenu.visible;
	}
	
	private void SetCell(GameObject instance)
	{
        foreach (var cell in _instanceMenu.cells)
        {
            if (cell == null || cell.value == null)
                return;

			var tuple = ((string, GameObject))(cell.value as DebugMenuCell.Item).reference;
            if (tuple.Item2 == instance)
			{
				_instanceMenu.SetCurrentCell(cell);
				OnSelectModel((tuple.Item1, tuple.Item2), false);

				if (instance == null)
					_simpleCamera.dragTarget = null;
				else
					_simpleCamera.dragTarget = instance.transform;

				return;
			}
        }
    }
	
	private void OnDestroy()
	{
		DebugMenu.SetRoot(null);
	}

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
		
		public static int GetLocation(int index)
		{
			for (int i=0; i<LocationRanges.Length; i++)
			{
				if (index <= LocationRanges[i].end - 1)
					return i;
			}

			return 0;
		}

		public string[] GetVariationNames()
		{
			var arr = variations.Select(x => x.Variation).ToArray();
			if (arr.Length == 1)
				return new string[] { "なし" };
			else
				return arr;
		}
	}
}