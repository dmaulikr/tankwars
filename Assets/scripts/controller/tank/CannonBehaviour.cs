using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour {

    // Fire
    public Rigidbody rocketPrefab;
    public float missileForce = 20f;


    private void Update() {
        if(Input.GetButtonDown("Fire2")) {
            AudioSource explosionAudio = GetComponent<AudioSource>();
            explosionAudio.Play();
            Rigidbody rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
            rocket.AddForce(transform.forward * missileForce, ForceMode.Impulse);
        }
    }
}
