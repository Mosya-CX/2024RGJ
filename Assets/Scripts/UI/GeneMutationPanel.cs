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
        GameManager.Instance.PauseGame();
    }

    public override void OnCloseUI()
    {
        base.OnCloseUI();
        GameManager.Instance.ResumeGame();
    }

    public void RefreshCells(List<BaseMutation> mutations)
    {
        Debug.Log("Cells数量:" + selectCells.Count);
        Debug.Log("Mutations数量:" + mutations.Count);
        for (int i = 0; i < selectCells.Count; i++)
        {
            selectCells[i].mutation = mutations[i];
            selectCells[i].RefreshUI();
        }
    }
}
