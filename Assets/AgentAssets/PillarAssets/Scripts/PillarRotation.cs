using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PillarRotation : MonoBehaviour
{
    private Controls _controls;

    public float rotationSpeed;

    private bool isActive;

    void Awake(){
        _controls = new Controls();
    }

    void OnEnable(){
        _controls.Enable();

        _controls.Touch.TouchDelta.performed += TouchPerformed;

        BouncerScreenScroll.StartTransition += TransitionStart;
        BouncerScreenScroll.EndTransition += TransitionEnd;
    }

    void OnDisable(){
        _controls.Touch.TouchDelta.performed -= TouchPerformed;

        BouncerScreenScroll.StartTransition -= TransitionStart;
        BouncerScreenScroll.EndTransition -= TransitionEnd;

        _controls.Disable();
    }

    void Start(){
        isActive = true;
    }

    private void TouchPerformed(InputAction.CallbackContext ctx){
        if (isActive){
            float rot = ctx.ReadValue<Vector2>().x;
            transform.Rotate(Vector3.up, -rot * rotationSpeed);
        }
    }

    private void TransitionStart(bool omitted){
        isActive = false;
    }

    private void TransitionEnd(){
        isActive = true;
    }
}
