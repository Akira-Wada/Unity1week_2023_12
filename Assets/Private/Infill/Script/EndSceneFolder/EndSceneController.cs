using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    public int pageNum = 0;
    [SerializeField] private int pageMin;
    [SerializeField] private int pageMax;
    [SerializeField] private List<GameObject> PanelList = new List<GameObject>();
    private void Start() {
        FitOpenPanel();
    }
    public void FitOpenPanel()
    {
        for(int i = 0; i < PanelList.Count; i++) PanelList[i].SetActive(i == pageNum);
    }
    public void OnClickNext()
    {
        if (pageNum == pageMax) return;
        else pageNum++;
        FitOpenPanel();
    }
    public void OnClickBack()
    {
        if (pageNum == pageMin) return;
        else pageNum--;
        FitOpenPanel();
    }
}
