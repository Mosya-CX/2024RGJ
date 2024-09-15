using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1008", fileName = "Mutation1008")]
public class Mutation1008 : BaseMutation
{
    public override bool TryMutate()
    {
        if (GameManager.Instance.playerData.shield == 0)
        {
            GameManager.Instance.playerData.shield = 1;
        }
        return true;
    }
}
