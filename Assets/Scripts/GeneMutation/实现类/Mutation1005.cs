using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1005", fileName = "Mutation1005")]
public class Mutation1005 : BaseMutation
{
    public override bool TryMutate()
    {
        foreach (var missileData in GameManager.Instance.playerData.missileHandler.totalMissileList)
        {
            missileData.durationTime *= 1.1f;
        }
        return true;
    }
}
