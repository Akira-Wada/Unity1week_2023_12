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
    private List<Image> rightChatBox = new List<Image>();
    private List<Image> leftChatBox = new List<Image>();
    private List<Image> upChatBox = new List<Image>();
    [SerializeField]private Animator rightAnimator;
    [SerializeField]private Animator leftAnimator;
    [SerializeField]private Animator upAnimator;

    //現在の表示吹きだしの状態
    public ChatBoxState chatBoxState;
    private Direction chatBoxDirection;
    private GameObject nowActiveChatBox;
    private int topChatBox = 0;
    List<Image> nowActiveChatBoxList = new List<Image>();
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


    private void Start() {
        //初期化
        chatBoxState = ChatBoxState.NotActive;
        chatBoxDirection = Direction.Idle;
        //リスト追加
        foreach (Transform child in rightChatBoxParent.transform) rightChatBox.Add(child.GetComponent<Image>());
        foreach (Transform child in leftChatBoxParent.transform) leftChatBox.Add(child.GetComponent<Image>());
        foreach (Transform child in upChatBoxParent.transform) upChatBox.Add(child.GetComponent<Image>());
        // rightAnimator = rightChatBoxParent.GetComponent<Animator>();
        // leftAnimator = leftChatBoxparent.GetComponent<Animator>();
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
            boxPopTimer = 0f;
            boxPosition = Random.Range(0, 3);

            switch(boxPosition)
            {
                //Left
                case 0:
                    StartChatBox(leftChatBoxParent,leftChatBox);
                    chatBoxDirection = Direction.Left;
                    break;
                //Right
                case 1:
                    StartChatBox(rightChatBoxParent,rightChatBox);
                    chatBoxDirection = Direction.Right;
                    break;
                case 2:
                    chatBoxDirection = Direction.Up;
                    StartChatBox(upChatBoxParent,upChatBox);
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
            chatBoxState = ChatBoxState.Looking;
        }
        //吹き出し削除
        if (lookingTimer > lookingTime && chatBoxState == ChatBoxState.Looking)
        {
            lookingTimer = 0f;
            //吹き出し削除
            nowActiveChatBoxList[topChatBox].gameObject.SetActive(false);
            topChatBox++;
            //もし吹き出しが全部消せたら
            Debug.Log($"topChatbox:{topChatBox},nowActiveChatBoxList{nowActiveChatBoxList.Count}");
            if(topChatBox == nowActiveChatBoxList.Count)
            {
                RemoveChatBox();
            }
            //もし吹きだし削除中に別方向を向いたら
            if(chatBoxDirection != playerLook.GetDirection() && chatBoxDirection != Direction.Idle)
            {
                chatBoxState = ChatBoxState.Repop;
                RepopChatBox(nowActiveChatBox, nowActiveChatBoxList);
            }
        }
        //吹き出しを放置した時
        if(nonLookingTimer > nonLookingTime)
        {
            //茶化しエンド
        }
    }
    ///<summary>
    ///Memo
    ///消える-> SetActive(false) できた
    ///も一回出す-> forしてSetActive(true)
    ///もし視線逸らす-> forしてSetActive(true)
    ///吹きだしを見たらListの上からSetActive(false)
    ///削除成功-> ひっこめさせる(Animation?Transform?)とりあえず後回し
    ///5秒タイマーは共通使用、吹きだしが出現中かつ出現方向を向いているときのみタイマーを増加させる
    ///もしタイマーがオーバーしたら、茶化しエンドへ強制突入
    ///</summary>

    ///<summary>
    ///ChatBoxによる妨害を開始する
    ///</sumamry>
    private void StartChatBox(GameObject activeObjectParent,List<Image> activeList)
    {
        Debug.Log("Start");
        chatBoxState = ChatBoxState.Move;
        nowActiveChatBox = activeObjectParent;
        nowActiveChatBoxList = activeList;
        SetActiveForListAll(activeList, true);
    }
    private void SetActiveForListAll(List<Image> list, bool setBool)
    {
        Debug.Log("ResetList");
        foreach (Image image in list) image.gameObject.SetActive(setBool);
        if(setBool)
        {
            chatBoxState = ChatBoxState.Idle;
        }
    }
    private void RepopChatBox(GameObject activeObject,List<Image> activeList)
    {
        Debug.Log("Repop");
        chatBoxState = ChatBoxState.Repop;
        topChatBox = 0;
        StartChatBox(activeObject,activeList);
    }
    private void RemoveChatBox()
    {
        Debug.Log("Remove");
        topChatBox = 0;
        SetActiveForListAll(nowActiveChatBoxList, false);
        chatBoxState = ChatBoxState.NotActive;
        chatBoxDirection = Direction.Idle;

        //現在の情報初期化
        topChatBox = 0;
    }
}
