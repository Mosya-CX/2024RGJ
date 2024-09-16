using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattlePanel : BasePanel
{
    public Sprite activeHp;
    public Sprite disactiveHp;
    public Sprite activeShield;
    public Sprite disactiveShield;
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
        hpIndex = playerData.hp;
        shieldIndex = 0;

        foreach (Image t in HpPoints)
        {
            // 对每个t进行初始化
            t.sprite = activeHp;
        }
        foreach (Image t in ShieldPoints)
        {
            // 对每个t进行初始化
            t.sprite = disactiveShield;
        }
    }

    public void UpdateHpPoints()
    {
        if (shieldIndex != playerData.shield)
        {
            for (int i = 0; i < ShieldPoints.Count; i++)
            {
                if (i < playerData.shield)
                {
                    ShieldPoints[i].sprite = activeShield;
                }
                else
                {
                    ShieldPoints[i].sprite = disactiveShield;
                }
            }
            shieldIndex = playerData.shield;
        }

        if (hpIndex != playerData.hp)
        {
            for (int i = 0; i < HpPoints.Count; i++)
            {
                if (i < playerData.hp)
                {
                    HpPoints[i].sprite = activeHp;
                }
                else
                {
                    HpPoints[i].sprite = disactiveHp;
                }
            }
            hpIndex = playerData.hp;
        }
    }
    
}
