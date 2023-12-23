using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingSceneScript : MonoBehaviour
{
    [SerializeField] private SceneController _sceneController;

    private Text _endText;
    private SceneDatas _sceneDatas;

    void Start()
    {
        _endText = GetComponent<Text>();
        LoadData();
        WriteEndNumberText();
    }

    public void WriteEndNumberText()
    {
        _endText.text = "No." + (_sceneController.GetSceneIndex() - _sceneController.GetOtherThanEndIndex() + 1);
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
