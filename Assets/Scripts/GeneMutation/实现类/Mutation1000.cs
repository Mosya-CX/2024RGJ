using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1000", fileName = "Mutation1000")]
public class Mutation1000 : BaseMutation
{
    public string Des;
    public Sprite Icon;

    public override bool TryMutate()
    {
        foreach (var missileData in GameManager.Instance.playerData.missileHandler.totalMissileList)
        {
            missileData.number++;
        }
        return true;
    }
}
