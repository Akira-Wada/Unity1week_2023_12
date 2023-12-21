using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "Datas/SceneData")]
public class SceneDatas : ScriptableObject
{
    public List<SceneData> dataList;

    [Serializable]
    public class SceneData
    {
        public string sceneName;
        public int sceneIndex;
    }
}
