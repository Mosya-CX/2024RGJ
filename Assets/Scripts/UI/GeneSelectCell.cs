using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneSelectCell : MonoBehaviour
{
    public Image cellIcon;
    public Text cellText;

    private void Awake()
    {
        cellIcon = GetComponentInChildren<Image>();
        cellText = GetComponentInChildren<Text>();
    }

    public void SetCell(Sprite icon, string text)
    {
        cellIcon.sprite = icon;
        cellText.text = text;
    }
}
