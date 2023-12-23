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
    //見続けてたら顔面が変わる
    [SerializeField] private float thresholdLookTime = 5f;
    private float timer;
    Direction nowDirection;
    //プレイヤーのオブジェクト
    [SerializeField,Header("Player")] private GameObject rightPlayer;
    [SerializeField] private GameObject leftPlayer;
    [SerializeField] private GameObject upPlayer;
    [SerializeField] private GameObject downPlayer;
    [SerializeField] private GameObject changeDownPlayer;//こっちがきもい方
    [SerializeField] private GameObject defaultPlayer;
    
    /// <summary>
    /// プレイヤーアニメーションのスイッチを切り替える
    /// </summary>
    /// <param name="direction"></param>
    private void FixedUpdate() {
        if (nowDirection == Direction.Down) timer += Time.deltaTime;
        if (timer > thresholdLookTime)
        {
            timer = 0;
            downPlayer.SetActive(false);
            changeDownPlayer.SetActive(true);
        }
    }
    public void ChangePlayerAnimation(Direction direction)
    {
        rightPlayer.SetActive(Direction.Right == direction);
        leftPlayer.SetActive(Direction.Left == direction);
        upPlayer.SetActive(Direction.Up == direction);
        downPlayer.SetActive(Direction.Down == direction);
        changeDownPlayer.SetActive(false);

        defaultPlayer.SetActive(false);
    }
}
