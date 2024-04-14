using System;
using System.Collections.Generic;
using DI.Attributes;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletSystem :  
        Listeners.IFixedUpdateListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener
    {
        private readonly HashSet<Bullet> activeBullets = new();
        private readonly List<Bullet> cache = new();
        
        private LevelBounds levelBounds;
        private BulletPool bulletPool;

        [Inject]
        public void Construct(LevelBounds levelBounds, BulletPool bulletPool)
        {
            this.levelBounds = levelBounds;
            this.bulletPool = bulletPool;
        }

        public void OnGamePaused()
        {
            foreach (var bullet in activeBullets)
            {
                bullet.StopFlying();
            }
        }

        public void OnGameResumed()
        {
            foreach (var bullet in activeBullets)
            {
                bullet.ContinueFlying();
            }
        }

        public void OnFixedUpdate(float fixedDeltaTime)
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

        public void FlyBulletByArgs(BulletArgs args)
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