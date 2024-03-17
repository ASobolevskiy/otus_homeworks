using UnityEngine;

namespace ShootEmUp
{
    public sealed class TeamComponent : MonoBehaviour
    {
        public bool IsPlayer => isPlayer;

        [SerializeField]
        private bool isPlayer;
    }
}