using Pml;
using Pml.Item;
using SmartPoint.AssetAssistant;
using UnityEngine;

public class FieldPokemonCenter
{
    private GameObject[] BallObjects;
    private AssetRequestOperation[] BallObjectLoads;

    public void Initialize()
    {
        BallObjects = new GameObject[(int)BallId.MAX + 1];
        BallObjectLoads = new AssetRequestOperation[(int)BallId.MAX + 1];
    }

    public void LoadTemotiBall()
    {
        bool newLoads = false;

        for (uint i=0; i<PlayerWork.playerParty.GetMemberCount(); i++)
        {
            var member = PlayerWork.playerParty.GetMemberPointer(i);

            if (member.IsEgg(Pml.PokePara.EggCheckType.BOTH_EGG))
                continue;

            var ballIndex = CheckBallId((BallId)member.GetGetBall());

            if (BallObjectLoads[(int)ballIndex] != null)
                continue;

            string assetBundleName = string.Format("{0}/ob{1:D4}_00", "objects", ballIndex == BallId.MAX ? 299 : (200 + (byte)ballIndex));
            BallObjectLoads[(int)ballIndex] = AssetManager.AppendAssetBundleRequest(assetBundleName, true, (type, name, content) =>
            {
                if (type != RequestEventType.Activated)
                    return;

                OnLoadedBallObject((int)ballIndex, content);
            }, null);

            newLoads = true;
        }

        if (newLoads)
            AssetManager.DispatchRequests(null);
    }

    public bool IsLoadedTemotiBall()
    {
        for (uint i=0; i<PlayerWork.playerParty.GetMemberCount(); i++)
        {
            var member = PlayerWork.playerParty.GetMemberPointer(i);

            if (member.IsEgg(Pml.PokePara.EggCheckType.BOTH_EGG))
                continue;

            var ballIndex = CheckBallId((BallId)member.GetGetBall());

            if (BallObjectLoads[(int)ballIndex] == null)
                return false;
        }

        return true;
    }

    public void ReleaseAll()
    {
        if (BallObjects != null)
        {
            for (int i=0; i<BallObjects.Length; i++)
                BallObjects[i] = null;
        }

        if (BallObjectLoads != null)
        {
            for (int i=0; i< BallObjectLoads.Length; i++)
            {
                if (BallObjectLoads[i] == null)
                    continue;

                AssetManager.UnloadAssetBundle(BallObjectLoads[i].assetBundleRequest.uri);
                BallObjectLoads[i] = null;
            }
        }
    }

    public GameObject GetBallObject(BallId ballId)
    {
        return BallObjects[(int)CheckBallId(ballId)];
    }

    private void OnLoadedBallObject(int index, Object content)
    {
        var go = content as GameObject;

        if (go == null)
            return;

        BallObjects[index] = go;
    }

    private BallId CheckBallId(BallId ballId)
    {
        return ItemManager.IsStrangeBall(ballId) ? BallId.MAX : ballId;
    }
}