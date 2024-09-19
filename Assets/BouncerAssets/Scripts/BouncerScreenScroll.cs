using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerScreenScroll : MonoBehaviour
{
    public static event Action<bool> StartTransition;
    public static event Action EndTransition;

    [SerializeField] private Rigidbody _rigidBody;

    private bool isTransitioning;

    void Start(){
        isTransitioning = false;
    }

    void FixedUpdate(){
        if (!isTransitioning){
            if (_rigidBody.position.y > 1f){
                ScreenTransition(true);
            }
            if (_rigidBody.position.y < 0f){
                ScreenTransition(false);
            }
        }
    }

    private void ScreenTransition(bool up){
        isTransitioning = true;
        StartTransition?.Invoke(up); // need to subscribe others
        StartCoroutine(TransitionCoroutine(up));
    }

    private IEnumerator TransitionCoroutine(bool up){
        float counter = 0f;
        Vector3 currentPos = _rigidBody.position;
        Vector3 transitionPos = new Vector3(0f, up ? 0.1f : 0.9f, 0f);
        while(counter < 0.5f){
            _rigidBody.MovePosition(Vector3.Lerp(currentPos, transitionPos, counter * 2f));
            counter += Time.deltaTime;
            yield return null;
        }
        _rigidBody.MovePosition(transitionPos);
        isTransitioning = false;
        EndTransition?.Invoke();
    }
}
