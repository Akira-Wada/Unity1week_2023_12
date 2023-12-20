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
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundVolumeManager.instance.bgmVolume = bgmAudioSlider.value;
        SoundVolumeManager.instance.seVolume = seAudioSlider.value;
    }
}
