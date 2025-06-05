using Dpr.Item;
using Dpr.UI;
using Pml;
using Pml.Item;
using System.Collections.Generic;
using XLSXContent;

public class ItemWork
{
    private static ItemWork _instance;
    private static ItemWork _temp_instance;
    private ItemInfo[] _items;
    private List<ItemInfo>[] _categorizedItems;
    private ItemListMemory[] _itemListMemories;
    private bool _bagIconSex;
    private bool _isShowWazaName;

    public static void Create()
    {
        if (_instance != null)
            return;

        _instance = new ItemWork();
    }

    // TODO
    public static void EnableDummyWork() { }

    // TODO
    public static void DisableDummyWork() { }

    // TODO
    public static int AddItem(int itemno, int num = 1) { return 0; }

    // TODO
    public static int SubItem(int itemno, int num = 1) { return 0; }

    // TODO
    public static bool IsAddItem(int itemno, int num = 1) { return false; }

    // TODO
    public static ItemInfo GetItemInfo(int itemno) { return null; }

    // TODO
    public static List<ItemInfo> GetItemInfosByCategory(ItemInfo.CategoryType category) { return null; }

    // TODO
    public static List<ItemInfo> GetItemInfosByCategory(int categoryId) { return null; }

    // TODO
    public static ItemTable.SheetItem GetItemData(ushort id) { return null; }

    // TODO
    public static bool IsIncludeNewItem(ItemInfo.CategoryType category) { return false; }

    // TODO
    public static bool IsIncludeNewItem(int categoryId) { return false; }

    // TODO
    public static bool IsIncludeFavoriteItem(ItemInfo.CategoryType category) { return false; }

    // TODO
    public static bool IsIncludeFavoriteItem(int categoryId) { return false; }

    // TODO
    public static List<ItemInfo> GetBagItem() { return null; }

    // TODO
    public static void SortItemInfosByCategory(ItemInfo.CategoryType category, ItemInfo.SortType sortType) { }

    // TODO
    public static void SortItemInfosByCategory(int categoryId, ItemInfo.SortType sortType) { }

    // TODO
    public static bool IsCategory(int itemno, ItemInfo.CategoryType category) { return false; }

    // TODO
    public static bool IsWazaMachine(int itemno) { return false; }

    // TODO
    public static ItemListMemory GetItemListMemory(UIBag.BootType bootType) { return null; }

    // TODO
    public static void ResetItemListMemory(UIBag.BootType bootType) { }

    // TODO
    public static bool IsDsPlayer() { return false; }

    // TODO
    public static void SetDsPlayer(bool flag) { }

    // TODO
    public static bool GetBagIconSex() { return false; }

    // TODO
    public static void SetBagIconSex(bool sex) { }

    // TODO
    public static bool IsUseSpray(out ItemNo itemno)
    {
        itemno = ItemNo.DUMMY_DATA;
        return false;
    }

    // TODO
    public static void SetSpray(ItemNo itemno, short value) { }

    // TODO
    public static short GetSprayCount() { return 0; }

    // TODO
    public static void SubSprayCount(short subval) { }

    // TODO
    public static int GetValidSaveSortNumberCount(ItemInfo.CategoryType category) { return 0; }

    // TODO
    public static int GetValidSaveSortNumberCount(int category) { return 0; }

    // TODO
    public static void UpdateListSort(ItemInfo itemInfo) { }

    // TODO
    public static bool IsShowWazaName() { return false; }

    public ItemWork(bool isDummy = false)
    {
        _items = new ItemInfo[ItemInfo.ItemSaveSize];
        _categorizedItems = new List<ItemInfo>[(int)ItemInfo.CategoryType.Length];

        for (int i=0; i<_categorizedItems.Length; i++)
            _categorizedItems[i] = new List<ItemInfo>();

        for (ushort i=0; i<_items.Length; i++)
        {
            _items[i] = new ItemInfo(i, isDummy);
            _categorizedItems[(int)_items[i].Category].Add(_items[i]);
        }

        for (int i=0; i<UIManager.Instance.searchIndexData.ItemName.Length; i++)
        {
            var item = UIManager.Instance.searchIndexData.ItemName[i];
            string[] splitMsgID = item.MessageID.Split(new char[1] { '_' });
            if (int.TryParse(splitMsgID[1], out int msgID))
            {
                if (msgID < _items.Length)
                    break;

                _items[msgID].NameSortOrder = i;
            }
        }

        var wazaSortOder = new Dictionary<int, int>();
        for (int i=0; i<UIManager.Instance.searchIndexData.WazaName.Length; i++)
        {
            var item = UIManager.Instance.searchIndexData.WazaName[i];
            string[] splitMsgID = item.MessageID.Split(new char[1] { '_' });
            if (int.TryParse(splitMsgID[1], out int msgID))
                wazaSortOder.Add(msgID, i);
        }

        var tms = _categorizedItems[(int)ItemInfo.CategoryType.WazaMachine];
        for (int i=0; i<tms.Count; i++)
        {
            WazaNo wazano = ItemData.GetWazaNo((ushort)tms[i].Id);
            if (wazaSortOder.TryGetValue((int)wazano, out int sortOrder))
                tms[i].NameSortOrder = sortOrder;

            if (!_isShowWazaName)
                _isShowWazaName = tms[i].IsShowWazaName;
        }

        for (int i=0; i<_categorizedItems.Length; i++)
            _categorizedItems[i].Sort((x, y) => x.SaveSortNumber.CompareTo(y.SaveSortNumber));

        _itemListMemories = new ItemListMemory[8];
        for (int i=0; i<_itemListMemories.Length; i++)
            _itemListMemories[i] = new ItemListMemory();

        _bagIconSex = PlayerWork.playerSex;
    }
}