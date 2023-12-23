using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuKeyboard : MonoBehaviour
{
    [SerializeField] private GameObject menuObject;
    // Start is called before the first frame update
    public void OnPushEscape(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (menuObject.activeSelf) menuObject.SetActive(false);
        else menuObject.SetActive(true);
    }
}
