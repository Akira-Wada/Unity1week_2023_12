using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueButton : MonoBehaviour
{
    [SerializeField] private GameObject menueObject;
    public void Activate()
    {
        menueObject.SetActive(true);
    }
    public void Deactivate()
    {
        menueObject.SetActive(false);
    }
}
