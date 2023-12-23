using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseDirection;

/// <summary>
/// 入力に合わせてプレイヤーの方向を管理する
/// </summary>
public class PlayerLook : MonoBehaviour
{

    //キャラクターの現在向いている方向
    private Direction direction;

    //キャラクターの方向変換スクリプト
    [SerializeField] private ChangePlayerImage changePlayerImage;
    [SerializeField] private FavoriteSystem favoriteSystem;


    // Start is called before the first frame update
    void Start()
    {
        //初期設定
        direction = Direction.Left;
    }

    /// <summary>
    /// InputSystemからの入力を受け取ってdirectionへ変更する
    /// </summary>
    /// <param name="inputDirection"></param>
    public void ChangeDirection(Direction inputDirection)
    {
        if (direction == inputDirection) return;

        direction = inputDirection;
        
        if (direction == Direction.Down)
        {
            favoriteSystem.OnLooking();
        }
        else
        {
            favoriteSystem.OnEndLooking();
        }

        changePlayerImage.ChangePlayerAnimation(direction);
    }
    
    /// <summary>
    /// 方向を外部から獲得できる
    /// </summary>
    /// <returns></returns>
    public Direction GetDirection()
    {
        return direction; 
    }
}
