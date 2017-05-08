using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBaseBehaviour : MonoBehaviour {

    [SerializeField]
    private int moveSmooth = 100;
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion actualRotation = transform.localRotation;
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * moveSmooth * Time.deltaTime);
    }
}
