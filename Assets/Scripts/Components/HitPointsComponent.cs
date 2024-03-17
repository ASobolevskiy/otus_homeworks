using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> OnHpEmpty;
        
        [SerializeField] 
        private int hitPoints;

        [SerializeField]
        private int maxHp = 3;
        
        public bool IsHitPointsExists() {
            return hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints <= 0)
            {
                OnHpEmpty?.Invoke(gameObject);
            }
        }

        public void RestoreHpToMax() => hitPoints = maxHp;
    }
}