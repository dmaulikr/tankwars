using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TankWars.Controller.Timer {

    public delegate void TimeChange(float millisecondsRemaining);
    public delegate void TimeFinished(object source);
    public delegate void TimeStopped(object source);

    public interface ITimer {
        event TimeChange OnTimeChange;
        event TimeFinished OnTimeFinished;
        event TimeStopped OnTimeStopped;
        void StopTimer();
        void AddMilliseconds(float milliseconds);
    }
}
