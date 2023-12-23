using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroinFaceSet : MonoBehaviour
{
    [SerializeField,Header("表情リスト")] private List<GameObject> faces = new List<GameObject>();
    public int face;            //現在の顔

    [SerializeField] private FavoriteSystem _favoriteSystem;

    private void Start()
    {
        //顔面初期設定
        //初期セット
        CheckFace();
    }
    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// 好感度変動時に顔面が変わる場合に変える
    /// </summary>
    /// <param name="favolitePoint">
    /// 好感度</param>
    public void SetFace(int _face)
    {
        face = _face;
        face = (int)_favoriteSystem.GetFavoriteStatus();
        CheckFace();
    }
    
    /// <summary>
    /// 顔面更新
    /// </summary>
    private void CheckFace()
    {
        for(int i = 0; i < faces.Count; i++)
        {
            faces[i].SetActive(i == face);
        }
    }

}
