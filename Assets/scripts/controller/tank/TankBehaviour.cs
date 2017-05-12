using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TankWars.Context;
using TankWars.Model;
using UnityEngine.UI;

namespace TankWars.Controller.Tank {

    public class TankBehaviour : MonoBehaviour {

        [SerializeField]
        private GameObject explosionPrefab;

        [SerializeField]
        private GameContext context;

        [SerializeField]
        private Slider lifeSlider;

        // Damege
        private const int DEFAULT_IMPACT_DAMAGE = 200;
        private const int DEFAULT_TANK_LIFE = 500;

        // Movement
        public float moveSpeed = 10f;
        public float turnSpeed = 50f;

        private TankWars.Model.ITank tank;

        private void Awake() {
            tank = new TankWars.Model.Tank(DEFAULT_TANK_LIFE);
            lifeSlider.maxValue = DEFAULT_TANK_LIFE;
            lifeSlider.value = DEFAULT_TANK_LIFE;
        }

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
            if(Input.GetKey(KeyCode.Backspace)) {
                FixPosition();
            }

            if(tank.IsDead()) {
                OnDestruction();
            }
        }

        private void FixPosition() {
            Vector3 actualRotation = transform.rotation.eulerAngles;
            actualRotation.x = 0;
            actualRotation.z = 0;
            transform.rotation = Quaternion.Euler(actualRotation);
            transform.position += new Vector3(0, 1, 0);
        }

        private void OnCollisionEnter(Collision collision)
        {
            MissileBehaviour missile = collision.gameObject.GetComponent<MissileBehaviour>();
            GraphicExplosion missileExplosion = collision.gameObject.GetComponent<GraphicExplosion>();
            LandmineBehaviour landmine = collision.gameObject.GetComponent<LandmineBehaviour>();

            if (missile != null || missileExplosion != null || landmine != null){
                OnImpact();
            }

        }

        public void TriggerDestruction() {
            tank.AddDamage(tank.Life);
        }

        private void OnImpact()
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.SetActive(true);
            tank.AddDamage(DEFAULT_IMPACT_DAMAGE);
            Debug.Log("Impact recieved!");
            if (tank.IsDead()){
                OnDestruction();
            } else {
                lifeSlider.value -= DEFAULT_IMPACT_DAMAGE;
            }
        }

        private void OnDestruction()
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.transform.localScale += new Vector3(1f, 1f, 1f);
            explosion.SetActive(true);
            gameObject.SetActive(false);
            lifeSlider.value = 0;
            //Destroy(gameObject);
            Debug.Log("Tank destroyed!");
        }
    }
}
