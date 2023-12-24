using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseDirection;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60;
    [SerializeField]private float _OtherEnd4Time = 5;
    [SerializeField]private GameEndScript _gameEndScript;
    [SerializeField]private PlayerLook _playerLook;
    private float _otherEnd4LookingTimer;
    private float _gameTiemr;

    [SerializeField] private AudioSource endAudio;
    public bool isEnd = false;

    void Start()
    {
        _otherEnd4LookingTimer = 0;
        _gameTiemr = 0;
    }

    void Update()
    {
        _gameTiemr += Time.deltaTime;

        if(_gameTiemr >= timeLimit)
        {
            _gameTiemr = 0f;
            endAudio.Play();
            EndScene();
        }

        if(_playerLook.GetDirection() == Direction.Up)
        {
            _otherEnd4LookingTimer += Time.deltaTime;
            if(_otherEnd4LookingTimer >= _OtherEnd4Time)
            {
                _gameEndScript.Other4End();
            }
        }
        else
        {
            _otherEnd4LookingTimer = 0;
        }
    }
    void EndScene()
    {
        _gameEndScript.TimeLimitEnd();
    }

}
