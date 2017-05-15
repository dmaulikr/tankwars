using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour : MonoBehaviour {

    [SerializeField]
    private Rigidbody rocketPrefab;
    [SerializeField]
    private float missileForce = 20f;

    private void Update() {
        if(Input.GetButtonDown("Fire2")) {
            AudioSource explosionAudio = GetComponent<AudioSource>();
            explosionAudio.Play();
            Rigidbody rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
            rocket.AddForce(transform.forward * missileForce, ForceMode.Impulse);
            //rocket.AddForceAtPosition(transform.forward * missileForce, (rocket.transform.position + (rocket.transform.forward * 1)), ForceMode.Impulse);
        }
    }
}
