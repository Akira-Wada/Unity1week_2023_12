using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseDirection;

/// <summary>
/// 方向転換したらキャラクターのアニメーションのスイッチを切り替える
/// </summary>
public class ChangePlayerImage : MonoBehaviour
{
    [SerializeField] private Animator animator;     //動かすAnimator
    private void Start()
    {
        //もしアタッチがない場合、アタッチされているオブジェクトから取得する
        if (animator == null) animator = GetComponent<Animator>();
    }
    
    /// <summary>
    /// プレイヤーアニメーションのスイッチを切り替える
    /// </summary>
    /// <param name="direction"></param>
    public void ChangePlayerAnimation(Direction direction)
    {
        animator.SetBool("isRight",Direction.Right == direction);
        animator.SetBool("isLeft",Direction.Left == direction);
        animator.SetBool("isUp",Direction.Up == direction);
        animator.SetBool("isDown",Direction.Down == direction);
    }
}
