using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "基因突变相关/基因突变类型/1004", fileName = "Mutation1004")]
public class Mutation1004 : BaseMutation
{
    public string Des;
    public Sprite Icon;
    public float amt = 1.1f;
    public override string _Des => Des;
    public override Sprite _Sprite => Icon;
    public override bool TryMutate()
    {
        foreach (var missileData in GameManager.Instance.playerData.missileHandler.totalMissileList)
        {
            missileData.speed *= amt;
        }
        return true;
    }
}
