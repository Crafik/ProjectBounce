using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PillarRotation : MonoBehaviour
{
    private Controls _controls;

    public float rotationSpeed;

    void Awake(){
        _controls = new Controls();
    }

    void OnEnable(){
        _controls.Enable();

        _controls.Touch.TouchDelta.performed += TouchPerformed;
    }

    void OnDisable(){
        _controls.Touch.TouchDelta.performed -= TouchPerformed;

        _controls.Disable();
    }

    private void TouchPerformed(InputAction.CallbackContext ctx){
        float rot = ctx.ReadValue<Vector2>().x;
        transform.Rotate(Vector3.up, -rot * rotationSpeed);
    }
}
