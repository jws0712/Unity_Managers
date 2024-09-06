namespace UnityFunctions.FSM.Step2.StudentOwnedState
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RestAndSleep : State
    {
        public override void Enter(Student entitys)
        {
            entitys.CurrentLocation = Locations.SweetHome;
            entitys.Stress = 0;

            entitys.PrintText("집 들어옴");
        }

        public override void Execute(Student entitys)
        {
            entitys.PrintText("ZZZ");

            if(entitys.Fatigue > 0)
            {
                entitys.Fatigue -= 10;
            }
            else
            {
                entitys.ChangeState(StudentStates.StudyHard);
            }
        }

        public override void Exit(Student entitys)
        {
            entitys.PrintText("집 나감");
        }
    }
    public class StudyHard : State
    {
        public override void Enter(Student entitys)
        {
            entitys.CurrentLocation = Locations.Library;

            entitys.PrintText("공부시작");
        }

        public override void Execute(Student entitys)
        {
            entitys.PrintText("공부중");

            entitys.Knowledge++;
            entitys.Stress++;
            entitys.Fatigue++;

            if(entitys.Knowledge >= 3 &&  entitys.Knowledge <= 10)
            {
                
                int isExit = Random.Range(0, 2);

                Debug.Log(isExit);

                if(isExit == 1 || entitys.Knowledge == 10)
                {
                    entitys.ChangeState(StudentStates.TakeAExam);

                }
            }
            if (entitys.Stress >= 20)
            {
                entitys.ChangeState(StudentStates.PlayeAGame);
            }

            if (entitys.Fatigue >= 50)
            {
                entitys.ChangeState(StudentStates.RestAndSleep);
            }

        }

        public override void Exit(Student entitys)
        {
            entitys.PrintText("공부끝");
        }
    }
    public class TakeAExam : State
    {
        public override void Enter(Student entitys)
        {
            entitys.CurrentLocation = Locations.LectureRoom;

            entitys.PrintText("시험시작");
        }

        public override void Execute(Student entitys)
        {
            int examScore = 0;

            if(entitys.Knowledge == 10)
            {
                examScore = 10;
            }
            else
            {
                int randIndex = Random.Range(0,10);
                examScore = randIndex < entitys.Knowledge ? Random.Range(6, 11) : Random.Range(1, 6);
            }

            entitys.Knowledge = 0;
            entitys.Fatigue += Random.Range(5, 11);

            entitys.TotalScore += examScore;
            entitys.PrintText($"시험 성적({examScore}), 총점({entitys.TotalScore})");

            if(entitys.TotalScore >= 100)
            {
                GameController.Stop(entitys);
                return;
            }

            if(examScore <= 3)
            {
                entitys.ChangeState(StudentStates.HitTheBottle);
            }
            else if(examScore <= 7)
            {
                entitys.ChangeState(StudentStates.StudyHard);
            }
            else
            {
                entitys.ChangeState(StudentStates.PlayeAGame);
            }
        }

        public override void Exit(Student entitys)
        {
            entitys.PrintText("시험 끝");
        }
    }
    public class PlayAGame : State
    {
        public override void Enter(Student entitys)
        {
            entitys.CurrentLocation = Locations.PCRoom;

            entitys.PrintText("PC방 입장");
        }

        public override void Execute(Student entitys)
        {
            entitys.PrintText("게임중");

            int randState = Random.Range(0, 10);
            if(randState == 0 || randState == 9)
            {
                entitys.Stress += 20;

                entitys.ChangeState(StudentStates.HitTheBottle);
            }
            else
            {
                entitys.Stress--;
                entitys.Fatigue += 2;

                if(entitys.Stress <= 0)
                {
                    entitys.ChangeState(StudentStates.StudyHard);
                }
            }
        }

        public override void Exit(Student entitys)
        {
            entitys.PrintText("PC방 나옴");
        }
    }
    public class HitTheBottle : State
    {
        public override void Enter(Student entitys)
        {
            entitys.CurrentLocation = Locations.Pub;

            entitys.PrintText("술집 감");
        }

        public override void Execute(Student entitys)
        {
            entitys.PrintText("술은 마신다");

            entitys.Stress -= 5;
            entitys.Fatigue += 5;

            if (entitys.Stress <= 0 || entitys.Fatigue >= 50)
            {
                entitys.ChangeState(StudentStates.RestAndSleep);
            }
        }

        public override void Exit(Student entitys)
        {
            entitys.PrintText("술집 나감");
        }
    }

}

