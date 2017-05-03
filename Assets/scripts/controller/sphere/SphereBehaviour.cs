using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TankWars.Context;
using TankWars.Model;
using TankWars.Controller.Tank;

public class SphereBehaviour : MonoBehaviour {
    public GameContext context;

    private void OnCollisionEnter(Collision collision) {
        GameObject collisionSource = collision.gameObject;
        //Debug.Log(collisionSource.name + ": " + collisionSource.tag);
        TankBehaviour tank = collisionSource.GetComponent<TankBehaviour>();
        if (tank != null) {
            Destroy(gameObject);
            context.getPathGoal().PathAchievedAction();
        } 
    }
}
