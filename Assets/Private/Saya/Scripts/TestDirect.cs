using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDirect : MonoBehaviour
{

    public GameObject hiroin1;
    public GameObject hiroin2;
    public GameObject hiroin3;
    public GameObject hiroin4;
    private FavoriteSystem _favo_system;

    void Start()
    {
        _favo_system = GetComponent<FavoriteSystem>();

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            _favo_system.OnLooking(hiroin1);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            _favo_system.OnLooking(hiroin2);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _favo_system.OnLooking(hiroin3);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _favo_system.OnLooking(hiroin4);
        }
        
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            _favo_system.OnEndLooking();
        }
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            _favo_system.OnEndLooking();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            _favo_system.OnEndLooking();
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _favo_system.OnEndLooking();
        }
    }
}
