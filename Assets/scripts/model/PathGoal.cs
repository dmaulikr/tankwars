using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankWars.Model {
    public class PathGoal{

        public const int NUMPATHS_GOAL = 4;

        public delegate void GoalAchievedDelegate(PathGoal sender);
        public event GoalAchievedDelegate onGoalAchieved;

        public int pathsReached = 0;

        public void PathAchievedAction() {
            pathsReached++;
            if (onGoalAchieved != null && pathsReached == NUMPATHS_GOAL) {
                onGoalAchieved(this);
            }
        }
    }
}
