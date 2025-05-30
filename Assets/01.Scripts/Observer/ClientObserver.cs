namespace DesignPetton.Observer
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ClientObserver : MonoBehaviour
    {
        private BikeController _bikeController;

        private void Start()
        {
            _bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Damage Bike"))
            {
                if (_bikeController)
                    _bikeController.TakeDamage(15.0f);
            }
            if (GUILayout.Button("Toggle Turbo"))
                if (_bikeController)
                    _bikeController.ToggleTurbo();
        }
    }
}


