using UnityEngine;

namespace ShootEmUp
{
    public class EnemyDestinationReachedObserver : MonoBehaviour
    {
        [SerializeField]
        private EnemyMoveAgent moveAgent;

        [SerializeField]
        private EnemyAttackAgent attackAgent;

        public void Activate()
        {
            moveAgent.OnDestinationReached += HandleDestinationReached;
        }

        public void Deactivate()
        {
            attackAgent.SetReadyForAttack(false);
            moveAgent.OnDestinationReached -= HandleDestinationReached;
        }

        private void HandleDestinationReached()
        {
            attackAgent.SetReadyForAttack(true);
        }
    }
}