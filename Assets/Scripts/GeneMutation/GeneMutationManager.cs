using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneMutationManager : SingletonWithoutMono<GeneMutationManager>
{
    public List<BaseMutation> mutationList;

    public void Init()
    {
        mutationList = new List<BaseMutation>();
        foreach(BaseMutation m in Resources.Load<MutationList>("Data/ScriptableObject/Mutation/MutationList").mutations)
        {
            mutationList.Add(m);
        }
    }

    public void MutateGenes()
    {

        
    }
}
