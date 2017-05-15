using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour {

    [SerializeField]
    private GameObject explosionPrefab;
    private Rigidbody rigid;

    private void Awake() {
        rigid = GetComponent<Rigidbody>();

    }

    private void Update() {
        transform.rotation = Quaternion.LookRotation(rigid.velocity);

    }

    private void OnCollisionEnter(Collision collision) {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        explosion.SetActive(true);
        Destroy(gameObject);
    }
}
