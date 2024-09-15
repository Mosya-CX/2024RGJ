using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "基因突变相关/创建一个基因突变种类List", fileName = "MutationList")]
public class MutationList : ScriptableObject
{
    public List<BaseMutation> mutations = new List<BaseMutation>();
}
