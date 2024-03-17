using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public event Action OnDestinationReached;

        [SerializeField] 
        private MoveComponent moveComponent;

        [SerializeField]
        private float moveThreshold = 0.25f;

        private Vector2 destination;
        private bool isReached;

        public void SetDestination(Vector2 endPoint)
        {
            destination = endPoint;
            isReached = false;
        }

        private void FixedUpdate()
        {
            if (isReached)
            {
                return;
            }
            
            var vector = destination - (Vector2) transform.position;
            if (vector.sqrMagnitude <= moveThreshold * moveThreshold)
            {
                isReached = true;
                OnDestinationReached?.Invoke();
                return;
            }

            var direction = vector.normalized * Time.fixedDeltaTime;
            moveComponent.MoveByRigidbodyVelocity(direction);
        }
    }
}