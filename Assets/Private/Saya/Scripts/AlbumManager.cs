using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumManager : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private int _otherThanEndSceneNum = 3;
    private Text _endText;
    private SceneDatas _sceneDatas;

    void Start()
    {
        _endText = GetComponent<Text>();
        LoadData();
        WriteEndNumText();
    }

    public void WriteEndNumText()
    {
        _endText.text = CountSeenScene() + " / " + CountTotalEndNum();
    }

    private int CountSeenScene()
    {
        int count = 0;
        for(int i =_otherThanEndSceneNum; i < _sceneDatas.dataList.Count; i++)
        {
            if(_sceneController.HasSeenEndScene(i)) count++;
        }
        return count;
    }

    private int CountTotalEndNum()
    {
        return _sceneDatas.dataList.Count - _otherThanEndSceneNum;
    }

    private void LoadData()
    {
        _sceneDatas = Resources.Load<SceneDatas>("SceneData");

        if(_sceneDatas == null)
        {
            Debug.LogWarning("SceneDatas is not loaded");
            return;
        }
    }
}
