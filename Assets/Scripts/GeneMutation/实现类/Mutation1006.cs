using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "����ͻ�����/����ͻ������/1006", fileName = "Mutation1006")]
public class Mutation1006 : BaseMutation
{
    public string Des;
    public Sprite Icon;

    public override string _Des => Des;
    public override Sprite _Sprite => Icon;
    public override bool TryMutate()
    {
        GameManager.Instance.playerData.moveSpeed *= 1.2f;
        return true;
    }
}
