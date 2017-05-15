using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBaseBehaviour : MonoBehaviour {

    private int moveSmooth = 70000;
    private int width;
    
    // Use this for initialization
	void Start () {
        width = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion actualRotation = transform.localRotation;
        transform.Rotate(Vector3.up, (Input.GetAxis("Mouse X") / width) * moveSmooth * Time.deltaTime);
    }
}
