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
    [SerializeField] private GameObject rightPlayer;
    [SerializeField] private GameObject leftPlayer;
    [SerializeField] private GameObject upPlayer;
    [SerializeField] private GameObject downPlayer;
    [SerializeField] private GameObject defaultPlayer;
    private void Start()
    {

    }
    
    /// <summary>
    /// プレイヤーアニメーションのスイッチを切り替える
    /// </summary>
    /// <param name="direction"></param>
    public void ChangePlayerAnimation(Direction direction)
    {
        rightPlayer.SetActive(Direction.Right == direction);
        leftPlayer.SetActive(Direction.Left == direction);
        upPlayer.SetActive(Direction.Up == direction);
        downPlayer.SetActive(Direction.Down == direction);

        defaultPlayer.SetActive(false);
    }
}
