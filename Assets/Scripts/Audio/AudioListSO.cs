using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "音频存储文件", fileName = "AudioListSO")]
public class AudioListSO : ScriptableObject
{
    [Header("背景音列表")]
    public List<Sound> bgmList;
    [Header("音效列表")]
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
