using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChatBoxState
{
    NotActive,
    Move,
    Idle,
    Looking,
    Repop
}
/// <summary>
/// 吹きだしの生成と判定を行う
/// </summary>
public class RandomChatBox : MonoBehaviour
{
    //吹きだし
    [SerializeField] private GameObject rightChatBoxParent;
    [SerializeField] private GameObject leftChatBoxparent;
    private List<Image> rightChatBox = new List<Image>();
    private List<Image> leftChatBox = new List<Image>();
    [SerializeField]private Animator rightAnimator;
    [SerializeField]private Animator leftAnimator;

    //現在の表示吹きだしの状態
    [SerializeField,Header("DebugOpen")]private ChatBoxState chatBoxState;

    //吹きだし出現タイマー
    private float boxPopTimer = 0f;

    //見てる時間タイマー
    private float lookingTimer = 0f;

    //見てない時間タイマー
    private float nonLookingTimer = 0f;

    //ランダム生成
    private int boxPosition;

    //タイマーコントロール
    private bool isStartGamePlay = true;

    //ハイパーパラメータ
    [SerializeField,Header("Param")] private float PopTime = 5f;
    [SerializeField] private float lookingTime = 1f;
    [SerializeField] private float nonLookingTime = 5f;
    private void Start() {
        //初期化
        chatBoxState = ChatBoxState.NotActive;
        //リスト追加
        foreach (Transform child in rightChatBoxParent.transform) rightChatBox.Add(child.GetComponent<Image>());
        foreach (Transform child in leftChatBoxparent.transform) leftChatBox.Add(child.GetComponent<Image>());
        // rightAnimator = rightChatBoxParent.GetComponent<Animator>();
        // leftAnimator = leftChatBoxparent.GetComponent<Animator>();
        //吹きだしの無効化
        SetActiveForListAll(rightChatBox, false);
        SetActiveForListAll(leftChatBox, false);
    }
    private void FixedUpdate() {
        //タイマー調整
        if (!isStartGamePlay) return;

        //タイマー追加
        if(chatBoxState == ChatBoxState.NotActive)boxPopTimer += Time.deltaTime;
        if(chatBoxState != ChatBoxState.NotActive && chatBoxState != ChatBoxState.Looking) nonLookingTime += Time.deltaTime;
        if(chatBoxState == ChatBoxState.Looking) lookingTime += Time.deltaTime;

        //処理
        //出現タイマー
        if(boxPopTimer > PopTime && chatBoxState != ChatBoxState.NotActive)
        {
            boxPosition = Random.Range(0, 3);

            //まだ３つ目が完成してないためオーバー
            if (boxPosition == 2) return;

            switch(boxPosition)
            {
                //Left
                case 0:
                    StartChatBox(leftChatBox);
                    break;
                //Right
                case 1:
                    StartChatBox(rightChatBox);
                    break;
                //Error
                default:
                    Debug.LogError("Random is Over");
                    break;
            }
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


    // void CreateChatBox()
    // {
    //     GameObject createBox = Instantiate(chatBox[0].gameObject, canvas.transform.position, Quaternion.identity);
    //     createBox.transform.parent = canvas.transform;
    // }

    ///<summary>
    ///ChatBoxによる妨害を開始する
    ///</sumamry>
    private void StartChatBox(List<Image> activeList)
    {
        chatBoxState = ChatBoxState.Move;
        SetActiveForListAll(activeList, true);
    }
    private void SetActiveForListAll(List<Image> list, bool setBool)
    {
        foreach (Image image in list) image.gameObject.SetActive(setBool);
        chatBoxState = ChatBoxState.Idle;
    }
    private void RepopChatBox(List<Image> activeList)
    {
        chatBoxState = ChatBoxState.Repop;
        StartChatBox(activeList);
    }
}
