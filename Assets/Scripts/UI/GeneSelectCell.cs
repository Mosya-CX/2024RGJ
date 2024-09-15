using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GeneSelectCell : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
