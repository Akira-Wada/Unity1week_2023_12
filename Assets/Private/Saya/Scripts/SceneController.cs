using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// 指定したシーンに遷移
/// ゲームマネージャーにアタッチ
/// </summary>
public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Resources->SceneDataで設定した番号
    /// 指定したシーンに移動するための番号
    /// </summary>
    [SerializeField, Header("テスト用")]
    private int _Test_selectSceneIndex;

    // [SerializeField]
    private int _startSceneIndex = 0;
    // [SerializeField]
    private int _inGameSceneIndex = 1;
    // [SerializeField]
    private int _albamSceneIndex = 2;

    private SceneDatas _sceneDatas;

    void Awake()
    {
        LoadData();
    }


    /// <summary>
    /// 指定したシーンに移動できる
    /// </summary>
    /// <param name="index">
    /// Resources->SceneDataで設定した番号
    /// </param>
    public void LoadSelectScene(int index)
    {
        // エンドシーンなら保存
        if(index != _startSceneIndex && index != _inGameSceneIndex)
        {
            RecordEndScene(index);
        }
        
        SceneManager.LoadScene(_sceneDatas.dataList[index].sceneName);
    }


    public void LoadStartScene()
    {
        SceneManager.LoadScene(_sceneDatas.dataList[_startSceneIndex].sceneName);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(_sceneDatas.dataList[_inGameSceneIndex].sceneName);
    }

    public void LoadAlbamScene()
    {
        RecordEndScene(_albamSceneIndex);
        SceneManager.LoadScene(_sceneDatas.dataList[_albamSceneIndex].sceneName);
    }

    /// <summary>
    /// 指定したエンドシーンはすでに見たものか
    /// </summary>
    /// <param name="index"></param>
    /// <returns>すでに見たならtrue</returns>
    public bool HasSeenEndScene(int index)
    {
        if(index == _startSceneIndex || index == _inGameSceneIndex)
        {
            Debug.LogWarning("HasSeenEndScene関数はエンドシーン以外では使えないです");
            return false;
        }

        return PlayerPrefs.GetInt(_sceneDatas.dataList[index].sceneName, 0) == 1;
    }

    public int CountSeenEndScene()
    {
        int count = 0;
        for(int i = _inGameSceneIndex + 1; i < _sceneDatas.dataList.Count; i++)
        {
            if (!HasSeenEndScene(i)) count++;
        }

        return count;
    }

    public int GetSelectSceneIndex()
    {
        return _Test_selectSceneIndex;
    }

    private void LoadData()
    {
        _sceneDatas = Resources.Load<SceneDatas>("SceneData");

        if(_sceneDatas == null)
        {
            Debug.LogWarning("SceneData is not loaded");
        }
    }

    private void RecordEndScene(int index)
    {
        PlayerPrefs.SetInt(_sceneDatas.dataList[index].sceneName, 1);
        PlayerPrefs.Save();
    }
}
