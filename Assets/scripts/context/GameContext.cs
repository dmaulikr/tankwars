using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using TankWars.Factory;
using TankWars.Model;

namespace TankWars.Context {
    public class GameContext : MonoBehaviour, ITankFactory, IGoalsFactory {

        private ITankFactory tankFactory;
        private IGoalsFactory goalsFactory;

        public Tank getTank() {
            return tankFactory.getTank();
        }

        public BoxGoal getBoxGoal() {
            return goalsFactory.getBoxGoal();
        }

        public PathGoal getPathGoal() {
            return goalsFactory.getPathGoal();
        }

        private void Awake() {
            tankFactory = new TankFactory();
            goalsFactory = new GoalsFactory();

            getBoxGoal().onGoalAchieved += BoxesGoalAchieved;
            getPathGoal().onGoalAchieved += PathsGoalAchieved;

            Debug.Log("Contexto cargado");
        }

        private void BoxesGoalAchieved(BoxGoal sender) {
            sender.onGoalAchieved -= BoxesGoalAchieved;
            Debug.Log("Boxes broken! Goal achieved!");
        }

        private void PathsGoalAchieved(PathGoal sender) {
            sender.onGoalAchieved -= PathsGoalAchieved;
            Debug.Log("Path points reached! Goal achieved!");
        }

    }
}

