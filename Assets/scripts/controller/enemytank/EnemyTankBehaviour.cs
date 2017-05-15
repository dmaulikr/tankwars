using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TankWars.Context;
using TankWars.Model;
using UnityEngine.UI;

namespace TankWars.Controller.Tank {

    public class EnemyTankBehaviour : MonoBehaviour {

        [SerializeField]
        private GameObject explosionPrefab;

        // Damage
        private const int DEFAULT_IMPACT_DAMAGE = 200;
        private const int DEFAULT_TANK_LIFE = 200;


        private TankWars.Model.ITank tank;

        private void Awake() {
            tank = new TankWars.Model.Tank(DEFAULT_TANK_LIFE);
        }

        // Update is called once per frame
        void Update() {

            if(tank.IsDead()) {
                OnDestruction();
            }
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
            if (tank.IsDead()){
                OnDestruction();
            }
        }

        private void OnDestruction()
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.transform.localScale += new Vector3(1f, 1f, 1f);
            explosion.SetActive(true);
            gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("Enemy destroyed!");
        }
    }
}
