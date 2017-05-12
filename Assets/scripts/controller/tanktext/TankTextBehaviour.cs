using System;
using System.Collections;
using System.Collections.Generic;
using TankWars.Context;
using UnityEngine;
using UnityEngine.UI;

public class TankTextBehaviour : MonoBehaviour {

    [SerializeField]
    private GameContext context;

    private bool []missionCompleted;

    // Use this for initialization
    void Start () {
        context.getPathGoal().onGoalAchieved += TankTextBehaviour_onPathGoalAchieved;
        context.getBoxGoal().onGoalAchieved += TankTextBehaviour_onBoxGoalAchieved;
        initCompleteMissionTrack();
    }

    private void initCompleteMissionTrack() {
        missionCompleted = new bool[2];
        for(int i=0; i< missionCompleted.Length; i++) {
            missionCompleted[i] = false;
        }
    }

    private bool areMissionsCompleted() {
        for(int i = 0; i < missionCompleted.Length; i++) {
            if(!missionCompleted[i]) return false;
        }
        return true;
    }

    private void TankTextBehaviour_onBoxGoalAchieved(TankWars.Model.BoxGoal sender) {
        missionCompleted[0] = true;
        Text textComponent = GetComponent<Text>();
        textComponent.text = " -- Mission 2 --\r\n Congrats, boxes goal archieved!";
        if(!areMissionsCompleted()) {
            StartCoroutine(loadPathMission());
        } else {
            StartCoroutine(loadGoalsAchieved());
        }
    }

    private void TankTextBehaviour_onPathGoalAchieved(TankWars.Model.PathGoal sender) {
        missionCompleted[1] = true;
        Text textComponent = GetComponent<Text>();
        textComponent.text = " -- Mission 1 --\r\n Congrats, path goal archieved!";
        if(!areMissionsCompleted()) {
            StartCoroutine(loadBoxMission());
        } else {
            StartCoroutine(loadGoalsAchieved());
        }
    }

    private IEnumerator loadPathMission() {
        yield return new WaitForSeconds(3f);
        Text textComponent = GetComponent<Text>();
        textComponent.text = " -- Mission 1 --\r\n Reach all checkpoints\r\n(Touch 'red balloons')";
        yield return null;
    }

    private IEnumerator loadBoxMission() {
        yield return new WaitForSeconds(3f);
        Text textComponent = GetComponent<Text>();
        textComponent.text = " -- Mission 2 --\r\n Destroy all boxes";
        yield return null;
    }

    private IEnumerator loadGoalsAchieved() {
        yield return new WaitForSeconds(3f);
        Text textComponent = GetComponent<Text>();
        textComponent.text = " -- Missions achieved --\r\n Congrats! All missions done!";
        context.getTimer().StopTimer();
        yield return null;
    }
}
