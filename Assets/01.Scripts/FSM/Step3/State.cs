namespace UnityFunctions.FSM.Step3
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class State<T> where T : class
    {
        public abstract void Enter(T entitys);
        public abstract void Execute(T entitys);
        public abstract void Exit(T entitys);
    }
}

