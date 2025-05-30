namespace DesignPetton.Observer
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class HUDController : Observer
    {
        private bool _isTurboOn;
        private float _currentHeath;
        private BikeController _bikeController;

        private void OnGUI()
        {
            GUILayout.BeginArea(new Rect(50, 50, 100, 200));
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Health: " + _currentHeath);
            GUILayout.EndHorizontal();

            if(_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated");
                GUILayout.EndHorizontal();
            }

            if(_currentHeath <= 50.0f)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("WARNING: Low Health");
                GUILayout.EndHorizontal();
            }

            GUILayout.EndArea();
        }

        public override void Notify(Subject subject)
        {
            if (!_bikeController)
                _bikeController = subject.GetComponent<BikeController>();
            
            if(_bikeController)
            {
                _isTurboOn = _bikeController.IsTurboOn;
                _currentHeath = _bikeController.CurrentHeath;
            }
        }
    }
}


