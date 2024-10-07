using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerFinish : MonoBehaviour
{
    public static event Action LevelFinished;
    
    [SerializeField] private Rigidbody _rigidBody;



    void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Finish")){
            // here be code
            Debug.Log("Finish finished yeah");
        }
    }
}
