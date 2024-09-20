using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplosionDiscard : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DiscardCoroutine());
    }

    private IEnumerator DiscardCoroutine(){
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);
    }
}
