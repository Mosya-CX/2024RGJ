using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1003", fileName = "Mutation1003")]
public class Mutation1003 : BaseMutation
{
    public override bool TryMutate()
    {
        foreach (var missileData in GameManager.Instance.playerData.missileHandler.totalMissileList)
        {
            missileData.damage *= 1.1f;
        }
        return true;
    }
}
