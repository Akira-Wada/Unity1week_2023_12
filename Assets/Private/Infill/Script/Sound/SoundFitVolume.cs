using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AudioSourceType
{
    bgm,
    se
}
public class SoundFitVolume : MonoBehaviour
{
    [SerializeField]AudioSourceType audioSourceType;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FitVolume();
    }
    private void FitVolume()
    {
        if (audioSourceType == AudioSourceType.bgm)
        {
            audioSource.volume = GameSettingDatas.instance.bgmVolume;
        }
        else if(audioSourceType == AudioSourceType.se)
        {
            audioSource.volume = GameSettingDatas.instance.seVolume;
        }
    }
}
