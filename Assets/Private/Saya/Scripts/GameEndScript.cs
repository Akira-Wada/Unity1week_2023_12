using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseDirection;

public class GameEndScript : MonoBehaviour
{
    [SerializeField] private FavoriteSystem _favoriteSystem;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private int _otherThanEndSceneNum = 3;
    

    private PlayerLook _nowDirection;

    public void ConfessionEnd()
    {
        Direction _nowDirection = _playerLook.GetDirection();
        switch(_nowDirection)
        {
            case Direction.Up:
                _sceneController.LoadSelectScene(11);
                break;
            case Direction.Right:
                _sceneController.LoadSelectScene(12);
                break;
            case Direction.Down:
                GoodEnd();
                break;
            case Direction.Left:
                _sceneController.LoadSelectScene(13);
                break;

        }
    }

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
