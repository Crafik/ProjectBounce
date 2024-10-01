using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSwitch : MonoBehaviour, IActivatable
{
    [SerializeField] private GameObject _hazard;

    public void Activate(){
        // here be code
        _hazard.SetActive(!_hazard.activeSelf);
    }
}
