using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BaseDirection;

public enum ChatBoxState
{
    NotActive,
    Move,
    Idle,
    Looking,
    Repop,
}
/// <summary>
/// 吹きだしの生成と判定を行う
/// </summary>
public class RandomChatBox : MonoBehaviour
{
    //吹きだし
    [SerializeField] private GameObject rightChatBoxParent;
    [SerializeField] private GameObject leftChatBoxParent;
    [SerializeField] private GameObject upChatBoxParent;
    private List<GameObject> rightChatBox = new List<GameObject>();
    private List<GameObject> leftChatBox = new List<GameObject>();
    [SerializeField]private List<GameObject> upChatBox = new List<GameObject>();
    [SerializeField]private Animator rightAnimator;
    [SerializeField]private Animator leftAnimator;
    [SerializeField]private Animator upAnimator;

    //現在の表示吹きだしの状態
    private ChatBoxState chatBoxState;
    [SerializeField]private Direction chatBoxDirection;
    private GameObject nowActiveChatBox;
    private int topChatBox = 0;
    [SerializeField]List<GameObject> nowActiveChatBoxList = new List<GameObject>();

    //吹きだし出現タイマー
    private float boxPopTimer = 0f;

    //見てる時間タイマー
    public float lookingTimer = 0f;

    //見てない時間タイマー
    [SerializeField]private float nonLookingTimer = 0f;

    //ランダム生成
    private int boxPosition;

    //タイマーコントロール
    private bool isStartGamePlay = true;

    //ハイパーパラメータ
    [SerializeField,Header("Param")] private float PopTime = 5f;
    [SerializeField] private float lookingTime = 1f;
    [SerializeField] private float nonLookingTime = 5f;

    //見ている方向取得
    [SerializeField,Header("Script")] private PlayerLook playerLook;

    //シーン遷移用Index
    private const int INDEX = 0;
    [SerializeField]SceneController sceneController;

    private void Start() {
        //初期化
        chatBoxState = ChatBoxState.NotActive;
        chatBoxDirection = Direction.Idle;
        //リスト追加
        foreach (Transform child in rightChatBoxParent.transform) rightChatBox.Add(child.gameObject);
        foreach (Transform child in leftChatBoxParent.transform) leftChatBox.Add(child.gameObject);
        foreach (Transform child in upChatBoxParent.transform) upChatBox.Add(child.gameObject);
        // rightAnimator = rightChatBoxParent.GetComponent<Animator>();
        // leftAnimator = leftChatBoxParent.GetComponent<Animator>();
        // upAnimator = upChatBoxParent.GetComponent<Animator>();
        //吹きだしの無効化
        SetActiveForListAll(rightChatBox, false);
        SetActiveForListAll(leftChatBox, false);
        SetActiveForListAll(upChatBox, false);
    }
    private void FixedUpdate() {
        //タイマー調整
        if (!isStartGamePlay) return;

        //タイマー追加
        if(chatBoxState == ChatBoxState.NotActive)boxPopTimer += Time.deltaTime;
        if (chatBoxState != ChatBoxState.NotActive && chatBoxState != ChatBoxState.Looking) nonLookingTimer += Time.deltaTime;
        else nonLookingTimer = 0;
        if(chatBoxState == ChatBoxState.Looking) lookingTimer += Time.deltaTime;

        //処理
        //出現タイマー
        if(boxPopTimer > PopTime && chatBoxState == ChatBoxState.NotActive)
        {
            Debug.Log("BoxCheck");
            boxPopTimer = 0f;
            boxPosition = Random.Range(0, 4);
            switch(boxPosition)
            {
                //Left
                case 0:
                    StartChatBox(leftChatBoxParent,leftChatBox);
                    chatBoxDirection = Direction.Left;
                    ChatBoxStateChange(ChatBoxState.Idle);
                    break;
                //Right
                case 1:
                    StartChatBox(rightChatBoxParent,rightChatBox);
                    chatBoxDirection = Direction.Right;
                    ChatBoxStateChange(ChatBoxState.Idle);
                    break;
                case 2:
                    chatBoxDirection = Direction.Up;
                    StartChatBox(upChatBoxParent,upChatBox);
                    ChatBoxStateChange(ChatBoxState.Idle);
                    break;
                case 3:
                    break;
                //Error
                default:
                    Debug.LogError("Random is Over");
                    break;
            }
        }
        //今プレイヤーが見ている方向と吹き出し方向の確認
        if (chatBoxDirection == playerLook.GetDirection())
        {
            ChatBoxStateChange(ChatBoxState.Looking);
        }
        //吹き出し削除
        if (lookingTimer > lookingTime && chatBoxState == ChatBoxState.Looking)
        {
            lookingTimer = 0f;
            //吹き出し削除
            nowActiveChatBoxList[topChatBox].gameObject.SetActive(false);
            topChatBox++;
            //もし吹き出しが全部消せたら
            if(topChatBox == nowActiveChatBoxList.Count)
            {
                RemoveChatBox();
            }
        }
        //もし吹きだし削除中に別方向を向いたら
        if(chatBoxDirection != playerLook.GetDirection() && chatBoxState == ChatBoxState.Looking)
        {
            RepopChatBox(nowActiveChatBox, nowActiveChatBoxList);
        }
        //吹き出しを放置した時
        if(nonLookingTimer > nonLookingTime)
        {
            //茶化しエンド
            sceneController.LoadSelectScene(INDEX);
        }
    }

    ///<summary>
    ///ChatBoxによる妨害を開始する
    ///</sumamry>
    private void StartChatBox(GameObject activeObjectParent,List<GameObject> activeList)
    {
        Debug.Log("Start");
        nowActiveChatBox = activeObjectParent;
        nowActiveChatBoxList = activeList;
        SetActiveForListAll(activeList, true);
    }
    private void SetActiveForListAll(List<GameObject> list, bool setBool)
    {
        Debug.Log("ResetList");
        foreach (GameObject item in list) item.SetActive(setBool);
    }
    private void RepopChatBox(GameObject activeObject,List<GameObject> activeList)
    {
        Debug.Log("Repop");
        ChatBoxStateChange(ChatBoxState.Repop);
        topChatBox = 0;
        lookingTimer = 0f;
        StartChatBox(activeObject,activeList);
        ChatBoxStateChange(ChatBoxState.Idle);
    }
    private void RemoveChatBox()
    {
        Debug.Log("Remove");
        topChatBox = 0;
        SetActiveForListAll(nowActiveChatBoxList, false);
        ChatBoxStateChange(ChatBoxState.NotActive);

        //現在の情報初期化
        topChatBox = 0;
        boxPopTimer = 0f;
        ChatBoxStateChange(ChatBoxState.NotActive);
        chatBoxDirection = Direction.Idle;
    }
    void ChatBoxStateChange(ChatBoxState chat)
    {
        Debug.Log($"ChatBoxState:{chat}");
        chatBoxState = chat;
    }
}
