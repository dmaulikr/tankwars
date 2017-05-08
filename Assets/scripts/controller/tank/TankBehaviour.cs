using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TankWars.Context;

namespace TankWars.Controller.Tank {

    public class TankBehaviour : MonoBehaviour {

        public GameContext context;

        // Movement
        public float moveSpeed = 10f;
        public float turnSpeed = 50f;

        // Update is called once per frame
        void Update() {
            if(Input.GetKey(KeyCode.UpArrow)) {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.DownArrow)) {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.LeftArrow)) {
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.RightArrow)) {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }


            
        }
    }
}
