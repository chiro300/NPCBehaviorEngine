using UnityEngine;

namespace Assets.Scripts.NPCBehaviorEngine
{
    public abstract class NPCDecision : MonoBehaviour, INPCBase
    {
        public string label = "NPC Decision";

        protected NPCBrain _brain;

        public virtual void Initialize()
        {

        }

        public abstract bool ExecuteDecide();

        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }
    }
}
