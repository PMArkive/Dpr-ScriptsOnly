using Audio;
using GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
    public class Townmap : MonoBehaviour
    {
        [SerializeField]
        protected float _cursorSpeed = 5.0f;
        [SerializeField]
        protected RectTransform _cellRoot;
        [SerializeField]
        protected TownmapPlayerIcon _player;
        [SerializeField]
        protected TownmapIcon _goal;
        [SerializeField]
        protected RectTransform _symbolRoot;
        [SerializeField]
        protected RectTransform _noticeRoot;
        [SerializeField]
        protected NoticeParam[] _noticeParams;
        [SerializeField]
        protected HiddenMapParam[] _hiddenMapParams;
        [SerializeField]
        protected Patch0DayParam _patch0DayParam;
        [SerializeField]
        protected float _snapDistance = CellSizeHalf;
        public const int CellNumX = 34;
        public const int CellNumY = 27;
        public const int CellSize = 24;
        public const float CellSizeHalf = 12.0f;
        protected static Cell[,] _cells = null;
        protected static Dictionary<ZoneID, List<TownMapTable.SheetData>> _dataDictByZoneId = new Dictionary<ZoneID, List<TownMapTable.SheetData>>();
        protected Vector3 _cursorPos = Vector3.zero;
        protected Vector2 _moveVec = Vector2.zero;
        protected bool _isAnalogCellChanged;
        protected UnityAction<Cell, bool> _onCellChanged;
        protected List<List<UIManager.DuplicateImageMaterialParam>> _duplicates = new List<List<UIManager.DuplicateImageMaterialParam>>();

        public RectTransform cellRoot { get => _cellRoot; }
        public Vector3 cursorPos { get => _cursorPos; }

        public void Setup(TownmapType type, TownMapGuideTable.SheetGuide guideData, UnityAction<Cell, bool> onCellChanged)
        {
            _onCellChanged = onCellChanged;

            SetupDatas();
            SetupSymbols();
            SetupKinomis();
            SetupHoneyTrees();
            SetupHiddenMap();

            var mapData = GetMapDataByPlayer();
            if (mapData != null)
                SetPlayerPos(mapData.NowPosXZ);

            if (type == TownmapType.Field)
            {
                _goal.gameObject.SetActive(false);
            }
            else
            {
                _goal.gameObject.SetActive(true);
                _goal.transform.position = ToCellIconPos(new Vector2(guideData.TownMapX, guideData.TownMapY));
            }

            _moveVec = Vector2.zero;
            _isAnalogCellChanged = false;

            ResetCursorPos(true);

            _patch0DayParam.Enable(true);
        }

        protected void OnDestroy()
        {
            for (int i=0; i<_duplicates.Count; i++)
                UIManager.RestoreDuplicateImageMaterials(_duplicates[i]);
        }

        protected TownMapTable.SheetData GetMapDataByPlayer()
        {
            FieldManager.Instance.GetTownMapPos(out ZoneID zone, out Vector3 pos);
            var data = GetData(zone, FieldObjectEntity.PositionToGrid(pos));
            if (data != null)
                return data;

            FieldManager.Instance.GetTownMapPos(out ZoneID prevZone, out Vector3 prevPos, true);
            return GetData(prevZone, FieldObjectEntity.PositionToGrid(prevPos));
        }

        protected void SetupDatas()
        {
            _cells = new Cell[CellNumY, CellNumX];

            var mapData = UIManager.Instance.townMapTable.Data;
            for (int i=0; i<mapData.Length; i++)
            {
                var cell = new Cell { data = mapData[i] };
                if (cell.data.TownPosXZ.x != -1.0f && cell.data.TownPosXZ.x < CellNumX &&
                    cell.data.TownPosXZ.y != -1.0f && cell.data.TownPosXZ.y < CellNumY)
                {
                    SetCell(cell.data.TownPosXZ, cell);
                }

                _dataDictByZoneId.TryGetValue(cell.data.zoneID, out List<TownMapTable.SheetData> value);

                if (value == null)
                {
                    value = new List<TownMapTable.SheetData>();
                    _dataDictByZoneId.Add(cell.data.zoneID, value);
                }

                value.Add(cell.data);
            }
        }

        protected void SetupSymbols()
        {
            var symbols = _symbolRoot.GetComponentsInChildren<TownmapSymbol>(true);
            var symbolDict = new Dictionary<string, TownmapSymbol>();

            for (int i=0; i<symbols.Length; i++)
            {
                var symbol = symbols[i];
                symbolDict.Add(symbol.name, symbol);
                _duplicates.Add(UIManager.DuplicateImageMaterials(symbol.transform));
            }

            var zoneSymbolDict = new Dictionary<ZoneID, List<TownmapSymbol>>();

            for (int i=_cells.GetLowerBound(0); i<=_cells.GetUpperBound(0); i++)
            {
                for (int j=_cells.GetLowerBound(1); j<=_cells.GetUpperBound(1); j++)
                {
                    var cell = _cells[i, j];
                    if (Cell.UseData(cell))
                    {
                        zoneSymbolDict.TryGetValue(cell.data.zoneID, out List<TownmapSymbol> zoneSymbols);
                        symbolDict.TryGetValue(cell.data.SymbolName, out TownmapSymbol symbol);

                        if (symbol != null)
                        {
                            if (zoneSymbols == null)
                            {
                                zoneSymbols = new List<TownmapSymbol>();
                                zoneSymbolDict.Add(cell.data.zoneID, zoneSymbols);
                            }

                            zoneSymbols.Add(symbol);
                            symbol.gameObject.SetActive(cell.data.ViewFlag >= EvScript.EvWork.WORK_INDEX.SCWK_WK_END || FlagWork.GetWork(cell.data.ViewFlag) != 0);

                            UIManager.Instance.Grayscale(symbol.transform, cell.IsArrive() ? 0.0f : 1.0f);
                        }

                        if (zoneSymbols != null)
                            cell.symbols = zoneSymbols;
                    }
                }
            }
        }

        protected void SetupKinomis()
        {
            var noticeParam = _noticeParams[0];
            var kinomis = (KinomiPlaceData.SheetSheet1[])DataManager.KinomiPlaceData.Sheet1.Clone();
            Array.Sort(kinomis, (l, r) => l.DesignationIndex - r.DesignationIndex);

            var hashset = new HashSet<int>();
            for (int i=0; i<kinomis.Length; i++)
            {
                var placedata = kinomis[i];
                var kinomi = new Cell.Kinomi()
                {
                    data = DataManager.GetKinomiDataByItemNo(placedata.ItemNo),
                    placeData = placedata,
                };

                if (placedata.SeedStartFlag < EvScript.EvWork.SYSFLAG_INDEX.SYSFLAG_END && FlagWork.GetSysFlag(placedata.SeedStartFlag))
                {
                    if (CanKinomiHarvest(placedata) && !hashset.Contains(placedata.DesignationIndex))
                    {
                        hashset.Add(placedata.DesignationIndex);
                        Instantiate(noticeParam.prefab, noticeParam.root, false).transform.position = ToCellIconPos(placedata.TownMapPosition);
                    }
                }
            }
        }

        protected void SetupHoneyTrees()
        {
            for (int i=0; i<DataManager.HoneyTree.HoneyTreeIndex.Length; i++)
            {
                var tree = DataManager.HoneyTree.HoneyTreeIndex[i];
                if (tree.HoneyStartFlag < EvScript.EvWork.SYSFLAG_INDEX.SYSFLAG_END && FlagWork.GetSysFlag(tree.HoneyStartFlag))
                {
                    if (GetCell(tree.HoneyPosXZ) == null)
                        SetCell(tree.HoneyPosXZ, new Cell());

                    var honeyData = HoneyWork.GetHoneyData(tree.ZoneID);
                    if (honeyData.HasValue)
                    {
                        int paramId;
                        switch (HoneyWork.CalcState(honeyData.Value))
                        {
                            case HoneyWork.State.HONEY_SPREAD_ALREADY:
                                paramId = 2;
                                break;

                            case HoneyWork.State.HONEY_SPREAD_ENCOUNT:
                                paramId = 3;
                                break;

                            default:
                                paramId = 1;
                                break;
                        }

                        Instantiate(_noticeParams[paramId].prefab, _noticeParams[paramId].root, false).transform.position = ToCellIconPos(tree.HoneyPosXZ);
                    }
                }
            }
        }

        protected void SetupHiddenMap()
        {
            for (int i=0; i<_hiddenMapParams.Length; i++)
                _hiddenMapParams[i].map.SetActive(GetCell(_hiddenMapParams[i].cell).IsArrive());
        }

        protected bool CanKinomiHarvest(KinomiPlaceData.SheetSheet1 placeData)
        {
            return KinomiWork.CalcGrowPhase(KinomiWork.GetGrow(placeData.Index)) == KinomiWork.GrowPhase.Fruit;
        }

        protected int GetIndex(TownMapTable.SheetData data, Vector2Int pos)
        {
            int x = pos.x > -1 ? pos.x : pos.x + 31;
            int y = pos.y > -1 ? pos.y : pos.y + 31;
            return data.Width * (y/32) + (x/32);
        }

        protected TownMapTable.SheetData GetData(ZoneID zoneId, Vector2Int pos)
        {
            _dataDictByZoneId.TryGetValue(zoneId, out var data);

            if (data != null)
                return data.FirstOrDefault(x => x.Index1 == GetIndex(x, pos)) ??
                       data.FirstOrDefault(x => x.Index2 == GetIndex(x, pos)) ??
                       data.FirstOrDefault(x => x.Index3 == GetIndex(x, pos));
            else
                return null;
        }

        protected TownMapTable.SheetData GetData(ZoneID zoneId, int index1)
        {
            _dataDictByZoneId.TryGetValue(zoneId, out var data);

            if (data != null)
                return data.FirstOrDefault(x => x.Index1 == index1);
            else
                return null;
        }

        protected Cell GetCell(Vector2 cellPos)
        {
            return _cells[(int)cellPos.y, (int)cellPos.x];
        }

        public void SetCell(Vector2 cellPos, Cell cell)
        {
            _cells[(int)cellPos.y, (int)cellPos.x] = cell;
        }

        public Cell GetCurrentCell()
        {
            return GetCell(ToCellPos(_cursorPos));
        }

        public Vector3 ToCellIconPos(Vector2 cellPos)
        {
            return new Vector3(_cellRoot.position.x + cellPos.x * CellSize, _cellRoot.position.y - cellPos.y * CellSize, _cellRoot.position.z) + new Vector3(12.0f, -12.0f, 0.0f);
        }

        public Vector2 ToCellPos(Vector3 iconPos)
        {
            var pos = iconPos - _cellRoot.position;
            return new Vector2(Mathf.FloorToInt(pos.x / CellSize), Mathf.FloorToInt(-pos.y / CellSize));
        }

        protected void SetPlayerPos(Vector2 cellPos)
        {
            _player.transform.position = ToCellIconPos(cellPos);
        }

        protected void SetCursorPos(Vector2 cellPos)
        {
            _cursorPos = ToCellIconPos(cellPos);
        }

        public void ResetCursorPos(bool isForce = false)
        {
            var prevPos = ToCellPos(_cursorPos);

            var cellpos = GetMapDataByPlayer()?.NowPosXZ ?? Vector2.zero;
            SetCursorPos(cellpos);

            var newPos = ToCellPos(_cursorPos);

            if (prevPos.x != newPos.x || prevPos.y != newPos.y || isForce)
                CellChanged(GetCurrentCell(), true, true); // Arguments are ignored and the actual values were removed by compiler optimization
        }

        public virtual bool OnUpdate(float deltaTime, UIInputController input)
        {
            return UpdateMove(deltaTime, input);
        }

        protected virtual bool UpdateMove(float deltaTime, UIInputController input)
        {
            if (UpdateAnalogMove(deltaTime, input))
                return true;

            return UpdateDigitalMove(deltaTime, input);
        }

        protected bool UpdateDigitalMove(float deltaTime, UIInputController input)
        {
            var prevPos = _cursorPos;

            if (input.IsOnButton(UIManager.StickLUp))
            {
                if (input.IsPushOrRepeatButton(UIManager.StickLUp))
                {
                    _cursorPos.y += CellSize;

                    if (input.IsOnButton(UIManager.StickLRight))
                        _cursorPos.x += CellSize;
                    else if (input.IsOnButton(UIManager.StickLLeft))
                        _cursorPos.x -= CellSize;
                }
            }
            else if (input.IsOnButton(UIManager.StickLDown))
            {
                if (input.IsPushOrRepeatButton(UIManager.StickLDown))
                {
                    _cursorPos.y -= CellSize;

                    if (input.IsOnButton(UIManager.StickLRight))
                        _cursorPos.x += CellSize;
                    else if (input.IsOnButton(UIManager.StickLLeft))
                        _cursorPos.x -= CellSize;
                }
            }
            else
            {
                if (input.IsPushOrRepeatButton(UIManager.StickLRight))
                    _cursorPos.x += CellSize;
                else if (input.IsPushOrRepeatButton(UIManager.StickLLeft))
                    _cursorPos.x -= CellSize;
            }

            if (prevPos.x == _cursorPos.x && prevPos.y == _cursorPos.y)
                return false;

            ClampCursorPos();

            var prevCell = GetCell(ToCellPos(prevPos));
            var cell = GetCurrentCell();
            if (prevCell != cell)
            {
                PlayCellChangeSe(cell);
                CellChanged(GetCurrentCell(), false, false); // Arguments are ignored and the actual values were removed by compiler optimization
            }

            return true;
        }

        protected void PlayCellChangeSe(Cell cell)
        {
            if (Cell.UseData(cell) && cell.IsView())
                AudioManager.Instance.PlaySe(AK.EVENTS.UI_MAP_ADSORPTION, null);
        }

        protected void ClampCursorPos()
        {
            _cursorPos.x = Mathf.Clamp(_cursorPos.x, _cellRoot.position.x + CellSize + CellSizeHalf, _cellRoot.position.x + _cellRoot.sizeDelta.x - CellSizeHalf);
            _cursorPos.y = Mathf.Clamp(_cursorPos.y, _cellRoot.position.y - _cellRoot.sizeDelta.y + CellSizeHalf, _cellRoot.position.y - CellSizeHalf);
        }

        protected bool UpdateAnalogMove(float deltaTime, UIInputController input)
        {
            if (!input.inputEnabled)
                return false;

            var prevMove = _moveVec;
            _moveVec = GameController.analogStickL;
            if (_moveVec.sqrMagnitude == 0.0f)
                _moveVec = GameController.analogStickR;

            if (_moveVec.sqrMagnitude > 0.0f)
            {
                var prevPos = ToCellPos(_cursorPos);

                float delta = deltaTime * 60.0f * _cursorSpeed;
                _cursorPos.x += delta * _moveVec.x;
                _cursorPos.y += delta * _moveVec.y;
                ClampCursorPos();

                var newPos = ToCellPos(_cursorPos);

                if (prevPos.x != newPos.x || prevPos.y != newPos.y)
                {
                    if (GetCell(prevPos) != GetCurrentCell())
                    {
                        _isAnalogCellChanged = true;
                        CellChanged(GetCurrentCell(), false, true); // Arguments are ignored and the actual values were removed by compiler optimization
                    }
                }

                return true;
            }

            if (prevMove.sqrMagnitude <= 0.0f)
            {
                _isAnalogCellChanged = false;
                return false;
            }

            var prevCellPos = ToCellPos(_cursorPos);
            var prevIconPos = ToCellIconPos(prevCellPos);
            GetAnalogStickIndex(_cursorPos - prevIconPos); // Result ignored

            var prevCell = GetCell(prevCellPos);
            if (!Cell.UseData(prevCell) || !UIManager.IsLeanFly() || !prevCell.data.FlyingAvailablePlace)
            {
                var directionVecs = new Vector2Int[8]
                {
                    new Vector2Int(-1, -1), new Vector2Int(0, -1),
                    new Vector2Int(1, -1),  new Vector2Int(-1, 0),
                    new Vector2Int(1, 0),   new Vector2Int(-1, 1),
                    new Vector2Int(0, 1),   new Vector2Int(1, 1),
                };

                float targetSnap = float.MaxValue;
                Cell targetCell = null;
                for (int i=0; i<directionVecs.Length; i++)
                {
                    var newX = directionVecs[i].x + (int)prevCellPos.x;
                    var newY = directionVecs[i].y + (int)prevCellPos.y;
                    if (newX < CellNumX && newY < CellNumY)
                    {
                        var cell = _cells[newY, newX];
                        if (Cell.UseData(cell) && cell.data.FlyingAvailablePlace)
                        {
                            var delta2D = new Vector2(directionVecs[i].x, -directionVecs[i].y).normalized * CellSize;
                            var newPos = new Vector3(prevIconPos.x + delta2D.x, prevIconPos.y + delta2D.y, prevIconPos.z);
                            var newMag = (newPos - _cursorPos).magnitude;
                            if (newMag < targetSnap)
                            {
                                targetSnap = newMag;
                                targetCell = cell;
                            }
                        }
                    }
                }

                if (targetCell != null && targetSnap <= _snapDistance)
                {
                    SetCursorPos(targetCell.data.TownPosXZ);

                    if (prevCellPos.x != targetCell.data.TownPosXZ.x || prevCellPos.y != targetCell.data.TownPosXZ.y)
                    {
                        _isAnalogCellChanged = true;
                        CellChanged(GetCurrentCell(), false, true); // Arguments are ignored and the actual values were removed by compiler optimization
                    }

                    prevCellPos = targetCell.data.TownPosXZ;
                }
            }

            if (_isAnalogCellChanged)
                PlayCellChangeSe(GetCell(prevCellPos));

            SetCursorPos(prevCellPos);

            _isAnalogCellChanged = false;
            return false;
        }

        private static int GetAnalogStickIndex(Vector2 analogStick)
        {
            float angle = Mathf.Atan2(-analogStick.x, -analogStick.y);
            angle = Mathf.Repeat(angle * Mathf.Rad2Deg + 180.0f + 360.0f - 22.5f, 360.0f);
            return (int)(angle / 45.0f + 1.0f) % 8;
        }

        public void SetNoticeType(NoticeType type)
        {
            for (int i=0; i<_noticeParams.Length; i++)
                _noticeParams[i].root.gameObject.SetActive((int)type == i);
        }

        private void CellChanged(Cell cell, bool isReset, bool isAnalogMoveing)
        {
            _onCellChanged?.Invoke(GetCurrentCell(), false);
        }

        [Serializable]
        protected class NoticeParam
        {
            public RectTransform root;
            public TownmapIcon prefab;
        }

        [Serializable]
        protected class HiddenMapParam
        {
            public Vector2Int cell = Vector2Int.zero;
            public RectTransform map;
        }

        [Serializable]
        protected class Patch0DayParam
        {
            public Image _cloud;
            public Image _road;

            public void Enable(bool enabled)
            {
                _cloud.gameObject.SetActive(!enabled);
                _road.gameObject.SetActive(enabled);
            }
        }

        public enum TownmapType : int
        {
            Default = 0,
            Field = 1,
            Fly = 2,
        }

        public enum NoticeType : int
        {
            None = -1,
            Kinomi = 0,
            Tree = 1,
            TreeWithHoneyWait = 2,
            TreeWithHoney = 3,
            Num = 4,
        }

        public class Cell
        {
            public TownMapTable.SheetData data;
            public List<TownmapSymbol> symbols;
            public int[] habitats = new int[6];

            public static bool UseData(Cell cell)
            {
                return cell?.data != null;
            }

            public bool IsView()
            {
                return data.ViewFlag >= EvScript.EvWork.WORK_INDEX.SCWK_WK_END || FlagWork.GetWork(data.ViewFlag) != 0;
            }

            public bool IsArrive()
            {
                bool isTown = GameManager.mapInfo[(int)data.zoneID].MapType == MapType.MAPTYPE_TOWN;
                bool colorOn = data.ColorOnFlag < EvScript.EvWork.SYSFLAG_INDEX.SYSFLAG_END && FlagWork.GetSysFlag(data.ColorOnFlag);

                return IsView() && (!isTown || colorOn);
            }

            public bool IsFly(bool useArrive)
            {
                return UIManager.IsLeanFly() && (!useArrive || IsArrive()) && data.FlyingAvailablePlace;
            }

            public static int GetHabitatIndex(SheetDistributionTable.HabitatType type, SheetDistributionTable.TimeZoneType timeZone)
            {
                return ((int)type) * 3 + ((int)timeZone);
            }

            public int GetHabitatBits(SheetDistributionTable.HabitatType habitatType, SheetDistributionTable.TimeZoneType timeZone)
            {
                return habitats[GetHabitatIndex(habitatType, timeZone)];
            }

            public class Kinomi
            {
                public KinomiData.SheetData data;
                public KinomiPlaceData.SheetSheet1 placeData;
            }

            [Flags]
            public enum HabitatBits : int
            {
                Fishing = 1,
                PokemonTraser = 2,
                HoneyTree = 4,
                Normal = 8,
                Set = 16,
                All = 15,
            }
        }
    }
}