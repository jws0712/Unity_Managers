namespace UnityFunctions.FSM.Step3
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public enum StudentStates { RestAndSleep = 0, StudyHard, TakeAExam, PlayeAGame, HitTheBottle }

    public class Student : BaseGameEntity
    {
        private int knowledge;
        private int stress;
        private int fatigue;
        private int totalScore;
        private Locations currentLocation;

        private State<Student>[] states;
        private State<Student> currentState;

        public int Knowledge
        {
            set => knowledge = Mathf.Max(0, value);
            get => knowledge;
        }
        public int Stress
        {
            set => stress = Mathf.Max(0, value);
            get => stress;
        }
        public int Fatigue
        {
            set => fatigue = Mathf.Max(0, value);
            get => fatigue;
        }
        public int TotalScore
        {
            set => totalScore = Mathf.Clamp(0, value, 100);
            get => totalScore;
        }
        public Locations CurrentLocation
        {
            set => currentLocation = value;
            get => currentLocation;
        }

        public override void Setup(string name)
        {
            base.Setup(name);

            gameObject.name = $"{ID:D2}_Student_{name}";

            states = new State<Student>[5];
            states[(int)StudentStates.RestAndSleep] = new StudentOwnedState.RestAndSleep();
            states[(int)StudentStates.StudyHard] = new StudentOwnedState.StudyHard();
            states[(int)StudentStates.TakeAExam] = new StudentOwnedState.TakeAExam();
            states[(int)StudentStates.PlayeAGame] = new StudentOwnedState.PlayAGame();
            states[(int)StudentStates.HitTheBottle] = new StudentOwnedState.HitTheBottle();

            ChangeState(StudentStates.RestAndSleep);

            knowledge = 0;
            stress = 0;
            fatigue = 0;
            totalScore = 0;
            currentLocation = Locations.SweetHome;
            
        }

        public override void Updated()
        {
            if(currentState != null)
            {
                currentState.Execute(this);
            }
        }

        public void ChangeState(StudentStates newState)
        {
            if (states[(int)newState] == null) return;

            if(currentState != null)
            {
                currentState.Exit(this);
            }

            currentState = states[(int)newState];
            currentState.Enter(this);
        }
    }
}



