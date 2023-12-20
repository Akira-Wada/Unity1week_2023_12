using System;
using System.Collections.Generic;
using UnityEngine;

public class FavoriteParam : MonoBehaviour
{
    public event Action OnFavoriteParamZero;
    [SerializeField] private int _favorite = 50;

    public int Get()
    {
        return _favorite;
    }

    public void Set(int value)
    {
        _favorite = Mathf.Clamp(value, 0, 999);

        if(_favorite <= 0)
        {
            OnFavoriteParamZero?.Invoke();
        }
    }
    
}
