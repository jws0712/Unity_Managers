namespace DesignPetton.Observer
{
    using System.Collections;
    using System.Collections.Generic;
    using TMPro.EditorUtilities;
    using UnityEngine;

    public class BikeController : Subject
    {
        public bool IsTurboOn
        {
            get; private set;
        }

        public float CurrentHeath
        {
            get { return health; }
        }

        private bool _isEngineOn;
        private HUDController _hudController;
        private CameraController _cameraController;

        [SerializeField]
        private float health = 100.0f;

        private void Awake()
        {
            _hudController = gameObject.AddComponent<HUDController>();
            _cameraController = (CameraController)FindObjectOfType(typeof(CameraController));
        }

        private void Start()
        {
            Debug.Log("스타트");
            StartEngine();
        }

        private void OnEnable()
        {
            if (_hudController)
                Attach(_cameraController);

            if (_cameraController)
                Attach(_cameraController);
        }

        private void OnDisable()
        {
            if (_hudController)
                Detach(_hudController);

            if (_cameraController)
                Detach(_cameraController);
        }

        private void StartEngine()
        {
            Debug.Log("엔진 시동");
            _isEngineOn = true;
            NotifyObsevers();
        }

        public void ToggleTurbo()
        {
            Debug.Log("터보 실행");
            if (_isEngineOn)
                IsTurboOn = !IsTurboOn;

            NotifyObsevers();
        }

        public void TakeDamage(float amount)
        {
            Debug.Log("데미지 받음");
            health -= amount;
            IsTurboOn = false;

            NotifyObsevers();

            if(health < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}


