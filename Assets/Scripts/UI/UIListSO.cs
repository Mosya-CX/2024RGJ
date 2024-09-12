using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI´æ´¢ÎÄ¼þ", fileName = "UIListSO")]
public class UIListSO : ScriptableObject
{
    public List<PanelInfo> panelList = new List<PanelInfo>();
}
[System.Serializable]
public class PanelInfo
{
    public string name;
    public GameObject prefab;
}
