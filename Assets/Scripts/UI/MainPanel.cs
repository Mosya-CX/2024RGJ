using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : BasePanel
{
    public Button start;
    public Button exit;
    private void Awake()
    {
        start = transform.Find("Start").GetComponent<Button>();
        exit = transform.Find("Exit").GetComponent<Button>();
        start.onClick.AddListener(OnClickStart);
        exit.onClick.AddListener(OnClickExit);
    }

    public void OnClickStart()
    {
        UIManager.Instance.OpenUI<BattlePanel>(UIConst._BattlePanel);
        GameManager.Instance.playerData.gameObject.SetActive(true);
        EnemyManager.Instance.gameObject.SetActive(true);
        GameManager.Instance.ResumeGame();
        UIManager.Instance.CloseUI(UIConst._MainPanel);
    }
    public void OnClickExit()
    {
        Application.Quit();
    }
}
