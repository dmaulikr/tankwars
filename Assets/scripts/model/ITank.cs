using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TankWars.Model {
    public interface ITank {
        int Life { get; set; }
        void AddDamage(int damage);
        bool IsDead();
    }
}
