using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI�洢�ļ�", fileName = "UIListSO")]
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
