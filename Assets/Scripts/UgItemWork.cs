using Dpr.Item;
using System.Collections.Generic;
using XLSXContent;

public class UgItemWork
{
    private static UgItemWork _instance;
    private UgItemInfo[] _items;

    public static void Create()
    {
        if (_instance != null)
            return;

        _instance = new UgItemWork();
    }

    // TODO
    private static int AddItem(int itemno, int num = 1) { return 0; }

    // TODO
    private static int SubItem(int itemno, int num = 1) { return 0; }

    // TODO
    public static int AddUgItem(int ugItemNo, int num = 1) { return 0; }

    // TODO
    public static int SubUgItem(int ugItemNo, int num = 1) { return 0; }

    // TODO
    public static bool IsAddItem(int ugItemNo, int num = 1) { return false; }

    // TODO
    public static UgItemInfo GetItemInfo(int itemno) { return null; }

    // TODO
    public static ItemTable.SheetItem GetItemData(ushort id) { return null; }

    // TODO
    public static bool hasStatue() { return false; }

    // TODO
    public static List<UgItemInfo> GetBagItem() { return null; }

    // TODO
    public static List<UgItemInfo> GetDoNotHaveStatue() { return null; }

    // TODO
    public static int GetHaveStatueKindNum() { return 0; }

    public UgItemWork()
    {
        _items = new UgItemInfo[UgItemInfo.ItemSaveSize];
        for (int i = 0; i < _items.Length; i++)
            _items[i] = new UgItemInfo(i);
    }
}