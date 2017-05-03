using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankWars.Model {
    public class BoxGoal{

        public const int NUMBOXES_GOAL = 4;

        public delegate void GoalAchievedDelegate(BoxGoal sender);
        public event GoalAchievedDelegate onGoalAchieved;

        public int boxDestroyed = 0;

        public void BoxDestroyedAction() {
            boxDestroyed++;
            if (onGoalAchieved != null && boxDestroyed == NUMBOXES_GOAL) {
                onGoalAchieved(this);
            }
        }

    }
}
