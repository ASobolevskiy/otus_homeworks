using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour,
        Listeners.IFixedUpdateListener
    {
        public event Action OnDestinationReached;
        
        [SerializeField] 
        private MoveComponentBase moveComponent;

        [SerializeField]
        private float moveThreshold = 0.25f;

        private Vector2 destination;
        private bool isReached;

        public void SetDestination(Vector2 endPoint)
        {
            destination = endPoint;
            isReached = false;
        }
        
        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (isReached)
            {
                return;
            }
            
            var vector = destination - (Vector2) transform.position;
            if (vector.sqrMagnitude <= moveThreshold * moveThreshold)
            {
                isReached = true;
                moveComponent.SetDirection(Vector2.zero);
                OnDestinationReached?.Invoke();
                return;
            }

            var direction = vector.normalized;
            moveComponent.SetDirection(direction);
        }
    }
}