using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 時間制限実装
/// </summary>
public class GameTImer : MonoBehaviour
{
    public float timer{ get; private set; }

    [SerializeField] private float timeLimit = 1f;
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    }
}
