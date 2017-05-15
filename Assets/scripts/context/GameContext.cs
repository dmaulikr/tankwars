using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using TankWars.Factory;
using TankWars.Model;
using TankWars.Service;
using TankWars.Controller.Timer;
using TankWars.Controller.Tank;

namespace TankWars.Context {
    public class GameContext : MonoBehaviour, ITankFactory, IGoalsFactory {

        private ITankFactory tankFactory;
        private IGoalsFactory goalsFactory;
        private ITimer timer;

        private const int DEFAULT_MISSION_TIME = 50 * 1000;

        [SerializeField]
        private TimerBehaviour timerUI;
        [SerializeField]
        private ScoreBehaviour scoreUI;
        [SerializeField]
        private TankBehaviour tankUI;

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

        public ITimer getTimer() {
            return timer;
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

            timer = new Timer(DEFAULT_MISSION_TIME);
            timer.OnTimeChange += Timer_OnTimeChange;
            timer.OnTimeFinished += Timer_OnTimeFinished;

        }

        private void Timer_OnTimeFinished(object source) {
            ITimer timer = (ITimer)source;
            timer.OnTimeFinished -= Timer_OnTimeFinished;
            timer.OnTimeChange -= Timer_OnTimeChange;
            tankUI.TriggerDestruction();
        }

        private void Timer_OnTimeChange(float millisecondsRemaining) {
            timerUI.RemainingTime = millisecondsRemaining;
        }

        private void BoxesGoalAchieved(BoxGoal sender) {
            sender.onGoalAchieved -= BoxesGoalAchieved;
            scoreUI.AddScore(300);
        }

        private void PathsGoalAchieved(PathGoal sender) {
            sender.onGoalAchieved -= PathsGoalAchieved;
            scoreUI.AddScore(100);
            timer.AddMilliseconds(60 * 1000);
        }

        public GameObject TankMagicPortalTeleportation(GameObject sourceMagickPortal) {
            int index = teleporTationService.randomPortalIndex(magickPortalList.Count, magickPortalList.IndexOf(sourceMagickPortal));
            return magickPortalList[index];
        }

        public void TriggerGameOver() {
            StartCoroutine(GameOver());
        }

        private IEnumerator GameOver() {
            yield return new WaitForSeconds(4f);
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
            yield return null;
        }


        private void Update() {
            if(Input.GetKeyDown(KeyCode.Keypad0)) {
                Debug.Log("Pantalla capturada");
                Application.CaptureScreenshot("Screenshot.png", 2);
            }
        }
    }
}

