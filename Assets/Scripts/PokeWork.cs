using DPData;
using Pml;
using Pml.PokePara;
using UnityEngine;

public static class PokeWork
{
    public static void WalkNatukiUpdate(int diff)
    {
        PlayerWork.natuki_walkcnt = PlayerWork.natuki_walkcnt - diff;

        if (PlayerWork.natuki_walkcnt < 1)
        {
            PlayerWork.natuki_walkcnt = 128;
            if (Random.Range(0, 2) != 1)
            {
                var party = PlayerWork.playerParty;
                for (uint i=0; i!=party.GetMemberCount(); i++)
                {
                    var member = party.GetMemberPointer(i);
                    if (!member.IsEgg(EggCheckType.BOTH_EGG))
                        member.AddFriendship(1);
                }
            }
        }
    }

    public static void CheckTimeChangeLandformSheimi()
    {
        if (GameManager.nowTime.Hour > 19 || GameManager.nowTime.Hour < 4)
        {
            var party = PlayerWork.playerParty;
            for (uint i=0; i!=party.GetMemberCount(); i++)
                ChangeLandformSheimi(party.GetMemberPointer(i));
        }
    }

    public static void ChangeLandformSheimi(PokemonParam param)
    {
        if (param != null && !param.IsNull() && !param.IsEgg(EggCheckType.BOTH_EGG) && param.GetMonsNo() == MonsNo.SHEIMI)
        {
            param.ChangeFormNo((ushort)SHEIMI_NUM.LAND, null);
            FieldManager.fwMng?.CheckPartnerPokeChange(param, false);
        }
    }
}