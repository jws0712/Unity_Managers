namespace UnityFunctions.FSM.Step3
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class StateMechine<T> where T : class
    {
        private T ownerEntity;
        private State<T> currentState;

        public void Setup(T owner, State<T> entryState)
        {
            ownerEntity = owner;
            currentState = null;

            ChangeState(entryState);
        }

        public void Eexcute()
        {
            if(currentState != null)
            {
                currentState.Execute(ownerEntity);
            }
        }

        public void ChangeState(State<T> newState)
        {
            if (newState == null) return;

            if(currentState != null)
            {
                currentState.Exit(ownerEntity);
            }

            currentState = newState;
            currentState.Enter(ownerEntity);
        }
    }
}
