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
            // ��ÿ��t���г�ʼ��

        }
        foreach (Transform t in ShieldPoints)
        {
            // ��ÿ��t���г�ʼ��

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
                    // ��t���в���

                }
                while (shieldIndex > playerData.shield)
                {
                    Transform t = ShieldPoints[shieldIndex--];
                    // ��t���в���

                }
            }

            if (hpIndex != playerData.hp - 1)
            {
                while (hpIndex < playerData.hp - 1)
                {
                    Transform t = HpPoints[++hpIndex];
                    // ��t���в���

                }
                while (hpIndex > playerData.hp - 1)
                {
                    Transform t = HpPoints[hpIndex--];
                    // ��t���в���

                }
            }
        }
    }
    
}
