using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTimer : MonoBehaviour
{
    [SerializeField] private HazardSwitch _hazardSwitch;

    [Space (15)]
    public bool isTimedSwitch;
    public float timer;
    public float delay;

    private float _counter;

    void Awake(){
        _counter = timer + delay;
    }

    void Update(){
        if (isTimedSwitch){
            _counter -= Time.deltaTime;

            if (_counter < 0f){
                _counter = timer;
                _hazardSwitch.Activate();
            }
        }
    }
}
