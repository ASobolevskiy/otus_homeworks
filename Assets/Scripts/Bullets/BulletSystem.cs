using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed partial class BulletSystem : MonoBehaviour
    {
        [SerializeField] 
        private LevelBounds levelBounds;

        [SerializeField]
        private BulletPool bulletPool;
        
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();
        
        private void FixedUpdate()
        {
            cache.Clear();
            cache.AddRange(activeBullets);

            for (int i = 0, count = cache.Count; i < count; i++)
            {
                var bullet = cache[i];
                if (!levelBounds.InBounds(bullet.transform.position))
                {
                    RemoveBullet(bullet);
                }
            }
        }

        public void FlyBulletByArgs(Args args)
        {
            var bullet = bulletPool.GetBullet();
            
            bullet.SetPosition(args.position);
            bullet.SetColor(args.color);
            bullet.SetPhysicsLayer(args.physicsLayer);
            bullet.Damage = args.damage;
            bullet.IsPlayer = args.isPlayer;
            bullet.SetVelocity(args.velocity);
            
            if (activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }
        
        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                bulletPool.EnqueueBullet(bullet);
            }
        }
    }
}