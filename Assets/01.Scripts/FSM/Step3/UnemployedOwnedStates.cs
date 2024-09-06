namespace UnityFunctions.FSM.Step3.UnemployedOwnedStates
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RestAndSleep : State<Unemployed>
    {
        public override void Enter(Unemployed entitys)
        {
            entitys.CurrentLocation = Locations.SweetHome;
            entitys.Stress = 0;
            entitys.Fatigue = 0;

            entitys.PrintText("�� ����");
        }

        public override void Execute(Unemployed entitys)
        {
            string state = Random.Range(0, 2) == 0 ? "ZZZZZ" : "TV����";
            entitys.PrintText(state);

            entitys.Bored += Random.Range(0, 100) < 70 ? 1 : -1;

            if (entitys.Bored >= 4)
            {
                entitys.ChangeState(UnemployedStates.PlayAGame);
            }
        }

        public override void Exit(Unemployed entitys)
        {
            entitys.PrintText("������");
        }
    }
    public class PlayAGame : State<Unemployed>
    {
        public override void Enter(Unemployed entitys)
        {
            entitys.CurrentLocation = Locations.PCRoom;

            entitys.PrintText("PC�� ��");
        }

        public override void Execute(Unemployed entitys)
        {
            entitys.PrintText("������");

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
            entitys.PrintText("������");
        }
    }
    public class HitTheBottle : State<Unemployed>
    {
        public override void Enter(Unemployed entitys)
        {
            entitys.CurrentLocation = Locations.Pub;

            entitys.PrintText("���� ��");
        }

        public override void Execute(Unemployed entitys)
        {
            entitys.PrintText("�ξ�� ���Ŷ�");

            entitys.Stress -= 4;
            entitys.Fatigue += 4;

            if (entitys.Stress <= 0 || entitys.Fatigue >= 50)
            {
                entitys.ChangeState(UnemployedStates.RestAndSleep);
            }
        }

        public override void Exit(Unemployed entitys)
        {
            entitys.PrintText("���� ����");
        }
    }
    public class VisitBathroom : State<Unemployed>
    {
        public override void Enter(Unemployed entitys)
        {
            entitys.PrintText("ȭ��� ��");
        }

        public override void Execute(Unemployed entitys)
        {
            entitys.PrintText("ȭ��� ���");

            entitys.RevertToPreviousState();
        }

        public override void Exit(Unemployed entitys)
        {
            entitys.PrintText("ȭ��� ");
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
    }
}
