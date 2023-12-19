using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPushRightArrow(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
    }
    public void OnPushLeftArrow(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
    }
    public void OnPushUpArrow(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
    }
    public void OnPushDownArrow(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
    }
}
