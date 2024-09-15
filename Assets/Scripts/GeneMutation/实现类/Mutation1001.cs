using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1001", fileName = "Mutation1001")]
public class Mutation1001 : BaseMutation
{
    public string Des;
    public Sprite Icon;

    public override string _Des => Des;
    public override Sprite _Sprite => Icon;
    public override bool TryMutate()
    {
        foreach (var missileData in GameManager.Instance.playerData.missileHandler.totalMissileList)
        {
            missileData.attackSpace *= 0.8f;
        }
        return true;
    }
}
