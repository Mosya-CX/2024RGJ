using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "基因突变相关/基因突变类型/1008", fileName = "Mutation1008")]
public class Mutation1008 : BaseMutation
{
    public string Des;
    public Sprite Icon;

    public override string _Des => Des;
    public override Sprite _Sprite => Icon;
    public override bool TryMutate()
    {
        if (GameManager.Instance.playerData.shield == 0)
        {
            GameManager.Instance.playerData.shield = 1;
        }
        return true;
    }
}
