using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TankWars.Model {
    public class Tank : ITank{

        private const int DEFAULT_LIFE = 500;
        private int life;

        public int Life {
            get { return life; }
            set { life = value; }
        }

        public Tank() {
            Life = DEFAULT_LIFE;
        }

        public Tank(int life) {
            Life = life;
        }

        public bool IsDead() {
            return Life <= 0;
        }

        public void AddDamage(int damage) {
            if (Life <= damage) life = 0;
            Life -= damage;
            
        }
    }
}
