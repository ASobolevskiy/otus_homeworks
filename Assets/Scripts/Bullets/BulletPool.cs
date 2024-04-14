using System;
using System.Collections.Generic;
using DI.Attributes;
using ShootEmUp.Factories;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class BulletPool : Listeners.IGameStartListener
    {
        [SerializeField]
        private int initialCount = 50;

        [SerializeField]
        private Transform container;
        
        private Transform worldTransform;
        private BulletFactory bulletFactory;
        private readonly Queue<Bullet> bulletPool = new();

        [Inject]
        public void Construct(Transform worldTransform, BulletFactory bulletFactory)
        {
            this.worldTransform = worldTransform;
            this.bulletFactory = bulletFactory;
        }

        public void OnGameStarted()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = bulletFactory.CreateBullet(container);
                bulletPool.Enqueue(bullet);
            }
        }

        public Bullet GetBullet()
        {
            if (bulletPool.TryDequeue(out var bullet))
            {
                bullet.transform.SetParent(worldTransform);
            }
            else
            {
                bullet = bulletFactory.CreateBullet(worldTransform);
            }
            return bullet;
        }

        public void EnqueueBullet(Bullet bullet)
        {
            bullet.transform.SetParent(container);
            bulletPool.Enqueue(bullet);
        }
    }
}