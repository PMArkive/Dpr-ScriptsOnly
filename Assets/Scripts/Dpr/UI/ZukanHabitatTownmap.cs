using Pml.PokePara;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using XLSXContent;

namespace Dpr.UI
{
    public class ZukanHabitatTownmap : Townmap
    {
        [SerializeField]
        private RectTransform[] _habitatRoots;
        [SerializeField]
        private Image _habitatItem;
        [SerializeField]
        private RectTransform _notFound;
        private SheetDistributionTable.HabitatType _type;
        private bool[] _notfounds = new bool[6];
        private bool _isNotfound = true;

        public SheetDistributionTable.HabitatType habitatType { get => _type; }
        public bool isNotfound { get => _isNotfound; }

        public void Setup(PokemonParam pokemonParam, SheetDistributionTable.TimeZoneType timeZone, UnityAction<Cell, bool> onCellChanged)
        {
            base.Setup(TownmapType.Field, null, onCellChanged);
            SetNoticeType(NoticeType.None);

            var fieldGrids = new List<Vector2Int>();
            var fieldDistData = UIManager.Instance.GetDistributionDatas(true)[(int)pokemonParam.GetMonsNo()];

            SetupSpecial(fieldGrids, fieldDistData, SheetDistributionTable.HabitatType.Field, SheetDistributionTable.SpecialType.Fishing);
            SetupSpecial(fieldGrids, fieldDistData, SheetDistributionTable.HabitatType.Field, SheetDistributionTable.SpecialType.PokemonTraser);
            SetupSpecial(fieldGrids, fieldDistData, SheetDistributionTable.HabitatType.Field, SheetDistributionTable.SpecialType.HoneyTree);

            SetupHabitat(new List<Vector2Int>(fieldGrids), fieldDistData, SheetDistributionTable.HabitatType.Field, SheetDistributionTable.TimeZoneType.Morning);
            SetupHabitat(new List<Vector2Int>(fieldGrids), fieldDistData, SheetDistributionTable.HabitatType.Field, SheetDistributionTable.TimeZoneType.Daytime);
            SetupHabitat(new List<Vector2Int>(fieldGrids), fieldDistData, SheetDistributionTable.HabitatType.Field, SheetDistributionTable.TimeZoneType.Night);

            var dungeonGrids = new List<Vector2Int>();
            var dungeonDistData = UIManager.Instance.GetDistributionDatas(false)[(int)pokemonParam.GetMonsNo()];

            SetupSpecial(dungeonGrids, dungeonDistData, SheetDistributionTable.HabitatType.Dungeon, SheetDistributionTable.SpecialType.Fishing);
            SetupSpecial(dungeonGrids, dungeonDistData, SheetDistributionTable.HabitatType.Dungeon, SheetDistributionTable.SpecialType.PokemonTraser);
            SetupSpecial(dungeonGrids, dungeonDistData, SheetDistributionTable.HabitatType.Dungeon, SheetDistributionTable.SpecialType.HoneyTree);

            SetupHabitat(new List<Vector2Int>(dungeonGrids), dungeonDistData, SheetDistributionTable.HabitatType.Dungeon, SheetDistributionTable.TimeZoneType.Morning);
            SetupHabitat(new List<Vector2Int>(dungeonGrids), dungeonDistData, SheetDistributionTable.HabitatType.Dungeon, SheetDistributionTable.TimeZoneType.Daytime);
            SetupHabitat(new List<Vector2Int>(dungeonGrids), dungeonDistData, SheetDistributionTable.HabitatType.Dungeon, SheetDistributionTable.TimeZoneType.Night);

            ShowHabitat(SheetDistributionTable.HabitatType.Field, timeZone);
        }

        private void SetupSpecial(List<Vector2Int> grids, SheetDistributionTable distData, SheetDistributionTable.HabitatType habitatType, SheetDistributionTable.SpecialType type)
        {
            var mapIds = distData.GetSpecialMapIds(type);
            var mapDists = UIManager.Instance.distributionTable.MapDistribution;

            for (int i=0; i<mapIds.Count; i++)
            {
                var lightUpGrids = mapDists[mapIds[i]].LightUpGridXZ;
                for (int j=0; j<lightUpGrids.Length; j++)
                {
                    var lightUpGrid = lightUpGrids[j];
                    if (lightUpGrid.x < 0 || lightUpGrid.y < 0)
                        break;

                    if (_cells[lightUpGrid.y, lightUpGrid.x] == null)
                        _cells[lightUpGrid.y, lightUpGrid.x] = new Cell();

                    var cell = _cells[lightUpGrid.y, lightUpGrid.x];
                    if (!Cell.UseData(cell) || cell.IsView())
                    {
                        grids.Add(lightUpGrid);
                        cell.habitats[Cell.GetHabitatIndex(habitatType, SheetDistributionTable.TimeZoneType.Morning)] |= 1 << (int)habitatType;
                        cell.habitats[Cell.GetHabitatIndex(habitatType, SheetDistributionTable.TimeZoneType.Daytime)] |= 1 << (int)habitatType;
                        cell.habitats[Cell.GetHabitatIndex(habitatType, SheetDistributionTable.TimeZoneType.Night)]   |= 1 << (int)habitatType;
                    }
                }
            }
        }

        private void SetupNormal(List<Vector2Int> grids, SheetDistributionTable distData, SheetDistributionTable.HabitatType type, SheetDistributionTable.TimeZoneType timeZone)
        {
            var mapIds = distData.GetMapIds(timeZone, ZukanWork.GetZenkokuFlag());
            var mapDists = UIManager.Instance.distributionTable.MapDistribution;

            for (int i=0; i<mapIds.Count; i++)
            {
                var lightUpGrids = mapDists[mapIds[i]].LightUpGridXZ;
                for (int j=0; j<lightUpGrids.Length; j++)
                {
                    var lightUpGrid = lightUpGrids[j];
                    if (lightUpGrid.x < 0 || lightUpGrid.y < 0)
                        break;

                    if (_cells[lightUpGrid.y, lightUpGrid.x] == null)
                        _cells[lightUpGrid.y, lightUpGrid.x] = new Cell();

                    var cell = _cells[lightUpGrid.y, lightUpGrid.x];
                    if (!Cell.UseData(cell) || cell.IsView())
                    {
                        grids.Add(lightUpGrid);
                        cell.habitats[Cell.GetHabitatIndex(type, timeZone)] |= (int)Cell.HabitatBits.Normal;
                    }
                }
            }
        }

        private void SetupHabitat(List<Vector2Int> grids, SheetDistributionTable distData, SheetDistributionTable.HabitatType type, SheetDistributionTable.TimeZoneType timeZone)
        {
            SetupNormal(grids, distData, type, timeZone);

            int habitatIndex = Cell.GetHabitatIndex(type, timeZone);
            var habitatRoot = _habitatRoots[habitatIndex];

            _habitatItem.gameObject.SetActive(false);
            int childIndex = 0;
            for (int i=0; i<grids.Count; i++)
            {
                var grid = grids[i];
                var habitat = _cells[grid.y, grid.x].habitats[habitatIndex];

                if (!((Cell.HabitatBits)habitat).HasFlag(Cell.HabitatBits.Set))
                {
                    _cells[grid.y, grid.x].habitats[habitatIndex] |= (int)Cell.HabitatBits.Set;
                    var mapchip = GetMapchipData(grid, type, timeZone);

                    var img = habitatRoot.childCount < childIndex+1 ? Instantiate(_habitatItem, habitatRoot, false) : habitatRoot.GetChild(childIndex).GetComponent<Image>();
                    img.transform.position = ToCellIconPos(grid);
                    img.sprite = UIManager.Instance.GetAtlasSprite(SpriteAtlasID.ZUKAN, mapchip.SpriteName);

                    var scale = img.transform.localScale;
                    scale.x = mapchip.FlipX ? -1.0f : 1.0f;
                    scale.y = mapchip.FlipY ? -1.0f : 1.0f;
                    img.transform.localScale = scale;

                    img.gameObject.SetActive(true);
                    childIndex++;
                }
            }

            for (int i=childIndex; i<habitatRoot.childCount; i++)
                habitatRoot.GetChild(i).gameObject.SetActive(false);

            _notfounds[habitatIndex] = grids.Count == 0;
        }

        private UIDatabase.SheetDistributionMapchip GetMapchipData(Vector2Int grid, SheetDistributionTable.HabitatType type, SheetDistributionTable.TimeZoneType timeZone)
        {
            var dirs = new Vector2Int[8]
            {
                new Vector2Int(-1, -1), new Vector2Int(0, -1),
                new Vector2Int(1, -1),  new Vector2Int(-1, 0),
                new Vector2Int(1, 0),   new Vector2Int(-1, 1),
                new Vector2Int(0, 1),   new Vector2Int(1, 1),
            };

            int neighbours = 0;
            for (int i=0; i<dirs.Length; i++)
            {
                var newX = grid.x + dirs[i].x;
                var newY = grid.y + dirs[i].y;
                if (newX < CellNumX && newY < CellNumY)
                {
                    var cell = _cells[newY, newX];
                    if (cell != null && (cell.habitats[Cell.GetHabitatIndex(type, timeZone)] & (int)Cell.HabitatBits.All) != 0)
                        neighbours |= 1 << (7-i);
                }
            }

            return UIManager.Instance.database.DistributionMapchip[neighbours];
        }

        public void ShowHabitat(SheetDistributionTable.HabitatType type, SheetDistributionTable.TimeZoneType timeZone)
        {
            int habitatIndex = Cell.GetHabitatIndex(type, timeZone);

            for (int i=0; i<_habitatRoots.Length; i++)
                _habitatRoots[i].gameObject.SetActive(habitatIndex == i);

            _type = type;
            _isNotfound = _notfounds[habitatIndex];

            for (int i=0; i<_notfounds.Length; i++)
            {
                _notFound.gameObject.SetActive(_notfounds[i]);
                _onCellChanged.Invoke(GetCurrentCell(), false);
            }
        }

        protected override bool UpdateMove(float deltaTime, UIInputController input)
        {
            if (_isNotfound)
                return false;

            return UpdateMove(deltaTime, input);
        }
    }
}