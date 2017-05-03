using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour {

    // Duration of missile
    public GameObject explosionPrefab;
    
    // Timeout destroy
    /*
    public float duration = 3f;
    void Start() {
        Destroy(gameObject, duration);
    }
    */

    private void OnCollisionEnter(Collision collision) {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        explosion.SetActive(true);
        Destroy(gameObject);
    }
}
