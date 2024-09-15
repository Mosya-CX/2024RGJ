using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/Ͷ��������", fileName = "MissileMutation")]
public class Mutation1009 : BaseMutation
{
    public int missileId;
    public override bool TryMutate()
    {
        MissileInfo info = null;
        MissileHandler missileHandler = GameManager.Instance.playerData.missileHandler;
        foreach (var m in missileHandler.totalMissileList)
        {
            if (m.missileData.id == missileId)
            {
                info = m;
                break;
            }
        }
        if (info == null)
        {
            missileHandler.AddMissile(Resources.Load<BaseMissile>("Data/ScriptableObject/Missile/Missle" + missileId.ToString()));
        }
        else
        {
            info.grade++;
            if (info.grade == MissileGrade.Good)
            {
                GeneMutationManager.Instance.mutationList.Remove(this);
            }
        }

        return true;
    }
}
