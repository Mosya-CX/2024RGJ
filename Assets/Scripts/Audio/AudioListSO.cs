using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "��Ƶ�洢�ļ�", fileName = "AudioListSO")]
public class AudioListSO : ScriptableObject
{
    [Header("�������б�")]
    public List<Sound> bgmList;
    [Header("��Ч�б�")]
    public List<Sound> effectList;

    public AudioClip GetBGMByName(string bgmName)
    {
        return bgmList.FirstOrDefault(bgm => bgm.name == bgmName).clip;
    }
    public AudioClip GetEffectByName(string effectName)
    {
        return effectList.FirstOrDefault(effect => effect.name == effectName).clip;
    }
}
