using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    [SerializeField]private GameObject volumeManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey && !Input.GetKey(KeyCode.Escape))
        {
            if (!Input.GetMouseButton(0) && !volumeManager.activeSelf)
            {
                SceneController sc = GetComponent<SceneController>();
                sc.LoadGameScene();
            }
        }
    }
}
