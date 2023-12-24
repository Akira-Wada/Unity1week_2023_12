using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseDirection;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60;
    [SerializeField]private float _koutyouEndTime = 5;
    [SerializeField]private GameEndScript _gameEndScript;
    [SerializeField]private PlayerLook _playerLook;
    private float _koutyouLookingTimer;
    private float _gameTiemr;

    //追記
    [SerializeField] private float endSETime;
    [SerializeField] private AudioSource endAudio;

    void Start()
    {
        _koutyouLookingTimer = 0;
        _gameTiemr = 0;
    }

    void Update()
    {
        _gameTiemr += Time.deltaTime;

        if(_gameTiemr >= timeLimit)
        {
            endAudio.Play();

            Invoke("EndScene", endSETime);
        }

        if(_playerLook.GetDirection() == Direction.Up)
        {
            _koutyouLookingTimer += Time.deltaTime;
            if(_koutyouLookingTimer >= _koutyouEndTime)
            {
                _gameEndScript.KoutyouEnd();
            }
        }
    }
    void EndScene()
    {
        _gameEndScript.TimeLimitEnd();
    }

}
