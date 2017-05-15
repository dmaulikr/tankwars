using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannonBehaviour : MonoBehaviour {

    private int moveSmooth = 70000;
    private int height;

    void Start()
    {
        height = Screen.height;
    }


    // Update is called once per frame
    void Update () {
        Quaternion actualRotation = transform.localRotation;
        transform.Rotate(Vector3.forward, (Input.GetAxis("Mouse Y") / height) * moveSmooth * Time.deltaTime);
    }
}
