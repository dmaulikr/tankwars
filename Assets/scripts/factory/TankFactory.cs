using System;
using System.Collections;
using System.Collections.Generic;
using TankWars.Model;
using UnityEngine;


namespace TankWars.Factory {
    public class TankFactory : ITankFactory {
        private Tank tank = null;

        public Tank getTank() {
            if(tank == null) {
                tank = new Tank();
            }
            return tank;
        }
    }
}
