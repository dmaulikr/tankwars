using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour {

    [SerializeField]
    private string format = "Time: {0:00}:{1:00}.{2:000}";
    private float remainingTime;

    public float RemainingTime {
        get {
            return remainingTime;
        }
        set {
            if(remainingTime <= 0) {
                remainingTime = 0;
            } else {
                remainingTime = value;
            }
        }
    }

        // Use this for initialization
    void Start () {
        remainingTime = 0;
    }

    public void UpdateTimer(float currentSeconds) {
        var currentTimeSpan = System.TimeSpan.FromSeconds(currentSeconds);
        Text text = GetComponent<Text>();
        text.text = string.Format(format, currentTimeSpan.Minutes, currentTimeSpan.Seconds, currentTimeSpan.Milliseconds);
    }

    private void Update() {
        UpdateTimer(remainingTime / 1000);
    }
}
