namespace UnityFunctions.FSM.Step4.StudentOwnedState
{
    using UnityEngine;

    public class RestAndSleep : State<Student>
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

        public override bool OnMessage(Student entitys, Telegram telegram)
        {
            return false;
        }
    }
    public class StudyHard : State<Student>
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

        public override bool OnMessage(Student entitys, Telegram telegram)
        {
            return false;
        }
    }
    public class TakeAExam : State<Student>
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

        public override bool OnMessage(Student entitys, Telegram telegram)
        {
            return false;
        }
    }
    public class PlayAGame : State<Student>
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

        public override bool OnMessage(Student entitys, Telegram telegram)
        {
            return false;
        }
    }
    public class HitTheBottle : State<Student>
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

        public override bool OnMessage(Student entitys, Telegram telegram)
        {
            return false;
        }
    }
    public class GlobalMessageReceive : State<Student>
    {
        public override void Enter(Student entitys)
        {
        }

        public override void Execute(Student entitys)
        {
        }

        public override void Exit(Student entitys)
        {
        }

        public override bool OnMessage(Student entitys, Telegram telegram)
        {
            entitys.PrintText($"Receive Message : sender({telegram.sender}), receiver({telegram.receiver})");

            if (telegram.message.Equals("GO_PCROOM"))
            {
                if(entitys.CurrentState == StudentStates.PlayeAGame)
                {
                    entitys.PrintText($"Send Message {telegram.receiver}님이 {telegram.receiver}님에게 ALREDY_PCROOM 전송");
                    MessageDispatcher.Instance.DispatchMessage(0, telegram.receiver, telegram.sender, "ALREDY_PCROOM");
                }
                else
                {
                    int stateIndex = Random.Range(0, 2);
                    if(stateIndex == 0)
                    {
                        entitys.PrintText($"Send Message {telegram.receiver}님이 {telegram.sender}님에게 GO_PCROOM 전송");
                        MessageDispatcher.Instance.DispatchMessage(0, telegram.receiver, telegram.sender, "GO_PCROOM");

                        entitys.ChangeState(StudentStates.PlayeAGame);
                    }
                    else
                    {

                        entitys.PrintText($"Send Message {telegram.receiver}님이 {telegram.sender}님에게 SORRY 전송");
                        MessageDispatcher.Instance.DispatchMessage(0, telegram.receiver, telegram.sender, "SORRY");
                    }
                }

                return true;
            }

            return false;
        }
    }
}

