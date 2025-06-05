using UnityEngine;

public class EncEffectSeqDataTable : ScriptableObject
{
    [Tooltip("[0] Morning\n[1] Daytime\n[2] Evening\n[3] Night\n[4] Midnight")]
    public Color[] DayColor;

    public EncEffectSeqDataTable() : base()
    {
        DayColor = new Color[5]
        {
            Color.white, Color.white, Color.white, Color.white, Color.white,
        };
    }
}