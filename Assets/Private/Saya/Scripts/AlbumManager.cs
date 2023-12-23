using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumManager : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;
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
        _endText.text = _sceneController.CountSeenScene() + " / " + _sceneController.CountTotalEndNum();
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
