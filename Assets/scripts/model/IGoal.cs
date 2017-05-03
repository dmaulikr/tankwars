using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankWars.Model {
    public interface IGoal {
        void Unsubscribe(IGoal goal);
    }
}
