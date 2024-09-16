using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattlePanel : BasePanel
{
    public List<Image> HpPoints;
    public List<Image> ShieldPoints;
    public TextMeshProUGUI TimerText;
    private PlayerMovement playerData;

    public int hpIndex;
    public int shieldIndex;

    private bool isOpen;
    private void Awake()
    {
        playerData = GameManager.Instance.playerData;
        HpPoints = transform.Find("Top/HpBar").GetComponentsInChildren<Image>().ToList();

        ShieldPoints = transform.Find("Top/ShieldBar").GetComponentsInChildren<Image>().ToList();

        TimerText = transform.Find("Top/Timer").GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        TimerText.text = GameManager.Instance.timer.ToString();
        UpdateHpPoints();
    }
    public override void OnOpenUI()
    {
        base.OnOpenUI();
        isOpen = true;

        InitHpBar();
    }

    public override void OnHideUI()
    {
        base.OnHideUI();
        isOpen = false;
    }

    public override void OnCloseUI()
    {
        base.OnCloseUI();
        isOpen = false;
    }

    public void InitHpBar()
    {
        hpIndex = playerData.hp - 1;
        shieldIndex = -1;

        foreach (Image t in HpPoints)
        {
            // 对每个t进行初始化
            t.color = new Color(1, 1, 1, 1);
        }
        foreach (Image t in ShieldPoints)
        {
            // 对每个t进行初始化
            t.color = new Color(1, 1, 1, 0);
        }
    }

    public void UpdateHpPoints()
    {
        if (shieldIndex != playerData.shield - 1)
        {
            while (shieldIndex < playerData.shield)
            {
                Image t = ShieldPoints[++shieldIndex];
                // 对t进行操作
                Color c = t.color;
                c.a = 1;
                t.color = c;
            }
            while (shieldIndex > playerData.shield)
            {
                Image t = ShieldPoints[shieldIndex--];
                // 对t进行操作
                Color c = t.color;
                c.a = 0;
                t.color = c;
            }
        }

        if (hpIndex != playerData.hp - 1)
        {
            while (hpIndex < playerData.hp - 1)
            {
                Image t = HpPoints[++hpIndex];
                // 对t进行操作
                Color c = t.color;
                c.a = 1;
                t.color = c;
            }
            while (hpIndex > playerData.hp - 1)
            {
                Image t = HpPoints[hpIndex--];
                // 对t进行操作
                Color c = t.color;
                c.a = 0;
                t.color = c;
            }
        }
    }
    
}
