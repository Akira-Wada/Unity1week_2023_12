using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumManager : MonoBehaviour
{
    [SerializeField] private Text _endText;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private int _otherThanEndSceneNum = 3;
    private FavoriteSettingDatas _favoriteSettingDatas;

    void Start()
    {
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
        for(int i = _otherThanEndSceneNum; i < _favoriteSettingDatas.dataList.Count; i++)
        {
            if(_sceneController.HasSeenEndScene(i)) count++;
        }
        return count;
    }

    private int CountTotalEndNum()
    {
        return _favoriteSettingDatas.dataList.Count;
    }

    private void LoadData()
    {
        _favoriteSettingDatas = Resources.Load<FavoriteSettingDatas>("FavoriteSettingData");

        if(_favoriteSettingDatas == null)
        {
            Debug.LogWarning("FavoriteSettingDatas is not loaded");
            return;
        }
    }
}
