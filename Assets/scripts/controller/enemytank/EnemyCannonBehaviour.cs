using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonBehaviour : MonoBehaviour {

    public Rigidbody rocketPrefab;
    public float missileForce = 20f;

    private void Start() {
        System.Random rnd = new System.Random();
        float fireRate = ((float)rnd.Next(10, 30))/10;
        InvokeRepeating("EnemyFire", 0, fireRate);
    }

    private void EnemyFire() {
        AudioSource explosionAudio = GetComponent<AudioSource>();
        explosionAudio.Play();
        Rigidbody rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
        rocket.AddForce(transform.forward * missileForce, ForceMode.Impulse);
    }
}
