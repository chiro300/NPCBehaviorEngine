using Assets.Scripts.Actions;
using UnityEngine;

namespace Assets.Scripts.NPCBehaviorEngine.NPCActions
{
    public class WalkingPatrolAction : NPCAction
    {
        public float leftBound = 5;
        public float rightBound = 5;

        protected Vector2 _boundsLeft;
        protected Vector2 _boundsRight;

        protected Walk walk;

        protected bool inOutLimits = false;

        public override void ExecuteAction()
        {
            if (this.transform.position.x < _boundsLeft.x)
            {
                ChangeDirection(Vector2.right);
                inOutLimits = true;
                return;
            }
            if (this.transform.position.x > _boundsRight.x)
            {
                ChangeDirection(Vector2.left);
                inOutLimits = true;
                return;
            }

            inOutLimits = false;
        }

        public override void Initialize()
        {
            walk = gameObject.GetComponent<Walk>();
            SetBounds();
        }

        protected virtual void ChangeDirection(Vector2 vector)
        {
            ChangeDirection(vector.x);
        }

        protected virtual void ChangeDirection(float x)
        {
            if (!inOutLimits)
            {
                walk.SetHorizontalMove(x);
            }
        }

        protected virtual void SetBounds()
        {
            _boundsLeft = this.transform.position + Vector3.left * leftBound;
            _boundsRight = this.transform.position + Vector3.right * rightBound;            
        }

        protected virtual void OnDrawGizmosSelected()
        {
            SetBounds();

            Gizmos.color = Color.red;
            Gizmos.DrawLine(_boundsLeft + Vector2.up , _boundsLeft + Vector2.down);
            Gizmos.DrawLine(_boundsRight + Vector2.up, _boundsRight + Vector2.down);
        }
    }
}
