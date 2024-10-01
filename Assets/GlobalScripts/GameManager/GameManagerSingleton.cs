using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance { get; private set; }

    void Awake(){
        if (instance != null && instance != this){
            Destroy(instance);
        }
        else{
            instance = this;
        }
    }
}
