namespace UnityFunctions.FSM.Step4
{
    using System.Collections.Generic;
    using UnityEngine;

    public enum Locations { SweetHome = 0, Library, LectureRoom, PCRoom, Pub }

    public class GameController : MonoBehaviour
    {
        [SerializeField] private string[] arrayStudents;
        [SerializeField] private GameObject studentPrefab;

        [SerializeField] private string[] arrayUnemployeds;
        [SerializeField] private GameObject unemployedPrefab;

        private List<BaseGameEntity> entitys;

        public static bool IsGameStop { set; get; } = false;

        private void Awake()
        {
            entitys = new List<BaseGameEntity>();

            for (int i = 0; i < arrayStudents.Length; ++ i)
            {
                GameObject clone = Instantiate(studentPrefab);
                Student entity = clone.GetComponent<Student>();
                entity.Setup(arrayStudents[i]);

                entitys.Add(entity);
            }

            for (int i = 0; i < arrayUnemployeds.Length; ++i)
            {
                GameObject clone = Instantiate(unemployedPrefab);
                Unemployed entity = clone.GetComponent<Unemployed>();
                entity.Setup(arrayUnemployeds[i]);

                entitys.Add(entity);
            }

            EntityDataBase.Instance.Setup();
            for(int i = 0;i < arrayStudents.Length; ++i)
            {
                EntityDataBase.Instance.RegisterEntity(entitys[i]);
            }

            MessageDispatcher.Instance.Setup();
        }

        private void Update()
        {
            if (IsGameStop == true) return;

            MessageDispatcher.Instance.DispatchDelayedMessage();

            for (int i = 0;i < entitys.Count; ++i)
            {
                entitys[i].Updated();
            }
        }

        public static void Stop(BaseGameEntity entity)
        {
            IsGameStop = true;

            entity.PrintText("프로그램 종료");
        }
    }
}


