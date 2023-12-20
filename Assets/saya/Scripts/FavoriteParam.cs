using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteParam : MonoBehaviour
{
    [SerializeField] private int _favorite = 50;

    public int Get()
    {
        return _favorite;
    }

    public void Set(int value)
    {
        _favorite = Mathf.Clamp(value, 0, 999);
    }
    
}
