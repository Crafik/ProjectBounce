using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    public float moveSpeed;

    [HideInInspector] public bool isMoving;
    private Vector3 _velocity;

    void OnEnable(){
        BouncerScreenScroll.StartTransition += TransitionStart;
        BouncerScreenScroll.EndTransition += TransitionEnd;
    }

    void OnDisable(){
        BouncerScreenScroll.StartTransition -= TransitionStart;
        BouncerScreenScroll.EndTransition -= TransitionEnd;
    }

    void Start(){
        _velocity = moveSpeed * Time.fixedDeltaTime * Vector3.up;
        isMoving = true;
    }

    void OnCollisionEnter(Collision collision){
        if (isMoving){
            if (collision.gameObject.CompareTag("Floor")){
                _velocity *= -1f;
            }
        }
    }

    void FixedUpdate(){
        if (isMoving){
            _rigidBody.MovePosition(_rigidBody.position + _velocity);
        }
    }

    private void TransitionStart(bool omitted){
        isMoving = false;
    }

    private void TransitionEnd(){
        isMoving = true;;
    }
}
