using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TankWars.Model;

namespace TankWars.Factory {
    class GoalsFactory : IGoalsFactory {
        private BoxGoal boxGoal = null;
        private PathGoal pathGoal = null;

        public BoxGoal getBoxGoal() {
            if(boxGoal == null) {
                boxGoal = new BoxGoal();
            }
            return boxGoal;
        }

        public PathGoal getPathGoal() {
            if(pathGoal == null) {
                pathGoal = new PathGoal();
            }
            return pathGoal;
        }
    }
}
