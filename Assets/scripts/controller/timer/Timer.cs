using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace TankWars.Controller.Timer {
    public class Timer : ITimer{
        // Default config
        private const float DEFAULT_TOTAL_MILISECONDS = 90000;
        private const float DEFAULT_TICK_INTERVAL = 500;

        private float timeRemaining;
        private System.Timers.Timer timer;

        // Events
        public event TimeChange OnTimeChange;
        public event TimeFinished OnTimeFinished;
        public event TimeStopped OnTimeStopped;

        public Timer() {
            timeRemaining = DEFAULT_TOTAL_MILISECONDS;
            StartTimer(DEFAULT_TICK_INTERVAL);
        }

        public Timer(float totalTimeInMilliseconds) {
            timeRemaining = totalTimeInMilliseconds;
            StartTimer(DEFAULT_TICK_INTERVAL);
        }

        public Timer(float totalTimeInMilliseconds, float intervalInMilliseconds) {
            timeRemaining = totalTimeInMilliseconds;
            StartTimer(intervalInMilliseconds);
        }

        private void StartTimer(float interval) {
            timer = new System.Timers.Timer();
            timer.Interval = interval;
            timer.AutoReset = true;
            timer.Elapsed += OnTimerEvent;
            // Start the timer
            timer.Enabled = true;
        }

        private void OnTimerEvent(object source, System.Timers.ElapsedEventArgs e) {
            timeRemaining -= (float)timer.Interval;
            if(timeRemaining <= 0) {
                timer.Elapsed -= ((Timer)source).OnTimerEvent;
                if(OnTimeFinished != null) {
                    OnTimeFinished(this);
                }
            } else {
                if(OnTimeFinished != null) {
                    OnTimeChange(timeRemaining);
                }
            }
        }

        public void StopTimer() {
            timer.Enabled = false;
            if(OnTimeStopped != null) {
                OnTimeStopped(this);
            }
        }
    }
}
