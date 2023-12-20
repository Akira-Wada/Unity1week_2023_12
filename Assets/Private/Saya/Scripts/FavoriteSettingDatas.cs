using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Datas/FavoriteSettingData", fileName = "FavoriteSettingData")]
public class FavoriteSettingDatas : ScriptableObject
{
    public List<FavoriteSettingData> dataList;

    [Serializable]
    public class FavoriteSettingData
    {
        [Header("好感度の下限値")]
        public int lowerScore;
        [Header("好感度の上限値")]
        public int upperScore;
        [Header("好感度変動の開始時間[s]")]
        public float waitTime;
        [Header("好感度変動の間隔[s]")]
        public float durationTime;
    }

}