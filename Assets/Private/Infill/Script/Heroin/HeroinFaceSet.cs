using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroinFaceSet : MonoBehaviour
{
    [SerializeField,Header("表情リスト")] private List<GameObject> faces = new List<GameObject>();

    [SerializeField,Header("閾値")] private List<int> favoliteThreshold = new List<int>();
    public int face;           //現在の顔
    private int minThreshold;   //現在の顔の閾値下限
    private int maxThreshold;   //現在の顔の閾値上限

    public int debug;

    private void Start()
    {
        //顔面初期設定
        minThreshold = 0;
        maxThreshold = favoliteThreshold[0];
        //初期セット
        CheckFace();
    }
    private void Update() {
        SetFace(debug);
    }
    public void SetFace(int favolitePoint)
    {
        //下限ツッパした時
        if(favolitePoint < minThreshold)
        {
            if(face != 0)
            {
                face--;
                if(face == 0)
                {
                    minThreshold = 0;
                    maxThreshold = favoliteThreshold[0];
                }
                else
                {
                    minThreshold = favoliteThreshold[face - 1];
                    maxThreshold = favoliteThreshold[face];
                }
            }
            CheckFace();    
        }
        //上限ツッパ
        if(favolitePoint > maxThreshold)
        {
            //顔面がfavoliteThreshold.Count以上にはならない
            if(face != favoliteThreshold.Count - 1)
            {
                face++;
                minThreshold = favoliteThreshold[face - 1];
                maxThreshold = favoliteThreshold[face];
            }
            CheckFace();    
        }
    }
    private void CheckFace()
    {
        for(int i = 0; i < faces.Count; i++)
        {
            faces[i].SetActive(i == face);
        }
    }

}
