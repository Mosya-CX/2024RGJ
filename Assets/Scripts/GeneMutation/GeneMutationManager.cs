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
        List<int> selectIndex = new List<int>();

        while (selectIndex.Count < 3)
        {
            int index = Random.Range(0, mutationList.Count);
            bool hasSelected = false;
            for (int i = 0; i < selectIndex.Count; i++)
            {
                if (selectIndex[i] == index)
                {
                    hasSelected = true;
                    break;
                }
            }
            if (!hasSelected)
            {
                selectIndex.Add(index);
            }
        }

        List<BaseMutation> selectedMutations = new List<BaseMutation>();
        foreach (int i in selectIndex)
        {
            selectedMutations.Add(mutationList[i]);
        }

        GeneMutationPanel panel = UIManager.Instance.OpenUI<GeneMutationPanel>(UIConst._GeneMutationPanel);
        panel.RefreshCells(selectedMutations);
    }
}
