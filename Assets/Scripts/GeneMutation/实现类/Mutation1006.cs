using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1006", fileName = "Mutation1006")]
public class Mutation1006 : BaseMutation
{
    public override bool TryMutate()
    {
        GameManager.Instance.playerData.moveSpeed *= 1.2f;
        return true;
    }
}
