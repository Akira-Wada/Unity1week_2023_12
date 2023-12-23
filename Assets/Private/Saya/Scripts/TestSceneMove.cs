using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneMove : MonoBehaviour
{

    public SceneController sceneController;
    private int num;

    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     CheckEndingScene(sceneController.GetSelectSceneIndex());
        //     Debug.Log(sceneController.GetSelectSceneIndex() + "番のシーンへ移動");
        //     sceneController.LoadSelectScene(sceneController.GetSelectSceneIndex());
        // }

        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            num = 0;
            CheckEndingScene(num);
            Debug.Log("タイトルシーンへ移動");
            sceneController.LoadStartScene();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            num = 1;
            CheckEndingScene(num);
            Debug.Log("インゲームシーンへ移動");
            sceneController.LoadGameScene();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            num = 2;
            CheckEndingScene(num);
            Debug.Log("アルバムへ移行");
            sceneController.LoadAlbamScene();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            num = 3;
            CheckEndingScene(num);
            Debug.Log("BadEnd1シーン1へ移動");
            sceneController.LoadSelectScene(num);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            num = 4;
            CheckEndingScene(num);
            Debug.Log("BadEnd2へ移動");
            sceneController.LoadSelectScene(num);
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            num = 5;
            CheckEndingScene(num);
            Debug.Log("GoodEnd1へ移行");
            sceneController.LoadSelectScene(num);
        }

        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            num = 6;
            CheckEndingScene(num);
            Debug.Log("GoodEnd2へ移行");
            sceneController.LoadSelectScene(num);
        }

        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            num = 7;
            CheckEndingScene(num);
            Debug.Log("GoodEnd3へ移行");
            sceneController.LoadSelectScene(num);
        }

        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            num = 8;
            CheckEndingScene(num);
            Debug.Log("GoodEnd4へ移行");
            sceneController.LoadSelectScene(num);
        }

        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            num = 9;
            CheckEndingScene(num);
            Debug.Log("GoodEnd5へ移行");
            sceneController.LoadSelectScene(num);
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
