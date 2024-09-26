using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerDestruction : MonoBehaviour
{
    public static event Action PlayerDeath;

    [SerializeField] private GameObject explosionPrefab;

    void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Hazard")){
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            PlayerDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
