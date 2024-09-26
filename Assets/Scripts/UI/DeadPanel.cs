using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DeadPanel : BasePanel
{

    public Button Restart;
    public Button BackToMain;
    public TextMeshProUGUI TimerText1;
    private void Awake()
    {
        
        Restart = transform.Find("Restart").GetComponent<Button>();
        BackToMain = transform.Find("BackToMain").GetComponent<Button>();
        TimerText1 = transform.Find("Timer").GetComponentInChildren<TextMeshProUGUI>();
        Restart.onClick.AddListener(OnClickRestart);
        BackToMain.onClick.AddListener(OnClickBackToMain);
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnOpenUI()
    {
        TimerText1.text = UIManager.Instance.GetUI<BattlePanel>(UIConst._BattlePanel).TimerText.text;
        base.OnOpenUI();
    }
    public void OnClickRestart()
    {

    }
    public void OnClickBackToMain()
    {

    }
}
