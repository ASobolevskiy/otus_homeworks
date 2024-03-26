using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyAttackAgent : MonoBehaviour,
        Listeners.IFixedUpdateListener
    {
        [SerializeField] 
        private WeaponComponent weaponComponent;
        
        [SerializeField]
        private float countdown;

        //TODO Fix with DI
        private BulletSystem bulletSystem;
        
        private GameObject target;
        private float currentTime;
        private bool readyForAttack;

        public void SetTarget(GameObject target)
        {
            this.target = target;
        }

        public void SetBulletSystem(BulletSystem bulletSystem)
        {
            if (this.bulletSystem == null)
                this.bulletSystem = bulletSystem;
        }

        public void SetReadyForAttack(bool ready)
        {
            readyForAttack = ready;
        }

        public void Reset()
        {
            currentTime = countdown;
        }
        
        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (!readyForAttack)
            {
                return;
            }

            if (!target.TryGetComponent(out HitPointsComponent hpComponent) || !hpComponent.IsHitPointsExists())
            {
                return;
            }

            currentTime -= fixedDeltaTime;
            if (currentTime <= 0)
            {
                Fire();
                currentTime += countdown;
            }
        }

        private void FixedUpdate()
        {
            
        }

        private void Fire()
        {
            var startPosition = weaponComponent.Position;
            var vector = (Vector2)target.transform.position - startPosition;
            var direction = vector.normalized;
            bulletSystem.FlyBulletByArgs(new BulletSystem.Args
            {
                isPlayer = false,
                physicsLayer = (int)PhysicsLayer.EnemyBullet,
                color = Color.red,
                damage = 1,
                position = startPosition,
                velocity = direction * 2.0f
            });
        }
    }
}