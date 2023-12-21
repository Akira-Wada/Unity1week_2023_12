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
            CheckEndingScene(sceneController.GetSelectSceneIndex());
            Debug.Log(sceneController.GetSelectSceneIndex() + "番のシーンへ移動");
            sceneController.LoadSelectScene(sceneController.GetSelectSceneIndex());
        }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            CheckEndingScene(0);
            Debug.Log("スタートシーンへ移動");
            sceneController.LoadStartScene();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CheckEndingScene(1);
            Debug.Log("インゲームシーンへ移動");
            sceneController.LoadGameScene();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CheckEndingScene(2);
            Debug.Log("エンドシーンへ移行");
            sceneController.LoadDefaultEndScene();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            CheckEndingScene(3);
            Debug.Log("エンドシーン1へ移動");
            sceneController.LoadSelectScene(3);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            CheckEndingScene(4);
            Debug.Log("エンドシーン2へ移動");
            sceneController.LoadSelectScene(4);
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            CheckEndingScene(5);
            Debug.Log("エンドシーン3へ移行");
            sceneController.LoadSelectScene(5);
        }
    }

    private void CheckEndingScene(int index)
    {
        if(sceneController.HasSeenEndScene(index))
        {
            Debug.Log("このシーンはすでに読み込みこみ");
        }
        else
        {
            Debug.Log("初めてこのシーンを読み込んだ");
        }
    }
}
