using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public enum WalkingStatus { Walk, Stop }

    public class Walk : MonoBehaviour
    {
        [Header("Speed")]
        public float WalkSpeed = 6f;

        public float MovementSpeedMultiplier = 1f;
        public LayerMask collisionLayers;

        public float horizontalMovement;
        public bool walking = true;

        private void Awake()
        {
            Debug.Log(transform.forward);
        }

        private void FixedUpdate()
        {
            Walking();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //if (LayerHelper.LayerInLayerMask(collision.gameObject.layer, collisionLayers))
            //{
            //    SetHorizontalMove(Random.Range(-1f, 1f));
            //    SetVerticalMove(Random.Range(-1f, 1f));
            //}
        }

        protected void Walking()
        {
            if (walking)
            {
                float horizontalMovementSpeed = horizontalMovement * WalkSpeed * MovementSpeedMultiplier * Time.deltaTime;
                
                gameObject.transform.position += new Vector3(horizontalMovementSpeed, 0, 0);
            }
        }

        public virtual void SetHorizontalMove(float value)
        {
            horizontalMovement = value;
        }

        public void StopWalking()
        {
            walking = false;
        }

        public void StartWalking()
        {
            walking = true;
        }
    }
}
