using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NPCBehaviorEngine
{
    [Serializable]
    public class NPCState : INPCBase
    {
        public string label = "NPCState";

        public List<NPCTransition> transitions;

        public List<NPCAction> actions;

        public NPCBrain Brain { get; set; }

        protected List<NPCAction> updateActions;

        protected List<NPCAction> fixedUpdateActions;

        public virtual void Initialize()
        {
            if (actions == null)
                return;

            updateActions = new List<NPCAction>();
            fixedUpdateActions = new List<NPCAction>();

            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].Initialize();
                actions[i].Brain = Brain;

                if (actions[i].updateType == UpdateTypes.Update)
                {
                    updateActions.Add(actions[i]);
                }
                else
                {
                    fixedUpdateActions.Add(actions[i]);
                }
            }
        }

        public virtual void OnEnter()
        {
            foreach (var current in actions)
            {
                current.OnEnter();
            }

            foreach (var current in transitions)
            {
                if (current.decision != null)
                    current.decision.OnEnter();
            }
        }

        public virtual void OnExit()
        {
            foreach (var current in actions)
            {
                current.OnExit();
            }

            foreach (var current in transitions)
            {
                if (current.decision != null)
                    current.decision.OnExit();
            }
        }

        public virtual void ProccessActionsInUpdate()
        {
            ProccessActions(updateActions);
        }

        public virtual void ProccessActionsInFixedUpdate()
        {
            ProccessActions(fixedUpdateActions);
        }

        protected virtual void ProccessActions(List<NPCAction> actions)
        {
            if (actions == null)
                return;

            foreach (var currentAction in actions)
            {
                currentAction.ExecuteAction();
            }
        }

        public virtual void ProcessDecisions()
        {
            foreach (var current in transitions)
            {
                if (current.decision != null)
                    if (current.decision.ExecuteDecide() && !string.IsNullOrEmpty(current.toTrue))
                        Brain.TransitionToState(current.toTrue);
                    else if (!string.IsNullOrEmpty(current.toFalse))
                        Brain.TransitionToState(current.toFalse);
            }
        }
    }
}
