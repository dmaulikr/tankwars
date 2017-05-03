using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TankWars.Model;

namespace TankWars.Factory {
    interface IGoalsFactory {
        BoxGoal getBoxGoal();
        PathGoal getPathGoal();
    }
}


