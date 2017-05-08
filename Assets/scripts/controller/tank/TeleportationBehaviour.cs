using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TankWars.Context;

namespace TankWars.Controller.Tank {

    public class TeleportationBehaviour : MonoBehaviour {

        [SerializeField]
        private GameContext context;
        [SerializeField]
        public int teleportationDistance = 5;

        private void OnCollisionEnter(Collision collision) {
            GameObject collisionSource = collision.gameObject;
            //Debug.Log(collisionSource.name + ": " + collisionSource.tag);
            MagickPortalBehaviour magickPortal = collisionSource.GetComponent<MagickPortalBehaviour>();
            if(magickPortal != null) {
                GameObject source = magickPortal.gameObject;
                Debug.Log(source.name);
                GameObject destiny = context.TankMagicPortalTeleportation(source);
                transform.position = destiny.transform.position + (destiny.transform.forward * teleportationDistance);
                transform.LookAt(destiny.transform.forward);
            }
        }
    }
}
