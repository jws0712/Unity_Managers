namespace UnityFunctions.FSM.Step4
{
    using UnityEngine;
    using StudentOwnedState;

    public enum StudentStates { RestAndSleep = 0, StudyHard, TakeAExam, PlayeAGame, HitTheBottle, GMessageRecevie }

    public class Student : BaseGameEntity
    {
        private int knowledge;
        private int stress;
        private int fatigue;
        private int totalScore;
        private Locations currentLocation;
        private StudentStates currentState;

        private State<Student>[] states;
        private StateMechine<Student> stateMachine;

        public StudentStates CurrentState => currentState;

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

            states = new State<Student>[6];
            states[(int)StudentStates.RestAndSleep]     = new RestAndSleep();           //0
            states[(int)StudentStates.StudyHard]        = new StudyHard();              //1
            states[(int)StudentStates.TakeAExam]        = new TakeAExam();              //2
            states[(int)StudentStates.PlayeAGame]       = new PlayAGame();              //3
            states[(int)StudentStates.HitTheBottle]     = new HitTheBottle();           //4
            states[(int)StudentStates.GMessageRecevie]  = new GlobalMessageReceive();   //5

            stateMachine = new StateMechine<Student>();
            stateMachine.Setup(this, states[(int)StudentStates.RestAndSleep]);

            stateMachine.SetGlobalState(states[(int)StudentStates.GMessageRecevie]);

            knowledge = 0;
            stress = 0;
            fatigue = 0;
            totalScore = 0;
            currentLocation = Locations.SweetHome;
            
        }

        public override void Updated()
        {
            stateMachine.Eexcute();
        }

        public void ChangeState(StudentStates newState)
        {
            currentState = newState;

            stateMachine.ChangeState(states[(int)newState]);
        }

        public override bool HandleMessage(Telegram telegram)
        {
            return stateMachine.HandleMessage(telegram);
        }
    }
}



