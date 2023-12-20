using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteTimer : MonoBehaviour
{

    [SerializeField] private float _eventTimer;
    [SerializeField] private float _countTimer;


    float GetEventTimer() 
    {
        return _eventTimer;
    }

    void SetEventTimer(float value) 
    {
        _eventTimer = value;
    }

    float GetCountTimer()
    {
        return _countTimer;
    }

    void SetCountTimer(float value) 
    {
        _countTimer = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
