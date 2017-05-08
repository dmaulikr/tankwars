using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TankWars.Context;
using TankWars.Controller.Tank;

public class MagickPortalBehaviour : MonoBehaviour {

    [SerializeField]
    private GameContext context;

    private void Start() {
        context.AddMagickPortal(gameObject);
    } 
}
