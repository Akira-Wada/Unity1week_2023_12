using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseDirection;
using UnityEngine.UI;

/// <summary>
/// 方向転換したらキャラクターのアニメーションのスイッチを切り替える
/// </summary>
public class ChangePlayerImage : MonoBehaviour
{
    [SerializeField] private Image rightPlayer;
    [SerializeField] private Image leftPlayer;
    [SerializeField] private Image upPlayer;
    [SerializeField] private Image downPlayer;
    private void Start()
    {

    }
    
    /// <summary>
    /// プレイヤーアニメーションのスイッチを切り替える
    /// </summary>
    /// <param name="direction"></param>
    public void ChangePlayerAnimation(Direction direction)
    {
        rightPlayer.gameObject.SetActive(Direction.Right == direction);
        leftPlayer.gameObject.SetActive(Direction.Left == direction);
        upPlayer.gameObject.SetActive(Direction.Up == direction);
        downPlayer.gameObject.SetActive(Direction.Down == direction);
    }
}
