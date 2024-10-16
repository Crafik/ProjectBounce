using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerFinish : MonoBehaviour
{
    public static event Action LevelFinished;
    
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private GameObject _ball;

    private bool isFinishing;

    void Start(){
        isFinishing = false;
    }

    void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Finish") && !isFinishing){
            isFinishing = true;
            LevelFinished?.Invoke();
            StartCoroutine(FinishingCoroutine(collision.transform.GetChild(0).position));
        }
    }

    private IEnumerator FinishingCoroutine(Vector3 finPos){
        float counter = 0f;
        Vector3 startPos = _rigidBody.position;
        Vector3 startScale = _ball.transform.localScale;
        while (counter < 1f){
            counter += Time.deltaTime;
            _rigidBody.MovePosition(Vector3.Lerp(startPos, finPos, counter));
            _ball.transform.localScale = Vector3.Lerp(startScale, Vector3.zero, counter);
            yield return null;
        }
    }
}
