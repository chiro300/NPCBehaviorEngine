using UnityEngine;

namespace Assets.Scripts.NPCBehaviorEngine
{
    public enum UpdateTypes
    {
        Update,
        FixedUpdate,
    }

    public abstract class NPCAction : MonoBehaviour, INPCBase
    {
        public string label = "NPC Action";
        public UpdateTypes updateType;

        public NPCBrain Brain { get; set; }

        public abstract void Initialize();

        public abstract void ExecuteAction();

        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }
    }
}
