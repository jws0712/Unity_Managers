namespace UnityFunctions.FSM.Step4
{
    using System.Collections.Generic;

    public class EntityDataBase
    {
        private static readonly EntityDataBase instance = new EntityDataBase();
        public static EntityDataBase Instance => instance;

        private Dictionary<string, BaseGameEntity> entityDictionary;

        public void Setup()
        {
            entityDictionary = new Dictionary<string, BaseGameEntity>();
        }

        public void RegisterEntity(BaseGameEntity newEntity)
        {
            entityDictionary.Add(newEntity.EntityName, newEntity);
        }

        public BaseGameEntity GetEntityFromID(string entityName)
        {
            foreach(KeyValuePair<string, BaseGameEntity> entity in entityDictionary)
            {
                if(entity.Key == entityName)
                {
                    return entity.Value;
                }
            }

            return null;
        }

        public void RemoveEntity(BaseGameEntity removeEntity)
        {
            entityDictionary.Remove(removeEntity.EntityName);
        }
    }
}

