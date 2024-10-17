using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBouncerMovement : MonoBehaviour
{
    void FixedUpdate(){
        transform.Rotate(Vector3.up, 90f * Time.fixedDeltaTime);
    }
}
