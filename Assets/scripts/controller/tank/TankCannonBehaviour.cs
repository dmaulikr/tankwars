using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannonBehaviour : MonoBehaviour {


    [SerializeField]
    private int moveSmooth = 300;
	
	// Update is called once per frame
	void Update () {
        Quaternion actualRotation = transform.localRotation;
        transform.Rotate(Vector3.forward, Input.GetAxis("Mouse Y") * moveSmooth * Time.deltaTime);
    }
}
