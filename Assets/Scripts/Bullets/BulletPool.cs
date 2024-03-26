using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletPool : MonoBehaviour,
        Listeners.IGameStartListener
    {
        [SerializeField]
        private int initialCount = 50;

        [SerializeField]
        private Transform container;

        [SerializeField]
        private Bullet prefab;

        [SerializeField]
        private Transform worldTransform;

        private readonly Queue<Bullet> bulletPool = new();

        public void OnGameStarted()
        {
            for (var i = 0; i < initialCount; i++)
            {
                var bullet = Instantiate(prefab, container);
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
                bullet = Instantiate(prefab, worldTransform);
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