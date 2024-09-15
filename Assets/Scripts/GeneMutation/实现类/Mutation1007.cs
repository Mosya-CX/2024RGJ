using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "基因突变相关/基因突变类型/1007", fileName = "Mutation1007")]
public class Mutation1007 : BaseMutation
{
    public override bool TryMutate()
    {
        if (GameManager.Instance.playerData.hp < 3)
        {
            GameManager.Instance.playerData.hp++;
        }
        return true;
    }
}
