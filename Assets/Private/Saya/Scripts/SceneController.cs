using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /// <summary>
    /// Resources->SceneDataで設定した番号
    /// 次のシーンを指定できる
    /// </summary>
    [SerializeField]
    private int _nextSceneIndex;

    // [SerializeField]
    private int _startSceneIndex = 0;
    // [SerializeField]
    private int _inGameSceneIndex = 1;
    // [SerializeField]
    private int _defaultEndSceneIndex = 2;


    private SceneDatas _sceneDatas;


    void Awake()
    {
        LoadData();
    }


    /// <summary>
    /// 次のシーンが決まっている時に使うと便利
    /// </summary>
    /// <param name="index">
    /// Resources->SceneDataで設定した番号
    /// </param>
    public void LoadNextScene(int index)
    {
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

    public void LoadDefaultEndScene()
    {
        SceneManager.LoadScene(_sceneDatas.dataList[_defaultEndSceneIndex].sceneName);
    }

    // public void LoadEndScene(int index)
    // {
    //     foreach (var endScene in endScenes)
    //     {
    //         if (index <= endScene.sceneIndex)
    //         {
    //             SceneManager.LoadScene(endScene.sceneName);
    //             return;
    //         }
    //     }
    // }

    public int GetNextSceneIndex()
    {
        return _nextSceneIndex;
    }

    private void LoadData()
    {
        _sceneDatas = Resources.Load<SceneDatas>("SceneData");

        if(_sceneDatas == null)
        {
            Debug.LogWarning("SceneData is not loaded");
        }
    }
}
