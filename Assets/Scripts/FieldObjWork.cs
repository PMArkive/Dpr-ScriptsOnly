using DPData;
using System.Collections.Generic;

public class FieldObjWork
{
    private bool isBuild;
    private Dictionary<int, int> _find_index;
    private static FieldObjWork _instance;

    private static FieldObjWork Inst
    {
        get
        {
            if (_instance != null)
                return _instance;

            _instance = new FieldObjWork();
            return _instance;
        }
    }

    private void BuildData()
    {
        if (isBuild)
            return;

        var fieldObjs = PlayerWork.fieldObjSave;
        if (fieldObjs.fldobj_sv.Length < _FIELDOBJ_SAVE.MAX)
        {
            fieldObjs.fldobj_sv = new FIELD_OBJ_SAVE_DATA[_FIELDOBJ_SAVE.MAX];
            for (int i=0; i<PlayerWork.fieldObjSave.fldobj_sv.Length; i++)
                fieldObjs.fldobj_sv[i] = PlayerWork.fieldObjSave.fldobj_sv[i];

            PlayerWork.fieldObjSave = fieldObjs;
        }

        _find_index = new Dictionary<int, int>(_FIELDOBJ_SAVE.MAX);
        for (int i=0; i<PlayerWork.fieldObjSave.fldobj_sv.Length; i++)
        {
            var fieldObj = PlayerWork.fieldObjSave.fldobj_sv[i];
            if (!_find_index.ContainsKey(fieldObj.name_hash))
                _find_index.Add(fieldObj.name_hash, i);
        }

        isBuild = true;
    }

    public static FIELD_OBJ_SAVE_DATA Get(int hash, out bool flag)
    {
        flag = false;

        Inst.BuildData();

        if (!Inst._find_index.ContainsKey(hash))
            return default(FIELD_OBJ_SAVE_DATA);

        int index = Inst._find_index[hash];
        if (PlayerWork.fieldObjSave.fldobj_sv[index].cnt == 0)
            return default(FIELD_OBJ_SAVE_DATA);

        flag = true;
        return PlayerWork.fieldObjSave.fldobj_sv[index];
    }

    public static void Set(FIELD_OBJ_SAVE_DATA data)
    {
        Inst.BuildData();

        if (!Inst._find_index.ContainsKey(data.name_hash))
        {
            for (int i=0; i<PlayerWork.fieldObjSave.fldobj_sv.Length; i++)
            {
                if (PlayerWork.fieldObjSave.fldobj_sv[i].cnt == 0)
                {
                    data.cnt = 1;
                    PlayerWork.fieldObjSave.fldobj_sv[i] = data;
                    Inst._find_index.Add(data.name_hash, i);
                    break;
                }
            }
        }
        else
        {
            var index = Inst._find_index[data.name_hash];
            data.cnt = 1;
            PlayerWork.fieldObjSave.fldobj_sv[index] = data;
        }
    }

    public static void Clear()
    {
        if (Inst._find_index == null)
            Inst._find_index = new Dictionary<int, int>();

        Inst._find_index.Clear();

        for (int i=0; i<PlayerWork.fieldObjSave.fldobj_sv.Length; i++)
            PlayerWork.fieldObjSave.fldobj_sv[i] = default(FIELD_OBJ_SAVE_DATA);
    }
}