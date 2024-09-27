namespace UnityFunctions.FSM.Step4
{
    using System.Collections.Generic;
    using UnityEngine;

    public class MessageDispatcher
    {
        static readonly MessageDispatcher instance = new MessageDispatcher();
        public static MessageDispatcher Instance => instance;

        private SortedDictionary<float, Telegram> prioritySD;

        public void Setup()
        {
            prioritySD = new SortedDictionary<float, Telegram>();
        }

        public void DispatchMessage(float delayTime, string senderName, string receiverName, string message)
        {
            BaseGameEntity receiver = EntityDataBase.Instance.GetEntityFromID(receiverName);
            if (receiver == null)
            {
                Debug.Log($"<color=red>Warning! No Receiver with ID of <b><i>{receiverName}</i></b> found</color>");
                return;
            }

            Telegram telegram = new Telegram();
            telegram.SetTelegram(0, senderName, receiverName, message);

            if(delayTime <= 0)
            {
                Discharge(receiver, telegram);
            }
            else
            {
                telegram.dispatchTime = Time.time + delayTime;
                prioritySD.Add(telegram.dispatchTime, telegram);
            }
        }

        private void Discharge(BaseGameEntity receiver, Telegram telegram)
        {
            receiver.HandleMessage(telegram);
        }

        public void DispatchDelayedMessage()
        {
            foreach(KeyValuePair<float, Telegram> entity in prioritySD)
            {
                if(entity.Key <= Time.time)
                {
                    BaseGameEntity receiver = EntityDataBase.Instance.GetEntityFromID(entity.Value.receiver);

                    Discharge(receiver, entity.Value);
                    prioritySD.Remove(entity.Key);

                    return;
                }
            }
        }
    }
}



