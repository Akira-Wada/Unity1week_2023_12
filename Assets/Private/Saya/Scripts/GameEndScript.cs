using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndScript : MonoBehaviour
{
    [SerializeField] private FavoriteSystem _favoriteSystem;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private int _otherThanEndSceneNum = 3;

    public void GoodEnd()
    {
        _sceneController.LoadSelectScene((int)_favoriteSystem.GetFavoriteStatus()+ _otherThanEndSceneNum);
    }

    public void BadEnd1()
    {
        _sceneController.LoadSelectScene((int)FavoriteStatus.BadEnd1 + _otherThanEndSceneNum);
    }

    public void BadEnd2()
    {
        _sceneController.LoadSelectScene((int)FavoriteStatus.BadEnd2 + _otherThanEndSceneNum);
    }
}
