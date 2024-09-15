using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1002", fileName = "Mutation1002")]
public class Mutation1002 : BaseMutation
{
    public string Des;
    public Sprite Icon;

    public override string _Des => Des;
    public override Sprite _Sprite => Icon;
    public override bool TryMutate()
    {
        foreach (var missileData in GameManager.Instance.playerData.missileHandler.totalMissileList)
        {
            missileData.size *= 1.1f;
        }
        return true;
    }
}
