using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSwitch : MonoBehaviour, IActivatable
{
    [SerializeField] private GameObject _hazard;

    [Space (15)]
    public bool isOff;

    void Start(){
        if (isOff){
            _hazard.SetActive(false);
        }
    }

    public void Activate(){
        // here be code
        _hazard.SetActive(!_hazard.activeSelf);
    }
}
