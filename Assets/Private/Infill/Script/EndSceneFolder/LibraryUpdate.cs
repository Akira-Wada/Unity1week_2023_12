using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryUpdate : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] private SceneController sceneController;
    // Start is called before the first frame update
    void Start()
    {
        FitDatas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FitDatas()
    {
        for(int i = 0; i < sceneController.CountTotalEndNum(); i++)gameObjects[i].SetActive(sceneController.HasSeenEndScene(i + sceneController._otherThanEndSceneNum));
    }
}
