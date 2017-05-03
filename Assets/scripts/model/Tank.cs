using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TankWars.Model {
    public class Tank {

        private int life;
        private int fuel;

        public int Life {
            get { return life; }
            set { life = value; }
        }

        public int Fuel {
            get { return fuel; }
            set { fuel = value; }
        }
    }
}
