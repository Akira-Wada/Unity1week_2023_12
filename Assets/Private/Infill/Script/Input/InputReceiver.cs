using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using BaseDirection;

/// <summary>
/// 入力を関数で獲得。
/// 不明点はInfillへ
/// </summary>
public class InputReceiver : MonoBehaviour
{
    [SerializeField]public PlayerLook playerLook;
    [SerializeField]private GameEndScript _gameEndScript;
    private void Awake() 
    {
        //もしセットされていなかった場合は検索してセット
        if (playerLook == null) playerLook = GameObject.Find("Player").GetComponent<PlayerLook>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 右入力　押した瞬間だけ発火。
    /// 二行目以降へ記入すること。
    /// </summary>
    /// <param name="context"></param>
    public void OnPushRightArrow(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        playerLook.ChangeDirection(Direction.Right);
    }
    /// <summary>
    /// 左入力　押した瞬間だけ発火。
    /// 二行目以降へ記入すること。
    /// </summary>
    /// <param name="context"></param>
    public void OnPushLeftArrow(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        playerLook.ChangeDirection(Direction.Left);
    }
    /// <summary>
    /// 上入力　押した瞬間だけ発火。
    /// 二行目以降へ記入すること。
    /// </summary>
    /// <param name="context"></param>
    public void OnPushUpArrow(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        playerLook.ChangeDirection(Direction.Up);
    }
    /// <summary>
    /// 下入力　押した瞬間だけ発火。
    /// 二行目以降へ記入すること。
    /// </summary>
    /// <param name="context"></param>
    public void OnPushDownArrow(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        playerLook.ChangeDirection(Direction.Down);
    }
    public void OnPushSpace(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _gameEndScript.GoodEnd();
    }
}
