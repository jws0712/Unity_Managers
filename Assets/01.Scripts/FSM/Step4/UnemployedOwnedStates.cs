namespace UnityFunctions.FSM.Step4.UnemployedOwnedStates
{
    using UnityEngine;

    public class RestAndSleep : State<Unemployed>
    {
        public override void Enter(Unemployed entitys)
        {
            entitys.CurrentLocation = Locations.SweetHome;
            entitys.Stress = 0;
            entitys.Fatigue = 0;

            entitys.PrintText("집 들어옴");
        }

        public override void Execute(Unemployed entitys)
        {
            string state = Random.Range(0, 2) == 0 ? "ZZZZZ" : "TV본다";
            entitys.PrintText(state);

            entitys.Bored += Random.Range(0, 100) < 70 ? 1 : -1;

            if (entitys.Bored >= 4)
            {
                string receiver = "고박사";
                entitys.PrintText($"Send Message {entitys.EntityName}님이 {receiver}님에게 GO_PCROOM 전송");
                MessageDispatcher.Instance.DispatchMessage(0, entitys.EntityName, receiver, "GO_PCROOM");

                entitys.ChangeState(UnemployedStates.PlayAGame);
            }
        }

        public override void Exit(Unemployed entitys)
        {
            entitys.PrintText("나간다");
        }

        public override bool OnMessage(Unemployed entitys, Telegram telegram)
        {
            return false;
        }
    }
    public class PlayAGame : State<Unemployed>
    {
        public override void Enter(Unemployed entitys)
        {
            entitys.CurrentLocation = Locations.PCRoom;

            entitys.PrintText("PC방 감");
        }

        public override void Execute(Unemployed entitys)
        {
            entitys.PrintText("게임중");

            int randState = Random.Range(0, 10);
            if(randState == 0 || randState == 9)
            {
                entitys.Stress += 20;

                entitys.ChangeState(UnemployedStates.HitTHeBottle);
            }
            else
            {
                entitys.Bored--;
                entitys.Fatigue += 2;

                if(entitys.Bored <= 0 || entitys.Fatigue >= 50)
                {
                    entitys.ChangeState(UnemployedStates.RestAndSleep);
                }
            }
        }

        public override void Exit(Unemployed entitys)
        {
            entitys.PrintText("잘즐겼다");
        }

        public override bool OnMessage(Unemployed entitys, Telegram telegram)
        {
            return false;
        }
    }
    public class HitTheBottle : State<Unemployed>
    {
        public override void Enter(Unemployed entitys)
        {
            entitys.CurrentLocation = Locations.Pub;

            entitys.PrintText("술집 감");
        }

        public override void Execute(Unemployed entitys)
        {
            entitys.PrintText("부어라 마셔라");

            entitys.Stress -= 4;
            entitys.Fatigue += 4;

            if (entitys.Stress <= 0 || entitys.Fatigue >= 50)
            {
                entitys.ChangeState(UnemployedStates.RestAndSleep);
            }
        }

        public override void Exit(Unemployed entitys)
        {
            entitys.PrintText("술집 나감");
        }

        public override bool OnMessage(Unemployed entitys, Telegram telegram)
        {
            return false;
        }
    }
    public class VisitBathroom : State<Unemployed>
    {
        public override void Enter(Unemployed entitys)
        {
            entitys.PrintText("화장실 감");
        }

        public override void Execute(Unemployed entitys)
        {
            entitys.PrintText("화장실 사용");

            entitys.RevertToPreviousState();
        }

        public override void Exit(Unemployed entitys)
        {
            entitys.PrintText("화장실 ");
        }

        public override bool OnMessage(Unemployed entitys, Telegram telegram)
        {
            return false;
        }
    }
    public class StateGlobal : State<Unemployed>
    {
        public override void Enter(Unemployed entitys)
        {

        }

        public override void Execute(Unemployed entitys)
        {
            if(entitys.CurrentState == UnemployedStates.VisitBathroom)
            {
                return;
            }

            int bathroomState = Random.Range(0, 100);
            if(bathroomState < 10)
            {
                entitys.ChangeState(UnemployedStates.VisitBathroom);
            }
        }

        public override void Exit(Unemployed entitys)
        {

        }

        public override bool OnMessage(Unemployed entitys, Telegram telegram)
        {
            return false;
        }
    }
}
