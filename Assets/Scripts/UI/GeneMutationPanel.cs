using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneMutationPanel : BasePanel
{
    public List <GeneSelectCell> selectCells;

    private void Awake()
    {
        selectCells = new List<GeneSelectCell>(GetComponentsInChildren<GeneSelectCell>());
    }

    public override void OnOpenUI()
    {
        base.OnOpenUI();
    }

    public void RefreshCells(List<BaseMutation> mutations)
    {
        for (int i = 0; i < selectCells.Count; i++)
        {
            selectCells[i].mutation = mutations[i];
            selectCells[i].RefreshUI();
        }
    }
}
