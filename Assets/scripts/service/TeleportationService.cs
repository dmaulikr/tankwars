using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using TankWars.Service.Exceptions;


namespace TankWars.Service {
    class TeleportationService {

        public TeleportationService() {
        }

        public int randomPortalIndex(int count, int actual) {
            if(count <= 0) throw new InvalidNumberException();
            System.Random rnd = new System.Random();
            int number;
            do {
                number = rnd.Next(0, count);
            } while(number == actual);
            return number;
        }
    }
}
