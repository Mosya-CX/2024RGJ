using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : SingletonWithMono<UIManager>
{
    public Canvas uiRoot { get; set; }// ����

    public Dictionary<string, GameObject> uiPrefabTable;// �洢UI���Ԥ����
    public Dictionary<string, BasePanel> instantiatedUIDict;// �洢ʵ������UI���

    public void Init()
    {
        // ��ʼ���ֵ�
        uiPrefabTable = new Dictionary<string, GameObject>();
        instantiatedUIDict = new Dictionary<string, BasePanel>();

        // ����������EventSystem
        CreateCanvas();

        // ����UI���Ԥ����
        List<PanelInfo> list = Resources.Load<UIListSO>("Data/ScriptableObject/UIListSO").panelList;
        foreach (PanelInfo info in list)
        {
            uiPrefabTable.Add(info.name, info.prefab);
        }
    }

    public void CreateCanvas()
    {
        // ��������
        uiRoot = GameObject.FindObjectOfType<Canvas>();
        if (uiRoot == null)
        {
            GameObject canvasGameObject = new GameObject("Canvas");
            canvasGameObject.layer = LayerMask.NameToLayer("UI");
            uiRoot = canvasGameObject.AddComponent<Canvas>();
            uiRoot.renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasScaler canvasScaler = canvasGameObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
            canvasGameObject.AddComponent<GraphicRaycaster>();
            uiRoot.sortingOrder = 0;
        }
        // ����EventSystem
        EventSystem eventSystem = GameObject.FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            GameObject eventSystemGameObject = new GameObject("EventSystem");
            eventSystem = eventSystemGameObject.AddComponent<EventSystem>();
            eventSystemGameObject.AddComponent<StandaloneInputModule>();
        }
    }
    public T OpenUI<T>(string uiName) where T : BasePanel
    {
        BasePanel newUI = null;
        if (!instantiatedUIDict.TryGetValue(uiName, out newUI))
        {
            GameObject uiPrefab = null;
            if (uiPrefabTable.TryGetValue(uiName, out uiPrefab))
            {
                newUI = GameObject.Instantiate(uiPrefab, uiRoot.transform).GetComponent<T>();
                newUI.name = uiName;
                instantiatedUIDict[uiName] = newUI;
            }
            else
            {
                Debug.LogError("������UI��" + uiName);
            }
        }
        newUI?.gameObject.SetActive(true);
        newUI?.OnOpenUI();
        return newUI as T;
    }

    public T HideUI<T>(string uiName) where T : BasePanel
    {
        BasePanel newUI = null;
        if (!instantiatedUIDict.TryGetValue(uiName, out newUI))
        {
            Debug.LogWarning("�޷�����δʵ������UI��" + uiName);
        }
        newUI?.gameObject.SetActive(false);
        newUI?.OnHideUI();
        return newUI as T;
    }
    public void CloseUI(string uiName)
    {
        BasePanel newUI = null;

        if (!instantiatedUIDict.TryGetValue(uiName, out newUI))
        {
            Debug.LogWarning("δʵ����UI�ͽ������ٲ�����" + uiName);
            return;
        }

        instantiatedUIDict.Remove(uiName);
        newUI?.OnCloseUI();

        GameObject.Destroy(newUI.gameObject);
    }

    public T GetUI<T>(string uiName) where T : BasePanel
    {
        return instantiatedUIDict[uiName] as T;
    }
}
