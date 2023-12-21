using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueButton : MonoBehaviour
{
    [SerializeField] private GameObject menueObject;
    private void Start() {
        menueObject.SetActive(false);
    }
    public void Activate()
    {
        menueObject.SetActive(true);
    }
    public void Deactivate()
    {
        menueObject.SetActive(false);
    }
}
