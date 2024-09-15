using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GeneSelectCell : MonoBehaviour, IPointerClickHandler
{
    public Image cellIcon;
    public Text cellText;

    public BaseMutation mutation;

    private void Awake()
    {
        cellIcon = GetComponentInChildren<Image>();
        cellText = GetComponentInChildren<Text>();
    }

    public void RefreshUI()
    {
        //cellIcon.sprite = mutation._Sprite;
        //cellText.text = mutation._Des;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        mutation.TryMutate();
        UIManager.Instance.CloseUI(UIConst._GeneMutationPanel);
    }

}
