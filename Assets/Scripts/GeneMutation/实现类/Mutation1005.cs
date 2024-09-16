using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1005", fileName = "Mutation1005")]
public class Mutation1005 : BaseMutation
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
            missileData.durationTime *= amt;
        }
        return true;
    }
}
