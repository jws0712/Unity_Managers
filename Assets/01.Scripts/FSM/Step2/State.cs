namespace UnityFunctions.FSM.Step2
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class State
    {
        public abstract void Enter(Student entitys);
        public abstract void Execute(Student entitys);
        public abstract void Exit(Student entitys);
    }
}

