namespace UnityFunctions.FSM.Step4
{
    using UnityEngine;

    public abstract class BaseGameEntity : MonoBehaviour
    {
        private static int m_iNextVauildID = 0;

        private int id;
        public int ID
        {
            set
            {
                id = value;
                m_iNextVauildID++;
            }
            get => id;
        }

        private string entityName;
        private string personalColor;

        public string EntityName => entityName;

        public virtual void Setup(string name)
        {
            ID = m_iNextVauildID;

            entityName = name;

            int color = Random.Range(0, 1000000);
            personalColor = $"#{color.ToString("x6")}";
        }

        public abstract void Updated();

        public abstract bool HandleMessage(Telegram telegram);

        public void PrintText(string text)
        {
            Debug.Log($"<color={personalColor}><b>{entityName}</b></color> : {text}");
        }
    }
}

