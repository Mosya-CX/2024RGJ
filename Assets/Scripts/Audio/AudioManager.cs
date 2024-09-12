using UnityEngine;

public class AudioManager : SingletonWithMono<AudioManager>
{
    public AudioListSO audioList;
    public float totalVolume;
    public float bgmVolume;
    public float effectVolume;
    public AudioSource bgmSource;
    public AudioSource effectSource;
    public void Init()
    {
        totalVolume = PlayerPrefs.GetFloat("TotalVolume", 1);
        bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 1);
        effectVolume = PlayerPrefs.GetFloat("EffectVolume", 1);


        bgmSource = gameObject.AddComponent<AudioSource>();
        effectSource = gameObject.AddComponent<AudioSource>();

        bgmSource.playOnAwake = false;
        effectSource.playOnAwake = false;
        bgmSource.loop = true;

        audioList = Resources.Load<AudioListSO>("Data/ScriptableObject/AudioListSO");

        SetVolume();
    }
    public void PlayBGM(string audioName)
    {
        bgmSource.Stop();
        bgmSource.clip = audioList.GetBGMByName(audioName);
        bgmSource.Play();
    }
    public void PlayEffect(string audioName)
    {
        effectSource.PlayOneShot(audioList.GetEffectByName(audioName));
    }
    public void ChangeTotalVolume(float value)
    {
        totalVolume = value;
        PlayerPrefs.SetFloat("TotalVolume", totalVolume);
        SetVolume();
    }
    public void ChangeBGMVolume(float value)
    {
        bgmVolume = value;
        PlayerPrefs.SetFloat("BGMVolume", bgmVolume);
        SetVolume();
    }
    public void ChangeEffectVolume(float value)
    {
        effectVolume = value;
        PlayerPrefs.SetFloat("EffectVolume", effectVolume);
        SetVolume();
    }
    public void SetVolume()
    {
        bgmSource.volume = bgmVolume * totalVolume;
        effectSource.volume = effectVolume * totalVolume;
    }
}
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
