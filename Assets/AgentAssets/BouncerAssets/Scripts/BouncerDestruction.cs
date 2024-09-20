using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerDestruction : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Hazard")){
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
