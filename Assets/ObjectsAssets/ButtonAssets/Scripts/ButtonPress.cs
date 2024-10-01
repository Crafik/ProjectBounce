using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private GameObject movingPart;

    [Space (10)]
    [Header ("===== References =====")]
    [SerializeField] public List<GameObject> activatableObjects;

    private bool isPressed;

    void Start(){
        isPressed = false;
    }

    void OnTriggerEnter(Collider collision){
        if (!isPressed){
            if (collision.CompareTag("Player")){
                isPressed = true;
                _collider.enabled = false;
                movingPart.transform.localPosition -= Vector3.up * 0.068f;
                foreach (GameObject obj in activatableObjects){
                    obj?.GetComponent<IActivatable>().Activate();
                }
            }
        }
    }
}
