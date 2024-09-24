using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GeneSelectCell : MonoBehaviour, IPointerClickHandler
{
    public Image cellIcon;
    public TextMeshProUGUI cellText;

    public BaseMutation mutation;

    private void Awake()
    {
        cellIcon = transform.Find("Image").GetComponent<Image>();
        cellText = transform.Find("Description").GetComponent<TextMeshProUGUI>();
        AudioManager.Instance.PlayEffect("Éý¼¶");
    }

    public void RefreshUI()
    {
        cellIcon.sprite = mutation._Sprite;
        cellText.text = mutation._Des;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        mutation.TryMutate();
        UIManager.Instance.CloseUI(UIConst._GeneMutationPanel);
       
    }

}
