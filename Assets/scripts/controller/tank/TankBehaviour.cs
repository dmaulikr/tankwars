using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TankWars.Context;

namespace TankWars.Controller.Tank {

    public class TankBehaviour : MonoBehaviour {

        [SerializeField]
        private GameObject explosionPrefab;

        [SerializeField]
        private GameContext context;

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

        private void OnCollisionEnter(Collision collision)
        {
            MissileBehaviour missile = collision.gameObject.GetComponent<MissileBehaviour>();
            GraphicExplosion missileExplosion = collision.gameObject.GetComponent<GraphicExplosion>();
            LandmineBehaviour landmine = collision.gameObject.GetComponent<LandmineBehaviour>();

            if (missile != null || missileExplosion != null || landmine != null)
            {
                OnImpact();
            }

        }

        private void OnImpact()
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.SetActive(true);
            Debug.Log("Impact recieved!");
        }

        private void OnDestruction()
        {
            /*
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.SetActive(true);
            Destroy(gameObject);
             */
            Debug.Log("Tank destroyed!");
        }
    }
}
