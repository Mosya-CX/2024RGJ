using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "����ͻ�����/����һ������ͻ������List", fileName = "MutationList")]
public class MutationList : ScriptableObject
{
    public List<BaseMutation> mutations = new List<BaseMutation>();
}
