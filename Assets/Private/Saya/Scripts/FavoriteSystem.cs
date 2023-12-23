using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 好感度をFavoriteSettingDataで設定した値に基づいて計算
/// 好感度が0になるとOnFavoriteZero()が発火する
/// 好感度の計測開始はOnLooking(GameObject)、終了はOnEndLooking() 
/// </summary>
public class FavoriteSystem : MonoBehaviour
{
    private float _lookingTime = 0;
    private float _countDurationTime = 0;
    private bool _isLooking = false;


    private FavoriteSettingDatas _favoriteSettingDatas;
    private int _dataIndex;
    private int _lowerScore;
    private int _upperScore;
    private float _waitTime;
    private float _durationTime;
    private FavoriteStatus _favoriteStatus;


    private FavoriteParam _favoriteParamScript;
    private int _current_favorite;

    [SerializeField]public GameObject _hiroinObject;

    [SerializeField]private GameEndScript _gameEndScript;


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
            CheckFavoriteRenge(_favoriteParamScript.Get());

            if(_countDurationTime < _durationTime)
            {
                return;
            }
            else
            {
                _countDurationTime = 0;
                _current_favorite = _favoriteParamScript.Get();
                VaryFavorite();

                Debug.Log(_hiroinObject.name + "の好感度：" + _favoriteParamScript.Get());
            }
        }
    }

    /// <summary>
    /// 好感度の計測開始 
    /// </summary>
    /// <param name="hiroin">
    /// 計測対象をGameObjectで取得
    /// 取得するGameObjectにはFavoriteParamスクリプトがアタッチされている必要がある
    /// </param>
    public void OnLooking()
    {
        _favoriteParamScript = _hiroinObject.GetComponent<FavoriteParam>();
        _current_favorite = _favoriteParamScript.Get();

        // 好感度が０になると発火する関数を格納
        _favoriteParamScript.OnFavoriteParamZero += OnFavoriteZero;
        
        _isLooking = true;
    }

    /// <summary>
    /// 好感度の計測終了
    /// </summary>
    public void OnEndLooking()
    {
        Debug.Log(_hiroinObject.name + "を見ていた時間： " + _lookingTime + " 秒");
        _lookingTime = 0;
        _isLooking = false;
    }

    public FavoriteStatus GetFavoriteStatus()
    {
        CheckFavoriteRenge(_favoriteParamScript.Get());
        return _favoriteStatus;
    }


    // 好感度が０になると呼び出される
    private void OnFavoriteZero()
    {
        Debug.Log(_hiroinObject.name + "<color=cyan>の好感度が０になった</color>");
        OnEndLooking();
        _gameEndScript.BadEnd1();
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

    private void CheckFavoriteRenge(int currentFavorite)
    {
        for(int i = 0; i < _favoriteSettingDatas.dataList.Count; i++)
        {
            if(currentFavorite >= _favoriteSettingDatas.dataList[i].lowerScore && currentFavorite <= _favoriteSettingDatas.dataList[i].upperScore)
            {
                _dataIndex = i;
                break;
            }
        }

        _lowerScore = _favoriteSettingDatas.dataList[_dataIndex].lowerScore;
        _upperScore = _favoriteSettingDatas.dataList[_dataIndex].upperScore;
        _waitTime = _favoriteSettingDatas.dataList[_dataIndex].waitTime;
        _durationTime = _favoriteSettingDatas.dataList[_dataIndex].durationTime;
        _favoriteStatus = _favoriteSettingDatas.dataList[_dataIndex].favoriteStatus;
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

