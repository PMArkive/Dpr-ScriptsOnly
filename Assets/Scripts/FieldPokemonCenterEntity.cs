using Dpr.EvScript;
using Pml;
using UnityEngine;

public class FieldPokemonCenterEntity : FieldEventEntity
{
    public Vector3[] BallPositions = new Vector3[6]
    {
        new Vector3(-0.68f, 0.6f, -2.2f),
        new Vector3(-1.32f, 0.6f, -2.2f),
        new Vector3(-0.68f, 0.6f, -1.8f),
        new Vector3(-1.32f, 0.6f, -1.8f),
        new Vector3(-0.68f, 0.6f, -1.4f),
        new Vector3(-1.32f, 0.6f, -1.4f),
    };
    public float BallScale = 3.0f;
    private GameObject[] BallObjects = new GameObject[6];
    private EffectFieldID[] EffectId = new EffectFieldID[6];

    public void PutBall(int index, BallId ballId)
    {
        DestroyBall(index);

        var ball = Instantiate(EvDataManager.Instanse.PokemonCenter.GetBallObject(ballId));
        ball.transform.SetParent(transform);
        ball.transform.localPosition = BallPositions[index];
        ball.transform.localScale = Vector3.one * BallScale;
        BallObjects[index] = ball;

        switch (ballId)
        {
            case BallId.PURESYASUBOORU:
                EffectId[index] = EffectFieldID.EF_F_BG_PMCENTER_OB216;
                break;

            case BallId.HEBIIBOORU:
                EffectId[index] = EffectFieldID.EF_F_BG_PMCENTER_OB220;
                break;

            case BallId.URUTORABOORU:
                EffectId[index] = EffectFieldID.EF_F_BG_PMCENTER_OB226;
                break;

            default:
                EffectId[index] = EffectFieldID.EF_F_BG_PMCENTER_BALL;
                break;
        }
    }

    public void DestroyAllBall()
    {
        for (int i=0; i<BallObjects.Length; i++)
            DestroyBall(i);
    }

    public void PlayHealEffect()
    {
        for (int i=0; i<BallObjects.Length; i++)
        {
            var ball = BallObjects[i];
            if (ball == null)
                continue;

            var effect = EffectId[i];
            if (effect == EffectFieldID.NONE)
                continue;

            FieldManager.Instance.CallEffect(effect, ball.transform, eff =>
            {
                eff.gameObject.transform.localScale = Vector3.one * BallScale;
            }, null);
        }
    }

    private void DestroyBall(int index)
    {
        if (BallObjects[index] == null)
            return;

        BallObjects[index].SetActive(false);
        Destroy(BallObjects[index]);
        BallObjects[index] = null;
    }
}