using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneMutationPanel : BasePanel
{
    public List <GeneSelectCell> selectCells;
    public Transform main;
    public Transform tip;
    public float delayTime = 2.5f;
    private void Awake()
    {
        selectCells = new List<GeneSelectCell>(GetComponentsInChildren<GeneSelectCell>());
        main = transform.Find("Main");
        tip = transform.Find("Tip");
    }

    public override void OnOpenUI()
    {
        base.OnOpenUI();
        GameManager.Instance.PauseGame();
        main.gameObject.SetActive(false);
        DelayOpenMain();
    }

    public async void DelayOpenMain()
    {
        // 打开提示
        tip.gameObject.SetActive(true);
        await System.Threading.Tasks.Task.Delay((int)(delayTime * 1000));
        tip.gameObject.SetActive(false);
        main.gameObject.SetActive(true);
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
