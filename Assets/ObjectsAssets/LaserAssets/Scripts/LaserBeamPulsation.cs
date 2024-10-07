using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamPulsation : MonoBehaviour
{
    [SerializeField] private Material _material;

    private float minOpacity;
    private float maxOpacity;
    private bool isRising;

    void Start(){
        minOpacity = 0.3f;
        maxOpacity = minOpacity + 0.3f;
        isRising = true;
    }

    void OnDisable(){
        Color buf = _material.color;
        buf.a = 0.4f;
        _material.color = buf;
    }

    void Update(){
        if (isRising){
            if (_material.color.a < maxOpacity){
                Color buf = _material.color;
                buf.a += 0.5f * Time.deltaTime;
                _material.color = buf;
            }
            else{
                isRising = false;
            }
        }
        else{
            if (_material.color.a > minOpacity){
                Color buf = _material.color;
                buf.a -= 0.5f * Time.deltaTime;
                _material.color = buf;
            }
            else{
                isRising = true;
            }
        }
    }
}
