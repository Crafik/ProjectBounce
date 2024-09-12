using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    public float moveSpeed;

    private Vector3 _velocity;

    void Start(){
        _velocity = moveSpeed * Time.fixedDeltaTime * Vector3.up;
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Floor")){
            _velocity *= -1f;
        }
    }

    void FixedUpdate(){
        _rigidBody.MovePosition(_rigidBody.position + _velocity);
    }
}
