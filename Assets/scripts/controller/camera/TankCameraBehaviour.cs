using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCameraBehaviour : MonoBehaviour {

    public Transform target;
    public float up = 5;
    public float back = 10;
    public float smooth = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Obtenemos 
        Vector3 sourcePosition = transform.position;
        Vector3 targetPosition = target.position + -target.transform.forward * back + target.transform.up * up;
        
        // Movimiento directo
        //transform.position = destinyPosition;

        // Movimiento interpolado
        Vector3 currentPosition = Vector3.Lerp(sourcePosition, targetPosition, smooth * Time.deltaTime);
        transform.position = currentPosition;

        // Dirección de vista
        transform.LookAt(target);
	}


}
