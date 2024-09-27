namespace UnityFunctions.FSM.Step4
{
    public abstract class State<T> where T : BaseGameEntity
    {
        public abstract void Enter(T entitys);
        public abstract void Execute(T entitys);
        public abstract void Exit(T entitys);
        public abstract bool OnMessage(T entitys, Telegram telegram);
    }
}

