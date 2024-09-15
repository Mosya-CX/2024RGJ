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
        RandomSetCells();
    }

    public void RandomSetCells()
    {

    }
}
