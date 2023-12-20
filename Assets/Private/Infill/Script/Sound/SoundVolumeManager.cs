using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeManager : MonoBehaviour
{

    public float bgmVolume;
    public float seVolume;

    public Slider bgmVolumeSlider;
    public Slider seVolumeSlider;

    private AudioSource bgmAudioSource;
    private AudioSource seAudioSource;

    public static SoundVolumeManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bgmAudioSource = GameObject.Find("BGMAudioSource").GetComponent<AudioSource>();
        seAudioSource = GameObject.Find("SEAudioSource").GetComponent<AudioSource>();
        SetVolume();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bgmVolumeSlider.gameObject.activeSelf) return;

        bgmVolume = bgmVolumeSlider.value;
        seVolume = seVolumeSlider.value;
        SetVolume();
    }
    void SetVolume()
    {
        bgmAudioSource.volume = bgmVolume;
        seAudioSource.volume = seVolume;
    }

    
}
