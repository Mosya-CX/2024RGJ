using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1004", fileName = "Mutation1004")]
public class Mutation1004 : BaseMutation
{
    public override bool TryMutate()
    {
        foreach (var missileData in GameManager.Instance.playerData.missileHandler.totalMissileList)
        {
            missileData.speed *= 1.1f;
        }
        return true;
    }
}
