using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.NPCBehaviorEngine
{
    public class NPCBrain : MonoBehaviour
    {
        
        public List<NPCState> states;

        public float frequencyActions;

        public float frequencyDecision;

        protected float _lastActionTime = 0f;

        protected float _lastDecisionTime = 0f;
        
        public string currentState;

        public NPCState CurrentState { get; protected set; }

        public Transform CurrentTarget { get; protected set; }

        public List<Transform> Targets { get; protected set; }

        public delegate void Reset();
        public event Reset OnResetBrain;

        public bool active = true;

        protected virtual void Awake()
        {
            if (states != null && states.Count > 0)
            {
                for (int i = 0; i < states.Count; i++)
                {
                    states[i].Initialize();
                    states[i].Brain = this;
                }

                CurrentState = states.FirstOrDefault();
                currentState = CurrentState.label;
            }
        }

        protected virtual void Update()
        {
            Processing(UpdateTypes.Update);
        }

        protected virtual void FixedUpdate()
        {
            Processing(UpdateTypes.FixedUpdate);
        }

        protected virtual void Processing(UpdateTypes updateType)
        {
            if (!active || CurrentState == null)
                return;

            if(Time.time - _lastActionTime > frequencyActions)
            {
                if (updateType == UpdateTypes.Update)
                    CurrentState.ProccessActionsInUpdate();
                else
                    CurrentState.ProccessActionsInFixedUpdate();

                _lastActionTime = Time.time;
            }

            if (Time.time - _lastDecisionTime > frequencyDecision)
            {
                CurrentState.ProcessDecisions();

                _lastDecisionTime = Time.time;
            }
        }

        public virtual void TransitionToState(string state)
        {
            if (CurrentState.label != state)
            {
                CurrentState.OnExit();

                var nextState = states.Where(x => x.label == state).FirstOrDefault();

                if (nextState != null)
                {
                    CurrentState = nextState;
                    currentState = CurrentState.label;
                }

            }
        }

        #region Targets Handler

        /// <summary>
        /// Add a new target and focus on him.
        /// </summary>
        /// <param name="target"></param>
        public void AddTargetAndFocus(Transform target)
        {
            AddTarget(target);

            CurrentTarget = target;
        }

        public void AddTarget(Transform target)
        {
            AddTargets(new List<Transform>() { target });
        }

        public void AddTargets(List<Transform> targets)
        {
            if (Targets == null)
                Targets = new List<Transform>();

            for (int i = 0; i < targets.Count; i++)
            {
                if (!Targets.Find(x => x == targets[i])) //TODO: Ver si funciona
                {
                    Targets.Add(targets[i]);
                }
            }
        }

        public void RemoveCurrentTarget()
        {
            RemoveTarget(CurrentTarget);
        }

        public void RemoveTarget(Transform target)
        {
            if (Targets == null)
                return;

            Targets.Remove(target);
        }

        public void RemoveAllTargets()
        {
            if (Targets == null)
                return;

            Targets.Clear();
        }

        #endregion

        public virtual void OnReset()
        {
            OnResetBrain.Invoke();
        }
    }
}
