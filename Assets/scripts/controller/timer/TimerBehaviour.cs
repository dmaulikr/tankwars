using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBehaviour : MonoBehaviour {

    [SerializeField]
    private string format = "Time: {0:00}:{1:00}.{2:000}";

    public float RemainingTime { get; set; }

        // Use this for initialization
    void Start () {
        RemainingTime = 0;
    }

    public void UpdateTimer(float currentSeconds) {
        System.TimeSpan currentTimeSpan = System.TimeSpan.FromSeconds(currentSeconds);
        Text text = GetComponent<Text>();
        text.text = string.Format(format, currentTimeSpan.Minutes, currentTimeSpan.Seconds, currentTimeSpan.Milliseconds);
    }

    private void Update() {
        UpdateTimer(RemainingTime / 1000);
    }
}
