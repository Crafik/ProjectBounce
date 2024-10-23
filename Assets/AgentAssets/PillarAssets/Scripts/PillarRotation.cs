using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PillarRotation : MonoBehaviour
{
    private Controls _controls;

    public float rotationSpeed;

    private bool isMousePressed;

    private bool isActive;

    void Awake(){
        _controls = new Controls();
        isMousePressed = false;
    }

    void OnEnable(){
        _controls.Enable();

        _controls.Touch.TouchDelta.performed += TouchPerformed;
        _controls.Mouse.MouseDrag.performed += MouseDragPerformed;
        _controls.Mouse.MouseClick.performed += MouseClickPerformed;
        _controls.Mouse.MouseClick.canceled += MouseClickPerformed;

        BouncerScreenScroll.StartTransition += TransitionStart;
        BouncerScreenScroll.EndTransition += SetActive;

        BouncerDestruction.PlayerDeath += SetInactive;

        BouncerFinish.LevelFinished += SetInactive;
    }

    void OnDisable(){
        _controls.Touch.TouchDelta.performed -= TouchPerformed;
        _controls.Mouse.MouseDrag.performed -= MouseDragPerformed;
        _controls.Mouse.MouseClick.performed -= MouseClickPerformed;
        _controls.Mouse.MouseClick.canceled -= MouseClickPerformed;

        BouncerScreenScroll.StartTransition -= TransitionStart;
        BouncerScreenScroll.EndTransition -= SetActive;

        BouncerDestruction.PlayerDeath -= SetInactive;

        BouncerFinish.LevelFinished -= SetInactive;

        _controls.Disable();
    }

    void Start(){
        isActive = true;
    }

    private void MouseDragPerformed(InputAction.CallbackContext ctx){
        if (isActive && isMousePressed){
            float rot = _controls.Mouse.MouseDrag.ReadValue<Vector2>().x;
            transform.Rotate(Vector3.up, -rot * rotationSpeed);
        }
    }

    private void TouchPerformed(InputAction.CallbackContext ctx){
        if (isActive){
            float rot = ctx.ReadValue<Vector2>().x;
            transform.Rotate(Vector3.up, -rot * rotationSpeed);
        }
    }

    private void MouseClickPerformed(InputAction.CallbackContext ctx){
        isMousePressed = ctx.performed;
    }

    private void TransitionStart(bool omitted){
        SetInactive();
    }

    private void SetActive(){
        isActive = true;
    }

    private void SetInactive(){
        isActive = false;
    }
}
