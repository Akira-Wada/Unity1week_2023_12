using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneMove : MonoBehaviour
{

    public SceneController sceneController;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("次のシーンへ移動");
            sceneController.LoadNextScene(sceneController.GetNextSceneIndex());
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("スタートシーンへ移動");
            sceneController.LoadStartScene();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("インゲームシーンへ移動");
            sceneController.LoadGameScene();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("エンドシーンへ移行");
            sceneController.LoadDefaultEndScene();
        }
    }
}
