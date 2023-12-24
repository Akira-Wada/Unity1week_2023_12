using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sceneを越えて使用するデータを持ち出すことが目的。
/// </summary>
public class GameSettingDatas : MonoBehaviour
{
    //Singleton
    public static GameSettingDatas instance;

    //AudioVolume
    public float bgmVolume;
    public float seVolume;
    
    
    private void Awake() {
        //Singleton
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
