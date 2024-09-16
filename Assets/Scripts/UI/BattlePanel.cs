using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;

public class BattlePanel : BasePanel
{
    public List<Transform> HpPoints;
    public List<Transform> ShieldPoints;
    public TextMeshProUGUI TimerText;
    private PlayerMovement playerData;

    private int hpIndex;
    private int shieldIndex;

    private bool isOpen;
    private void Awake()
    {
        playerData = GameManager.Instance.playerData;
        Transform hpBar = transform.Find("Top/HpBar");
        foreach (Transform t in hpBar.transform)
        {
            HpPoints.Add(t);
        }
        Transform shieldBar = transform.Find("Top/ShieldBar");
        ShieldPoints = new List<Transform>();
        foreach (Transform t in shieldBar.transform)
        {
            ShieldPoints.Add(t);
        }
        TimerText = transform.Find("Top/Timer").GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        TimerText.text = GameManager.Instance.timer.ToString();
    }
    public override void OnOpenUI()
    {
        base.OnOpenUI();
        isOpen = true;

        InitHpBar();

        ThreadPool.QueueUserWorkItem(UpdateHpPoints);
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
        hpIndex = playerData.hp;
        shieldIndex = 0;

        foreach (Transform t in HpPoints)
        {
            // 对每个t进行初始化

        }
        foreach (Transform t in ShieldPoints)
        {
            // 对每个t进行初始化

        }
    }

    public void UpdateHpPoints(object callback)
    {
        while (isOpen)
        {
            if (shieldIndex != playerData.shield)
            {
                while (shieldIndex < playerData.shield)
                {
                    Transform t = ShieldPoints[++shieldIndex];
                    // 对t进行操作

                }
                while (shieldIndex > playerData.shield)
                {
                    Transform t = ShieldPoints[shieldIndex--];
                    // 对t进行操作

                }
            }

            if (hpIndex != playerData.hp - 1)
            {
                while (hpIndex < playerData.hp - 1)
                {
                    Transform t = HpPoints[++hpIndex];
                    // 对t进行操作

                }
                while (hpIndex > playerData.hp - 1)
                {
                    Transform t = HpPoints[hpIndex--];
                    // 对t进行操作

                }
            }
        }
    }
    
}
