namespace DesignPetton.Observer
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Subject : MonoBehaviour
    {
        private readonly ArrayList _observer = new ArrayList();

        public void Attach(Observer observer)
        {
            _observer.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observer.Remove(observer);
        }

        public void NotifyObsevers()
        {
            foreach(Observer observer in _observer)
            {
                observer.Notify(this);
            }
        }
    }
}



