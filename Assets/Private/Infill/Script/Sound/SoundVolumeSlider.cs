using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider bgmAudioSlider;
    [SerializeField] private Slider seAudioSlider;

    // Start is called before the first frame update
    void Start()
    {
        bgmAudioSlider.value = GameSettingDatas.instance.bgmVolume;
        seAudioSlider.value = GameSettingDatas.instance.seVolume;   
    }

    // Update is called once per frame
    void Update()
    {
        GameSettingDatas.instance.bgmVolume = bgmAudioSlider.value;
        GameSettingDatas.instance.seVolume = seAudioSlider.value;
    }
}
