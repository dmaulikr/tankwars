using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonBehaviour : MonoBehaviour {

    // Fire
    public Rigidbody rocketPrefab;
    public float missileForce = 20f;


    private void Start() {
        InvokeRepeating("EnemyFire", 0, 1f);
    }

    private void EnemyFire() {
        AudioSource explosionAudio = GetComponent<AudioSource>();
        explosionAudio.Play();
        Rigidbody rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
        rocket.AddForce(transform.forward * missileForce, ForceMode.Impulse);
    }
}
