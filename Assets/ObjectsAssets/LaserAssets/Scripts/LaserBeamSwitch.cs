using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamSwitch : MonoBehaviour, IActivatable
{
    [SerializeField] private GameObject _beam;

    public void Activate(){
        // here be code
        _beam.SetActive(!_beam.activeSelf);
    }
}
