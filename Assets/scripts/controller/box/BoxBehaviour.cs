using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TankWars.Context;
using TankWars.Model;

public class BoxBehaviour : MonoBehaviour {
    public GameContext context;

    private void OnCollisionEnter(Collision collision) {
        GameObject collisionSource = collision.gameObject;
        //Debug.Log(collisionSource.name + ": " + collisionSource.tag);
        MissileBehaviour missile = collisionSource.GetComponent<MissileBehaviour>();
        if (missile != null) {
            Destroy(gameObject);
            context.getBoxGoal().BoxDestroyedAction();
        } 
    }
}
