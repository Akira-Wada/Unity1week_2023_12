using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 時間制限実装
/// </summary>
public class GameTImer : MonoBehaviour
{
    [SerializeField]SceneController sceneController;
    public float timer{ get; private set; }
    private const int BADEND_INDEX = 4;

    [SerializeField] private float timeLimit = 1f;
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > timeLimit)
        {
            sceneController.LoadSelectScene(BADEND_INDEX);
        }
    }
}
