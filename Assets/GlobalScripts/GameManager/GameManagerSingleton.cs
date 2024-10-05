using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSingleton : MonoBehaviour
{
    public static GameManagerSingleton instance { get; private set; }

    [SerializeField] private LevelList _levelList;

    void Awake(){
        if (instance != null && instance != this){
            Destroy(instance);
        }
        else{
            instance = this;
        }
    }

    // here be code
}
