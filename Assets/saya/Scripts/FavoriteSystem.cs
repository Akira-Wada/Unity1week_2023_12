using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteSystem : MonoBehaviour
{
    // private float _adjustTime; // 計測調整用 いらんかも
    private float _lookingTime = 0;
    private float _countDurationTime = 0;
    private bool _isLooking = false;


    private FavoriteSettingDatas _favoriteSettingDatas;
    private int _dataIndex;
    private int _lowerScore;
    private int _upperScore;
    private float _waitTime;
    private float _durationTime;


    private FavoriteParam _favoriteParamScript;
    private int _current_favorite;


    // 必要な機能
    // ヒロイン[N]の好感度を取ってくる
    // 好感度のランクによって時間変数をセット
    // 好感度を更新する処理
    void Start()
    {
        LoadData();
    }

    void Update()
    {
        if (_isLooking)
        {
            _lookingTime += Time.deltaTime;
            _countDurationTime += Time.deltaTime;
            CheckFavoriteRenge();

            if(_countDurationTime < _durationTime)
            {
                return;
            }
            else
            {
                _countDurationTime = 0;
                VaryFavorite();
            }
            Debug.Log(_current_favorite);
        }
        
    }

    public void OnLooking(GameObject hiroin)
    {
        _favoriteParamScript = hiroin.GetComponent<FavoriteParam>();
        _current_favorite = _favoriteParamScript.Get();
        
        // _adjustTime = Time.time;
        _isLooking = true;
    }

    public void OnEndLooking()
    {
        Debug.Log("ヒロインを見ていた時間： " + _lookingTime + " 秒");
        _lookingTime = 0;
        _isLooking = false;
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

    private void CheckFavoriteRenge()
    {
        for(int i = 0; i < _favoriteSettingDatas.dataList.Count; i++)
        {
            if(_current_favorite >= _favoriteSettingDatas.dataList[i].lowerScore && _current_favorite <= _favoriteSettingDatas.dataList[i].upperScore)
            {
                _dataIndex = i;
                break;
            }
        }

        _lowerScore = _favoriteSettingDatas.dataList[_dataIndex].lowerScore;
        _upperScore = _favoriteSettingDatas.dataList[_dataIndex].upperScore;
        _waitTime = _favoriteSettingDatas.dataList[_dataIndex].waitTime;
        _durationTime = _favoriteSettingDatas.dataList[_dataIndex].durationTime;
    }


    private void VaryFavorite()
    {
        if(_lookingTime < _waitTime)
        {
            _current_favorite++;
        }
        else{
            _current_favorite--;
        }

        _favoriteParamScript.Set(_current_favorite);
    }
    
}

