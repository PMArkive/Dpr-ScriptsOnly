using UnityEngine;

[CreateAssetMenu(fileName = "Curves", menuName = "ScriptableObjects/CurvePatterns")]
public class CurvePatterns : ScriptableObject
{
    [SerializeField]
    private AnimationCurve[] curves;

	public float[] times { get; set; }
    public int Count { get => curves.Length; }

    public void OnEnable()
    {
        times = new float[curves.Length];

        for (int i=0; i<curves.Length; i++)
            times[i] = curves[i].keys[curves[i].length - 1].time;
    }

    public AnimationCurve this[int index] => curves[index];
}