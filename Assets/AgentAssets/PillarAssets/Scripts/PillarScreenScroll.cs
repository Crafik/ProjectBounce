using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PillarScreenScroll : MonoBehaviour
{
    void OnEnable(){
        BouncerScreenScroll.StartTransition += Transition;
    }

    void OnDisable(){
        BouncerScreenScroll.StartTransition -= Transition;
    }

    private void Transition(bool up){
        StartCoroutine(TransitionCoroutine(up));
    }

    private IEnumerator TransitionCoroutine(bool up){
        float counter = 0f;
        Vector3 startPos = transform.position;
        Vector3 transitionPos = startPos + ((up ? -1 : 1) * Vector3.up);
        while (counter < 0.5f){
            transform.position = Vector3.Lerp(startPos, transitionPos, counter * 2f);
            counter += Time.deltaTime;
            yield return null;
        }
        transform.position = transitionPos;
    }
}
