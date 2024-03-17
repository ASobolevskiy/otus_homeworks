using UnityEngine;

namespace ShootEmUp
{
    public class EnemyDestinationReachedObserver : MonoBehaviour
    {
        [SerializeField]
        private EnemyMoveAgent moveAgent;

        [SerializeField]
        private EnemyAttackAgent attackAgent;

        private void Awake()
        {
            moveAgent.OnDestinationReached += HandleDestinationReached;
        }

        private void OnDestroy()
        {
            moveAgent.OnDestinationReached -= HandleDestinationReached;
        }

        private void HandleDestinationReached()
        {
            attackAgent.SetReadyForAttack(true);
        }
    }
}