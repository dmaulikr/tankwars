using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TankWars.Controller.Tank;

public class LandmineBehaviour : MonoBehaviour {

    [SerializeField]
    private GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        TankBehaviour tank = collision.gameObject.GetComponent<TankBehaviour>();
        MissileBehaviour missile = collision.gameObject.GetComponent<MissileBehaviour>();
        GraphicExplosion missileExplosion = collision.gameObject.GetComponent<GraphicExplosion>();

        if (tank != null || missile != null || missileExplosion != null)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.SetActive(true);
            Destroy(gameObject);
        }
        
    }
}
