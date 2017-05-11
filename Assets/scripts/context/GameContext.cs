using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using TankWars.Factory;
using TankWars.Model;
using TankWars.Service;
using TankWars.Controller.Timer;

namespace TankWars.Context {
    public class GameContext : MonoBehaviour, ITankFactory, IGoalsFactory {

        private ITankFactory tankFactory;
        private IGoalsFactory goalsFactory;
        private ITimer timer;

        [SerializeField]
        private TimerBehaviour timerUI;
        [SerializeField]
        private ScoreBehaviour scoreUI;

        private List<GameObject> magickPortalList;
        private TeleportationService teleporTationService;

        public Tank getTank() {
            return tankFactory.getTank();
        }

        public BoxGoal getBoxGoal() {
            return goalsFactory.getBoxGoal();
        }

        public PathGoal getPathGoal() {
            return goalsFactory.getPathGoal();
        }

        public void AddMagickPortal(GameObject magickPortal) {
            magickPortalList.Add(magickPortal);
        }

        private void Awake() {
            tankFactory = new TankFactory();
            goalsFactory = new GoalsFactory();
            magickPortalList = new List<GameObject>();
            teleporTationService = new TeleportationService();

            getBoxGoal().onGoalAchieved += BoxesGoalAchieved;
            getPathGoal().onGoalAchieved += PathsGoalAchieved;

            timer = new Timer();
            timer.OnTimeChange += Timer_OnTimeChange;
            timer.OnTimeFinished += Timer_OnTimeFinished;

            Debug.Log("Contexto cargado");
        }

        private void Timer_OnTimeFinished(object source) {
            ITimer timer = (ITimer)source;
            timer.OnTimeFinished -= Timer_OnTimeFinished;
            timer.OnTimeChange -= Timer_OnTimeChange;
        }

        private void Timer_OnTimeChange(float millisecondsRemaining) {
            Debug.Log("xdxx");
            timerUI.RemainingTime = millisecondsRemaining;
        }

        private void BoxesGoalAchieved(BoxGoal sender) {
            sender.onGoalAchieved -= BoxesGoalAchieved;
            Debug.Log("Boxes broken! Goal achieved!");
        }

        private void PathsGoalAchieved(PathGoal sender) {
            sender.onGoalAchieved -= PathsGoalAchieved;
            Debug.Log("Path points reached! Goal achieved!");
        }

        public GameObject TankMagicPortalTeleportation(GameObject sourceMagickPortal) {
            int index = teleporTationService.randomPortalIndex(magickPortalList.Count, magickPortalList.IndexOf(sourceMagickPortal));
            return magickPortalList[index];
        }
    }
}

